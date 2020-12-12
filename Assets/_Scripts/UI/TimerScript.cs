using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public int timer = 0;
    public GameObject globalController;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncrementTimer", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncrementTimer()
    {
        timer++;
        GetComponent<Text>().text = "Timer: " + timer;
        globalController.GetComponent<GlobalController>().timerScore = timer;
    }
}
