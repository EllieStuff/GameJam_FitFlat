using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    Button playBtn;
    Button optionsBtn;
    Button exitBtn;


    void Start()
    {
        playBtn = GameObject.Find("PlayButton").GetComponent<Button>();
        optionsBtn = GameObject.Find("OptionsButton").GetComponent<Button>();

        playBtn.onClick.AddListener(()=>LoadScene("Gameplay"));
    }

    void LoadScene(string name)
    {
        StartCoroutine(Fade.ScreenFadeInAndLoadScene(0.5f, "FadeImage", name));
        StartCoroutine(Fade.MusicFadeOut(0.5f, Resources.Load<AudioMixer>("Audio/AudioMixers/MainMixer")));
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
