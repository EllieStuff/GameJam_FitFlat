using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int puntuation;
    [SerializeField] private float totalCombo;
    [SerializeField] private int puntuationBase;
    public Animator animator;
    public  NavMeshAgent agent;
    public GameObject destination;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI combo;
    [SerializeField] TextMeshProUGUI exerciseID;
    [SerializeField] Building building;
    public GameObject timerObj;
    public int bestPuntuation;
    public Constants.Gender gender = Constants.Gender.MAN;
    
    [SerializeField] GameObject manChair, womanChair;
    bool reafirmPos = false;
    Vector3 reafirmingPos;
    Rigidbody rb;

    // Start is called before the first frame update


    void Start()
    {
        puntuationBase = 2;
        puntuation = 0; //Init
        bestPuntuation = PlayerPrefs.GetInt("BestPuntuation", 0);
        totalCombo = 1f;
        StartCoroutine("IncreasePuntuation");
        ReafirmPos(true);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = puntuation.ToString();
        combo.text = "x" + totalCombo.ToString();
        exerciseID.text = "Exercise " + (building.exerciseID+1).ToString();
        if (rb.velocity.magnitude < 10f) rb.velocity = Vector3.zero;
        if (reafirmPos && Vector3.Distance(transform.position, reafirmingPos) > 0.001f)
        {
            transform.position = reafirmingPos;
            Debug.Log("Reafirming Pos");
        }
    }

    public void ReafirmPos(bool _enable)
    {
        reafirmPos = _enable;
        if (reafirmPos) reafirmingPos = transform.position;
    }

    public void AddCombo(float comb)
    {
        totalCombo += comb;
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


    public int GetPuntuation()
    {
        return puntuation;
    }

    public bool IsChairActive()
    {
        if (gender == Constants.Gender.MAN)
            return manChair.activeSelf;
        else
            return womanChair.activeSelf;
    }
    public void SetChairActive(bool _enable)
    {
        if (gender == Constants.Gender.MAN)
        {
            manChair.SetActive(_enable);
            //if (manChair.activeSelf) StartCoroutine(DisableChairLerp());
            //else manChair.SetActive(_enable);
        }
        else
        {
            womanChair.SetActive(_enable);
            //if (womanChair.activeSelf) StartCoroutine(DisableChairLerp());
            //else womanChair.SetActive(_enable);
        }
    }


    //IEnumerator DisableChairLerp()
    //{
    //    float timer = 0, maxTime = 0.5f;
    //    while(timer < maxTime)
    //    {
    //        yield return new WaitForEndOfFrame();
    //        timer += Time.deltaTime;
    //        fadeBlackImage.color = Color.Lerp(Color.clear, Color.black, timer / maxTime);
    //    }

    //    if (gender == Constants.Gender.MAN) manChair.SetActive(false);
    //    else womanChair.SetActive(false);

    //    timer = 0;
    //    while (timer < maxTime)
    //    {
    //        yield return new WaitForEndOfFrame();
    //        timer += Time.deltaTime;
    //        fadeBlackImage.color = Color.Lerp(Color.black, Color.clear, timer / maxTime);
    //    }
    //}
    

}
