using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static bool isStart = false;

    public void SetStart()
    {
        isStart = true;
        gameObject.SetActive(false);
    }
}
