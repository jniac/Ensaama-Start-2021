using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownChildCloner : MonoBehaviour
{
    public int numOfClones = 10;

    void Start() {
        for (int i = 0; i < numOfClones; i = i + 1) {
            MakeAClone();
        }
    }

    void MakeAClone() {
        GameObject clone = Instantiate(gameObject, transform.parent);
        
        // IL FAUT D2TRUIRE LE SCRIPT SUR L4ENFANT!!!!
        // Sans cela celui se clonera à son tour, puis son enfant aussi, puis le petit-enfant, puis le petit-petit-enfant, puis le
        Destroy(clone.GetComponent<CrownChildCloner>());

        float yAngle = Random.Range(0f, 360f);
        clone.transform.Rotate(0f, yAngle, 0f);

        // Changeons la vitesse de rotation du clone.
        Rotate rotate = clone.GetComponent<Rotate>();
        rotate.rotationSpeed = new Vector3(
            0f,
            Random.Range(20f, 30f),
            0f
        );

        // Changeons la taille de l'enfant du clone (arf).
        clone.transform.GetChild(0).localScale = Vector3.one * Random.Range(0.2f, 1f);
    }
}
