using UnityEngine;

public class Sword : MonoBehaviour
{
    /// <summary>
    /// 玩家
    /// </summary>
    public Transform transformPlayer;

    /// <summary>
    /// 劍
    /// </summary>
    public Transform transformSword;

    void Start()
    {
        transformPlayer = GameObject.Find("player").transform;
        InvokeRepeating("SwordInsert",1, 0.4f);
    }


    public void SwordInsert()
    {
        if (Player.Life > 0)
        {
            GameObject gameObject = Instantiate(transformSword, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), Quaternion.identity).gameObject;
            gameObject.AddComponent<SwordMove>();
        }
    }
}
