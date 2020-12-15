using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by: Kendall Tencio Esquivel

public class PointerBehavior : MonoBehaviour
{
    public string name;
    public GameObject canvas;
    public CharacterDialog cd;
    public PlayerMovement playerMovement;

    void Update()
    {
        if (cd.this_dialog)
        {
            if (!cd.finished)
            {
                playerMovement.canMove = false;
            }
            else
            {
                playerMovement.canMove = true;
                cd.this_dialog = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (cd.finished)
        {
            playerMovement.canMove = false;
            canvas.SetActive(true);
            cd.activated = true;
            cd.finished = false;
            cd.this_dialog = true;
        }
    }
}
