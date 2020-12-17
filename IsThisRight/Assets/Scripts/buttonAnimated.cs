using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAnimated : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void clicked()
    {
        animator.SetBool("Down", true);
    }
    public void unclicked()
    {
        animator.SetBool("Down", false);
    }
}
