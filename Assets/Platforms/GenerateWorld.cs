using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public GameObject[] platforms;
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        for (int i = 0; i < 20; i++)
        {
            int platformNumber = Random.Range(0, platforms.Length);
            Instantiate(platforms[platformNumber], pos, Quaternion.identity);
            pos.z += 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
