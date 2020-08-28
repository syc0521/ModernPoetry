using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.PaperCutting
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] papers = new GameObject[3];
        public GameObject[] paperButton = new GameObject[3];
        public Vector2 position;
        private GameObject currentPaper;
        public static GameManager _instance;
        public static int count = 0;
        private readonly int[] pieces = { 27, 26, 38 };
        void Start()
        {
            _instance = this;
            CreatePaper(0);
        }

        public void CreatePaper(int index)
        {
            currentPaper = Instantiate(papers[index]);
        }
        public void DestroyPaper()
        {
            Destroy(currentPaper);
        }
    }
}
