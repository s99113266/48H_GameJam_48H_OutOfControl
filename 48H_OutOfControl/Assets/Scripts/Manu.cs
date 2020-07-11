using UnityEngine;
using UnityEngine.SceneManagement;

public class Manu : MonoBehaviour
{

    public void LoadSecen()
    {
        SceneManager.LoadScene("Play");
    }

    public void ButtonClickDelyAction()
    {
        Invoke("LoadSecen", 0.9f);
    }
}
