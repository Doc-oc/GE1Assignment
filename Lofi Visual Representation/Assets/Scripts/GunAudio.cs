using UnityEngine.Audio;
using UnityEngine;

public class GunAudio : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip audioClip;

    public void audioPlay(){
        audio.clip = audioClip;
        audio.Play();
    }
}
