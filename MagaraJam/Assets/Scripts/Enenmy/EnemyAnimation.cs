using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Animator _anim;
    void Awake()
    {
        _anim = GetComponent<Animator>();
       
    }
    private void Start()
    {

    }

    public void Attack()
    {
        _anim.SetTrigger(TagManager.ATTACK_PARAMETER);
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



































