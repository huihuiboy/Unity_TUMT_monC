using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lady : MonoBehaviour {

    private Animator ani;
    private Rigidbody rig;

    [Header("速度"),Range(0,80f)]
    public float speed = 20f;

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
        Attack();
        Jump();
    }
    //
    //
    //
    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        ani.SetBool(parWak,Input.GetAxisRaw("Vertical") !=0 || Input.GetAxisRaw("Horizontal") != 0);
        //rig.AddForce(0,0, Input.GetAxisRaw("Vertical")*speed); //世界座標
        rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed); //區域座標
        
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
