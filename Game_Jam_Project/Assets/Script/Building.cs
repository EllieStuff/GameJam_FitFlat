using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Building : MonoBehaviour
{
    public Constants.Difficulties difficulty;
    [SerializeField] ExercisesClass[] flat;
    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController controller;
    [SerializeField] Camera camera;
    [SerializeField] GameObject player;
    public float durationExercise;

    int exerciseID = 0;

    // Start is called before the first frame update
    void Start()
    {
        durationExercise = GetDurationExercise();
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.DOLookAt(player.transform.position, 1f);
        camera.transform.DOMoveX(player.transform.position.x-2, 1f);
        camera.transform.DOMoveY(player.transform.position.y+1, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flat[exerciseID].StartExercice(animator);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exerciseID++;
        }
    }

    float GetDurationExercise()
    {
        float tmpTime = 0;
        foreach(ExercisesClass exer in flat)
        {
            tmpTime += exer.timeExercise;
        }

        return tmpTime;
    }

    public void SelectLevel(Constants.Difficulties level)
    {
        difficulty = level;
        if(level == Constants.Difficulties.EASY)
        {
            flat = new ExercisesClass[9];
            flat[0] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/SitUp").GetComponent<ExercisesClass>();
            flat[1] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Quick steps").GetComponent<ExercisesClass>();
            flat[2] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Circle crunches").GetComponent<ExercisesClass>();
            flat[3] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath sitting idle").GetComponent<ExercisesClass>();
            flat[4] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Push ups").GetComponent<ExercisesClass>();
            flat[5] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Planch").GetComponent<ExercisesClass>();
            flat[6] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Cross jumps").GetComponent<ExercisesClass>();
            flat[7] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>();
            flat[8] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Stretching 1").GetComponent<ExercisesClass>();
        }
        else if(level == Constants.Difficulties.MEDIUM)
        {
            // Desactivem les plantes que no son necessaries
            GameObject.Find("Floor15").SetActive(false);
            GameObject.Find("Floor14").SetActive(false);
            GameObject.Find("Floor13").SetActive(false);

            flat = new ExercisesClass[13];
            flat[0] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Sit up idle").GetComponent<ExercisesClass>();
            flat[1] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Quick steps").GetComponent<ExercisesClass>();
            flat[2] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Circle crunches").GetComponent<ExercisesClass>();
            flat[3] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath sitting idle").GetComponent<ExercisesClass>();
            flat[4] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Push ups").GetComponent<ExercisesClass>();
            flat[5] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Planch").GetComponent<ExercisesClass>();
            flat[6] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Cross jumps").GetComponent<ExercisesClass>();
            flat[7] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>();
            flat[8] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Stretching 1").GetComponent<ExercisesClass>();
            flat[9] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Push ups").GetComponent<ExercisesClass>();
            flat[10] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Planch").GetComponent<ExercisesClass>();
            flat[11] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Cross jumps").GetComponent<ExercisesClass>();
            flat[12] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>();
        }
        else
        {
            // Desactivem les plantes que no son necessaries
            GameObject.Find("Floor15").SetActive(false);
            GameObject.Find("Floor14").SetActive(false);
            GameObject.Find("Floor13").SetActive(false);
            GameObject.Find("Floor12").SetActive(false);
            GameObject.Find("Floor11").SetActive(false);
            GameObject.Find("Floor10").SetActive(false);

            flat = new ExercisesClass[15];
            flat[0] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Sit up idle").GetComponent<ExercisesClass>();
            flat[1] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Quick steps").GetComponent<ExercisesClass>();
            flat[2] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Circle crunches").GetComponent<ExercisesClass>();
            flat[3] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath sitting idle").GetComponent<ExercisesClass>();
            flat[4] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Push ups").GetComponent<ExercisesClass>();
            flat[5] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Planch").GetComponent<ExercisesClass>();
            flat[6] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Cross jumps").GetComponent<ExercisesClass>();
            flat[7] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>();
            flat[8] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Stretching 1").GetComponent<ExercisesClass>();
            flat[9] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Push ups").GetComponent<ExercisesClass>();
            flat[10] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Planch").GetComponent<ExercisesClass>();
            flat[11] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Cross jumps").GetComponent<ExercisesClass>();
            flat[12] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>();
            flat[13] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Stretching 1").GetComponent<ExercisesClass>();
            flat[14] = Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>();
        }
    }
}
