using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    /// <summary>
    /// 玩家
    /// </summary>

    public Transform PlayerObject;
    
    /// <summary>
    /// 判斷目前上下左右的參數
    /// </summary>
    public string W, S, A, D;

    /// <summary>
    /// UI 文字
    /// </summary>
    public Text TextUp, TextDom, TextLeft, TextRight, TextSeconds;

    /// <summary>
    /// 上下左右的陣列參數
    /// </summary>
    List<string> MoveTypeList = new List<string>();


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
    public string MoveNamaUIView(string MoveNama)
    {
        string MoveStr = "";
        switch (MoveNama)
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
        return MoveStr;
    }

    /// <summary>
    /// 重置上下左右的list
    /// </summary>
    public void ResetMoveList()
    {
        int MoveListCount, MoveListRandom;

        MoveTypeList.Clear();
        MoveTypeList.Add("w");
        MoveTypeList.Add("s");
        MoveTypeList.Add("a");
        MoveTypeList.Add("d");

        MoveListCount = MoveTypeList.Count;
        MoveListRandom = Random.Range(0, MoveListCount);
        W = MoveTypeList[MoveListRandom];
        TextUp.text = "上：" + MoveNamaUIView(MoveTypeList[MoveListRandom]);
        MoveTypeList.RemoveAt(MoveListRandom);


        MoveListCount = MoveTypeList.Count;
        MoveListRandom = Random.Range(0, MoveListCount);
        S = MoveTypeList[MoveListRandom];
        TextDom.text = "下：" + MoveNamaUIView(MoveTypeList[MoveListRandom]);
        MoveTypeList.RemoveAt(MoveListRandom);

        MoveListCount = MoveTypeList.Count;
        MoveListRandom = Random.Range(0, MoveListCount);
        A = MoveTypeList[MoveListRandom];
        TextLeft.text = "左：" + MoveNamaUIView(MoveTypeList[MoveListRandom]);
        MoveTypeList.RemoveAt(MoveListRandom);

        MoveListCount = MoveTypeList.Count;
        MoveListRandom = Random.Range(0, MoveListCount);
        D = MoveTypeList[MoveListRandom];
        TextRight.text = "右：" + MoveNamaUIView(MoveTypeList[MoveListRandom]);
        MoveTypeList.RemoveAt(MoveListRandom);
    }

    private void Start()
    {
        PlayerObject = GameObject.Find("player").transform;
        ResetMoveList();
    }

    private void Update()
    {
        TextSeconds.text = (60 - ((int)Time.time % 60)).ToString();
        if ((int)Time.time % 60 == 0)
        {
            ResetMoveList();
        }
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            Move(W, 10);
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            Move(S, 10);
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            Move(A, 10);
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            Move(D, 10);
        }
    }
}
