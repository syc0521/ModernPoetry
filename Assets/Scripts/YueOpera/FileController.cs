using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Games.YueOpera
{
    public class FileController : MonoBehaviour
    {
        public float[] LineYPosition = new float[2];
        public GameObject manager;
        private AudioSource source;
        private AudioClip song;
        void Start()
        {
            ReadSong();
            ReadTimeline();
            Debug.Log("Finish");
        }

        void Update()
        {

        }

        private void ReadSong()
        {
            song = Resources.Load<AudioClip>("track");
            gameObject.AddComponent<AudioSource>();
            source = gameObject.GetComponent<AudioSource>();
            source.clip = song;
        }
        private void ReadTimeline()
        {
            var timelineText = Resources.Load<TextAsset>("timeline");
            var lines = Regex.Split(timelineText.text, "\r\n");
            foreach (var line in lines)
            {
                var temp = line.Split(',');
                if (temp.Length == 3)
                {
                    NoteManager.timelines.Add(new Timeline(temp[0], temp[1], temp[2]));
                }
            }
        }
    }

}
