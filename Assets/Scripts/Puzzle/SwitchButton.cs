using Games.Puzzle;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.Puzzle
{
    public class SwitchButton : MonoBehaviour
    {
        public void ButtonClick()
        {
            Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            CreatePatch._instance.index = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
            CreatePatch._instance.DeletePatch();
            CreatePatch._instance.CreatePatchObj();
        }
    }

}
