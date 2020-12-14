using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by: Kendall Tencio Esquivel

public class PointerBehavior : MonoBehaviour
{
    public string type;
    public GameObject canvas;
    public CharacterDialog cd;
    public PlayerMovement playerMovement;

    void Update()
    {
        if (!cd.finished)
        {
            playerMovement.canMove = false;
        }
        else
        {
            playerMovement.canMove = true;
        }
    }

    void OnMouseDown()
    {
        if (cd.finished)
        {
            Debug.Log("Entré");
            playerMovement.canMove = false;
            canvas.SetActive(true);
            cd.activated = true;
        }
    }
}
