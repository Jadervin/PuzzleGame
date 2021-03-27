using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Animator buttonAnim;

    // Start is called before the first frame update
    void Start()
    {
        buttonAnim = GetComponent<Animator>();
        
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
        if (collision.gameObject.tag=="Crate")
        {

            buttonAnim.SetBool("ButtonPress", true);
            Debug.Log("Animation Bool Play");

            //buttonAnim.SetTrigger("Press");
           //Debug.Log("Animation Trigger Play");
        }
    }
    

}
