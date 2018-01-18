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
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public Boundary boundary;

    
    

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        movement *= Time.deltaTime;
        rotation *= Time.deltaTime;
        rBody.position = new Vector3
       (
           Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),
           0.0f,
           Mathf.Clamp(rBody.position.z, boundary.zMin, boundary.zMax)
       );

        rBody.transform.Translate(movement, 0.0f, 0.0f );
        rBody.transform.Rotate(0.0f, 0.0f, rotation);
    }

    private void Update()
    {
        
    }
}
