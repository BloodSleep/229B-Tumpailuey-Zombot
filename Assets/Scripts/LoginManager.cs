using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start");

        if (Application.CanStreamedLevelBeLoaded(1))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogError("Scene 'Game' not found in Build Settings!");
        }
    }
}