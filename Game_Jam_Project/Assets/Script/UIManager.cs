using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button man_button;
    [SerializeField] Button woman_button;
    [SerializeField] Button[] difficult_buttons;

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
            GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Characters/MAN"), new Vector3(0,0,0), Quaternion.Euler(0, -90, 0)).name = "Player";
        }
        else
        {
            GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Characters/WOMAN"), new Vector3(0, 0, 0), Quaternion.Euler(0, -90, 0)).name = "Player";
        }
    }

    void SelectLevel(Constants.Difficulties level)
    {

        if (level == Constants.Difficulties.EASY)
        {
            GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Building Easy"), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).name = "Building";
        }
        else if(level == Constants.Difficulties.MEDIUM)
        {
            GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Building Medium"), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).name = "Building";
        }
        else
        {
            GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Building Hard"), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)).name = "Building";
        }

        GameObject.Find("Building").GetComponent<Building>().difficulty = level;
    }
}
