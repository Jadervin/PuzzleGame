using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueScript : MonoBehaviour
{
    public Animator tongueAnim;

    

    // Start is called before the first frame update
    void Start()
    {

        tongueAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            
            tongueAnim.SetBool("IsStretched", true);
            Debug.Log("Tongue Stretched");
        }
    }

    public void TongueStretchAttack()
    {
        

    }

    private void OnTriggerEnter(Collider collider)
    {
       
    }

}
