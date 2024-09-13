using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TotalScore : MonoBehaviour
{
    public int total = 78;
    
    [SerializeField]
    TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = $"Score: {total}";
    }

    public void TallyScore(int numShut)
    {
        total = total - numShut;
        text.text = $"Score: {total}";
    }
}
