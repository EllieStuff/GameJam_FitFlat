using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int puntuation;
    [SerializeField] private float totalCombo;
    [SerializeField] private int currentFlat;
    [SerializeField] private int puntuationBase;
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
        
    }

    public void AddCombo(float comb)
    {
        totalCombo += comb;
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
