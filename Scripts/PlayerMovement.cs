using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 200f;

    public float horizontal;

    public GameObject explosion;

   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);//если world то вращаться будет но двигать токо прямо!
        transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.deltaTime);
    }
}
