using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{

    public Sprite one_Hand_Sprite, two_Hand_Sprite;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeToOneHand()
    {
        sr.sprite = one_Hand_Sprite;
    }

    public void ChangeToTwoHand()
    {
        sr.sprite = two_Hand_Sprite;
    }


} // class