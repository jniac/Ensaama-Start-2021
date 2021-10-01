using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;
    public float jumpCoolDown = 0f;
    public float jumpRandomAngularSpeed = 12f;

    // Ici body est null par défaut, la variable sera initialisée durant "Start".
    Rigidbody body;

    void Start() {
        body = GetComponent<Rigidbody>();

        // Par principe, le composant rigidbody doit exister.
        // Si ce n'est pas le cas, on suspend le moteur, et on affiche une erreur.
        if (body == null) {
            Debug.LogError("Yo utilisateur, tu as oublié d'associer un Rigidbody ici.");
            Debug.Break();
        }

        // Une solution plus sympa que d'envoyer une erreur, consisterait à ajouter 
        // automatiquement le Rigidbody lorsque celui-ci est absent.
        // Cela pourrait prendre la forme suivante.
        // C'est plus sympa, mais c'est parfois mieux d'être sévère (sévère mais juste).
        // if (body == null) {
        //     body = gameObject.AddComponent<Rigidbody>();
        // }
    }

    void UpdateMove() {

        Vector3 velocity = body.velocity;

        float ix = Input.GetAxis("Horizontal");
        float iz = Input.GetAxis("Vertical");
        float input = Mathf.Clamp01(Mathf.Sqrt(ix * ix + iz * iz));

        // C'est bien de savoir ce que c'est qu'une interpolation linéaire (Lerp).
        // Alors ici on se tape la doc : 
        // https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html
        velocity.x = Mathf.Lerp(velocity.x, ix * moveSpeed, input);
        velocity.z = Mathf.Lerp(velocity.z, iz * moveSpeed, input);

        body.velocity = velocity;
    }

    void UpdateJump() {

        jumpCoolDown = jumpCoolDown - Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && jumpCoolDown <=0) {
            jumpCoolDown = 1.5f;

            Vector3 velocity = body.velocity;
            velocity.y = jumpSpeed;

            body.velocity = velocity;
            // Random est une classe de Unity offrant des solutions pour ce qui est
            // d'obtenir des valeurs aléatoires. Qu'il s'agisse d'un simple nombre
            // ou d'un Vector3 comme ici.
            // Random.onUnitSphere renvoit un Vector3 aléatoire dont la longueur
            // (ou magnitude) est de 1 ("on unit sphere").
            body.angularVelocity = Random.onUnitSphere * jumpRandomAngularSpeed;
        }
    }

    void Update() {
        
        UpdateMove();
        UpdateJump();
    }
}
