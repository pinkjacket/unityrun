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
            GameObject p = Instantiate(platforms[platformNumber], pos, Quaternion.identity);

            if(platforms[platformNumber].tag == "stairsUp")
            {
                pos.y += 5;
            }

            else if (platforms[platformNumber].tag == "stairsDown")
            {
                pos.y -= 5;
                p.transform.Rotate(new Vector3(0, 180, 0));
                p.transform.position = pos;
            }
            pos.z -= 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
