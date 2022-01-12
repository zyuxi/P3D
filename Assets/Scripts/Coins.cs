using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        ScoringSystem.theScore += 1;//Count number+1
        Destroy(gameObject);//Destroy the coin which is collected.
        collectSound.Play();//Play the audio every time the coin collected.
    }

}
