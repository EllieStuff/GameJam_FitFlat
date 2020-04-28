using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Button playBtn;
    Button optionsBtn;
    Button exitBtn;


    void Start()
    {
        playBtn = GameObject.Find("PlayButton").GetComponent<Button>();
        optionsBtn = GameObject.Find("OptionsButton").GetComponent<Button>();
        // exitBtn = GameObject.Find("ExitButton").GetComponent<Button>();

        playBtn.onClick.AddListener(()=>LoadScene("Gameplay"));
        // exitBtn.onClick.AddListener(() => ExitGame());
    }

    void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
