using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplamaBari : MonoBehaviour
{
    public static ZiplamaBari Instance;

    public  float maxZiplama = 100;
    public  float  ZiplamaSeviyesi = 0;
    float GercekScale;
    float animasyonYavasligi = 20;
    public  float artisSeviyesi = 0.5f;
    [SerializeField] private bool GroundCheck = false;
    private bool _isJumpable;
    [SerializeField] private GameObject _blueBar;
    private Rigidbody2D _rigidbody2;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        _rigidbody2 = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        JumpCalculate();
        jump();
        if (Input.GetKey(KeyCode.A)&&!GroundCheck)
        {
            JumpIncrease();
            //GroundCheck = true;
        }
    }

    private void JumpCalculate()
    {
        GercekScale = ZiplamaSeviyesi / maxZiplama;
        if (_blueBar.transform.localScale.x > GercekScale)

            _blueBar.transform.localScale =
                new Vector3(_blueBar.transform.localScale.x, _blueBar.transform.localScale.y
                + (GercekScale - _blueBar.transform.localScale.y) / animasyonYavasligi, _blueBar.transform.localScale.z);


        if (ZiplamaSeviyesi >= maxZiplama)

            ZiplamaSeviyesi = maxZiplama;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Zemin") && !GroundCheck)
        {
            _isJumpable = true;
            if (Input.GetKey(KeyCode.A))
            {
                JumpIncrease();
                Debug.Log(ZiplamaSeviyesi);
                //GroundCheck = true;
            }
        }
        else
            _isJumpable=false;
     }

    private void JumpIncrease()
    {
        ZiplamaSeviyesi += artisSeviyesi * Time.deltaTime;
    }

    public void jump()
    {
        if (Input.GetKeyUp(KeyCode.A)&&_isJumpable)
        {
            _rigidbody2.AddForce(new Vector2(0,ZiplamaSeviyesi * 20));
            ZiplamaSeviyesi = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            GroundCheck = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            GroundCheck = false;
        }
    }
}


