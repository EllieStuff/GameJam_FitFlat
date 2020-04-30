using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }
    public void PauseGame()
    {
        if(Time.timeScale == 1)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

}
