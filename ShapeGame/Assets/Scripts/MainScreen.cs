using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour {
    public void ExitGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}