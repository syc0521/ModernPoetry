using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.YueOpera
{
    public class Tap : MonoBehaviour
    {
        public Note thisNote;
        public GameObject[] Sprites;
        private GameObject judgeSprite;
        public GameObject noteEffect;
        private readonly float judgeDelta = -0.74f;
        private readonly float perfect = 0.1f;
        private readonly float great = 0.25f;

        void Update()
        {
            ShowNote();
            int judgeType = JudgeNote();
            switch (judgeType)
            {
                case 0:
                    Debug.Log(thisNote + "perfect");
                    JudgeNext();
                    NoteManager.perfect++;
                    Destroy(gameObject);
                    Instantiate(noteEffect, gameObject.transform.position, Quaternion.identity);
                    break;
                case 1:
                    Debug.Log(thisNote + "great");
                    JudgeNext();
                    NoteManager.great++;
                    Destroy(gameObject);
                    Instantiate(noteEffect, gameObject.transform.position, Quaternion.identity);
                    break;
            }
            if (judgeType != -2)
            {
                ShowJudge(judgeType);
            }
            if (Time.timeSinceLevelLoad >= thisNote.Time + 0.25f || judgeType == -1)
            {
                ShowJudge(2);
                Debug.Log(thisNote + "miss");
                NoteManager.miss++;
                Destroy(gameObject);
            }
        }
        private void JudgeNext()
        {
            NoteManager.notes[NoteManager.notes.IndexOf(thisNote) + 1].CanJudge = true;
        }
        private void ShowJudge(int index)
        {
            judgeSprite = Instantiate(Sprites[index]);
            judgeSprite.GetComponent<Judge>().time = Time.timeSinceLevelLoad;
            judgeSprite.transform.position = new Vector3(gameObject.transform.position.x, 
                                                 gameObject.transform.position.y + judgeDelta);
        }
        private void ShowNote()
        {
            if (Time.timeSinceLevelLoad >= NoteManager.timelines[thisNote.TimelineID].Start - 1f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }
        private int JudgeNote()
        {
            if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J)) && thisNote.CanJudge)
            {
                var time = Time.timeSinceLevelLoad;
                if (time >= thisNote.Time - perfect && time < thisNote.Time + perfect) return 0;
                else if (time >= thisNote.Time - great && time < thisNote.Time + great) return 1;
                else if (time >= thisNote.Time + great) return 2;
            }
            return -2;
        }
    }

}
