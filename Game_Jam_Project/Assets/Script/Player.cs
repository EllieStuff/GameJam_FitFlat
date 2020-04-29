using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] private int puntuation;
    [SerializeField] private float totalCombo;
    [SerializeField] private int currentFlat;
    [SerializeField] private int puntuationBase;
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject destination;
    // Start is called before the first frame update


    void Start()
    {
        puntuationBase = 2;
        puntuation = 0; //Init
        totalCombo = 0;
        StartCoroutine("IncreasePuntuation");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(destination.transform.position, gameObject.transform.position) < 0.2f)
        {
            agent.isStopped = true;
            animator.enabled = false;
        }
    }

    public void AddCombo(float comb)
    {
        totalCombo += comb;
    }

    public void SetDestination()
    {
        agent.SetDestination(destination.transform.position);
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Controller/Walk");
        // animator.Play(0);
    }

    IEnumerator IncreasePuntuation()
    {
        while (true)
        {
            puntuation += (int)(puntuationBase * totalCombo);
            yield return new WaitForSeconds(.1f);
        }
    }
}
