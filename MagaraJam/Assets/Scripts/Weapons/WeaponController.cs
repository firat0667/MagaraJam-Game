using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NameWeapon
{
    MELEE,
    PISTOL,
    MP5,
    M3,
    AK,
    AWP,
    FIRE,
    ROCKET
}

public class WeaponController : MonoBehaviour
{
    [Header("Elements")]
    public DefaultConfing DefaultConfing;
    public NameWeapon NameWp;

    protected PlayerAnimations playerAnim;
    protected float lastShot;
    [Header("Settings")]
    public int GunIndex;
    public int CurrentBullet;
    public int BulletMax;

    void Awake()
    {
        playerAnim = GetComponentInParent<PlayerAnimations>();
        CurrentBullet = BulletMax;
    }

    public void CallAttack()
    {

        if (Time.time > lastShot + DefaultConfing.FireRate)
        {

            if (CurrentBullet > 0)
            {

                ProcessAttack();

                // animate shoot player attack anim
               playerAnim.AttackAnimation();


                lastShot = Time.time;
                CurrentBullet--;

            }
            else
            {
                // PLAY NO AMMO SOUND
            }

        }

    } // call attack

    public virtual void ProcessAttack() { }

} // class
