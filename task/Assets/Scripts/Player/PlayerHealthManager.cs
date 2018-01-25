using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int health;
    public int armour;

    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            gameController.GameOver();
        }
    }

    public void OnDamage(int damage)
    {
        Debug.Log("Health :" + health + ' ' + "Armour :" + armour);
        if (armour != 0)
        {
            armour--;
        }
        else
        {
            health -= damage;
        }
    }
}
