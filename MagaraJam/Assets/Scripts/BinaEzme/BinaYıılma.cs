using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class BinaYıılma : MonoBehaviour
{
    [SerializeField] ParticleSystem fxCrush;
    [SerializeField] GameObject Building;
    [SerializeField] Transform pos;
    [SerializeField] Transform pos2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BinaYikilma();
        Destroy(gameObject);
    }

    public void BinaYikilma()
    {
        Instantiate(fxCrush, pos2.position, Quaternion.identity);
        Instantiate(Building, pos.position, Quaternion.identity);
       
    }
}
