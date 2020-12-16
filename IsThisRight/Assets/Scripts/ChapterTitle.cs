using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterTitle : MonoBehaviour
{
    bool first_time = true;
    public GameObject canvas;
    public Text chapter_text;
    public string name_of_chapter;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fade()
    {

    }

    IEnumerator FadeImage()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            chapter_text.color = new Color(1, 1, 1, i);
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            chapter_text.color = new Color(1, 1, 1, i);
            yield return null;
        }
        first_time = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && first_time)
        {
            chapter_text.text = name_of_chapter;
            canvas.SetActive(true);
            StartCoroutine(FadeImage());
        }
        
    }
}
