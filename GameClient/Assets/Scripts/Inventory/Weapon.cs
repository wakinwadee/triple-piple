using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



class Weapon : Equipment
{
    public WEAPON_TYPE weaponType;
    public FIRING_MODE firingMode;
    public int semiRoundsValue = 3;
    public int roundsValue = 30;
    public int weaponDamage = 50;
    public int projectilesNumber = 1;
    public float projectileSpeed = 100f;
    public float dispersion = 1f;
    public float fireRate = 1f;
    public float shootingRange = 100f;
    
    public ParticleSystem bulletsParticle;


    //TODO: change after medthods compplite
    private int semiRoundsLeft;
    private int roundsLeft;
    private float lastShotTime = 0;


    private void Start()
    {
        semiRoundsLeft = semiRoundsValue;
        roundsLeft = roundsValue;
        var main = bulletsParticle.main;
        main.startSpeed = projectileSpeed;
    }

    private void FireSingeShot(GameObject playerObject)
    {
        bulletsParticle.Emit(1);

        RaycastHit hit;

        if (Physics.Raycast(playerObject.transform.Find(Constants.RAYCAST_SPOT).position,
                            playerObject.transform.Find(Constants.RAYCAST_SPOT).forward,
                            out hit,
                            shootingRange))
        {
            if (hit.transform.CompareTag(Constants.ENEMY))
            {
                EnemyBehaviour enemy = hit.transform.GetComponent<EnemyBehaviour>();
                enemy.CountHit(weaponDamage);
            }
        }
    }
    
    public override void Action(GameObject playerObject)
    {
        if (Input.GetButtonDown("Fire1")                                && 
            firingMode == FIRING_MODE.SINGLE                            &&
            roundsLeft > 0                                              &&
            Time.time - lastShotTime >= 1 / fireRate)
        {
            FireSingeShot(playerObject);
            roundsLeft -= 1;
        }
        
        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))  &&
             firingMode == FIRING_MODE.FULL_AUTO                        &&
             roundsLeft > 0                                             &&
             Time.time - lastShotTime >= 1 / fireRate)
        {
            FireSingeShot(playerObject);
            roundsLeft -= 1;
            lastShotTime = Time.time;
        }

        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))  &&
             firingMode == FIRING_MODE.SEMI_AUTO                        &&
             roundsLeft > 0                                             &&
             semiRoundsLeft > 0                                         &&
             Time.time - lastShotTime >= 1 / fireRate)
        {
            FireSingeShot(playerObject);
            roundsLeft -= 1;
            semiRoundsLeft -= 1;
            lastShotTime = Time.time;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            semiRoundsLeft = semiRoundsValue;
        }

        if (Input.GetButtonDown("Reload"))
        {
            roundsLeft = roundsValue;
        }
    }


    public override bool IsComposite()
    {
        return false;
    }
}

