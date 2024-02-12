using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public DiceRoll dice1;
    public DiceRoll dice2;

    [SerializeField]
    TextMeshProUGUI scoreText;

    private void Update()
    {
        if (dice1 != null && dice2 != null)
        {
            if (dice1.diceFaceNum != 0 && dice2.diceFaceNum != 0)
            {
                if (dice1.GetComponent<Rigidbody>().velocity == Vector3.zero && dice2.GetComponent<Rigidbody>().velocity == Vector3.zero)
                {
                    scoreText.text = (dice1.diceFaceNum + dice2.diceFaceNum).ToString();
                }
            }
        }
    }
}
