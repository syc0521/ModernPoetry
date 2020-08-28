using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void Convert1()
    {
        SceneManager.LoadScene("PaperCutting");
    }
    public void Convert2()
    {
        SceneManager.LoadScene("YueOpera");
    }
    public void Convert3()
    {
        SceneManager.LoadScene("Puzzle");
    }
    public void Convert4()
    {
        SceneManager.LoadScene("Pottery");
    }
}
