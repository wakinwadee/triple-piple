using System;
using UnityEngine;
using System.Collections;



class Item : Equipment
{
    private ITEM_TYPE itemType;


    public override bool IsComposite()
    {
        return false;
    }
}
