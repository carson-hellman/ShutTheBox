using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AllDominos : MonoBehaviour
{
    List<GameObject> dominos = new List<GameObject>();
    private TotalScore totalScoreScript;
    [SerializeField]
    TextMeshProUGUI FinalScoreText;

    public GameObject CanvasObject;
    private Score scoreScript;
    private SceneControl sceneScript;

    public GameObject ResultCanvas;
    [SerializeField]
    TextMeshProUGUI ResultScoreText;
    [SerializeField]
    TextMeshProUGUI ResultText;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            dominos.Add(child.gameObject);
        }
        totalScoreScript = FinalScoreText.GetComponent<TotalScore>();
        scoreScript = CanvasObject.GetComponent<Score>();
        sceneScript = CanvasObject.GetComponent<SceneControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValidOrLose()
    {
        int total = totalScoreScript.total;
        List<int> unusedTiles = new List<int>();

        foreach(GameObject obj in dominos)
        {
            DominoSelect dom = obj.GetComponent<DominoSelect>();
            if (dom.movable == true && dom.upright == true)
            {
                unusedTiles.Add(dom.tileCost);
            }
        }

        // call can match sum and the deal with that
        bool valid = CanMatchSum(unusedTiles, scoreScript.NumRolled);

        if (!valid)
        {
            // player lost / game over
            // Debug.Log($"You lose, rolled a {scoreScript.NumRolled}");
            CanvasObject.SetActive (false);
            ResultText.text = "You Lose";
            ResultScoreText.text = $"Final Score: {totalScoreScript.total}";
            ResultCanvas.SetActive (true);
            // UPDATE UI HERE FOR LOSE SCREEN
        }
    }

    private bool CanMatchSum(List<int> numbers, int target)
    {
        // Base case: exact match
        if (target == 0) return true;

        // No match if no numbers left or target is negative
        if (numbers.Count == 0 || target < 0) return false;

        // Check each subset by including or excluding the first number
        int first = numbers[0];
        var rest = numbers.Skip(1).ToList();

        // Check if including or excluding the first number leads to a match
        return CanMatchSum(rest, target - first) || CanMatchSum(rest, target);
    }
}
