using UnityEngine;

public class practice : MonoBehaviour {

    //欄位 field 
    //欄位類型 欄位名稱(指定 值)
    [Header("分數")]
    [Range(1,100)]
    public int score = 60; //整數
    [Header("分數"), Range(1f, 10f)]
    public float speed = 1.5f; //點數
    [Header("分數")]
    public string prop = "藥水"; //字串
    [Header("分數")]
    public bool mission = false; //布林值true or false

    public Vector2 PosA = new Vector2(7, 77);
    public Vector3 PosB = new Vector3(1, 3, 5);
    public Vector3 Zero = Vector3.zero;

    public Color blue = Color.blue;
    public Color red = new Color(0.8f, 0.1f, 0.5f);

    //(非靜態)類別類型
    public AudioClip sound;
    public Camera Cam;
    public Light lig;
    public Animation ani;
    public GameObject Yee;
    //(靜態)類別不能宣告為欄位
    //public Debug deb;

    private void Start()
    {
        //非靜態類別//
        //Camera.depth = 10.5f;//錯誤寫法
        Cam.depth = 10.5f;

        Debug.Log("挖撈為");
    }
}
