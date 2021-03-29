using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserCollision : MonoBehaviour
{
    //public ParticleSystem laser;
    public string youLose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject collision)
    {
        //Debug.Log("Touched Player");
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("Touched Player");
            Destroy(collision.gameObject);
            //Instantiate(gitsEffect, transform.position, Quaternion.identity);
            SceneManager.LoadScene(youLose);

        }

        if (collision.gameObject.tag == "blue crate")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "red crate")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "green crate")
        {
            Destroy(this.gameObject);
        }

    }


    
}
