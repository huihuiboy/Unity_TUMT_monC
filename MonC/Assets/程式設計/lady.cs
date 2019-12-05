using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lady : MonoBehaviour {

    private Animator ani;
    private Rigidbody rig;

    [Header("速度"),Range(0,80f)]
    public float speed = 20f;
    [Header("旋轉"), Range(0, 100f)]
    public float turn = 50f;
    [Header("血量"),Range(100,500)]
    public int hp = 100;


    [Header("動畫控制器=參數名稱")]
    public string parWak = "walk";
    public string parAtk = "atk";
    public string parJum = "jump";
    public string parHut = "hurt";
    public string parDie = "die";

    //屬性 可以設定權限 取得get、設定set
    //修飾詞 類型 名稱 { 取得 設定 }
    public int MyProperty { get; set; }


    public bool isHut
    {
        get
        {
            return (ani.GetCurrentAnimatorStateInfo(0).IsName("hurt"));
        }
    }
    public bool isAtk
    {
        get
        {
            return (ani.GetCurrentAnimatorStateInfo(0).IsName("atk"));
        }
    }

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        rig = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isAtk || isHut) return; // 傳回空值 = 跳出
        Turn();
        Attack();
        

        //判斷動畫狀態
        //print("是否為受傷動畫:" + isHut);
        //print("是否為受傷動畫:" + isAtk);

    }

    private void FixedUpdate()
    {
        if (isAtk || isHut) return;
        Walk();
        Jump();
    }
    
    /// <summary>
    /// 前後左右走路
    /// </summary>
    private void Walk()
    {
        ani.SetBool(parWak,Input.GetAxisRaw("Vertical") !=0 || Input.GetAxisRaw("Horizontal") != 0);
        //rig.AddForce(0,0, Input.GetAxisRaw("Vertical")*speed); //世界座標
        //rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed); //區域座標
        //前方 transform.forword  右方 transform.right  上方  transform.up
        rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed+ transform.right * Input.GetAxisRaw("Horizontal") * speed);

    }
    /// <summary>
    /// 左右旋轉
    /// </summary>
    private void Turn()
    {
        float x = Input.GetAxis("Mouse X");
        transform.Rotate ( 0 , x * turn * Time.deltaTime , 0 );
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            ani.SetTrigger(parAtk);
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
            ani.SetTrigger(parJum);
    }
    /// <summary>
    /// 受傷
    /// </summary>
    private void Hurt()
    {
        ani.SetTrigger(parHut);
        hp -= 50;
        if (hp <= 0) Die();
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Die()
    {
        ani.SetBool(parDie,true);
        //this 此腳本
        //enable 啟動
        this.enabled = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "陷阱")
        {
            Hurt();
        }
    }
}
