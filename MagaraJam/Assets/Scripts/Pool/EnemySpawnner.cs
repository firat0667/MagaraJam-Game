using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform spawnPoint;

    private GameObject zombie;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;


        AudioManager.instance.ZombieRiseSound();

        zombie = Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity);

        if (zombie.transform.position.x < player.position.x)
        {

            zombie.transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (zombie.transform.position.x > player.position.x)
        {

            zombie.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        StartCoroutine(WaitDeactivate());

    }

    IEnumerator WaitDeactivate()
    {
        yield return new WaitForSeconds(Random.Range(2.5f, 4f));

        gameObject.SetActive(false);
    }

}
