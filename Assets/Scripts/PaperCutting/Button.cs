using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.PaperCutting
{
    public class Button : MonoBehaviour
    {
        public void ButtonClick()
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            GameManager.count = 0;
            GameManager._instance.DestroyPaper();
            GameManager._instance.CreatePaper(Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name));
        }
    }
}

