using System;
using UnityEngine;
using System.Collections;


class Armor : Equipment
{
    public ARMOR_TYPE armorTier;


    public override bool IsComposite()
    {
        return false;
    }
}
