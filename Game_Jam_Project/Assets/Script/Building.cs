using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Constants.Difficulties difficulty;
    [SerializeField] ExercisesClass[] flat;
    public ExercisesClass[] exercises = new ExercisesClass[(int)Constants.ExerciseType.COUNT];
    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController controller;
    public float durationExercise;
    public UIManager uiManager;

    private int exerciseID = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
        //infoPanelExplanation = infoPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //infoPanelTitle = infoPanel.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        //infoPanel.SetActive(false);

        durationExercise = GetDurationExercise();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("in");
            uiManager.infoPanel.SetActive(true);
            uiManager.RefreshInfoPanel(flat[exerciseID].titleText, flat[exerciseID].explanationText);

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

    public void SetFlatsDifficulty()
    {
        switch (difficulty)
        {
            case Constants.Difficulties.EASY:
                flat = new ExercisesClass[9];
                flat[0] = exercises[(int)Constants.ExerciseType.SIT_UP_IDLE];
                flat[1] = exercises[(int)Constants.ExerciseType.QUICK_STEPS];
                flat[2] = exercises[(int)Constants.ExerciseType.CIRCLE_CRUNCHES];
                flat[3] = exercises[(int)Constants.ExerciseType.BREATH_SITTING_IDLE];
                flat[4] = exercises[(int)Constants.ExerciseType.PUSH_UPS];
                flat[5] = exercises[(int)Constants.ExerciseType.PLANCH];
                flat[6] = exercises[(int)Constants.ExerciseType.CROSS_JUMPS];
                flat[7] = exercises[(int)Constants.ExerciseType.PIKE_WALK];
                flat[8] = exercises[(int)Constants.ExerciseType.STRETCHING];

                break;

            case Constants.Difficulties.MEDIUM:
                flat = new ExercisesClass[13];
                flat[0] = exercises[(int)Constants.ExerciseType.JUMPING_JACKS];
                flat[1] = exercises[(int)Constants.ExerciseType.PIKE_WALK];
                flat[2] = exercises[(int)Constants.ExerciseType.PLANCH];
                flat[3] = exercises[(int)Constants.ExerciseType.BREATH_SITTING_IDLE];
                flat[4] = exercises[(int)Constants.ExerciseType.AIR_SQUAD];
                flat[5] = exercises[(int)Constants.ExerciseType.PIKE_WALK];
                flat[6] = exercises[(int)Constants.ExerciseType.AIR_SQUAD_BENT_ARMS];
                flat[7] = exercises[(int)Constants.ExerciseType.BREATH_IDLE];
                flat[8] = exercises[(int)Constants.ExerciseType.BURPEES];
                flat[9] = exercises[(int)Constants.ExerciseType.BICEPS_CURL];
                flat[10] = exercises[(int)Constants.ExerciseType.CROSS_JUMPS];
                flat[11] = exercises[(int)Constants.ExerciseType.BREATH_SITTING_IDLE];
                flat[12] = exercises[(int)Constants.ExerciseType.STRETCHING];

                break;

            case Constants.Difficulties.HARD:
                flat = new ExercisesClass[15];
                flat[0] = exercises[(int)Constants.ExerciseType.QUICK_STEPS];
                flat[1] = exercises[(int)Constants.ExerciseType.AIR_SQUAD];
                flat[2] = exercises[(int)Constants.ExerciseType.BICYCLE_CRUNCH];
                flat[3] = exercises[(int)Constants.ExerciseType.BREATH_SITTING_IDLE];
                flat[4] = exercises[(int)Constants.ExerciseType.PLANCH];
                flat[5] = exercises[(int)Constants.ExerciseType.PIKE_WALK];
                flat[6] = exercises[(int)Constants.ExerciseType.FRONT_RAISE];
                flat[7] = exercises[(int)Constants.ExerciseType.BREATH_IDLE];
                flat[8] = exercises[(int)Constants.ExerciseType.PUSH_UPS];
                flat[9] = exercises[(int)Constants.ExerciseType.BURPEES];
                flat[10] = exercises[(int)Constants.ExerciseType.SIT_UP_IDLE];
                flat[11] = exercises[(int)Constants.ExerciseType.BICEPS_CURL];
                flat[12] = exercises[(int)Constants.ExerciseType.BREATH_SITTING_IDLE];
                flat[13] = exercises[(int)Constants.ExerciseType.STRETCHING];
                flat[14] = exercises[(int)Constants.ExerciseType.STRETCHING_2];

                break;

            default:
                break;
        }
    }
}
