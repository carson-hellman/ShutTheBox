using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DominoSelect : MonoBehaviour
{

    public GameObject CanvasObject;
    private Score scoreScript;
    [SerializeField]
    TextMeshProUGUI UsablePointsText;
    [SerializeField]
    TextMeshProUGUI FinalScoreText;
    private TotalScore totalScoreScript;
    public int tileCost;
    public bool movable = true;
    public bool upright = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = CanvasObject.GetComponent<Score>();
        totalScoreScript = FinalScoreText.GetComponent<TotalScore>();
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
            UsablePointsText.text = $"{scoreScript.NumRolled} Usable Points";
        }
        else if (movable && !upright)
        {
            upright = true;
            transform.Rotate(270, 0, 0);
            scoreScript.NumRolled += tileCost;
            UsablePointsText.text = $"{scoreScript.NumRolled} Usable Points";
        }
    }

    public void finishedTurn()
    {

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
        }

        if (totalScoreScript.total == 0)
        {
            Debug.Log("YOU WIN!");
        }
    }
}
