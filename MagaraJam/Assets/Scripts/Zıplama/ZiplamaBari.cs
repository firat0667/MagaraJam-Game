using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplamaBari : MonoBehaviour
{
    public static ZiplamaBari Instance;

   public float maxZiplama = 100;
   public float ZiplamaSeviyesi = 0;
    float GercekScale;
   public float animasyonYavasligi = 1f;
   public float artisSeviyesi = 80f;
    [SerializeField] private bool GroundCheck = false;
    [SerializeField] Animasyon animasyon;
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
        if (Input.GetKey(KeyCode.Space)&&!GroundCheck)
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
            _blueBar.SetActive(true);
            _isJumpable = true;
            if (Input.GetKey(KeyCode.Space))
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
        if (Input.GetKeyUp(KeyCode.Space)&&_isJumpable)
        {
            _rigidbody2.AddForce(new Vector2(0,ZiplamaSeviyesi * 20));
            ZiplamaSeviyesi = 0;
            //jumpAnimasyonu();
        //    animasyon.jumpAnimation(true);
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
         //   animasyon.jumpAnimation(false);
        }
    }
    //IEnumerator jumpAnimasyonu()
    //{
    //    animasyon.jumpAnimation(true); 
    //    yield return new WaitForSeconds(ZiplamaSeviyesi);
    //    animasyon.jumpAnimation(false);
    //}
}


