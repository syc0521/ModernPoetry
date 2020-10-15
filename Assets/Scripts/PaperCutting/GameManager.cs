using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Games.PaperCutting
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] papers = new GameObject[3];
        public GameObject[] paperButton = new GameObject[3];
        public Vector2 position;
        private GameObject currentPaper;
        public static GameManager _instance;
        public static int count;
        private readonly int[] pieces = { 27, 26, 38 };
        public GameObject victory;
        public GameObject cursor;
        public static int level = 0;
        void Start()
        {
            Cursor.visible = false;
            count = 0;
            _instance = this;
            CreatePaper(0);
            victory.SetActive(false);
        }

        public void CreatePaper(int index)
        {
            currentPaper = Instantiate(papers[index]);
        }
        public void DestroyPaper()
        {
            Destroy(currentPaper);
        }
        private void Update()
        {
            cursor.transform.position = ConvertPosition();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main");
            }
            if (count >= pieces[level])
            {
                victory.SetActive(true);
            }
        }

        private Vector3 ConvertPosition()
        {
            var screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector3(screenPos.x, screenPos.y, 1);
        }
    }
}
