using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    void FixedUpdate()
    {
        //the -0.1f is the game's scrolling speed, so it can be changed here
        this.transform.position += PlayerController.player.transform.forward * -0.1f;
    }
}
