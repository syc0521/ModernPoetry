using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Games.YueOpera
{
    public class ScanLine : MonoBehaviour
    {
        public float[] LineXPosition = new float[2];
        public float[] LineYPosition = new float[2];
        private Timeline currentTimeline;
        public Text lyric;
        public GameObject gamePad;

        private void Start()
        {
            gamePad.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
        void Update()
        {
            foreach (var item in NoteManager.timelines)
            {
                currentTimeline = item;
                if (Time.timeSinceLevelLoad >= currentTimeline.Start &&
                    Time.timeSinceLevelLoad <= currentTimeline.Start + currentTimeline.Duration)
                {
                    Moving();
                    ShowText();
                    ShowPad();
                }
            }
        }

        private void ShowText()
        {
            if (currentTimeline.Lyric != null)
            {
                lyric.text = currentTimeline.Lyric;
            }
            else
            {
                lyric.text = "";
            }
        }

        private void ShowPad()
        {
            float alpha = 1;
            if (currentTimeline.Position == -2)
            {
                alpha = Mathf.InverseLerp(currentTimeline.Start, currentTimeline.Start + 1f, Time.timeSinceLevelLoad);
            }
            else if (currentTimeline.Position == -1)
            {
                alpha = 1 - Mathf.InverseLerp(currentTimeline.Start, currentTimeline.Start + 1f, Time.timeSinceLevelLoad);
            }
            gamePad.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }
        private void Moving()
        {
            if (currentTimeline.Position == 0 || currentTimeline.Position == 1)
            {
                float delta = Mathf.InverseLerp(currentTimeline.Start, currentTimeline.Start + currentTimeline.Duration, Time.timeSinceLevelLoad);
                float x = Mathf.Lerp(LineXPosition[0], LineXPosition[1], delta);
                transform.position = new Vector3(x, LineYPosition[currentTimeline.Position]);
            }
        }
    }
}

