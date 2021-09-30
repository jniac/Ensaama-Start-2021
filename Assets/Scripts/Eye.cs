using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Transform target;
    public bool isFalling = false;
    public GameObject clone;

    void Update() {
        if (target != null) {
            if (isFalling == false) {
                transform.LookAt(target);
            }
        }
    }

    void OnMouseDown() {
        clone = Instantiate(gameObject, transform.parent);
        clone.SetActive(false);

        isFalling = true;
        Rigidbody body = gameObject.AddComponent<Rigidbody>();
        // "traîné<e angulaire", càd la friction associée à la rotation
        // 0.05f par défaut, nous mettons 0.8f pour ralentir les yeux.
        body.angularDrag = 1.0f;
        body.drag = 0.5f;

        Debug.Log("i'm falliiiiiiiing!!!");
        StartCoroutine(FallEnd());
    }

    // pénible mais c'est ainsi dans Unity, pour retardé une exécution
    // il faut créer une fonction de type "IEnumerator"
    IEnumerator FallEnd() {
        yield return new WaitForSeconds(4f);
        isFalling = false;
        Debug.Log("finally, it's ok, i'm still alive");

        clone.SetActive(true);
    }
}
