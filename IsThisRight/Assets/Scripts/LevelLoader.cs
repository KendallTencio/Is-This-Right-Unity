using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime = 1f;
    public Text shutDownText;
    public AudioSource spaceHit;
    public AudioSource instructionHit;
    public string nextLevelName;
    public GameObject canvas_instructions;
    private bool instrOn = false;

    void Start()
    {
        canvas_instructions.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(shutDownText != null)
            {
                shutDownText.gameObject.SetActive(false);
            }
            spaceHit.Play();
            StartCoroutine(loadLevel());
        }
        if (Input.GetKeyDown("c"))
        {
            if (instrOn)
            {
                canvas_instructions.SetActive(false);
                instructionHit.Play();
                instrOn = false;
            }
            else
            {
                canvas_instructions.SetActive(true);
                instructionHit.Play();
                instrOn = true;
            }
            
        }
    }

    IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextLevelName);
    }


}
