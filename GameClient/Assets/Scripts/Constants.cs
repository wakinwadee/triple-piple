using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    //tags
    public const string     HORIZONTAL      =    "Horizontal";
    public const string     PLAYER          =        "Player";
    public const string     VERTICAL        =      "Vertical";
    public const string     OBSTRUCTION     =   "Obstruction";
    public const string     ENEMY           =         "Enemy";

    //equipmet types
    public const string     EQUIPMENT_WEAPON    =   "Equipment_weapon";
    public const string     EQUIPMENT_ARMOR     =    "Equipment_armor";
    public const string     EQUIPMENT_ITEM      =     "Equipment_item";

    //player points
    public const string     R_WEAPON_POINT      =       "WeaponPointR";
    public const string     L_WEAPON_POINT      =       "WeaponPointL";
    public const string     RAYCAST_SPOT        =        "RaycastSpot";

}


public enum WEAPON_TYPE
{
    PISTOL      = 0,
    RIFLE       = 1,
    SHOTGUN     = 2
}

public enum ITEM_TYPE
{
    GRENADE     = 0,
    SHIELD      = 1,
    AID_KIT     = 2
}

public enum ARMOR_TYPE
{
    LIGHT       = 0,
    MEDIUM      = 1,
    HEAVY       = 2
}


public enum FIRING_MODE
{
    FULL_AUTO   = 0,
    SEMI_AUTO   = 1,
    SINGLE      = 2
}