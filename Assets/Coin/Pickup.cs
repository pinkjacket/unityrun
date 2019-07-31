using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    MeshRenderer[] mrs;
    public GameObject scorePrefab;
    public GameObject particlePrefab;
    GameObject canvas;

    void Start()
    {
        mrs = this.GetComponentsInChildren<MeshRenderer>();
        canvas = GameObject.Find("Canvas");
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameData.singleton.UpdateScore(1);
            PlayerController.sfx[1].Play();
            //uncomment this and attach floatingtext to coin to put score on coins
            //Gameobject scoretext = Instantiate(scorePrefab);
            //scoreText.transform.parent = canvas.transform;

            GameObject pE = Instantiate(particlePrefab, this.transform.position, Quaternion.identity);
            Destroy(pE, 1);

            foreach (MeshRenderer m in mrs)
                m.enabled = false;
        }
    }

    void OnEnable()
    {
        if(mrs != null)
            foreach (MeshRenderer m in mrs)
                m.enabled = true;
    }
}
