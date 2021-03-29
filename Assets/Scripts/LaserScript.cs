using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public ParticleSystem[] laser;
    //public ParticleSystem MuzzleFlash;
    public int projectileSelected = 0;
    public GameObject muzzle;
    public float cooldownTime;
    float coolTimer = 0;

    public AudioSource soundSource;
    public AudioClip laserSound;


    private void Update()
    {

        //ChangeWeapons();
        if (coolTimer > 0)
        {
            coolTimer -= Time.deltaTime;
        }


        else if (coolTimer <= 0)
        {
            Shoot();
            coolTimer = cooldownTime;
        }

    }

    void Shoot()
    {
        ParticleSystem temp;
        //MuzzleFlash.Play();
        temp = Instantiate(laser[projectileSelected], muzzle.transform.position,
           muzzle.transform.rotation);
        soundSource.PlayOneShot(laserSound);

    }
}
