using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawning : MonoBehaviour
{
    public GameObject[] Fishes;

    public int ChildCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (ChildCount < 5)
        {
            Instantiate(Fishes[Random.Range(0,Fishes.Length)], new Vector3(-4, Random.Range(-4f,2f), 0), Quaternion.identity);
            ChildCount++;
        }
    }
}
