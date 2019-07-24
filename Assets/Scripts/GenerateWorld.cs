using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    static public GameObject dummyMapper;
    static public GameObject lastPlatform;

    void Awake()
    {
        dummyMapper = new GameObject("dummy");
    }

    public static void RunDummy()
    {
        GameObject p = Pool.singleton.GetRandom();
        if (p == null) return;

        if (lastPlatform != null)
        {
            dummyMapper.transform.position = lastPlatform.transform.position +
                PlayerController.player.transform.forward * 10;

            if (lastPlatform.tag == "stairsUp")
                dummyMapper.transform.Translate(0, 5, 0);
        }

        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = dummyMapper.transform.position;
        p.transform.rotation = dummyMapper.transform.rotation;

        if (p.tag == "stairsDown")
        {
            dummyMapper.transform.Translate(0, -5, 0);
            p.transform.Rotate(0, 180, 0);
            p.transform.position = dummyMapper.transform.position;
        }
    }
}
