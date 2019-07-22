using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    GameObject dummyMapper;
    void Start()
    {
        dummyMapper = new GameObject("dummy");
        //Vector3 pos = new Vector3(0, 0, 0);
        for (int i = 0; i < 30; i++)
        {
            GameObject p = Pool.singleton.GetRandom();
            if (p == null) return;
            p.SetActive(true);
            p.transform.position = dummyMapper.transform.position;
            p.transform.rotation = dummyMapper.transform.rotation;

            if(p.tag == "stairsUp")
            {
                dummyMapper.transform.Translate(0, 5, 0);
            }

            else if (p.tag == "stairsDown")
            {
                dummyMapper.transform.Translate(0, -5, 0);
                p.transform.Rotate(new Vector3(0, 180, 0));
                p.transform.position = dummyMapper.transform.position;
            }
            else if (p.tag == "platformTSection")
            {
                if (Random.Range(0, 2) == 0)
                    dummyMapper.transform.Rotate(new Vector3(0, 90, 0));
                else
                    dummyMapper.transform.Rotate(new Vector3(0, -90, 0));

                dummyMapper.transform.Translate(Vector3.forward * -10);
            }
            dummyMapper.transform.Translate(Vector3.forward * -10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
