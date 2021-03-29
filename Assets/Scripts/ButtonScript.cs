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

   
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="blue crate")
        {
            if (this.gameObject.tag=="blue button")
            {

                soundSource.PlayOneShot(buttonPress);
                buttonAnim.SetBool("ButtonPress", true);
                Debug.Log("Animation Bool Play");

                Instantiate(spawn, spawnPosition.transform.position, spawn.transform.rotation);
                GameObject temp =
                    Instantiate(keyPrefab, spawnPosition.position, keyPrefab.transform.rotation);
            }

            //buttonAnim.SetTrigger("Press");
           //Debug.Log("Animation Trigger Play");

        }

        if (collision.gameObject.tag == "red crate")
        {
            if (this.gameObject.tag == "red button")
            {
                soundSource.PlayOneShot(buttonPress);
                buttonAnim.SetBool("ButtonPress", true);
                Debug.Log("Animation Bool Play");

                Instantiate(spawn, spawnPosition.transform.position, spawn.transform.rotation);
                GameObject temp =
                    Instantiate(keyPrefab, spawnPosition.position, keyPrefab.transform.rotation);
            }

            //buttonAnim.SetTrigger("Press");
            //Debug.Log("Animation Trigger Play");

        }

        if (collision.gameObject.tag == "green crate")
        {
            if (this.gameObject.tag == "green button")
            {
                soundSource.PlayOneShot(buttonPress);
                buttonAnim.SetBool("ButtonPress", true);
                Debug.Log("Animation Bool Play");

                Instantiate(spawn, spawnPosition.transform.position, spawn.transform.rotation);
                GameObject temp =
                    Instantiate(keyPrefab, spawnPosition.position, keyPrefab.transform.rotation);
            }

            //buttonAnim.SetTrigger("Press");
            //Debug.Log("Animation Trigger Play");

        }
    }
    

}
