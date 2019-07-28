using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameObject[] panels;
    GameObject[] mmButtons;

    void Start()
    {
        //creating arrays of the menu buttons and panels they open
        panels = GameObject.FindGameObjectsWithTag("subpanel");
        mmButtons = GameObject.FindGameObjectsWithTag("mmbutton");

        //hiding panels
        foreach (GameObject p in panels)
            p.SetActive(false);
    }

    public void ClosePanel(Button button)
    {
        //reaches into the button's parent panel to close it
        button.gameObject.transform.parent.gameObject.SetActive(false);
        foreach (GameObject b in mmButtons)
            b.SetActive(true);
    }

    public void OpenPanel(Button button)
    {
        button.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //hide buttons when a panel opens
        foreach (GameObject b in mmButtons)
            if (b != button.gameObject)
                b.SetActive(false);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("ScrollingWorld", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            QuitGame();
        }
    }
    
}
