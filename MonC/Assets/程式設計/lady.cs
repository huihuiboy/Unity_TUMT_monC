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


    [Header("動畫控制器=參數名稱")]
    public string parWak = "walk";
    public string parAtk = "atk";
    public string parJum = "jump";
    public string parHut = "hurt";
    public string parDie = "die";

    private void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        rig = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Walk();
        Turn();
        Attack();
        Jump();
    }
    //
    //
    //
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
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Die()
    {
        ani.SetBool(parDie,true);
    }
}
