using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{

    public int getKeyAmount = 1;
    public int currentkeyAmount = 0;
    /*
    public int currentkeyAmount
    {
        get
        {
            return _currentkeyAmount;
        }
        set
        {


            _currentkeyAmount = value;

        }
    }
    public static KeyCollect Instance;

    */
    // Start is called before the first frame update
    private void Start()
    {
        /*
        Instance = this;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }



}
