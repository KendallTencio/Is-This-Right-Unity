using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofCofScript : MonoBehaviour
{
    public AudioClip cough_1;
    public AudioClip cough_2;
    public AudioClip cough_3;
    AudioSource aud_sou;

    bool cofcof_active;
    bool update_flag;

    // Start is called before the first frame update
    void Start()
    {
        update_flag = true;
        aud_sou = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cofcof_active && update_flag)
        {
            cofcof_active = false;
            update_flag = false;
            
        }
    }

    IEnumerator Coughing()
    {
        aud_sou.clip = cough_1;
        aud_sou.Play();
        yield return new WaitForSeconds(4.0f);
        aud_sou.clip = cough_2;
        aud_sou.Play();
        yield return new WaitForSeconds(2.0f);
        aud_sou.clip = cough_3;
        aud_sou.Play();
        yield return new WaitForSeconds(6.0f);
    }

    void OnTriggerEnter2D()
    {
        StartCoroutine(Coughing());
    }

    void OnTriggerExit2D()
    {
        cofcof_active = false;
        update_flag = true;
    }
}
