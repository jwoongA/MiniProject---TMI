using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
        GameManager.Instance.SettingGame();
        //Time.timeScale = 1.0f;
    }
}
 