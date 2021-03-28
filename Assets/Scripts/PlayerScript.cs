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
    public int keyAmount;
    

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


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            GetKey();
            Destroy(other.gameObject);
        }
    }

    IEnumerator playerInvincibility()
    {
        isInvincibile = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincibile = false;
    }

    void GetKey()
    {
        KeyCollect.Instance.currentkeyAmount =
            KeyCollect.Instance.currentkeyAmount + KeyCollect.Instance.getKeyAmount;
    }
}
