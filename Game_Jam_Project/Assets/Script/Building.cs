using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Building : MonoBehaviour
{
    public Constants.Difficulties difficulty;
    [SerializeField] ExercisesClass[] flat;
    public ExercisesClass[] exercises = new ExercisesClass[(int)Constants.ExerciseType.COUNT];
    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController controller;
    [SerializeField] Camera camera;
    [SerializeField] Player player;
    public float durationExercise;
    public UIManager uiManager;
    public bool doingExercise;

    public int exerciseID = 0;

    // Start is called before the first frame update
    void Start()
    {

        //infoPanelExplanation = infoPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //infoPanelTitle = infoPanel.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        //infoPanel.SetActive(false);
        doingExercise = false;
        durationExercise = GetDurationExercise();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, player.destination.transform.position) < 1.2f && !doingExercise)
        {
            player.agent.isStopped = true;
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Controller/Idle");

            camera.DOOrthoSize(3f, 2f);
            camera.transform.DOLookAt(new Vector3(player.transform.position.x - 5, player.transform.position.y, player.transform.position.z), 2f);

            //Show info undo neightbour
            uiManager.infoPanel.SetActive(true);
            uiManager.RefreshInfoPanel(flat[exerciseID].titleText, flat[exerciseID].explanationText);

            doingExercise = true;
            Debug.Log(doingExercise);
        }

       
        if (!doingExercise)
        {
            camera.transform.DOLookAt(new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), 1f);
            camera.transform.DOMoveX(player.transform.position.x - 2, 1f);
            camera.transform.DOMoveY(player.transform.position.y + 1.5f, 1f);
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

        if (level == Constants.Difficulties.EASY)
        {
            // Desactivem les plantes que no son necessaries
            GameObject.Find("Floor15").SetActive(false);
            GameObject.Find("Floor14").SetActive(false);
            GameObject.Find("Floor13").SetActive(false);
            GameObject.Find("Floor12").SetActive(false);
            GameObject.Find("Floor11").SetActive(false);
            GameObject.Find("Floor10").SetActive(false);

            flat = new ExercisesClass[9];
            flat[0] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Sit up").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);    
            flat[1] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Quick steps").GetComponent<ExercisesClass>(),GameObject.Find("Exercices").transform);
            flat[2] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Circle crunches").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[3] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath sitting idle").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[4] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Push ups").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[5] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Planch").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[6] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Cross jumps").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[7] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[8] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Stretching 1").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);


            //VECINOS
            for (int i = 0; i < flat.Length; i++)
            {
                GameObject.Find("Vecino"+i.ToString()).GetComponent<Animator>().runtimeAnimatorController = flat[i].controller;
            }
           

        }
        else if(level == Constants.Difficulties.MEDIUM)
        {

            // Desactivem les plantes que no son necessaries
            GameObject.Find("Floor15").SetActive(false);
            GameObject.Find("Floor14").SetActive(false);
            //GameObject.Find("Floor13").SetActive(false);

            flat = new ExercisesClass[13];
            flat[0] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Jumping Jacks").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[1] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[2] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Planch").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[3] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath sitting idle").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[4] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Air Squad").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[5] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[6] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Air Squd Bent Arms").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[7] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath idle").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[8] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Burpees").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[9] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Biceps curl").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[10] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Cross jumps").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[11] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath sitting idle").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[12] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Stretching 2").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);

            //VECINOS
            for (int i = 0; i < flat.Length; i++)
            {
                GameObject.Find("Vecino" + i.ToString()).GetComponent<Animator>().runtimeAnimatorController = flat[i].controller;
            }

        }
        else
        {
           

            flat = new ExercisesClass[15];
            flat[0] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Quick steps").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[1] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Air Squad").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[2] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Bicycle crunch").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[3] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath sitting idle").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[4] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Planch").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[5] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Pike walk").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[6] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Front raise").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[7] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath idle").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[8] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Push ups").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[9] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Burpees").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[10] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Sit up").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[11] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Biceps curl").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[12] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Breath sitting idle").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[13] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Stretching 1").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);
            flat[14] = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Buildings/Exercises/Stretching 2").GetComponent<ExercisesClass>(), GameObject.Find("Exercices").transform);

            //VECINOS
            for (int i = 0; i < flat.Length; i++)
            {
                GameObject.Find("Vecino" + i.ToString()).GetComponent<Animator>().runtimeAnimatorController = flat[i].controller;
            }
        }
    }

    public void StartExercice()
    {
        flat[exerciseID].StartExercice(animator);

        camera.transform.DOLookAt(new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), 2f);
        camera.transform.DOMoveY(player.transform.position.y + 2f, 1f);
        camera.DOOrthoSize(2f, 1f);
    }
}
