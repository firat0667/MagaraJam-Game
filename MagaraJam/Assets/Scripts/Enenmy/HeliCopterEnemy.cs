using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCopterEnemy : MonoBehaviour
{
    public float fireCooldown = 2f; // Ateþ etme aralýðý
    private float nextFireTime = 0f;
    public GameObject bulletPrefab; // Ateþ objesinin prefabý
    public float firingDistance = 5f; // Ateþ etme mesafesi

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, PlayerInputController.Instance.transform.position);

        if (distanceToPlayer <= firingDistance && Time.time > nextFireTime)
        {
            FireAtPlayer();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void FireAtPlayer()
    {
        // Oyuncuya doðru ateþ et
        Vector2 directionToPlayer = PlayerInputController.Instance.transform.position - transform.position;
        directionToPlayer.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Mermi objesinin yönünü ayarla
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * 10f; // Ateþin hýzý

        Destroy(bullet, 2f); // Ateþ objesini belirli bir süre sonra yok et
    }
}
