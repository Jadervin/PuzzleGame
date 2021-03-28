using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : EntityScript
{
    //public GameObject particle;
    public float force = 3;

    //public string hurtingTag= "Enemy";
    public float invincibilityTime = 3;
    bool isInvincibile = false;
    public int keyAmount;
    

    public Vector3 lastPosition;


    public KeyCollect collect;

    public GameObject door;
    public string youWin;

    new private void Start()
    {
        base.Start();
       
    }

    private void Update()
    {
        if (collect.currentkeyAmount==3)
        {
            Destroy(door);
        }
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

        if (other.CompareTag("Win"))
        {
            SceneManager.LoadScene(youWin);
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
        collect.currentkeyAmount =
            collect.currentkeyAmount + collect.getKeyAmount;
    }
}
