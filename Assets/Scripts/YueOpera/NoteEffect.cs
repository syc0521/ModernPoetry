using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEffect : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(DestroyThis), 1f);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
