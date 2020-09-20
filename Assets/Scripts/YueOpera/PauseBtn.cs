using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    public GameObject manager;
    public Sprite pause;
    public Sprite resume;
    public void Pause()
    {
        Time.timeScale = 0;
        manager.GetComponent<AudioSource>().Pause();
        gameObject.GetComponent<Image>().sprite = resume;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        manager.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Image>().sprite = pause;
    }

    public void ClickBtn()
    {
        if (Time.timeScale == 0) Resume();
        else Pause();
    }
}
