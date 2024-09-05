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
    public int tileCost;
    private bool movable;
    private bool upright = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = CanvasObject.GetComponent<Score>();
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
            // AT END OF ROUND IF PUT DOWN NEED TO MAKE SET MOVABLE FALSE !!!!!!!!!!!!!!!!!!!
            // NEED BUTTON TO FINISH SELECTION THEN CHANGE ROLLING BACK TO TRUE ON SCORE SCRIP!!!!
        }
        else if (movable && !upright)
        {
            // Debug.Log($"Should rotate back {tileCost}");
            upright = true;
            transform.Rotate(270, 0, 0);
            scoreScript.NumRolled += tileCost;
            UsablePointsText.text = $"{scoreScript.NumRolled} Usable Points";
        }
    }
}
