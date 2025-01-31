using UnityEngine;
using UnityEngine.Audio;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayAudio()
    {
        audio.Play();
    }
}
