using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Animator buttonAnim;

    public ParticleSystem spawn;
    public Transform spawnPosition;
    public GameObject keyPrefab;

    public AudioSource soundSource;
    public AudioClip buttonPress;
    public bool isSpawned=false;

    // Start is called before the first frame update
    void Start()
    {
        buttonAnim = GetComponent<Animator>();
        Debug.Log("Found Animator");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*
    private void OnTriggerEnter(Collider collider)
    {
       
        if (collider.CompareTag("Crate"))
        {
            buttonAnim.SetBool("ButtonPress", true);
            Debug.Log("Animation Bool Play");


            //buttonAnim.SetTrigger("Press");
            //Debug.Log("Animation Trigger Play");

        }
    }
   */

   
    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Something");
        if (collision.gameObject.tag=="blue crate")
        {
            Debug.Log("Blue Crate");
            if (this.gameObject.tag=="blue button"&&isSpawned==false)
            {
                Debug.Log("Press");
                soundSource.PlayOneShot(buttonPress);
                buttonAnim.SetBool("ButtonPress", true);
                Debug.Log("Animation Bool Play");
                isSpawned = true;
                Instantiate(spawn, spawnPosition.transform.position, spawn.transform.rotation);
                GameObject temp =
                    Instantiate(keyPrefab, spawnPosition.position, keyPrefab.transform.rotation);

            }

            //buttonAnim.SetTrigger("Press");
           //Debug.Log("Animation Trigger Play");

        }

        if (collision.gameObject.tag == "red crate")
        {
            if (this.gameObject.tag == "red button" && isSpawned == false)
            {
                soundSource.PlayOneShot(buttonPress);
                buttonAnim.SetBool("ButtonPress", true);
                Debug.Log("Animation Bool Play");
                isSpawned = true;
                Instantiate(spawn, spawnPosition.transform.position, spawn.transform.rotation);
                Destroy(spawnPosition);
                GameObject temp =
                    Instantiate(keyPrefab, spawnPosition.position, keyPrefab.transform.rotation);
            }

            //buttonAnim.SetTrigger("Press");
            //Debug.Log("Animation Trigger Play");

        }

        if (collision.gameObject.tag == "green crate")
        {
            if (this.gameObject.tag == "green button" && isSpawned == false)
            {
                soundSource.PlayOneShot(buttonPress);
                buttonAnim.SetBool("ButtonPress", true);
                Debug.Log("Animation Bool Play");
                isSpawned = true;
                Instantiate(spawn, spawnPosition.transform.position, spawn.transform.rotation);
                GameObject temp =
                    Instantiate(keyPrefab, spawnPosition.position, keyPrefab.transform.rotation);
            }

            //buttonAnim.SetTrigger("Press");
            //Debug.Log("Animation Trigger Play");

        }
    }
    

}
