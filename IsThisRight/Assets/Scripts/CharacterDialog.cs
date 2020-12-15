using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//The base of this code is taken from: https://www.youtube.com/watch?v=f-oSXg6_AMQ
// Modified by: Kendall Tencio Esquivel

public class CharacterDialog : MonoBehaviour
{
    public GameObject dialog_canvas;
    public Text text_display;

    public Sprite[] head_sprites;
    public int[] sent_order;
    public string[] sentences;

    private int index;
    public float typing_speed;

    public Image head_image;

    public GameObject next_button;
    public bool activated;
    public bool finished;
    public bool this_dialog;

    void Start()
    {
        activated = false;
        finished = true;
        this_dialog = false;
    }

    void Update()
    {
        if (text_display.text == sentences[index])
        {
            next_button.SetActive(true);
        }
        if (activated)
        {
            activated = false;
            finished = false;
            StartCoroutine(TypingDialog());
        }
    }

    IEnumerator TypingDialog()
    {
        head_image.sprite = head_sprites[sent_order[index]];

        foreach (char letter in sentences[index].ToCharArray())
        {
            text_display.text += letter;
            yield return new WaitForSeconds(typing_speed);
        }
    }

    public void NextSentence()
    {
        if (this_dialog)
        {
            next_button.SetActive(false);

            if (index < sentences.Length - 1)
            {
                index++;
                text_display.text = "";
                StartCoroutine(TypingDialog());
            }
            else
            {
                text_display.text = "";
                next_button.SetActive(false);
                dialog_canvas.SetActive(false);
                activated = false;
                finished = true;
              //  this_dialog = false;
                index = 0;
            }
        }
    }
}
