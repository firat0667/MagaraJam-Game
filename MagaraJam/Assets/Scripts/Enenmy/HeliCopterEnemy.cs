using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeliCopterEnemy : MonoBehaviour
{
    public float fireCooldown = 2f; // Ate� etme aral���
    private float nextFireTime = 0f;
    public GameObject bulletPrefab; // Ate� objesinin prefab�
    public GameObject BombPrefab;
    public float firingDistance = 5f; // Ate� etme mesafesi
    public bool IsF16;
    public bool Zombie;
    public Transform BulletPos;
    private bool _isbombed;
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, PlayerInputController.Instance.transform.position);

        if (distanceToPlayer <= firingDistance && Time.time > nextFireTime&& PlayerInputController.Instance.transform.position.x<gameObject.transform.position.x)
        {
            if (!Zombie)
            {
                FireAtPlayer();
                nextFireTime = Time.time + fireCooldown;
            }
            else if(Zombie)
            {
                ZombieFireAtPlayer();
                nextFireTime = Time.time + fireCooldown;
            }
          
        }
        if(IsF16)
        {
            if (!_isbombed&&distanceToPlayer<=8f)
            {
               BombAtPlayer();
               _isbombed = true;
            }
        }
    }

    void FireAtPlayer()
    {
        // Oyuncuya do�ru ate� et
        Vector2 directionToPlayer = PlayerInputController.Instance.transform.position - transform.position;
        directionToPlayer.Normalize();



        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        // Mermi objesinin y�n�n� ayarla
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * 10f; // Ate�in h�z�

        Destroy(bullet, 2f); // Ate� objesini belirli bir s�re sonra yok et
    }
    void ZombieFireAtPlayer()
    {
        // Oyuncuya do�ru ate� et
        Vector2 directionToPlayer = PlayerInputController.Instance.transform.position - transform.position;
        directionToPlayer.Normalize();



        GameObject bullet = Instantiate(bulletPrefab, BulletPos.position, Quaternion.identity);
        // Mermi objesinin y�n�n� ayarla
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * 10f; // Ate�in h�z�

        Destroy(bullet, 2f); // Ate� objesini belirli bir s�re sonra yok et
    }
    void BombAtPlayer()
    {
        // Oyuncuya do�ru ate� et
        Vector2 directionToPlayer = PlayerInputController.Instance.transform.position - transform.position;
        directionToPlayer.Normalize();

        GameObject bullet = Instantiate(BombPrefab, transform.position, Quaternion.identity);

        // Mermi objesinin y�n�n� ayarla
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * 10f; // Ate�in h�z�

        Destroy(bullet, 2f); // Ate� objesini belirli bir s�re sonra yok et
    }
}
