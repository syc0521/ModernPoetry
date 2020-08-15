using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.YueOpera
{
    public class Judge : MonoBehaviour
    {
        public float time;

        void Update()
        {
            float alpha = 1 - Mathf.InverseLerp(time + 0.2f, time + 0.8f, Time.timeSinceLevelLoad);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
            Invoke(nameof(Destroy), 1f);
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }

}
