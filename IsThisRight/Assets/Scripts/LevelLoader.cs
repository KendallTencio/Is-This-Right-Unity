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
    public string nextLevelName;

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
    }

    IEnumerator loadLevel()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextLevelName);
    }


}
