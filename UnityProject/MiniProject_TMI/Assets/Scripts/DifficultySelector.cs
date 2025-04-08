using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public void SelectDifficulty(int level)
    {
        PlayerPrefs.SetInt("SelectedDifficulty", level); // ����
      
        GameManager.Instance.SettingGame();
        AudioManager.instance.Playclick();
        AudioManager.instance.Playstage();

        SceneManager.LoadScene("GameScene"); // ���ξ����� �̵�
    }
}
