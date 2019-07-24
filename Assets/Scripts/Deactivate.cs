using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    bool dScheduled = false;
   void OnCollisionExit(Collision player)
    {
        if (player.gameObject.tag == "Player" && !dScheduled)
        {
            //platform disappears after 3 seconds
            Invoke("SetInactive", 3.0f);
            dScheduled = true;
        }
    }
    void SetInactive()
    {
        this.gameObject.SetActive(false);
        dScheduled = false;
    }
}
