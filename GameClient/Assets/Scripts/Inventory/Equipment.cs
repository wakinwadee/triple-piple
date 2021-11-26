using System;
using UnityEngine;
using System.Collections;



//Base type for every inventory entity
public abstract class Equipment : MonoBehaviour
{
    public Equipment() { }


    //Make possible to add modifiers to any inventory item
    public virtual void Add(Equipment equipment)
    {
        throw new NotImplementedException();
    }


    //Make possible to remove modifiers to any inventory item
    public virtual void Remove(Equipment equipment)
    {
        throw new NotImplementedException();
    }


    //Activate the action that the equipment has
    public virtual void Action(GameObject palyerObject)
    {
        throw new NotImplementedException();
    }


    public virtual bool IsComposite()
    {
        return true;
    }
}
