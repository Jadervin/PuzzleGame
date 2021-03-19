using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : EntityScript
{
    public GameObject particle;
    
    //public string hurtingTag= "Enemy";
    public float invincibilityTime = 3;
    bool isInvincibile = false;
    new private void Start()
    {
        base.Start();
       
    }

    private void Update()
    {
        ChangeWeapons();
    }


    void ChangeWeapons()
    {
        float dir = Input.GetAxis("Mouse ScrollWheel");
        

        if (dir > 0)
        {
            


        }
        else if (dir < 0)
        {
            

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
