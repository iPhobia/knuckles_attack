using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;

    private int currentEnemyHealth;

	// Use this for initialization
	void Start () {

        currentEnemyHealth = enemyHealth;
	}
	
	// Update is called once per frame
	void Update () {

        if (currentEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void HurtEnemy(int damage)
    {
        currentEnemyHealth -= damage;
    }
}
