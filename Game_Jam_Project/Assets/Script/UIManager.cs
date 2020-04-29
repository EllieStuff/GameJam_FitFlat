using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button man_button;
    [SerializeField] Button woman_button;
    [SerializeField] Button[] difficult_buttons;
    [SerializeField] Button continue_button;
    [SerializeField] Building building;
    [SerializeField] Player player;
    public GameObject infoPanel;

    public TextMeshProUGUI infoPanelExplanation;
    public TextMeshProUGUI infoPanelTitle;

    // Start is called before the first frame update
    void Start()
    {
        man_button.onClick.AddListener(() => SelectGenere(Constants.Genere.MAN));
        woman_button.onClick.AddListener(() => SelectGenere(Constants.Genere.WOMAN));

        difficult_buttons[0].onClick.AddListener(() => SelectLevel(Constants.Difficulties.EASY));
        difficult_buttons[1].onClick.AddListener(() => SelectLevel(Constants.Difficulties.MEDIUM));
        difficult_buttons[2].onClick.AddListener(() => SelectLevel(Constants.Difficulties.HARD));

        continue_button.onClick.AddListener(() => infoPanel.SetActive(false));

        building = GameObject.Find("Building").GetComponent<Building>();

        infoPanel.SetActive(false);
    }

    void SelectGenere(Constants.Genere gen)
    {
        if(gen == Constants.Genere.MAN)
        {
            GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Characters/MAN"), new Vector3(0,0,0), Quaternion.Euler(0, -90, 0)).name = "Player";
        }
        else
        {
            GameObject.Find("SM_Chr_Developer_Male_01").SetActive(false);
        }
    }

    void SelectLevel(Constants.Difficulties level)
    {
        building.SelectLevel(level);
        new WaitForSeconds(2);
        player.SetDestination();

        infoPanelExplanation.text = explanation;
        infoPanelTitle.text = title;
        infoPanel.SetActive(true);
    {
    public void RefreshInfoPanel(string title, string explanation)
    }




    IEnumerator StartMovingPlayer()
    {
        yield return new WaitForSeconds(2);
        player.SetDestination();
    }

}
