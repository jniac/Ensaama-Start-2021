using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneOnClick : MonoBehaviour
{
    public int numberOfClones = 3;

    private void OnMouseDown() {
        // La Mort !
        // Destroy(gameObject);

        // La Vie !
        for (int i = 0; i < numberOfClones; i = i + 1) {
            GameObject toto = Instantiate(gameObject);
            Destroy(toto, 1f);
        }
    }
}
