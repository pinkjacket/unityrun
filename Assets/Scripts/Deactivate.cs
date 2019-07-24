﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
   void OnCollisionExit(Collision player)
    {
        if (player.gameObject.tag == "Player")
            //platform disappears after 3 seconds
            Invoke("SetInactive", 3.0f);
    }
    void SetInactive()
    {
        this.gameObject.SetActive(false);
    }
}
