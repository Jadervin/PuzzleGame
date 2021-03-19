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
    new private void Start()
    {
        base.Start();
       
    }

    private void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="crate")
        {
            this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);

        }



    }

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
