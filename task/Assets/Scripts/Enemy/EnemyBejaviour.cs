using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBejaviour : MonoBehaviour {

    

    private CharController player;

    private void Start()
    {
        player = FindObjectOfType<CharController>();    
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
