using UnityEngine;
using System.Collections.Generic;
using System;

public class GunController : MonoBehaviour {


    [SerializeField]
    private List<GunBehaviour> guns = new List<GunBehaviour>(); 
    private GunBehaviour currentGun;
    private Action onNextGun, onPreviousGun, onFire;
    private int currentGunIndex;

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
            if (onPreviousGun != null)
            {
                onPreviousGun();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            if (onNextGun != null)
            {
                onNextGun();
            }
        }

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire");
            if (onFire != null)
            {
                onFire();
            }
        }
    }

    private void Awake()
    {
        onNextGun += SwitchToNext;
        onPreviousGun += SwitchToPrevious;
        onFire += TryToFire;
        currentGun = guns[1];
    }

    private void OnDestroy()
    {
        onNextGun -= SwitchToNext;
        onPreviousGun -= SwitchToPrevious;
        onFire -= TryToFire;
    }

    private void SwitchToNext()
    {
        if (currentGunIndex >= guns.Count - 1)
        {
            currentGunIndex = 0;
        }
        else
        {
            currentGunIndex++;
        }

        currentGun = guns[currentGunIndex];
    }

    private void SwitchToPrevious()
    {
        if (currentGunIndex <= 0)
        {
            currentGunIndex = guns.Count - 1;
        }
        else
        {
            currentGunIndex--;
        }

        currentGun = guns[currentGunIndex];
    }

    private void TryToFire()
    {
        currentGun.Shoot();
    }
}
