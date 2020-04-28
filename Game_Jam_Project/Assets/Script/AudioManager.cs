using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] AudioClip[] musicClips;
    [SerializeField] AudioClip[] effectClips;

    [SerializeField] AudioMixerSnapshot paused;
    [SerializeField] AudioMixerSnapshot unPaused;

    [SerializeField] Slider effectsSlider;
    [SerializeField] Slider musicSlider;

    AudioSource backgroundMusic;
    AudioSource soundEffects;

    private void Awake()
    {
        AudioSource[] audio = GetComponentsInChildren<AudioSource>();
        backgroundMusic = audio[0];
        soundEffects = audio[1];



        // Llegim el valor del volum guardat i l'actualitzem
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        SetMusicVolume(musicSlider.value);
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0);
        SetEffectsVolume(effectsSlider.value);

        Button[] buttons = FindObjectsOfType<Button>();
        foreach(Button b  in buttons)
        {
            b.onClick.AddListener(() => PlayClickButton());
        }
    }

    void Update()
    {
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.clip = GetRandomClip();
            backgroundMusic.Play();
        }
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("EffectsVolume", volume);
        PlayerPrefs.SetFloat("EffectsVolume", volume);
    }

    AudioClip GetRandomClip()
    {
        return musicClips[Random.Range(0, musicClips.Length)];
    }

    public void PauseAudio(bool active)
    {
        if (active)
            paused.TransitionTo(0.01f);
        else
            unPaused.TransitionTo(0.01f);

    }

    public void PlayClickButton()
    {
        soundEffects.PlayOneShot(effectClips[0]);
    }
}
