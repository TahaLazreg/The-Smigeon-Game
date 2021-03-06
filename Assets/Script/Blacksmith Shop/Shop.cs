﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject player;
    private float money;
    private Text SwordType;
    private string currentText;
    private DataBaseSmi db;
    public GameObject[] button;
    public List<Items> listItem;
    // Start is called before the first frame update
    void Start()
    {
        SwordType = GameObject.Find("Sword Stats").GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player");
        money = player.GetComponent<Player>().stats.getGold();


        db = new DataBaseSmi();
        //Set the shop scene to be active
        //GameObject.Find("BlacksmithShop").SetActive(true);


        button = GameObject.FindGameObjectsWithTag("Button");


        listItem = db.getAllMaterials();
        foreach (Items item in listItem)//Assign the name, price and damage to the button
        {
            button[item.id - 1].GetComponentInChildren<Text>().text = item.name + " " + item.price + "gp  +" + item.damage_defense;
        }

        SwordType.text = db.getItemName(player.GetComponent<Player>().equipement.getWeapon(), "material"); //Show the name of the current sword
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        /* when the player press escape
         the shop camera is disabled, the UI scene is loaded, the shop is unloaded
         and the main Scene is activated*/
        {

            GameObject.Find("BlacksmithShop").SetActive(false);
            
        }

    }

}
