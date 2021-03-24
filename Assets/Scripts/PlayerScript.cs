using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : EntityScript
{
    //public GameObject particle;
    public float force = 3;

    //public string hurtingTag= "Enemy";
    public float invincibilityTime = 3;
    bool isInvincibile = false;

    public GameObject cratePrefabChild;
    public Transform playerParent;

    public Vector3 lastPosition;

    new private void Start()
    {
        base.Start();
       
    }

    private void LateUpdate()
    {
        lastPosition = transform.position;
    }


   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Crate")
        {

            
            //this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);

        }



    }

    /*
     public void BoxPush(Transform newParent)
     {
        
        cratePrefabChild.transform.SetParent(newParent);
        
       
        cratePrefabChild.transform.SetParent(newParent, false);

       
        cratePrefabChild.transform.SetParent(null);
     }
    */
    private void OnTriggerEnter(Collider other)
    {
        
    }

    IEnumerator playerInvincibility()
    {
        isInvincibile = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincibile = false;
    }
}
