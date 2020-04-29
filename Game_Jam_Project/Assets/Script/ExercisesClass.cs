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
    [SerializeField] bool startExercise;
    [SerializeField] float exerciseCombo;

    [Header("Question")]
    public TextMeshProUGUI question;
    public TextMeshProUGUI[] answers;

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
                isCompleted = true;
            }
        }

        if(isCompleted)
        {
            //Show Quest and setCombo

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
