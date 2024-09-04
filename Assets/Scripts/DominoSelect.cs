using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DominoSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectedDomino()
    {
        // Debug.Log($"is this: {}");
        if(transform.eulerAngles.x == 315)
        {
            // Debug.Log("rotate down");
            transform.Rotate(90, 0, 0);
        }
        else
        {
            // Debug.Log("Should rotate back");
            transform.Rotate(270, 0, 0);
        }
    }
}
