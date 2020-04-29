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

    //private TextMeshProUGUI explanation;
    //private TextMeshProUGUI title;
    public float timeExercise;
    private float currentTime;
    private float initTime;
    [SerializeField] bool isCompleted;
    [SerializeField] bool questAnswer;
    [SerializeField] bool startExercise;
    [SerializeField] float exerciseCombo;

    [Header("Question")]
    public TextMeshProUGUI question;
    public TextMeshProUGUI[] answers;
    public int answerId;

    private void Start()
    {
        //GameObject infoPanel = GameObject.FindGameObjectWithTag("InfoPanel");
        //explanation = infoPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //title = infoPanel.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();

        startExercise = isCompleted = false;
        currentTime = timeExercise;
        exerciseCombo = initTime = 0;
    }

    private void Update()
    {
        if (startExercise&&!isCompleted)
        {
            currentTime = timeExercise - (Time.time - initTime);
            if (currentTime <= 0)
            {
                Building tmp = GameObject.Find("Building").GetComponent<Building>();
                tmp.doingExercise = false;
                tmp.exerciseID++;              
                currentTime = 0;
                isCompleted = true;
                Player player = GameObject.Find("Player").GetComponent<Player>();
                player.animator.SetBool("finish", true);
                player.agent.isStopped = false;
                player.destination.transform.position += new Vector3(0, 3f, 0);
                player.SetDestination();
               
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
        animator.runtimeAnimatorController = controller;
        GameObject.Find("Player").GetComponent<Animator>().runtimeAnimatorController = controller;
        initTime = Time.time;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }


}
