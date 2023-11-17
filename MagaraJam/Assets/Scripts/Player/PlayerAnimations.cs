using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void PlayerRunAnimation(bool run)
    {
        _anim.SetBool(TagManager.RUN_PARAMETER, run);
    }

    public void AttackAnimation()
    {
        _anim.SetTrigger(TagManager.ATTACK_PARAMETER);
    }

    public void SwitchWeaponAnimation(int typeWeapon)
    {
        _anim.SetInteger(TagManager.TYPE_WEAPON_PARAMETER, typeWeapon);
        _anim.SetTrigger(TagManager.SWITCH_PARAMETER);
    }

    public void Hurt()
    {
        _anim.SetTrigger(TagManager.GET_HURT_PARAMETER);
    }

    public void Dead()
    {
        _anim.SetTrigger(TagManager.DEAD_PARAMETER);
    }

} // class






































