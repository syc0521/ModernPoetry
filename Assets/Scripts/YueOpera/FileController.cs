using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Games.YueOpera
{
    public class FileController : MonoBehaviour
    {
        public float[] LineYPosition = new float[2];
        private AudioSource source;
        private AudioClip song;
        void Awake()
        {
            ReadSong();
            ReadTimeline();
            ReadChart();

        }
        private void Start()
        {
            source.Play();
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
                if (temp.Length == 4)
                {
                    NoteManager.timelines.Add(new Timeline(temp[0], temp[1], temp[2], temp[3]));
                }
            }
        }
        private void ReadChart()
        {
            var chartText = Resources.Load<TextAsset>("chart");
            var lines = Regex.Split(chartText.text, "\r\n");
            foreach (var line in lines)
            {
                if (!line.Equals(""))
                {
                    NoteManager.notes.Add(new Note(line));
                }
            }
            NoteManager.notes[0].CanJudge = true;
        }
    }

}
