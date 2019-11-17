using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGateAnimation : MonoBehaviour
{
    public static StartGateAnimation getGateAnimation;

    Animator animator;
    private void Awake()
    {
        getGateAnimation = this;
        animator = GetComponent<Animator>();
        //animator.enabled = false;
        
    }
    public void PlayGateAnimation()
    {
        animator.enabled = true;
        animator.SetTrigger("Pressed");
    }
}
