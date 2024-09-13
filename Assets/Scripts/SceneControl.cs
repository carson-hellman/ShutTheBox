using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject Button10;
    public GameObject Button12;
    public Image StartButtonImage;

    public void StartGameScene12()
    {
        SceneManager.LoadScene("MainLoopScene12");
    }

    public void StartGameScene10()
    {
        SceneManager.LoadScene("MainLoopScene10");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ChoseMode()
    {
        if (Button10.activeSelf == false)
        {
            StartButtonImage.color = new Color32(255,255,0,60);
            Button10.SetActive(true);
            Button12.SetActive(true);
        }
        else
        {
            StartButtonImage.color = new Color32(255,255,255,60);
            Button10.SetActive(false);
            Button12.SetActive(false);
        }
    }
}
