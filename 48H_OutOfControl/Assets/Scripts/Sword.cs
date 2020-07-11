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
        InvokeRepeating("SwordInsert",1, 0.8f);
    }


    public void SwordInsert()
    {
        GameObject gameObject = Instantiate(transformSword, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), Quaternion.identity).gameObject;
        gameObject.AddComponent<SwordMove>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
