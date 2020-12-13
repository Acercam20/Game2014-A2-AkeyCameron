using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject controller;
    int score = 0;
    public Text setText;
    string toPrint;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindWithTag("GlobalController");
    }

    // Update is called once per frame
    void Update()
    {
        score = controller.GetComponent<GlobalController>().timerScore;
        Debug.Log(score);
        toPrint = "Your time was: " + score.ToString();
        setText.text = toPrint;
    }
}
