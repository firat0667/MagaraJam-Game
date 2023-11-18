using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Animasyon : MonoBehaviour
{
    private  Animator _anim;
     void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public  void jumpAnimation(bool jump)
    {          
        _anim.SetBool(TagManager.JUMP_ANIMATION, jump);             
    }
    public void TurnAnimation(bool turn)
    {
        _anim.SetBool(TagManager.TURN_ANIMATION, turn);
    }
}
