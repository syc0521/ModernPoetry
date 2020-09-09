using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float redPosition;
    public GameObject green;
    public float YPosition;
    public GameObject triangle;
    private float time = 5f;
    public Text TimeText;
    private bool isJudged = false;
    public Vector2 maxPosition;
    public Vector2 maxRedPosition;
    public Sprite[] resultSprites = new Sprite[4];
    public SpriteRenderer result;
    private System.Random random;
    void Start()
    {
        long tick = DateTime.Now.Ticks;
        random = new System.Random((int)(tick & 0x12345678L) | ((int)tick >> 32));
        var temp = Instantiate(green);
        redPosition = UnityEngine.Random.Range(maxRedPosition.x, maxRedPosition.y);
        //Debug.Log(redPosition);
        //float left = Mathf.InverseLerp(maxPosition.x, maxPosition.y, redPosition - 0.8f);
        //float right = Mathf.InverseLerp(maxPosition.x, maxPosition.y, redPosition + 0.8f);
        //Debug.Log(left);
        //Debug.Log(right);
        temp.transform.position = new Vector3(redPosition, YPosition);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene("Main");
        //}
        if (Button.isStart)
        {
            ShowTime();
            LimitPosition();
            if (time == 0 && isJudged == false)
            {
                JudgeWin();
                isJudged = true;
            }
            Press();
            if (time == 0)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Button.isStart = false;
                    SceneManager.LoadScene("Pottery");
                }
            }
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
        float left = redPosition - 0.78f;
        float right = redPosition + 0.78f;
        float middle = triangle.transform.position.x;
        if (middle >= left && middle <= right)
        {
            Debug.Log("win");
            result.sprite = resultSprites[random.Next(1, 3)];
        }
        else
        {
            Debug.Log("lose");
            result.sprite = resultSprites[0];
        }
    }
    private void Press()
    {
        if (time != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(MoveTriangle());
            }
#if UNITY_EDITOR
            float x = triangle.transform.position.x - 0.008f;
#else
            float x = triangle.transform.position.x - 0.056f;
#endif
            triangle.transform.position = new Vector3(x, triangle.transform.position.y);
        }
    }
    private IEnumerator MoveTriangle()
    {
#if UNITY_EDITOR
        float speed = 0.15f + 0.2f * (float)random.NextDouble();
        float acceleration = speed / 25.0f;
#else
        float speed = 0.21f + 0.25f * (float)random.NextDouble();
        float acceleration = speed / 12.0f;
#endif
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
        if (triangle.transform.position.x <= maxPosition.x)
        {
            triangle.transform.position = new Vector3(maxPosition.x, triangle.transform.position.y);
        }
        if (triangle.transform.position.x >= maxPosition.y)
        {
            triangle.transform.position = new Vector3(maxPosition.y, triangle.transform.position.y);
        }
    }
}
