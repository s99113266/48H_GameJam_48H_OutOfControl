using UnityEngine;

public class SwordMove : MonoBehaviour
{


    public Transform transformPlayer;

    private void Start()
    {
        transformPlayer = GameObject.Find("player").transform;
        transform.up = transformPlayer.position - transform.position;
    }

    void Update()
    {
        transform.Translate(transformPlayer.up * 0.015f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //碰到玩家扣血
        if (collision.gameObject.name == "player")
        {
            //大於0就繼續扣血
            if (Player.Life > 0)
                Player.Life--;
            Destroy(gameObject);
        }

        //碰到牆壁
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
