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
    public TextMeshProUGUI explanation;
    public RuntimeAnimatorController controller;
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
                currentTime = 0;
                isCompleted = true;
                GameObject.Find("Player").GetComponent<Animator>().SetBool("finish", true);
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
        initTime = Time.time;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

 

}
