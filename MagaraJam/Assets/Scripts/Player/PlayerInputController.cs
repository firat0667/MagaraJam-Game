using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private WeaponManager _weaponManager;

    [HideInInspector]
    public bool canShoot;

    private bool isHoldAttack;
    public static PlayerInputController Instance;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        _weaponManager = GetComponent<WeaponManager>();
        canShoot = true;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _weaponManager.SwitchWeapon();
        }

        if (Input.GetMouseButton(0))
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
