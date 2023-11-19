using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
using UnityEngine.Playables;

public class bossMovement : MonoBehaviour
{
    [SerializeField] GameObject Lazer;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Wall;
    [SerializeField] Transform pos;
    [SerializeField] Transform pos2;
    [SerializeField] GameObject pos3;
    [SerializeField] Transform wallPos;
    [SerializeField] Animasyon animasyon;
    public float hiz;
    private bool isLaserShoted = false;
    [SerializeField] PlayableDirector pd;
    void Start()
    {
     StartCoroutine(BossMove());    
    }
    IEnumerator BossMove()
    {
        yield return new WaitForSeconds(2f);
        GameObject laser = Instantiate(Lazer, pos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(laser);
        yield return new WaitForSeconds(2f);
        GameObject lager = Instantiate(Lazer, pos2.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(lager);
        yield return new WaitForSeconds(2f);
        animasyon.jumpAnimation(true);
        Boss.transform.position = Vector3.MoveTowards(Boss.transform.position, pos3.transform.position, hiz);
        yield return new WaitForSeconds(1f);
        GameObject wal = Instantiate(Wall, wallPos.position, Quaternion.identity);
        animasyon.jumpAnimation(false);
        yield return new WaitForSeconds(2f);
        GameObject laxer = Instantiate(Lazer, pos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(laxer);
        GameObject lacer = Instantiate(Lazer, pos2.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(wal);
        Destroy(lacer);
        yield return new WaitForSeconds(2f);
        GameObject laeer = Instantiate(Lazer, pos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(laeer);
        GameObject larer = Instantiate(Lazer, pos2.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(larer);
        GameObject laver = Instantiate(Lazer, pos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(laver);
        GameObject laber = Instantiate(Lazer, pos2.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(laber);
        GameObject laner = Instantiate(Lazer, pos.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(laner);
        GameObject lamer = Instantiate(Lazer, pos2.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(lamer);
        yield return new WaitForSeconds(2f);
        pd.Play();
        
    }
}
