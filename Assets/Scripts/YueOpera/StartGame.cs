using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject uiElements;
    public GameObject manager;
    public GameObject pause;
    public void StartThis()
    {
        uiElements.SetActive(true);
        manager.GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        gameObject.SetActive(false);
        pause.SetActive(true);
    }
}
