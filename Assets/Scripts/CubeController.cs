using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 10f;
    public float jumpCoolDown = 0f;

    void Update() {
        Rigidbody body = GetComponent<Rigidbody>();
        
        Vector3 move = new Vector3();

        move.x = speed * Input.GetAxis("Horizontal");
        move.y = body.velocity.y;
        move.z = speed * Input.GetAxis("Vertical");

        jumpCoolDown = jumpCoolDown - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && jumpCoolDown <=0) {
            jumpCoolDown = 1.5f;
            move.y = jumpSpeed;
        }

        body.velocity = move;
    }
}
