using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    public Rigidbody rBody;
    public float speed = 10f;
    public float rotationSpeed = 100f;
    
    private float movement;
    private float rotation;

    private void FixedUpdate()
    {
        movement *= Time.deltaTime;
        rotation *= Time.deltaTime;
   
        rBody.transform.Translate(0f, 0.0f, movement );
        rBody.transform.Rotate(0.0f, rotation, 0f);
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Vertical") * speed;
        rotation = Input.GetAxisRaw("Horizontal") * rotationSpeed;
    }
}
