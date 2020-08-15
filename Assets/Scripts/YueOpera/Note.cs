using System;
using System.Collections.Generic;
using UnityEngine;

namespace Games.YueOpera
{
    public class Note
    {
        public float Time { get; set; }
        public int Position { get; set; }
        public int TimelineID { get; set; }
        public bool CanJudge { get; set; } = true;
        public Note(string time)
        {
            int min = Convert.ToInt32(time.Substring(0, 1));
            int sec = Convert.ToInt32(time.Substring(2, 2));
            int mil = Convert.ToInt32(time.Substring(5, 3));
            Time = min * 60 + sec + mil / 1000.0f;
            for (int i = 0; i < NoteManager.timelines.Count; i++)
            {
                var timeline = NoteManager.timelines[i];
                if (Time >= timeline.Start && Time <= timeline.Start + timeline.Duration)
                {
                    Position = timeline.Position;
                    TimelineID = i;
                }
            }
        }

        public override string ToString()
        {
            return Time + " " + Position + " " + TimelineID;
        }
    }
    public class Timeline
    {
        public float Start { get; set; }
        public float Duration { get; set; }
        public int Position { get; set; }
        public string Lyric { get; set; }
        public Timeline(string start, string duration, string pos, string lyric)
        {
            try
            {
                Start = Convert.ToInt32(start) / 1000.0f;
                Duration = Convert.ToInt32(duration) / 1000.0f;
                Position = Convert.ToInt32(pos);
                if (!lyric.Equals("0"))
                {
                    Lyric = lyric;
                }
            }
            catch (Exception)
            {
                Debug.LogError("Read Timeline Error");
            }
        }
    }
    enum TimelinePosition
    {
        Up = 0,
        Down = 1,
        Start = -2,
        End = -1
    }
}
