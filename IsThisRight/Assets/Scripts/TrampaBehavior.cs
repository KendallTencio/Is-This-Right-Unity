using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaBehavior : MonoBehaviour
{
    private Animator trampaClose;
    public AudioSource trapSound;
    void Start()
    {
        trampaClose = GetComponent<Animator>();
    }
    void OnCollisionEnter2D()
    {
        trapSound.Play();
        trampaClose.Play("trampa_cerrandose");
    }
    void OnCollisionExit2D()
    {
        trampaClose.Play("trampa_abriendose");
    }
}
