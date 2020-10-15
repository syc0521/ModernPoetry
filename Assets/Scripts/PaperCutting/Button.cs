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
            GameManager._instance.victory.SetActive(false);
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            GameManager.count = 0;
            GameManager._instance.DestroyPaper();
            var name = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
            GameManager._instance.CreatePaper(name);
            GameManager.level = name;
        }
    }
}

