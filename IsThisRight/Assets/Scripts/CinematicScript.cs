using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicScript : MonoBehaviour
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

    void Start()
    {
        cinematic_image.sprite = cinematic_sprite;
        finished = false;
    }

    public void fade()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            cinematic_image.color = new Color(1, 1, 1, i);
            yield return null;
        }
        StartCoroutine(TypingDialog());
        yield return new WaitForSeconds(fade_out_time);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            cinematic_image.color = new Color(1, 1, 1, i);
            yield return null;
        }
        finished = true;
    }

    IEnumerator TypingDialog()
    {
        // head_image.sprite = head_sprites[sent_order[index]];
        head_image.color = new Color(255, 255, 255, 255);
        head_image.sprite = head_sprite;

        foreach (char letter in sentences[index].ToCharArray())
        {
            text_display.text += letter;
            yield return new WaitForSeconds(typing_speed);
        }
    }
}