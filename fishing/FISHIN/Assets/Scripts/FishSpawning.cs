using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    public GameObject[] Fishes;

    public int ChildCount = 0;
    public float TimeLeft;
    public bool TimerDone = false;

    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerDone == false)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                TimerDone = true;
            }
        }

        if (ChildCount < 5 && TimerDone == true)
        {
            Instantiate(Fishes[Random.Range(0,Fishes.Length)], new Vector3(-4, Random.Range(-4f,2f), 0), Quaternion.identity);
            ChildCount++;
            TimeLeft = Random.Range(1, 3);
            TimerDone = false;
        }
    }
}
