using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public Animator animator;
    private bool hasEntered = false;
    public delegate void OnTargetCollisionEventHandler(TriggerButton target);

    public event OnTargetCollisionEventHandler OnTargetCollisionEvent;

    private void Awake()
    {
        OnTargetCollisionEvent = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Chicken" && !hasEntered)
        {
            hasEntered = true;
            animator.SetTrigger("button");

            if (OnTargetCollisionEvent != null)
                OnTargetCollisionEvent(this);
            
            Invoke(nameof(toggleHasEnteredToFalse), 1f);
        }
    }
    
    private void toggleHasEnteredToFalse()
    {
        hasEntered = false;
    }
}