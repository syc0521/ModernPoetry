using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float greenPosition;
    public GameObject green;
    public float YPosition;
    public GameObject triangle;
    private float time = 5f;
    public Text TimeText;
    private bool isJudged = false;
    public Vector2 maxPosition;
    public Vector2 maxRedPosition;
    void Start()
    {
        var temp = Instantiate(green);
        greenPosition = UnityEngine.Random.Range(-maxPosition.x, maxPosition.y);
        Debug.Log(greenPosition);
        float left = Mathf.InverseLerp(-maxPosition.x, maxPosition.y, greenPosition - 1);
        float right = Mathf.InverseLerp(-maxPosition.x, maxPosition.y, greenPosition + 1);
        Debug.Log(left);
        Debug.Log(right);
        temp.transform.position = new Vector3(greenPosition, YPosition);
    }

    void Update()
    {
        ShowTime();
        LimitPosition();
        Press();
        if (time == 0 && isJudged == false)
        {
            JudgeWin();
            isJudged = true;
        }
        if (time != 0)
        {
            float x = triangle.transform.position.x - 0.008f;
            triangle.transform.position = new Vector3(x, triangle.transform.position.y);
        }
    }

    private void ShowTime()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 0;
            TimeText.text = "0.00";
        }
        else TimeText.text = Math.Round(time, 2) + "";
    }

    private void JudgeWin()
    {
        float left = Mathf.InverseLerp(-5, 5, greenPosition - 1);
        float right = Mathf.InverseLerp(-5, 5, greenPosition + 1);
        float middle = Mathf.InverseLerp(-maxRedPosition.x, maxRedPosition.y, triangle.transform.position.x);
        if (middle >= left && middle <= right)
        {
            Debug.Log("win");
        }
        else
        {
            Debug.Log("lose");
        }
    }
    private void Press()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveTriangle());
        }
    }
    private IEnumerator MoveTriangle()
    {
        float speed = UnityEngine.Random.Range(0.15f, 0.34f);
        float acceleration = speed / 25.0f;
        float x = triangle.transform.position.x;
        while (speed > 0)
        {
            speed -= acceleration;
            x += speed;
            triangle.transform.position = new Vector3(x, triangle.transform.position.y);
            LimitPosition();
            yield return null;
        }
    }
    private void LimitPosition()
    {
        
        if (triangle.transform.position.x <= -maxRedPosition.x)
        {
            triangle.transform.position = new Vector3(-maxRedPosition.x, triangle.transform.position.y);
        }
        if (triangle.transform.position.x >= maxRedPosition.y)
        {
            triangle.transform.position = new Vector3(maxRedPosition.y, triangle.transform.position.y);
        }
    }
}
