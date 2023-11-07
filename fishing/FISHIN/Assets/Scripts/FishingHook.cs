using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishingHook : MonoBehaviour
{
    FishSpawning fishScript;
    public int FishCaught = 0;
    public int Health = 3;
    public int NumOfHearts;

    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public bool CanInterract = true;
    public bool FishOnHook = false;
    public bool TakenDamage = false;

    public TMP_Text Score;

    // Start is called before the first frame update
    void Start()
    {
        fishScript = FindObjectOfType<FishSpawning>();
        Score.text = " " + FishCaught;
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.Translate(new Vector2(0, Input.GetAxis("Vertical") * Time.deltaTime * 10));

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

    }

    private void OnTriggerEnter2D(Collider2D TouchFish)
    {
        
        if (TouchFish.gameObject.tag == "Fish" && CanInterract == true)
        {
            FishOnHook = true;
            CanInterract = false;
            //switch sprite to having fish
            Destroy(TouchFish.gameObject);
            fishScript.ChildCount -= 1;
        }
        if (TouchFish.tag == "Surface" && FishOnHook == true)
        {
            ++FishCaught;
            Score.text = " " + FishCaught;
            FishOnHook = false;
            CanInterract = true;
            //switch sprite to normal 
        }

        if (TouchFish.tag == "Trash" && TakenDamage == false)
        {
            -- Health;
            CanInterract = false;
            TakenDamage = true;
            //switch sprite to damaged hook
        }
        if (TouchFish.tag == "Surface" && TakenDamage == true && Health >= 0)
        {
            CanInterract = true;
            //switch sprite to normal
        }
    }
}

