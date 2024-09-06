using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene("MainLoopScene");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
