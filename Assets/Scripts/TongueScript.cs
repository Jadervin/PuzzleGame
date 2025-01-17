﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueScript : MonoBehaviour
{
    public Animator tongueAnim;
    public AudioSource soundSource;
    public AudioClip tongueStretchSound;
    public AudioClip tongueDestretchSound;

    // Start is called before the first frame update
    void Start()
    {

        tongueAnim = GetComponent<Animator>();
        Debug.Log("Found Animator");

    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            soundSource.PlayOneShot(tongueStretchSound);
            tongueAnim.SetBool("IsStretched", true);
            Debug.Log("Tongue Stretched");
        }

        
        else if (Input.GetKeyDown("tab"))
        {
            soundSource.PlayOneShot(tongueDestretchSound);
            tongueAnim.SetBool("IsStretched", false);
            Debug.Log("Tongue De-Stretched");
        }
        
    }

    public void TongueStretchAttack()
    {
        

    }

    private void OnTriggerEnter(Collider collider)
    {
       
    }

}
