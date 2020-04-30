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
                questionAsked = true;
                UIManager uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
                uiManager.questionPanel.SetActive(true);
                uiManager.RefreshQuestionPanel(question, answers);
                GameObject.Find("Timer").SetActive(false);

            }
            if (currentTime <= 0 && !mustAskQuestion)
            {
                Building tmp = GameObject.Find("Building").GetComponent<Building>();
                tmp.doingExercise = false;
                tmp.exerciseID++;              
                currentTime = -1;
                isCompleted = true;
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.animator.SetBool("finish", true);
                player.agent.isStopped = false;
                player.destination.transform.position += new Vector3(0, 3f, 0);
                player.SetDestination();
                StartCoroutine(FuncTime(1));
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

    IEnumerator FuncTime(int time)
    {
        yield return new WaitForSeconds(time);
        timerObj.gameObject.SetActive(false);

    }

    
}
