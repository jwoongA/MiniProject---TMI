using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        AudioManager.instance.Playstage();
        SceneManager.LoadScene("GameScene");
        GameManager.Instance.SettingGame();
    }
}
 