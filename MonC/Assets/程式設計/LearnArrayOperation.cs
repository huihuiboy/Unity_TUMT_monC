using UnityEngine;

public class LearnArrayOperation : MonoBehaviour
{
    public int studentA = 10;
    public int studentB = 20;
    public int studentC = 30;

    //陣列
    public int[] stundents = { 10,20,30,40,50,60,70,80,90 };

    private void Start()
    {
        //取陣列
        Debug.Log(stundents[4]);
        //存陣列
        stundents[3] = 444;
        //陣列長度
        Debug.Log(stundents.Length);
    }
    private void Update()
    {
        Debug.Log(Input.GetKeyDown(KeyCode.Space));
    }
}
