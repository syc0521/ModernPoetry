﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Games.YueOpera
{
    class NoteManager : MonoBehaviour
    {
        public static List<Timeline> timelines = new List<Timeline>();
        public static List<Note> notes = new List<Note>();
        public float[] TapXPosition = new float[2];
        public float[] TapYPosition = new float[2];
        public GameObject tap;
        public static int perfect;
        public static int great;
        public static int miss;
        public Text[] result;//p g m
        public static NoteManager _instance;
        private void Start()
        {
            _instance = this;
            foreach (var note in notes)
            {
                Timeline current = timelines[note.TimelineID];
                if (note.Time > current.Start && note.Time < current.Start + current.Duration)
                {
                    GameObject obj = Instantiate(tap);
                    obj.GetComponent<Tap>().thisNote = note;
                    float delta = Mathf.InverseLerp(current.Start, current.Start + current.Duration, note.Time);
                    float x = Mathf.Lerp(TapXPosition[0] + 0.1f, TapXPosition[1] + 0.3f, delta);
                    obj.transform.position = new Vector3(x, TapYPosition[current.Position]);
                    obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
            }
        }
        public void FinishText()
        {
            result[0].text = perfect.ToString();
            result[1].text = great.ToString();
            result[2].text = miss.ToString();
        }
    }
}
