using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class ExercisesClass : MonoBehaviour
{
    public Constants.ExerciseType exerciseType;
    public RuntimeAnimatorController controller;
    public string titleText;
    public string explanationText;
    public bool mustAskQuestion = false;

    //private TextMeshProUGUI explanation;
    //private TextMeshProUGUI title;
    public float timeExercise;
    private float currentTime;
    private float initTime;
    [SerializeField] bool isCompleted;
    [SerializeField] bool questAnswer;
    [SerializeField] bool startExercise;
    [SerializeField] float exerciseCombo;
    

    private bool questionAsked = false;

    private GameObject timerObj;
    public TextMeshProUGUI timer;

    private GameObject skipButton;

    [Header("Question")]
    public string question;
    public string[] answers = new string [3];

    private void Start()
    {
        if(answers[0] == "")
        {
            answers[0] = "A";
            answers[1] = "B";
            answers[2] = "C";
        }
    }

    public void Init()
    {
        startExercise = isCompleted = false;
        currentTime = timeExercise;
        exerciseCombo = initTime = 0;

        timer = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        skipButton = GameObject.Find("SkipButton");
        timerObj = GameObject.Find("Timer");
    }

    private void Update()
    {
        if (startExercise && !isCompleted)
        {
            currentTime = timeExercise - (Time.time - initTime);
            timer.SetText(((int)currentTime+1).ToString());
            if (currentTime <= 0 && mustAskQuestion && !questionAsked)
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEndExerciseAudio();
                questionAsked = true;
                UIManager uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
                uiManager.questionPanel.SetActive(true);
                skipButton.SetActive(false);
                uiManager.RefreshQuestionPanel(question, answers);
                GameObject.Find("Timer").SetActive(false);

            }
            if (currentTime <= 0 && !mustAskQuestion)
            {

                Building tmp = GameObject.Find("Building").GetComponent<Building>();
                skipButton.SetActive(false);
                tmp.doingExercise = false;
                tmp.exerciseID++;              
                currentTime = 0;
                isCompleted = true;
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.animator.SetBool("finish", true);
                player.destination.transform.position += new Vector3(0, 3f, 0);
                StartCoroutine(FinishExercise(4, player));
                StartCoroutine(FuncTime(0.2f));
                //player.agent.isStopped = false;
                //player.destination.transform.position += new Vector3(0, 3f, 0);
                //player.SetDestination();

            }
        }

        if(questAnswer)
        {
            GameObject.Find("Player").GetComponent<Player>().AddCombo(exerciseCombo);
            questAnswer = false;
        }
    }

    public void StartExercice(Animator animator)
    {
        startExercise = true;
        timerObj.gameObject.SetActive(true);
        skipButton.SetActive(true);
        animator.runtimeAnimatorController = controller;
        GameObject.Find("Player").GetComponent<Animator>().runtimeAnimatorController = controller;
        initTime = Time.time;
        Building tmpBuilding = GameObject.Find("Building").GetComponent<Building>();
        if (tmpBuilding.flatQuestions.Count > 0 && tmpBuilding.exerciseID == tmpBuilding.flatQuestions.Peek())
        {
            tmpBuilding.flatQuestions.Dequeue();
            mustAskQuestion = true;

        }

    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    IEnumerator FinishExercise(int time, Player ply)
    {
        timer.SetText("0");
        if(!questionAsked) GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayEndExerciseAudio();
        yield return new WaitForSeconds(time);
        ply.agent.isStopped = false;
        ply.SetDestination();
        timerObj.gameObject.SetActive(false);
    }

    IEnumerator FuncTime(float time)
    {
        timer.SetText("0");
        yield return new WaitForSeconds(time);
        timerObj.gameObject.SetActive(false);

    }


    public void SkipExercise () {
        FuncTime(1);
        timeExercise = 0;
        currentTime=0;
    }
}
