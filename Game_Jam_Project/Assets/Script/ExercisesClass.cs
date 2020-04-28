using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Animations;

public class ExercisesClass : MonoBehaviour
{
    public Constants.ExerciseType exerciseType;
    public TextMeshProUGUI explanation;
    public Animator exerciseAnimation;
    public float timeExercise;
    //Questions
    public bool isCompleted;
    public float exerciseCombo;

    //    private void Start()
    //    {
    //        <<<<<<< Updated upstream
    //        Sentadillas
    //        exercises[(int)Const.Difficulty.LOW, (int)Const.Quantity.LOW, (int)Const.Exercise.SENTADILLAS] = 10;
    //        exercises[(int)Const.Difficulty.LOW, (int)Const.Quantity.HIGH, (int)Const.Exercise.SENTADILLAS] = 30;

    //        exercises[(int)Const.Difficulty.MEDIUM, (int)Const.Quantity.LOW, (int)Const.Exercise.SENTADILLAS] = 15;
    //        exercises[(int)Const.Difficulty.MEDIUM, (int)Const.Quantity.HIGH, (int)Const.Exercise.SENTADILLAS] = 35;

    //        exercises[(int)Const.Difficulty.HIGH, (int)Const.Quantity.LOW, (int)Const.Exercise.SENTADILLAS] = 20;
    //        exercises[(int)Const.Difficulty.HIGH, (int)Const.Quantity.HIGH, (int)Const.Exercise.SENTADILLAS] = 40;


    //        Flexiones
    //        exercises[(int)Const.Difficulty.LOW, (int)Const.Quantity.LOW, (int)Const.Exercise.FLEXIONES] = 5;
    //        exercises[(int)Const.Difficulty.LOW, (int)Const.Quantity.HIGH, (int)Const.Exercise.FLEXIONES] = 20;

    //        exercises[(int)Const.Difficulty.MEDIUM, (int)Const.Quantity.LOW, (int)Const.Exercise.FLEXIONES] = 10;
    //        exercises[(int)Const.Difficulty.MEDIUM, (int)Const.Quantity.HIGH, (int)Const.Exercise.FLEXIONES] = 30;

    //        exercises[(int)Const.Difficulty.HIGH, (int)Const.Quantity.LOW, (int)Const.Exercise.FLEXIONES] = 20;
    //        exercises[(int)Const.Difficulty.HIGH, (int)Const.Quantity.HIGH, (int)Const.Exercise.FLEXIONES] = 40;


    //        Etc.



    //        =======

    //        >>>>>>> Stashed changes
    //            }

    //    private void Update()
    //    {

    //    }
}
