using System;
using UnityEngine;
using System.Collections;


public class IngameInventory
{
    public Equipment ingameWeapon;
    public Equipment ingameArmor;
    public Equipment ingameItem;

    public IngameInventory()
    {
        LoadPlayerSetupByDeafult();
    }


    private void LoadPlayerSetupByDeafult()
    {
        ingameArmor = new Armor();
        ingameWeapon = new Weapon();
        ingameItem = new Item();
        Debug.LogWarning("Default inventory setup was loaded");
    }


}

