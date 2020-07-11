using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 玩家
    /// </summary>
    public Transform PlayerObject;

    /// <summary>
    /// 死亡訊息
    /// </summary>
    public GameObject DieMessage;

    /// <summary>
    /// 判斷目前上下左右的參數
    /// </summary>
    string W, S, A, D;

    /// <summary>
    /// 生命
    /// </summary>
    public static int Life;

    /// <summary>
    /// UI 文字
    /// </summary>
    public Text TextUp, TextDom, TextLeft, TextRight, TextSeconds, TextLife;

    /// <summary>
    /// 取得動畫控制器
    /// </summary>
    public Animator Ain;

    /// <summary>
    /// 上下左右的陣列參數
    /// </summary>
    List<string> MoveTypeList = new List<string>();


    /// <summary>
    /// 死亡
    /// </summary>
    public void Die()
    {
        LifeView();
        if (Life <= 0)
        {
            Ain.SetTrigger("Die");
            Invoke("DieMessageView", 1);
        }
    }

    /// <summary>
    /// 死亡訊息
    /// </summary>
    private void DieMessageView()
    {
        DieMessage.SetActive(true);
    }

    /// <summary>
    /// 顯示生命
    /// </summary>
    public void LifeView()
    {
        TextLife.text = "生命：" + Life.ToString();
    }

    /// <summary>
    /// 移動方法
    /// </summary>
    public void Move(string MoveType, float speed)
    {
        switch (MoveType)
        {
            case "w":
                PlayerObject.Translate(0, speed * Time.deltaTime, 0);
                break;
            case "s":
                PlayerObject.Translate(0, speed * -Time.deltaTime, 0);
                break;
            case "a":
                PlayerObject.Translate(speed * -Time.deltaTime, 0, 0);
                break;
            case "d":
                PlayerObject.Translate(speed * Time.deltaTime, 0, 0);
                break;
        }
    }

    /// <summary>
    /// 顯示UI面板的狀況
    /// </summary>
    public void MoveNamaUIView(string MoveKey, string MoveNama)
    {
        string MoveStr = "";
        switch (MoveKey)  //按鍵
        {
            case "w":
                MoveStr = "W、↑";
                break;
            case "s":
                MoveStr = "S、↓";
                break;
            case "a":
                MoveStr = "A、←";
                break;
            case "d":
                MoveStr = "D、→";
                break;
        }

        switch (MoveNama) //方向
        {
            case "w":
                MoveStr = "上：" + MoveStr;
                TextUp.text = MoveStr;
                break;
            case "s":
                MoveStr = "下：" + MoveStr;
                TextDom.text = MoveStr;
                break;
            case "a":
                MoveStr = "左：" + MoveStr;
                TextLeft.text = MoveStr;
                break;
            case "d":
                MoveStr = "右：" + MoveStr;
                TextRight.text = MoveStr;
                break;
        }
    }

    /// <summary>
    /// 重置上下左右的list
    /// </summary>
    public void ResetMoveList()
    {
        int MoveListCount, MoveListRandom;

        MoveTypeList.Add("w");
        MoveTypeList.Add("s");
        MoveTypeList.Add("a");
        MoveTypeList.Add("d");

        MoveListCount = MoveTypeList.Count;
        MoveListRandom = Random.Range(0, MoveListCount);
        W = MoveTypeList[MoveListRandom];
        MoveNamaUIView("w", W);
        MoveTypeList.RemoveAt(MoveListRandom);

        MoveListCount = MoveTypeList.Count;
        MoveListRandom = Random.Range(0, MoveListCount);
        S = MoveTypeList[MoveListRandom];
        MoveNamaUIView("s", S);
        MoveTypeList.RemoveAt(MoveListRandom);

        MoveListCount = MoveTypeList.Count;
        MoveListRandom = Random.Range(0, MoveListCount);
        A = MoveTypeList[MoveListRandom];
        MoveNamaUIView("a", A);
        MoveTypeList.RemoveAt(MoveListRandom);

        MoveListCount = MoveTypeList.Count;
        MoveListRandom = Random.Range(0, MoveListCount);
        D = MoveTypeList[MoveListRandom];
        MoveNamaUIView("d", D);
        MoveTypeList.RemoveAt(MoveListRandom);
    }

    private void Start()
    {
        PlayerObject = GameObject.Find("player").transform;
        InvokeRepeating("ResetMoveList", 0, 60);
        Life = 2;
        LifeView();
    }


    private void Update()
    {
        if (Life > 0)
        {
            TextSeconds.text = "重置時間：" + (60 - ((int)Time.time % 60)).ToString();

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                Move(W, 10);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                Move(S, 10);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Move(A, 10);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Move(D, 10);
            }
        }
        Die();
    }
}
