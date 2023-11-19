using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmartPool : MonoBehaviour
{
    public static SmartPool instance;

    [Header("List")]
    private List<GameObject> _bullet_Fall_Fx = new List<GameObject>();
    private List<GameObject> _bullet_Prefabs = new List<GameObject>();
    private List<GameObject> _rocket_Bullet_Prefabs = new List<GameObject>();

    [Header("Elements")]
    public GameObject[] Enemies;
    public GameObject[] FlyingEnemies;
  [SerializeField]  private float _y_Spawn_Pos_Min = 0, y_Spawn_Pos_Max = 2f;
  [SerializeField]  private float _groundYpos;
    private Camera _mainCamera;

    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        _mainCamera = Camera.main;

        InvokeRepeating("StartSpawningEnemies", 3f, Random.Range(1f, 5f));

    }

    void OnDisable()
    {
        instance = null;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CreateBulletAndBulletFall(GameObject bullet, GameObject bulletFall, int count)
    {

        for (int i = 0; i < count; i++)
        {

            GameObject temp_Bullet = Instantiate(bullet);
            GameObject temp_Bullet_Fall = Instantiate(bulletFall);

            _bullet_Prefabs.Add(temp_Bullet);
            _bullet_Fall_Fx.Add(temp_Bullet_Fall);

            _bullet_Prefabs[i].SetActive(false);
            _bullet_Fall_Fx[i].SetActive(false);

        }

    } // create bullet and bullet fall

    public void CreateRocket(GameObject rocket, int count)
    {

        for (int i = 0; i < count; i++)
        {

            GameObject temp_Rocket_Bullet = Instantiate(rocket);

            _rocket_Bullet_Prefabs.Add(temp_Rocket_Bullet);

            _rocket_Bullet_Prefabs[i].SetActive(false);

        }

    } // create rocket

    public GameObject SpawnBulletFallFX(Vector3 position, Quaternion rotation)
    {

        for (int i = 0; i < _bullet_Fall_Fx.Count; i++)
        {

            if (!_bullet_Fall_Fx[i].activeInHierarchy)
            {

                _bullet_Fall_Fx[i].SetActive(true);
                _bullet_Fall_Fx[i].transform.position = position;
                _bullet_Fall_Fx[i].transform.rotation = rotation;

                return _bullet_Fall_Fx[i];

            }

        }

        return null;

    } // spawn bullet fall fx

    public void SpawnBullet(Vector3 position, Vector3 direction, Quaternion rotation,
                            NameWeapon weaponName)
    {


        if (weaponName != NameWeapon.ROCKET)
        {

            for (int i = 0; i < _bullet_Prefabs.Count; i++)
            {

                if (!_bullet_Prefabs[i].activeInHierarchy)
                {

                    _bullet_Prefabs[i].SetActive(true);
                    _bullet_Prefabs[i].transform.position = position;
                    _bullet_Prefabs[i].transform.rotation = rotation;

                    // GET THE BULLET SCRIPT
                    _bullet_Prefabs[i].GetComponent<BulletController>().SetDirection(direction);

                    // SET BULLET DAMAGE
                    SetBulletDamage(weaponName, _bullet_Prefabs[i]);

                    break;
                }

            }

        }
        else
        {

            for (int i = 0; i < _rocket_Bullet_Prefabs.Count; i++)
            {

                if (!_rocket_Bullet_Prefabs[i].activeInHierarchy)
                {


                    _rocket_Bullet_Prefabs[i].SetActive(true);
                    _rocket_Bullet_Prefabs[i].transform.position = position;
                    _rocket_Bullet_Prefabs[i].transform.rotation = rotation;


                    // GET THE BULLET SCRIPT
                    _rocket_Bullet_Prefabs[i].GetComponent<BulletController>().SetDirection(direction);

                    // SET BULLET DAMAGE
                    SetBulletDamage(weaponName, _rocket_Bullet_Prefabs[i]);

                    break;

                }

            }

        }


    }

    void SetBulletDamage(NameWeapon weaponName, GameObject bullet)
    {

        switch (weaponName)
        {

            case NameWeapon.PISTOL:
                bullet.GetComponent<BulletController>().Damage = 2;
                break;

            case NameWeapon.MP5:
                bullet.GetComponent<BulletController>().Damage = 3;
                break;

            case NameWeapon.M3:
                bullet.GetComponent<BulletController>().Damage = 4;
                break;

            case NameWeapon.AK:
                bullet.GetComponent<BulletController>().Damage = 5;
                break;

            case NameWeapon.AWP:
                bullet.GetComponent<BulletController>().Damage = 10;
                break;

            case NameWeapon.ROCKET:
                bullet.GetComponent<BulletController>().Damage = 10;
                break;

        }

    }

    void StartSpawningEnemies()
    {

        if (GameplayController.instance.gameGoal == GameGoal.DEFEND_FENCE)
        {

            float xPos = _mainCamera.transform.position.x;
            xPos += 15f;

            float a = Random.Range(0,4);
            if (a == 0)
            {
                float flyingPos = Random.Range(_y_Spawn_Pos_Min, y_Spawn_Pos_Max);
                Instantiate(FlyingEnemies[Random.Range(0, Enemies.Length)],
                new Vector3(xPos, flyingPos, 0f), Quaternion.identity);
            }
            else
            {
                float groundpos = _groundYpos;
                Instantiate(Enemies[Random.Range(0, Enemies.Length)],
                new Vector3(xPos, groundpos, 0f), Quaternion.identity);
            }
        }

        if (GameplayController.instance.gameGoal == GameGoal.KILL_ENEMY ||
           GameplayController.instance.gameGoal == GameGoal.TIMER_COUNTDOWN ||
           GameplayController.instance.gameGoal == GameGoal.WALK_TO_GOAL_STEPS)
        {

            float xPos = _mainCamera.transform.position.x;

            if (Random.Range(0, 2) > 0)
            {
                xPos += Random.Range(10f, 15f);
            }
            else
            {
                xPos -= Random.Range(10f, 15f);
            }

            float yPos = Random.Range(_y_Spawn_Pos_Min, y_Spawn_Pos_Max);

            Instantiate(Enemies[Random.Range(0, Enemies.Length)],
                        new Vector3(xPos, yPos, 0f), Quaternion.identity);

        }

        if (GameplayController.instance.gameGoal == GameGoal.GAME_OVER)
        {
            CancelInvoke("StartSpawningZombies");
        }

    }

} // class
