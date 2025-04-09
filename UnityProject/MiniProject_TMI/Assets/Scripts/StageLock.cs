using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageLock : MonoBehaviour
{
    [SerializeField] GameObject stageLock;
    [SerializeField] Button btnStage;
    [SerializeField] Shadow btnStageShadow;
    [SerializeField] int stageNum;

    void Lock()
    {
        // Lock ������Ʈ Ȱ��ȭ, ��ư ��� ��Ȱ��ȭ(��ư ���� ����), Shadow ��Ȱ��ȭ(���ü�)
        this.stageLock.SetActive(true);
        this.btnStage.enabled = false;
        this.btnStageShadow.enabled = false;
    }

    private void OnEnable()
    {
        // �ش� ��ũ��Ʈ�� ���� �ִ� Stage�� Ŭ���� �� ���ִ��� üũ
        // ������ ���ٸ� Lock
        if(GameManager.Instance != null) // null üũ
        {
            bool stageClear = PlayerPrefs.GetInt($"Stage{GameManager.Instance.curStage}_Clear", 0) == 1;
            if(GameManager.Instance.curStage + 1 == this.stageNum)
            {
                if (stageClear) { GameManager.Instance.OnEnableStageLock(this); }
                else { Lock(); }
            }
        }
    }

    public void UnLock()
    {
        // ���⿡�� �ִϸ��̼� �÷����Ͻø� �˴ϴ�.

        // Lock ������Ʈ ��Ȱ��ȭ, ��ư ��� Ȱ��ȭ, Shadow Ȱ��ȭ(���ü�)
        this.stageLock.SetActive(false);
        this.btnStage.enabled = true;
        this.btnStageShadow.enabled = true;
    }
}
