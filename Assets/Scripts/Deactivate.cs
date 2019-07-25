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
            //won't destroy the platform if you die, so you can rest in peace
            if (PlayerController.isDead) return;
            //platform disappears after 3 seconds
            Invoke("SetInactive", 4.0f);
            dScheduled = true;
        }
    }
    void SetInactive()
    {
        this.gameObject.SetActive(false);
        dScheduled = false;
    }
}
