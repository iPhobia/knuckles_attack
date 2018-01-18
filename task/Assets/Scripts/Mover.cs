using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    Rigidbody rB;
    public float speed = 15.0f;

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        rB.velocity = transform.forward * speed;
    }
}
