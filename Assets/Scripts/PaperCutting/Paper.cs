using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.PaperCutting
{
    public class Paper : MonoBehaviour
    {
        void OnMouseDown()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            GameManager.count++;
            Debug.Log(GameManager.count);
        }
    }
}

