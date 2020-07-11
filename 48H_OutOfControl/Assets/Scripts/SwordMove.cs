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
        transform.Translate(transformPlayer.up * 0.008f);
    }
}
