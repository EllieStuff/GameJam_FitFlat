using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public int score = 0;   //puntuacio actual
    //public bool challengeAchieved = false;  //Per indicar que l'exercisi ha estat completat (crec que no fa falta)
    public Const.Exercise exerType = Const.Exercise.SENTADILLAS;    //Tipus d'exercisi a fer

    private Const.Difficulty difficulty = Const.Difficulty.MEDIUM;  //Dificultat seleccionada
    //private int exercisesQuantity = 0;  //Numero de vegades que el jugador diu que ha fet un exercisi
    private ExercisesClass exercises;   //Suposarem que el script estara al mateix gameObject
    private int level = 0;  //Pis de la torre en el que el jugador es troba actualment


    // Start is called before the first frame update
    void Start()
    {
        exercises = GetComponent<ExercisesClass>();
        
    }

    void RefreshScore(int exercisesQuantity)
    {
        //Pitjor dels casos += 8
        //Millor dels casos += 107
        score += (int)(((int)difficulty + 1) * 11 * GetMultimplier(exercisesQuantity));

    }


    float GetMultimplier(int exercisesQuantity)
    {
        //No es necessari declarables pero les he deixat prq s'entengui millor el codi d'abaix
        int lowerQuantity = exercises.GetInfo((int)difficulty, (int)Const.Quantity.LOW, (int)exerType);
        int higherQuantity = exercises.GetInfo((int)difficulty, (int)Const.Quantity.HIGH, (int)exerType);

        //Formula = (dificultat / 2f) * bonus per fer-ho be + (pis actual / 2)
        float bonus;
        if(lowerQuantity > exercisesQuantity)   //Ha fet poques repeticions
        {
            bonus = 1;
        }
        else if(higherQuantity < exercisesQuantity) //Ha fet masses repeticions
        {
            bonus = 2.5f;
        }
        else    //Ha fet una quantitat correcte de repeticions
        {
            bonus = 0.5f;
        }

        return (((int)difficulty + 1) / 0.2f) * bonus + (level / 2);
    }



}
