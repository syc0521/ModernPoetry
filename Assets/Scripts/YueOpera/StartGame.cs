using Games.YueOpera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject uiElements;
    public GameObject manager;
    public GameObject pause;
    public GameObject finish;
    public GameObject line;
    public GameObject lyric;
    public void StartThis()
    {
        uiElements.SetActive(true);
        var source = manager.GetComponent<AudioSource>();
        source.Play();
        Invoke(nameof(HideUI), source.clip.length);
        Time.timeScale = 1;
        gameObject.SetActive(false);
        pause.SetActive(true);
    }

    private void HideUI()
    {
        uiElements.SetActive(false);
        pause.SetActive(false);
        finish.SetActive(true);
        line.SetActive(false);
        lyric.SetActive(false);
        NoteManager._instance.FinishText();
    }
}
