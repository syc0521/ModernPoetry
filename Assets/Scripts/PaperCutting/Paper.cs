using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.PaperCutting
{
    public class Paper : MonoBehaviour
    {
        AudioSource cuttingAudio;
        private void Start()
        {
            var clip = Resources.Load<AudioClip>("cutting");
            cuttingAudio = gameObject.AddComponent<AudioSource>();
            cuttingAudio.playOnAwake = false;
            cuttingAudio.clip = clip;
        }
        private void OnMouseDown()
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            cuttingAudio.Play();
            Debug.Log(GameManager.count);
            Invoke(nameof(DestroyObj), 0.4f);
        }

        private void DestroyObj()
        {
            GameManager.count++;
            Destroy(gameObject);
        }
    }
}

