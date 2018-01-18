using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }

    public Rigidbody rBody;
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public Boundary boundary;

    private float movement;
    private float rotation;

    private void FixedUpdate()
    {
        movement *= Time.deltaTime;
        rotation *= Time.deltaTime;
        rBody.position = new Vector3
       (
           Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),
           0.0f,
           Mathf.Clamp(rBody.position.z, boundary.zMin, boundary.zMax)
       );

        rBody.transform.Translate(0f, 0.0f, movement );
        rBody.transform.Rotate(0.0f, rotation, 0f);
    }

    private void Update()
    {
        movement = Input.GetAxis("Vertical") * speed;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;
    }
}
