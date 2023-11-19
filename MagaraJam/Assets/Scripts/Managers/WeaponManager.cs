using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Elements")]
    public List<WeaponController> Weapons_Unlocked;
    public WeaponController[] Total_Weapons;

   // [HideInInspector]
    public WeaponController current_Weapon;

    private int _current_Weapon_Index;

    private TypeControlAttack _current_Type_Control;

    private PlayerArmController[] _armController;

    private PlayerAnimations playerAnim;

    private bool _isShooting;

    public GameObject MeleeDamagePoint;
    public static WeaponManager instance;
    
    void Awake()
    {
         playerAnim = GetComponent<PlayerAnimations>();

        LoadActiveWeapons();

        _current_Weapon_Index = 0;
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        _armController = GetComponentsInChildren<PlayerArmController>();

        // set the first weapon to be pistol
        ChangeWeapon(Weapons_Unlocked[0]);

        playerAnim.SwitchWeaponAnimation(
         (int)Weapons_Unlocked[_current_Weapon_Index].DefaultConfing.TypeWeapon
        );

    }

    void LoadActiveWeapons()
    {
        Weapons_Unlocked.Add(Total_Weapons[0]);
    }

    public void SwitchWeapon()
    {
        _current_Weapon_Index++;

        _current_Weapon_Index =
            (_current_Weapon_Index >= Weapons_Unlocked.Count) ? 0 : _current_Weapon_Index;

       playerAnim.SwitchWeaponAnimation(
           (int)Weapons_Unlocked[_current_Weapon_Index].DefaultConfing.TypeWeapon
        );

        ChangeWeapon(Weapons_Unlocked[_current_Weapon_Index]);

    }

    void ChangeWeapon(WeaponController newWeapon)
    {

        if (current_Weapon)
            current_Weapon.gameObject.SetActive(false);

        current_Weapon = newWeapon;
        _current_Type_Control = newWeapon.DefaultConfing.TypeControl;

        newWeapon.gameObject.SetActive(true);

        if (newWeapon.DefaultConfing.TypeWeapon == TypeWeapon.TwoHand)
        {

            for (int i = 0; i < _armController.Length; i++)
            {
                _armController[i].ChangeToTwoHand();
            }

        }
        else
        {

            for (int i = 0; i < _armController.Length; i++)
            {
                _armController[i].ChangeToOneHand();
            }
        }

    }

    public void Attack()
    {

        if (_current_Type_Control == TypeControlAttack.Hold)
        {

            current_Weapon.CallAttack();

        }
        else if (_current_Type_Control == TypeControlAttack.Click)
        {

            if (!_isShooting)
            {

                current_Weapon.CallAttack();
                _isShooting = true;

            }

        }

    }

    public void ResetAttack()
    {
        _isShooting = false;
    }

    void AllowCollisionDetection()
    {
        MeleeDamagePoint.SetActive(true);
    }

    void DenyCollisionDetection()
    {
        MeleeDamagePoint.SetActive(false);
    }
}
