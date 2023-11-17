using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private WeaponManager _weaponManager;

    [HideInInspector]
    public bool canShoot;

    private bool isHoldAttack;

    void Awake()
    {
        _weaponManager = GetComponent<WeaponManager>();
        canShoot = true;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _weaponManager.SwitchWeapon();
        }

        if (Input.GetMouseButtonDown(0))
        {

            isHoldAttack = true;

        }
        else
        {

            _weaponManager.ResetAttack();
            isHoldAttack = false;
        }

        if (isHoldAttack && canShoot)
        {
            _weaponManager.Attack();
        }

    }
}
