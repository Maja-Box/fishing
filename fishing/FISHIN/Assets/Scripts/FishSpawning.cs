using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    public GameObject[] Fishes;
    public GameObject[] Trash;

    public int ChildCount = 0;
    float TimeLeft;
    float TrashTime;
   


    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = Random.Range(1, 5);
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        TrashTime -= Time.deltaTime;
        if (ChildCount < 4 && TimeLeft < 0)
        {
            Instantiate(Fishes[Random.Range(0,Fishes.Length)], new Vector3(-4, Random.Range(-4.5f,3f), 0), Quaternion.identity);
            ChildCount++;
            TimeLeft = Random.Range(1, 5);
           
        }
        if (TrashTime < 0)
        {
            TrashTime = Random.Range(3f, 5f) * 25 / (25 + FishingHook.FishCaught);
            Instantiate(Trash[Random.Range(0, Trash.Length)], new Vector3(-4, Random.Range(-4.5f, 3f), 0), Quaternion.identity);
        }
    }
}
