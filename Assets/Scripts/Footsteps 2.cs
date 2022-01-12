using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private AudioSource audioSource;

    //Play an audio clip.
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Each movement of the player will randomly play
    //a clip from the given audio clips.
    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    //The range of the given audio clips.
    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioClip.Length - 1);
        return audioClip[index];
    }

}
