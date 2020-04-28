﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Constants.Difficulties difficulty;
    [SerializeField] ExercisesClass[] flat;
    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController controller;
    public int flatPuntuation;
    public float durationExercise;

    int exerciseID = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            flat[exerciseID].StartExercice(animator, exerciseID);
        }
    }
}
