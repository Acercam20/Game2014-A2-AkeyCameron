using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    // Start is called before the first frame update
    public int timerScore;
    public int numberOfRuns;
    public int maxNumPickups = 3;
    public int currentNumPickups = 0;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        InitPickups();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitPickups()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        Shuffle(pickups);

        while (currentNumPickups < maxNumPickups)
        {
            if(!pickups[currentNumPickups].GetComponent<BonusPickup>().isActive)
            {
                pickups[currentNumPickups].GetComponent<BonusPickup>().Activate();
                currentNumPickups++;
            }
        }
    }

    public void Shuffle(GameObject[] array)
    {
        GameObject tempGO;
        for (int i = 0; i < array.Length; i++)
        {
            int rnd = Random.Range(0, array.Length);
            tempGO = array[rnd];
            array[rnd] = array[i];
            array[i] = tempGO;
        }
    }
}
