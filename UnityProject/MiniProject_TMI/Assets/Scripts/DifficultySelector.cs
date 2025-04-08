using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{
    public void SelectDifficulty(int level)
    {
        PlayerPrefs.SetInt("SelectedDifficulty", level); // ����
        SceneManager.LoadScene("GameScene"); // ���ξ����� �̵�
        GameManager.Instance.SettingGame();
    }
}
