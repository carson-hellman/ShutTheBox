using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DominoSelect : MonoBehaviour
{

    public GameObject CanvasObject;
    private Score scoreScript;
    private SceneControl sceneScript;
    [SerializeField]
    TextMeshProUGUI UsablePointsText;
    [SerializeField]
    TextMeshProUGUI FinalScoreText;
    private TotalScore totalScoreScript;
    public int tileCost;
    public GameObject ResultCanvas;
    [SerializeField]
    TextMeshProUGUI ResultScoreText;
    [SerializeField]
    TextMeshProUGUI ResultText;
    public GameObject RollDiceButton;
    [SerializeField]
    TextMeshProUGUI scoreText;
    public Image DominoSelectorImage;
    [SerializeField]
    TextMeshProUGUI DominoSelectorText;
    public bool movable = true;
    public bool upright = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = CanvasObject.GetComponent<Score>();
        totalScoreScript = FinalScoreText.GetComponent<TotalScore>();
        sceneScript = CanvasObject.GetComponent<SceneControl>();
        movable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectedDomino()
    {
        scoreScript.rolling = false;
        if(transform.eulerAngles.x == 315 && (scoreScript.NumRolled - tileCost >= 0))
        {
            // Debug.Log("rotate down");
            upright = false;
            transform.Rotate(90, 0, 0);
            scoreScript.NumRolled -= tileCost;
            UsablePointsText.text = $"{scoreScript.NumRolled} Usable Point(s)";
            DominoSelectorImage.color = new Color32(255,255,0,60);
        }
        else if (movable && !upright)
        {
            upright = true;
            transform.Rotate(270, 0, 0);
            scoreScript.NumRolled += tileCost;
            UsablePointsText.text = $"{scoreScript.NumRolled} Usable Point(s)";
            DominoSelectorImage.color = new Color32(255,255,255,60);
        }
    }

    public void finishedTurn()
    {
        scoreText.text = "";
        RollDiceButton.SetActive(true);

        if(scoreScript.NumRolled != 0)
        {
            UsablePointsText.text = "Invalid selection";
            return;
        }

        if (upright == false && movable)
        {
            UsablePointsText.text = "";
            movable = false;
            totalScoreScript.total -= tileCost;
            DominoSelectorImage.color = new Color32(255,255,225,0);
            DominoSelectorText.text = "";
        }

        if (totalScoreScript.total == 0)
        {
            // Debug.Log("YOU WIN!");
            CanvasObject.SetActive (false);
            ResultText.text = "You Win!";
            ResultScoreText.text = "Final Score: 0";
            ResultCanvas.SetActive (true);
            // update UI HERE FOR WIN SCREEN
        }
    }
}
