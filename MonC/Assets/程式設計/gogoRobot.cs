using UnityEngine;

public class gogoRobot : MonoBehaviour {

    Animator ani;
    int count = 1;
    bool dan;

	void Start () {
        ani = gameObject.GetComponent<Animator>();
        dan = false;
	}

	void Update () {
        //利用奇偶數判斷動畫-只適用只有idle與跳舞
        /* if (Input.GetKeyDown(KeyCode.Space) )
         {
             count++;
             Debug.Log("count="+count);
         if (count/2 > 0 && count % 2 == 0)
         {
             ani.SetBool("idle", false);
             ani.SetTrigger("dancee");
         }
         else if(count / 2 > 0 && count % 2 != 0)
         {
             ani.SetBool("idle", !true);

         }
         }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dan = !false ;
            Debug.Log("now"+dan);
            if (dan == true)
            {
                ani.SetBool("idle", false);
                ani.SetTrigger("dancee");
            }
            else if(dan == false)
            {
                ani.SetBool("idle", true);
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            ani.SetBool("run", true);
            ani.ResetTrigger("dancee");
        }
        else ani.SetBool("run", false);

    }
}
