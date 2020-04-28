using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExercisesClass : MonoBehaviour
{
                                      //3 modes de dificultat i dos marges per a decidir la quantitat apropiada
    private int[,,] exercises = new int[3, 2, (int)Const.Exercise.COUNT];


    private void Awake()
    {
        //Sentadillas
        exercises[(int)Const.Difficulty.LOW, (int)Const.Quantity.LOW, (int)Const.Exercise.SENTADILLAS] = 10;
        exercises[(int)Const.Difficulty.LOW, (int)Const.Quantity.HIGH, (int)Const.Exercise.SENTADILLAS] = 30;

        exercises[(int)Const.Difficulty.MEDIUM, (int)Const.Quantity.LOW, (int)Const.Exercise.SENTADILLAS] = 15;
        exercises[(int)Const.Difficulty.MEDIUM, (int)Const.Quantity.HIGH, (int)Const.Exercise.SENTADILLAS] = 35;

        exercises[(int)Const.Difficulty.HIGH, (int)Const.Quantity.LOW, (int)Const.Exercise.SENTADILLAS] = 20;
        exercises[(int)Const.Difficulty.HIGH, (int)Const.Quantity.HIGH, (int)Const.Exercise.SENTADILLAS] = 40;


        //Flexiones
        exercises[(int)Const.Difficulty.LOW, (int)Const.Quantity.LOW, (int)Const.Exercise.FLEXIONES] = 5;
        exercises[(int)Const.Difficulty.LOW, (int)Const.Quantity.HIGH, (int)Const.Exercise.FLEXIONES] = 20;

        exercises[(int)Const.Difficulty.MEDIUM, (int)Const.Quantity.LOW, (int)Const.Exercise.FLEXIONES] = 10;
        exercises[(int)Const.Difficulty.MEDIUM, (int)Const.Quantity.HIGH, (int)Const.Exercise.FLEXIONES] = 30;

        exercises[(int)Const.Difficulty.HIGH, (int)Const.Quantity.LOW, (int)Const.Exercise.FLEXIONES] = 20;
        exercises[(int)Const.Difficulty.HIGH, (int)Const.Quantity.HIGH, (int)Const.Exercise.FLEXIONES] = 40;


        //Etc.
        


    }


    public int GetInfo(int difficulty, int quantity, int exerType)
    {

        return exercises[difficulty, quantity, exerType];
    }


}
