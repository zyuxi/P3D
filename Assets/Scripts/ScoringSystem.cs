using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{

    [SerializeField] private GameObject scoreText;
    public static int theScore;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject mObject;
    [SerializeField] private int maxObjects;

    private int numObjects;

    void Update()
    {
        //Update the number of coins colleced in score txt.
        scoreText.GetComponent<Text>().text = "COINS: " + theScore;

        //If all the coins(10) are collected.
        if (theScore >= 10)
        {
            //Set the maximum number of object can be spawned.
            if (numObjects < maxObjects)
            {
                //If not reach the maximum number, then spawn an object.
                SpawnObject(numObjects);
                //Number of object spawned +1.
                numObjects++;
            }

        }

    }

    //Functipn of spawn object.
    void SpawnObject(int num)
    {
        GameObject mObjectClone = Instantiate(mObject, spawnPoint.position, Quaternion.identity) as GameObject;
        mObjectClone.SetActive(true);
    }
}
