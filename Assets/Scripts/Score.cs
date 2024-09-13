using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public DiceRoll dice1;
    Vector3 startPosD1;
    Rigidbody d1Body;
    public DiceRoll dice2;
    Vector3 startPosD2;
    Rigidbody d2Body;
    public int NumRolled;
    public bool rolling = true;

    [SerializeField]
    TextMeshProUGUI scoreText;

    public GameObject Dominos;
    private AllDominos allDominosScript;

    private void Start()
    {
        startPosD1 = dice1.transform.position;
        startPosD2 = dice2.transform.position;
        d1Body = dice1.GetComponent<Rigidbody>();
        d2Body = dice2.GetComponent<Rigidbody>();
        
        allDominosScript = Dominos.GetComponent<AllDominos>();

    }

    private void Update()
    {
        if (rolling)
        {
            if (dice1.GetComponent<Rigidbody>().velocity == Vector3.zero && dice2.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                NumRolled = dice1.diceFaceNum + dice2.diceFaceNum;
                if (NumRolled != 0)
                {
                    scoreText.text = "Rolled " + (NumRolled).ToString();
                    allDominosScript.ValidOrLose();
                    rolling = false;
                }
            }
        }
    }
}
