using UnityEngine;

public class gogoRobot : MonoBehaviour {

    Animator ani;

	void Start () {
        ani = gameObject.GetComponent<Animator>();
	}

	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
           ani.SetTrigger("dancee") ;
        ani.SetBool("run", Input.GetKey(KeyCode.R));

	}
}
