using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public GameObject platform;
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        for (int i = 0; i < 20; i++)
        {
            Instantiate(platform, pos, Quaternion.identity);
            pos.z += 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
