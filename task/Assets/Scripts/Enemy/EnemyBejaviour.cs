using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBejaviour : MonoBehaviour {

    public int speed;
    public int damageToGive;

    private Rigidbody rB;
    private CharController player;
    private GameController gameController;

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        player = FindObjectOfType<CharController>();
        gameController = FindObjectOfType<GameController>();
    }

    private void FixedUpdate()
    {
        rB.velocity = transform.forward * speed;
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthManager>().OnDamage(damageToGive);
            gameController.UpdateValues();
        }
    }
}
