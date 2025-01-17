﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Transform player;
    public bool isParented = false;
    Vector3 lastPlayerPosition;
    Transform originalParent;

    public Transform tongue;
    public bool isTongueParented = false;
    Vector3 lastTonguePosition;
    Transform originalTongueParent;

    public AudioSource soundSource;
    public AudioClip pushingSound;

    //public Animator buttonAnim;
    public Rigidbody rb;

    private void Start()
    {
        originalParent = transform.parent;
        
        //buttonAnim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (isParented)
        {
            
            Vector3 movementVec = player.position - lastPlayerPosition;
            Vector3 directionVec = transform.position - player.position;

            if (movementVec.x * directionVec.x < 0
                || movementVec.z * directionVec.z < 0)
            {
                isParented = false;
                rb.isKinematic = false;
                transform.SetParent(originalParent);
            }


            lastPlayerPosition = player.position;
        }

        if (isTongueParented)
        {
            //transform.LookAt(tongue, Vector3.left);

            
            //Vector3 movementVec = tongue.position - lastTonguePosition;
            //Vector3 directionVec = transform.position - tongue.position;
            /*
            if (movementVec.x * directionVec.x < 0
                || movementVec.z * directionVec.z < 0)
            {
                isTongueParented = false;
                transform.SetParent(originalParent);
            }
            */

            lastTonguePosition = tongue.position;
        }
        

    }

    //The player must have a triger around them. Make sure its big enough so the 
    //skin width of the character controller doesnt interfere.
    private void OnTriggerEnter(Collider collider)
    {
        if (!isParented && collider.CompareTag("Player"))
        {
            soundSource.PlayOneShot(pushingSound);
            player = collider.transform;
            transform.SetParent(player);
            isParented = true;
            rb.isKinematic = true;
            lastPlayerPosition = player.position;
        }

       if (!isTongueParented&& collider.CompareTag("Tongue"))
        {
            soundSource.PlayOneShot(pushingSound);
            tongue = collider.transform;
            transform.SetParent(tongue);
            isTongueParented = true;
            rb.isKinematic = true;
            lastTonguePosition = tongue.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isTongueParented && other.CompareTag("Tongue"))
        {

            isTongueParented = false;
            rb.isKinematic = false;
            transform.SetParent(originalParent);
            
            lastTonguePosition = tongue.position;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
    }
}