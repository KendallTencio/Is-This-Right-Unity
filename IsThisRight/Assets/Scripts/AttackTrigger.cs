using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private plantAttack leg;
    float timer = 0;
    bool timerReached = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leg.attack();
        }
        else
        {
            leg.stop();
        }         
    }

}
