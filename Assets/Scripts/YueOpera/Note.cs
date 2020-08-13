using System;
using System.Collections.Generic;
using UnityEngine;

namespace Games.YueOpera
{
    class Note
    {
        public float Time { get; set; }
        public int Position { get; set; }
        public Note(string time, string pos)
        {
            Time = Convert.ToInt32(time) / 1000.0f;
            Position = Convert.ToInt32(pos);
        }
    }
    class Timeline
    {
        public float Start { get; set; }
        public float Duration { get; set; }
        public int Position { get; set; }
        public Timeline(string start, string duration, string pos)
        {
            try
            {
                Start = Convert.ToInt32(start) / 1000.0f;
                Duration = Convert.ToInt32(duration) / 1000.0f;
                Position = Convert.ToInt32(pos);
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
