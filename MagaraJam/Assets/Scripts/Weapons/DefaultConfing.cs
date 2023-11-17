using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeControlAttack
{
    Click,
    Hold
}

public enum TypeWeapon
{
    Melee,
    OneHand,
    TwoHand
}

[System.Serializable]
public struct DefaultConfing
{

    public TypeControlAttack TypeControl;
    public TypeWeapon TypeWeapon;

    [Range(0, 100)]
    public int Damage;

    [Range(0, 100)]
    public int CriticalDamage;

    [Range(0.01f, 1.0f)]
    public float FireRate;

    [Range(0, 100)]
    public int CriticalRate;

}
