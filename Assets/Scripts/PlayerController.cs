﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public static GameObject player;
    public static GameObject currentPlatform;
    public static AudioSource[] sfx;
    
    bool canTurn = false;
    Vector3 startPosition;
    public static bool isDead = false;
    Rigidbody rb;

    public GameObject magic;
    public Transform magicStartPos;
    Rigidbody mRb;

    int livesLeft;
    public Texture aliveIcon;
    public Texture deadIcon;
    public RawImage[] icons;

    public GameObject gameOverPanel;
    public Text highScore;

    bool falling = false;

    void RestartGame()
    {
        SceneManager.LoadScene("ScrollingWorld", LoadSceneMode.Single);
    }

    void OnCollisionEnter(Collision other)
    {
        if ((falling || other.gameObject.tag == "fire" || other.gameObject.tag == "wall") && !isDead)
        {
            if (falling)
                anim.SetTrigger("isFalling");
            else
                anim.SetTrigger("isDead");
            isDead = true;
            sfx[6].Play();
            livesLeft--;
            PlayerPrefs.SetInt("lives", livesLeft);

            if (livesLeft > 0)
                Invoke("RestartGame", 2);
            else
            {
                icons[0].texture = deadIcon;
                gameOverPanel.SetActive(true);

                PlayerPrefs.SetInt("lastscore", PlayerPrefs.GetInt("score"));
                if(PlayerPrefs.HasKey("highscore"))
                {
                    int hs = PlayerPrefs.GetInt("highscore");
                    if (hs < PlayerPrefs.GetInt("score"))
                        PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
                }
                else
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("score"));
            }
                
        }
            
        else
            currentPlatform = other.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
        mRb = magic.GetComponent<Rigidbody>();
        sfx = GameObject.FindWithTag("gamedata").GetComponentsInChildren<AudioSource>();

        player = this.gameObject;
        startPosition = player.transform.position;

        GenerateWorld.RunDummy();

        if (PlayerPrefs.HasKey("highscore"))
            highScore.text = "High Score: " + PlayerPrefs.GetInt("highscore");
        else
            highScore.text = "High Score: 0";

        isDead = false;
        livesLeft = PlayerPrefs.GetInt("lives");

        for (int i = 0; i < icons.Length; i++)
        {
            if(i >= livesLeft)
            icons[i].texture = deadIcon;
        }
    }

    void CastMagic()
    {
        magic.transform.position = magicStartPos.position;
        magic.SetActive(true);
        mRb.AddForce(this.transform.forward * 2000);
        Invoke("KillMagic", 1);
    }

    void KillMagic()
    {
        magic.SetActive(false);
    }

    void PlayMagic()
    {
        sfx[7].Play();
    }


    //I decided not to use these because I don't care for constant footstep noises, they'd go on frames 4 and 12 of the running animation
    void Footstep1()
    {
        sfx[3].Play();
    }

    void Footstep2()
    {
        sfx[4].Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other is BoxCollider && GenerateWorld.lastPlatform.tag != "platformTSection")
            GenerateWorld.RunDummy();

        //no sphere colliders besides the one on the T platforms, that's how it's differentiated
        if (other is SphereCollider)
            canTurn = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other is SphereCollider)
            canTurn = false;
    }

    void StopJump()
    {
        anim.SetBool("isJumping", false);
    }

    void StopMagic()
    {
        anim.SetBool("isMagic", false);
    }
    // Update is called once per frame
    void Update()
    {

        if (PlayerController.isDead) return;

        if (currentPlatform != null)
        {
            if (this.transform.position.y < (currentPlatform.transform.position.y -5))
            {
                falling = true;
                OnCollisionEnter(null);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && anim.GetBool("isMagic") == false && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * 200);
            sfx[2].Play();
        }
        else if(Input.GetKeyDown(KeyCode.M) && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isMagic", true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * 90);
            GenerateWorld.dummyMapper.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if(GenerateWorld.lastPlatform.tag != "platformTSection")
                GenerateWorld.RunDummy();

            this.transform.position = new Vector3(startPosition.x,
                                                this.transform.position.y,
                                                startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn)
        {
            this.transform.Rotate(Vector3.up * -90);
            GenerateWorld.dummyMapper.transform.forward = -this.transform.forward;
            GenerateWorld.RunDummy();

            if (GenerateWorld.lastPlatform.tag != "platformTSection")
                GenerateWorld.RunDummy();

            this.transform.position = new Vector3(startPosition.x,
                                                this.transform.position.y,
                                                startPosition.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-0.5f, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }
    }
}
