using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.YueOpera
{
    public class ScanLine : MonoBehaviour
    {
        public float[] LineXPosition = new float[2];
        public float[] LineYPosition = new float[2];
        Timeline currentTimeline;

        void Update()
        {
            foreach (var item in NoteManager.timelines)
            {
                currentTimeline = item;
                if (Time.timeSinceLevelLoad >= currentTimeline.Start &&
                    Time.timeSinceLevelLoad <= currentTimeline.Start + currentTimeline.Duration)
                {
                    Moving();
                }
            }
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

