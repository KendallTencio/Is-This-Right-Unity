using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantAttack : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void attack()
    {
        animator.SetBool("planting", true);
    }
    public void stop()
    {
        animator.SetBool("planting", false);
    }
}
