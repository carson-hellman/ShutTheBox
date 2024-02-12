using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDetector : MonoBehaviour
{
    public DiceRoll dice1;
    public DiceRoll dice2;

    private void OnTriggerStay(Collider other)
    {
        DiceRoll curDice = null;

        if (other.tag == "Dice1")
        {
            curDice = dice1;
        }
        if (other.tag == "Dice2")
        {
            curDice = dice2;
        }

        if (curDice != null)
        {
            if (curDice.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                curDice.diceFaceNum = int.Parse(other.name);
            }
        }
    }
}
