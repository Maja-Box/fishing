using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FishingHook : MonoBehaviour
{
    FishSpawning fishScript;
    MoveCycle moveScript;
    public static int FishCaught = 0;
    public int Health = 3;
    public int NumOfHearts;
    public static int Highscore;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip fishCaught;
    [SerializeField] AudioClip pointGet;
    [SerializeField] AudioClip hookBroke;

    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public bool CanInterract = true;
    public bool FishOnHook = false;
    public bool TakenDamage = false;

    public TMP_Text Score;

    public Sprite NormalHook;
    public Sprite HookOff;
    GameObject hookedFish;
    int height; 

    // Start is called before the first frame update
    void Start()
    {
        FishCaught = 0;
        fishScript = FindObjectOfType<FishSpawning>();
        Score.text = " " + FishCaught;
        
    }
    
    
    // Update is called once per frame
    void Update()
    {


        //transform.Translate(new Vector2(0, Input.GetAxis("Vertical") * Time.deltaTime * 10));

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(new Vector2(0,  1 * Time.deltaTime * 5));

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(new Vector2(0,  - 1 * Time.deltaTime * 5));

        }

        if (Health > NumOfHearts)
        {
            Health = NumOfHearts;
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < Health)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }

            if (i < NumOfHearts)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }

        if (Health <= 0)
        {
            if (FishCaught > Highscore)
            {
                Highscore = FishCaught;
            }
            SceneManager.LoadScene("StartScreen");
        }
    }

    private void OnTriggerEnter2D(Collider2D TouchFish)
    {
        
        if (TouchFish.gameObject.tag == "Fish" && CanInterract == true)
        {
            FishOnHook = true;
            CanInterract = false;

            //Destroy(TouchFish.gameObject);
            TouchFish.gameObject.GetComponent<MoveCycle>().enabled = false;
            TouchFish.transform.parent = transform;
            hookedFish = TouchFish.gameObject;
            hookedFish.transform.Rotate(0,0,90);
            hookedFish.transform.localPosition = new Vector3(0, 0, 0);
            moveScript = hookedFish.GetComponent<MoveCycle>();
            hookedFish.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            audiosource.PlayOneShot(fishCaught);
            fishScript.ChildCount -= 1;
        }
        if (TouchFish.tag == "Surface" && FishOnHook == true)
        {
            FishCaught +=  moveScript.Points;
            Score.text = " " + FishCaught;
            audiosource.PlayOneShot(pointGet);
            FishOnHook = false;
            CanInterract = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = NormalHook;
            if(hookedFish != null)
            {
                Destroy(hookedFish);
                hookedFish = null;
            }
        }

        if (TouchFish.tag == "Trash" && TakenDamage == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = HookOff;
            -- Health;
            CanInterract = false;
            TakenDamage = true;
            audiosource.PlayOneShot(hookBroke);
            //switch sprite to damaged hook
            FishOnHook = false;
            if (hookedFish != null)
            {
                Destroy(hookedFish);
                hookedFish = null;
            }
        }
        if (TouchFish.tag == "Surface" && TakenDamage == true && Health >= 0)
        {
            CanInterract = true;
            TakenDamage = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = NormalHook;
        }
    }
}

