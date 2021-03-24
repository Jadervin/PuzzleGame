using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Transform player;
    public bool isParented = false;
    Vector3 lastPlayerPosition;
    Transform originalParent;

    private void Start()
    {
        originalParent = transform.parent;
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
                transform.SetParent(originalParent);
            }


            lastPlayerPosition = player.position;
        }
    }

    //The player must have a triger around them. Make sure its big enough so the 
    //skin width of the character controller doesnt interfere.
    private void OnTriggerEnter(Collider collider)
    {
        if (!isParented && collider.CompareTag("Player"))
        {
            player = collider.transform;
            transform.SetParent(player);
            isParented = true;
            lastPlayerPosition = player.position;
        }
    }
}