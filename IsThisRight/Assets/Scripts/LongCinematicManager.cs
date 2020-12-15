using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongCinematicManager : MonoBehaviour
{
    public GameObject canvas_cinematics;
    public LongCinematicScript lcs;

    // Start is called before the first frame update
    void Start()
    {
        canvas_cinematics.SetActive(true);
    }

    void Update()
    {
        if (lcs.finished)
        {
            canvas_cinematics.SetActive(false);
            lcs.finished = false;
            lcs.text_display.text = "";
        }
    }

}
