﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    public Text KeyDisplay;
    public Transform healthParent;
    public Transform healthIconPrefab;
    public PlayerScript player;

    private int healthDisplayed = 0;


    public KeyCollect collect;
    //public PlayerScript keyCollectConnect;

    // Start is called before the first frame update
    private void Start()
    {

        //KeyDisplay.text = KeyCollect.Instance.currentkeyAmount.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (healthDisplayed != player.HP)
        {
            healthDisplayed = player.HP;
            DisplayHealth();

        }

        KeyDisplay.text = collect.currentkeyAmount.ToString();
    }

    void DisplayHealth()
    {
        Transform[] spawnedCrosses = healthParent.GetComponentsInChildren<Transform>();

        for (int n = spawnedCrosses.Length-1; n>0; n--)
        {
            Destroy(spawnedCrosses[n].gameObject);
        }


        for (int i=0; i<healthDisplayed;i++)
        {
            Instantiate(healthIconPrefab, healthParent);
        }
    }
}
