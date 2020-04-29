using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button man_button;
    [SerializeField] Button woman_button;
    [SerializeField] Button[] difficult_buttons;
    [SerializeField] Building building;

    // Start is called before the first frame update
    void Start()
    {
        man_button.onClick.AddListener(() => SelectGenere(Constants.Genere.MAN));
        woman_button.onClick.AddListener(() => SelectGenere(Constants.Genere.WOMAN));

        difficult_buttons[0].onClick.AddListener(() => SelectLevel(Constants.Difficulties.EASY));
        difficult_buttons[1].onClick.AddListener(() => SelectLevel(Constants.Difficulties.MEDIUM));
        difficult_buttons[2].onClick.AddListener(() => SelectLevel(Constants.Difficulties.HARD));
    }

    void SelectGenere(Constants.Genere gen)
    {
        if(gen == Constants.Genere.MAN)
        {
            GameObject.Find("SM_Chr_Developer_Female_02").SetActive(false);
        }
        else
        {
            GameObject.Find("SM_Chr_Developer_Male_01").SetActive(true);
        }
    }

    void SelectLevel(Constants.Difficulties level)
    {

        if (level == Constants.Difficulties.EASY)
        {      
            building.difficulty = level;
        }
        else if(level == Constants.Difficulties.MEDIUM)
        {
            building.difficulty = level;
        }
        else
        {
            building.difficulty = level;
        }

        GameObject.Find("Building").GetComponent<Building>().difficulty = level;
    }
}
