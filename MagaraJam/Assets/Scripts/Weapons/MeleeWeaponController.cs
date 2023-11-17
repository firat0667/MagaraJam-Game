using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : WeaponController
{
    public override void ProcessAttack()
    {
        //base.ProcessAttack();
        AudioManager.instance.MeleeAttackSound();
    }
}
