using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPley : MonoBehaviour
{
    public void ResetPleyScene()
    {
        SceneManager.LoadScene("menu");
    }

    public void ResetPleySceneDely()
    {
        Invoke("ResetPleyScene",0.9f);
    }
}
