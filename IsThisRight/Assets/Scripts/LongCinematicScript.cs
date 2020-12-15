using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongCinematicScript : MonoBehaviour
{
    public Sprite cinematic_sprite;
    public Image cinematic_image;

    public Sprite head_sprite;
    public Image head_image;
    public Text text_display;

    public string[] sentences;

    private int index;
    public float typing_speed;
    public float fade_out_time;

    public bool finished;
    public bool this_dialog;
    public bool continueGame;
    public GameObject next_button;
    public GameObject canvas_cinematic;
    public GameObject retaniAnim;

    void Start()
    {
        cinematic_image.sprite = cinematic_sprite;
        finished = false;
        retaniAnim.gameObject.GetComponent<Animator>().enabled = false;
        fade();
    }

    void Update()
    {
        if (text_display.text == sentences[index])
        {
            next_button.SetActive(true);
        }
    }

    public void fade()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        StartCoroutine(TypingDialog());

        while (finished == false)
        {
            yield return null;
        }

        canvas_cinematic.SetActive(false);
    }

    IEnumerator TypingDialog()
    {
        head_image.color = new Color(255, 255, 255, 255);
        head_image.sprite = head_sprite;

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
                finished = true;
                this_dialog = false;
                index = 0;
                retaniAnim.gameObject.GetComponent<Animator>().enabled = true;
            }
        }
    }
}