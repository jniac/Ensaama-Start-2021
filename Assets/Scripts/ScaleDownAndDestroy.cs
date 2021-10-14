using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleDownAndDestroy : MonoBehaviour
{
    public float duration = 10f; // durée de vie en secondes
    public float time = 0f; // temps actuel

    void Update() {
        time += Time.deltaTime;

        float progress = time / duration;
        float t = 1f - progress * progress * progress * progress;
        transform.localScale = Vector3.one * t;

        if (time >= duration) {
            Destroy(gameObject);
        }
    }
}
