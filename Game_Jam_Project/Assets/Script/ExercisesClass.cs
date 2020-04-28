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
    [SerializeField] bool isCompleted;
    [SerializeField] float exerciseCombo;

    [Header("Question")]
    public TextMeshProUGUI question;
    public TextMeshProUGUI[] answers;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void StartExercice(Animator animator)
    {
        animator.runtimeAnimatorController = controller;
    }

}
