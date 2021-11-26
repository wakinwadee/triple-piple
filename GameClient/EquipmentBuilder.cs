using System;
using UnityEngine;
using System.Collections;


public class EquipmentBuilder
{
    private Equipment processedEquipment;


    public void Reset()
    {
        processedEquipment = new Equipment();
    }

    public void SetEquipmentType(string type)
    {
        processedEquipment
    }


    public Equipment GetResult()
    {
        try
        {
            return processedEquipment;
        }
        catch(Exception e)
        {
            Debug.Log("Equipment object unable to be returned, default returned instead");
            Debug.LogException(e);
            return new Equipment();
        }
    }
}
