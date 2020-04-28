using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] musicClips;
    [SerializeField] AudioClip[] effectClips;
    [SerializeField] AudioMixerSnapshot paused;
    [SerializeField] AudioMixerSnapshot unPaused;
    AudioSource backgroundMusic;
    AudioSource soundEffects;

    //private void Start()
    //{
    //    AudioSource[] audio = GetComponentsInChildren<AudioSource>();
    //    backgroundMusic = audio[0];
    //    soundEffects = audio[1];

    //}

    //void Update()
    //{
    //    if(!backgroundMusic.isPlaying)
    //    {
    //        backgroundMusic.clip = GetRandomClip();
    //        backgroundMusic.Play();
    //    }
    //}

    //AudioClip GetRandomClip()
    //{
    //    return musicClips[Random.Range(0, musicClips.Length)];
    //}

    //public void PauseAudio(bool active)
    //{
    //    if (active)
    //        paused.TransitionTo(0.01f);
    //    else
    //        unPaused.TransitionTo(0.01f);

    //}

    //public void PlayClickButton()
    //{
    //    soundEffects.PlayOneShot(effectClips[0]);
    //}
}
