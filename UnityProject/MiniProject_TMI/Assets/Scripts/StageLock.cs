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
    [SerializeField] Animator anim;

   
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
        bool stageClear = PlayerPrefs.GetInt($"Stage{this.stageNum-1}_Clear", 0) == 1;
        if (GameManager.Instance != null) // null üũ
        {
            if(GameManager.Instance.curStage + 1 == this.stageNum)
            {
                if (stageClear) { GameManager.Instance.OnEnableStageLock(this); }
                else { Lock(); }
            }
        }
        else if (!stageClear)
        {
            Lock();
        }
    }
    public void UnLock()
    {
        // ���⿡�� �ִϸ��̼� �÷����Ͻø� �˴ϴ�.
        anim.SetBool("isUnLock", true);
        Invoke("InvokeUnLock", 2f);
    }
    public void InvokeUnLock()
    {
        // Lock ������Ʈ ��Ȱ��ȭ, ��ư ��� Ȱ��ȭ, Shadow Ȱ��ȭ(���ü�)
        this.stageLock.SetActive(false);
        this.btnStage.enabled = true;
        this.btnStageShadow.enabled = true;
        anim.SetBool("isUnLock", false);
    }   
}
