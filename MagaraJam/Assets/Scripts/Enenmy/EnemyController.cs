using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyMovement _enemy_Movement;
    private EnemyAnimation _enemy_Animation;

    private Transform targetTransform;
    private bool canAttack;
    private bool _enemy_Alive;

    public GameObject damage_Collider;

    public int EnemyHealth = 10;
    public GameObject fxDead;

    private float _timerAttack;

    private int _fireDamage = 10;

    public GameObject coinCollectable;

    // Use this for initialization
    void Start()
    {

        _enemy_Movement = GetComponent<EnemyMovement>();
        _enemy_Animation = GetComponent<EnemyAnimation>();

        _enemy_Alive = true;

        if (GameplayController.instance.EnemyGoal == EnemyGoal.PLAYER)
        {
            targetTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;

        }
        else if (GameplayController.instance.EnemyGoal == EnemyGoal.FENCE)
        {

            GameObject[] fences = GameObject.FindGameObjectsWithTag(TagManager.FENCE_TAG);

            targetTransform = fences[Random.Range(0, fences.Length)].transform;

        }

    }

    void Update()
    {
        if (_enemy_Alive)
        {
            CheckDistance();
        }
    }

    void CheckDistance()
    {

        if (targetTransform)
        {

            if (Vector3.Distance(targetTransform.position, transform.position) > 1.5f)
            {

                _enemy_Movement.Move(targetTransform);

            }
            else
            {

                if (canAttack)
                {

                    _enemy_Animation.Attack();

                    _timerAttack += Time.deltaTime;

                    if (_timerAttack > 0.45f)
                    {
                        _timerAttack = 0f;
                        AudioManager.instance.ZombieAttackSound();
                    }

                }

            }

        }

    }

    public void ActivateDeadEffect()
    {
        Instantiate(fxDead,transform.position,Quaternion.identity);

    }

    IEnumerator DeactivateZombie()
    {
        ActivateDeadEffect();
        AudioManager.instance.ZombieDieSound();

        yield return new WaitForSeconds(1f);

        GameplayController.instance.ZombieDied();

        if (Random.Range(0, 10) > 6)
        {
            Instantiate(coinCollectable, transform.position, Quaternion.identity);
        }

        gameObject.SetActive(false);
    }

    public void DealDamage(int damage)
    {
        _enemy_Animation.Hurt();

        EnemyHealth -= damage;

        if (EnemyHealth <= 0)
        {

            _enemy_Alive = false;
            _enemy_Animation.Dead();

            StartCoroutine(DeactivateZombie());
        }

    }

    void ActivateDamagePoint()
    {
        damage_Collider.SetActive(true);
    }

    void DeactivateDamagePoint()
    {
        damage_Collider.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == TagManager.PLAYER_HEALTH_TAG || target.tag == TagManager.PLAYER_TAG
           || target.tag == TagManager.FENCE_TAG)
        {

            canAttack = true;

        }

        if (target.tag == TagManager.BULLET_TAG || target.tag == TagManager.ROCKET_MISSILE_TAG)
        {

            _enemy_Animation.Hurt();

            EnemyHealth -= target.gameObject.GetComponent<BulletController>().Damage;
           
            if (target.tag == TagManager.ROCKET_MISSILE_TAG)
            {
                target.gameObject.GetComponent<BulletController>().ExplosionFX();
            }

            if (EnemyHealth <= 0)
            {

                _enemy_Alive = false;
                _enemy_Animation.Dead();

                StartCoroutine(DeactivateZombie());

            }

            target.gameObject.SetActive(false);

        }

        if (target.tag == TagManager.FIRE_BULLET_TAG)
        {

            _enemy_Animation.Hurt();

            EnemyHealth -= _fireDamage;

            if (EnemyHealth <= 0)
            {
                _enemy_Alive = false;
                _enemy_Animation.Dead();

                StartCoroutine(DeactivateZombie());
            }

        }

    }

    void OnTriggerExit2D(Collider2D target)
    {

        if (target.tag == TagManager.PLAYER_HEALTH_TAG || target.tag == TagManager.PLAYER_TAG
           || target.tag == TagManager.FENCE_TAG)
        {

            canAttack = false;

        }

    }

}
