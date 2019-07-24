using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    void FixedUpdate()
    {
        //the -0.1f is the game's scrolling speed, so it can be changed here
        this.transform.position += PlayerController.player.transform.forward * -0.1f;

        if (PlayerController.currentPlatform == null) return;
        //the .06f is related to the angle of the stair model
        if (PlayerController.currentPlatform.tag == "stairsUp")
            this.transform.TransformDirection(0, -0.06f, 0);
        if (PlayerController.currentPlatform.tag == "stairsDown")
            this.transform.TransformDirection(0, 0.06f, 0);
    }
}
