using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            GameObject.Find("ChooseLevel").SetActive(false);
        }
        catch
        {

        }

        StartCoroutine(Fade.ScreenFadeOut(0.5f, "FadeImage"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().name == "MainMenu")
                    Application.Quit();
                else
                    LoadMainMenu();

                return;
            }
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        //StartCoroutine(Fade.ScreenFadeInAndLoadScene(0.5f,"FadeImage", "MainMenu"));
        //StartCoroutine(Fade.MusicFadeOut(0.5f, Resources.Load<AudioMixer>("Audio/AudioMixers/MainMixer")));
    }
    public void PauseGame()
    {
        if(Time.timeScale == 1)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    

}
