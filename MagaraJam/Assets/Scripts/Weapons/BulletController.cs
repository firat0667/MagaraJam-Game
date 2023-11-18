using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [HideInInspector]
    public int Damage;
    [Header("Settings")]
    private float _speed = 60f;
    [Header("Elements")]
    private WaitForSeconds _wait_For_Time_Alive = new WaitForSeconds(2f);
    private IEnumerator IcoroutineDeactivate;

    private Vector3 _direction;

    public GameObject rocket_Explosion;

    void Start()
    {
        if (this.tag == TagManager.ROCKET_MISSILE_TAG)
        {
            _speed = 8f;
        }
    }

    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        if(PlayerInputController.Instance.transform.position.x+15<gameObject.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }


    void OnEnable()
    {
        IcoroutineDeactivate = WaitForDeactivate();
        StartCoroutine(IcoroutineDeactivate);
    }

    void OnDisable()
    {
        if (IcoroutineDeactivate != null)
        {
            StopCoroutine(IcoroutineDeactivate);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        _direction = dir;
    }

    IEnumerator WaitForDeactivate()
    {
        yield return _wait_For_Time_Alive;
        gameObject.SetActive(false);
    }

    public void ExplosionFX()
    {
        AudioManager.instance.FenceExplosion();
        Instantiate(rocket_Explosion, transform.position, Quaternion.identity);
    }

} // class
