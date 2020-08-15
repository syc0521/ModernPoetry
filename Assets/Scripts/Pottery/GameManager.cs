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
    private float maxPosition = 7.58f;
    void Start()
    {
        var temp = Instantiate(green);
        greenPosition = UnityEngine.Random.Range(-5, 5);
        temp.transform.position = new Vector3(greenPosition, YPosition);
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 0;
            TimeText.text = "0.00";
        }
        else TimeText.text = Math.Round(time, 2) + "";
        LimitPosition();
        Press();
        if (time == 0 && !isJudged)
        {
            JudgeWin();
            isJudged = true;
        }
        else
        {
            float x = triangle.transform.position.x - 0.008f;
            triangle.transform.position = new Vector3(x, triangle.transform.position.y);
        }
    }
    private void JudgeWin()
    {
        float left = Mathf.InverseLerp(-5, 5, greenPosition - 1);
        float right = Mathf.InverseLerp(-5, 5, greenPosition + 1);
        float middle = Mathf.InverseLerp(-maxPosition, maxPosition, triangle.transform.position.x);
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
        float speed = 0.08f;
        float x = triangle.transform.position.x;
        while (speed > 0)
        {
            speed -= 0.0014f;
            x += speed;
            triangle.transform.position = new Vector3(x, triangle.transform.position.y);
            LimitPosition();
            yield return null;
        }
    }
    private void LimitPosition()
    {
        
        if (triangle.transform.position.x <= -maxPosition)
        {
            triangle.transform.position = new Vector3(-maxPosition, triangle.transform.position.y);
        }
        if (triangle.transform.position.x >= maxPosition)
        {
            triangle.transform.position = new Vector3(maxPosition, triangle.transform.position.y);
        }
    }
}
