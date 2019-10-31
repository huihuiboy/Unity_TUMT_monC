using UnityEngine;

public class gogoRobot : MonoBehaviour {

    Animator ani;
    int count = 1;


	void Start () {
        ani = gameObject.GetComponent<Animator>();
        
	}

	void Update () {

        if (count/2 > 0 && count % 2 == 0)
        {

            ani.SetBool("dance",true);
        }
        else if(count % 2 != 0)
        {
            ani.SetBool("dance", false);

        }
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            count++;
            Debug.Log("count="+count);
        }
        ani.SetBool("run", Input.GetKey(KeyCode.R));

	}
}
