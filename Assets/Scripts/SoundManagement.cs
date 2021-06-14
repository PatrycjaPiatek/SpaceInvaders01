using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagement : MonoBehaviour
{
    public static SoundManagement Instance = null;

    public AudioClip alienBuzz1;
    public AudioClip alienBuzz2;
    public AudioClip alienDies;
    public AudioClip bulletFire;
    public AudioClip shipExplosion;
    public AudioClip intro;
    public Button sound;
    public Sprite sounOn, soundOff;

    public static AudioSource soundEffectAudio;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if ( Instance != this)
        {
            Destroy(gameObject);
        }
        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;
    }
    public void PlayOneShot(AudioClip clip)
    {
        float vol = 0.2f;

        if(clip.name == "yellow_cat")
        {
            vol = 1;
        }
        soundEffectAudio.PlayOneShot(clip, vol);
    }

    void Update()
    {
        if (GameState.SoundOn)
        {
            soundEffectAudio.enabled = true;
            sound.GetComponent<Image>().sprite = sounOn;
        }
        if (!GameState.SoundOn)
        {
            soundEffectAudio.enabled = false;
            sound.GetComponent<Image>().sprite = soundOff;
        }
    }
}
