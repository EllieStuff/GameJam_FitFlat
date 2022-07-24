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
    public Button welcome_button;
    [SerializeField] Building building;
    [SerializeField] Player player;

    public GameObject infoPanel;
    public GameObject WelcomePanel;
    public GameObject questionPanel;
    public GameObject finalScorePanel;
    public GameObject fsPanelNewBestScore;

    public TextMeshProUGUI infoPanelExplanation;
    public TextMeshProUGUI infoPanelTitle;
    public TextMeshProUGUI questionPanelQuestion;
    public TextMeshProUGUI[] questionPanelAnswers = new TextMeshProUGUI[3];
    public TextMeshProUGUI fsPanelBestScore;
    public TextMeshProUGUI fsPanelFinalScore;

    private string[] answersOrder = new string[3];
    [SerializeField] Image[] questionImg = new Image[3];

    //1, 1.25, 1.5

    // Start is called before the first frame update
    void Start()
    {
        man_button.onClick.AddListener(() => SelectGender(Constants.Gender.MAN));
        woman_button.onClick.AddListener(() => SelectGender(Constants.Gender.WOMAN));

        difficult_buttons[0].onClick.AddListener(() => SelectLevel(Constants.Difficulties.EASY));
        difficult_buttons[1].onClick.AddListener(() => SelectLevel(Constants.Difficulties.MEDIUM));
        difficult_buttons[2].onClick.AddListener(() => SelectLevel(Constants.Difficulties.HARD));


        continue_button.onClick.AddListener(() => infoPanel.SetActive(false));
        welcome_button.onClick.AddListener(() => WelcomeStart());

        building = GameObject.Find("Building").GetComponent<Building>();

        infoPanel.SetActive(false);
        WelcomePanel.SetActive(false);
        questionPanel.SetActive(false);
        fsPanelNewBestScore.SetActive(false);
        finalScorePanel.SetActive(false);
    }

    void SelectGender(Constants.Gender gen)
    {
        player.gender = gen;
        player.SetChairActive(false);
        if(gen == Constants.Gender.MAN)
        {
            GameObject.Find("SM_Chr_Developer_Female_02").SetActive(false);
            //GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Characters/MAN"), new Vector3(0,0,0), Quaternion.Euler(0, -90, 0)).name = "Player";
        }
        else
        {
            GameObject.Find("SM_Chr_Developer_Male_01").SetActive(false);
        }
    }

    void SelectLevel(Constants.Difficulties level)

    {

        building.SelectLevel(level);

        //new WaitForSeconds(2);

        //player.SetDestination();
        WelcomePanel.SetActive(true);
        
    }

    public void WelcomeStart()

    {
        Debug.Log("HEMOS ENTRADO");
        WelcomePanel.SetActive(false);

        new WaitForSeconds(2);

        player.SetDestination();

    }


    public void RefreshFinalScorePanel(int bestScore, int finalScore)
    {
        fsPanelBestScore.text = bestScore.ToString();
        fsPanelFinalScore.text = finalScore.ToString();

    }

    public void RefreshQuestionPanel(string question, string[] answers)
    {
        questionPanelQuestion.SetText(question);

        for(int i = 0; i < answers.Length; i++)
        {
            answersOrder[i] = answers[i];

            string tmpAns = answers[Random.Range(0, answers.Length)];
            while (AnsRepeated(tmpAns, questionPanelAnswers.Length))
            {
                tmpAns = answers[Random.Range(0, answers.Length)];
            }
            questionPanelAnswers[i].text = tmpAns;
        }
        
    }

    private bool AnsRepeated(string currentAns, int length)
    {
        for(int i = 0; i < length; i++)
        {
            if (questionPanelAnswers[i].text == currentAns) return true;

        }
        return false;
    }

    public void SetCombo(GameObject buttonAnswer)
    {
        TextMeshProUGUI _buttonAnswer = buttonAnswer.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Image imgAnswer = buttonAnswer.GetComponent<Image>();
        imgAnswer.color = Color.grey;
        int comboPos = GetAnswerPos(_buttonAnswer.text);
        
        switch (comboPos)
        {
            case 0:
                imgAnswer.color = Color.green;
                player.AddCombo(1.5f);
                break;

            case 1:
                player.AddCombo(1.2f);
                break;

            case 2:
                player.AddCombo(1);
                break;

            default:
                break;

        }

        StartCoroutine(QuestionPanelFalse(1, imgAnswer));
    }

    IEnumerator QuestionPanelFalse(float time, Image imageAnswer)
    {
        yield return new WaitForSeconds(time);
        imageAnswer.color = Color.white;
        questionPanel.SetActive(false);
        building.GetCurrentFlat().mustAskQuestion = false;
    }
    private int GetAnswerPos(string buttonAnswer)
    {
        for (int i = 0; i < answersOrder.Length; i++)
        {
            if (buttonAnswer == answersOrder[i])
                return i;
            
        }

        return -1;
    }

    public void RefreshInfoPanel(string title, string explanation)
    {
        infoPanelExplanation.text = explanation;
        infoPanelTitle.text = title;

    }

    IEnumerator StartMovingPlayer()
    {
        yield return new WaitForSeconds(2);

        player.SetDestination();
    }

}
