using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityScript : MonoBehaviour
{
    public int MaxHealth;
    public int HP;

    public float speed;


    protected void Start()
    {
        HP = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(uint dmg)
    {
        HP = HP - (int)dmg;
        //HP = Mathf.Clamp(HP - (int)dmg, 0, MaxHealth);

        

    }


}
