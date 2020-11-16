using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] 
    private Torch torch;

    public float distance = 5;

    public bool triggered = false;

    public Animator animator;
    private static readonly int Play = Animator.StringToHash("Play");

    private void Update()
    {
        var distanceToTorch = Vector3.Distance(torch.transform.position, this.transform.position);
        
        if (distanceToTorch < distance && triggered == false)
        {
            triggered = true;
            //play anim
            animator.SetTrigger(Play);
        }

        if (distanceToTorch > distance && triggered)
        {
            triggered = false;
        }
        
    }
}
