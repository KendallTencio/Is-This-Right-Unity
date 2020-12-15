using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    public GameObject canvas_cinematics;
    public CinematicScript cs;

    // Start is called before the first frame update
    void Start()
    {
        canvas_cinematics.SetActive(false);
    }

    void Update()
    {
        if (cs.finished)
        {
            canvas_cinematics.SetActive(false);
            cs.finished = false;
            cs.text_display.text = "";
        }
    }

    void OnMouseDown()
    {
        canvas_cinematics.SetActive(true);
        cs.fade();
    }
}
