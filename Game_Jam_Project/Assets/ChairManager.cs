using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    [SerializeField] GameObject chairRef;

    Animator animator;
    RuntimeAnimatorController sittingAnimController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sittingAnimController = Resources.Load<RuntimeAnimatorController>("Animations/Controller/BreathSittingIdle");
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.runtimeAnimatorController != null)
        {
            if (animator.runtimeAnimatorController == sittingAnimController)
                chairRef.SetActive(true);
            else
                chairRef.SetActive(false);

            this.enabled = false;
        }
    }
}
