using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private int puntuation;
    [SerializeField] private float totalCombo;
    [SerializeField] private int currentFlat;
    [SerializeField] private int puntuationBase;
    public Animator animator;
    public  NavMeshAgent agent;
    public GameObject destination;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI combo;
    public GameObject timerObj;

    // Start is called before the first frame update


    void Start()
    {
        puntuationBase = 2;
        puntuation = 0; //Init
        totalCombo = 0.5f;
        StartCoroutine("IncreasePuntuation");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = puntuation.ToString();
        combo.text = "x" + totalCombo.ToString();
    }

    public void AddCombo(float comb)
    {
        totalCombo *= comb;
    }

    public void SetDestination()
    {
        agent.SetDestination(destination.transform.position);
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Controller/Walk");
    }

    public void ReinitPuntuation()
    {
        puntuation = 0;
    }

    IEnumerator IncreasePuntuation()
    {
        while (true)
        {
            if(timerObj.activeSelf)
                puntuation += (int)(puntuationBase * totalCombo);

            yield return new WaitForSeconds(.1f);
        }
    }
}
