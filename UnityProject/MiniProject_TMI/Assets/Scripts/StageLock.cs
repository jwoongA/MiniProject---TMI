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
        // Lock 오브젝트 활성화, 버튼 기능 비활성화(버튼 누름 방지), Shadow 비활성화(가시성)
        this.stageLock.SetActive(true);
        this.btnStage.enabled = false;
        this.btnStageShadow.enabled = false;
    }

    private void OnEnable()
    {
        // 해당 스크립트를 갖고 있는 Stage가 클리어 된 적있는지 체크
        // 정보가 없다면 Lock
        if(GameManager.Instance != null) // null 체크
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
        // 여기에서 애니메이션 플레이하시면 됩니다.

        // Lock 오브젝트 비활성화, 버튼 기능 활성화, Shadow 활성화(가시성)
        this.stageLock.SetActive(false);
        this.btnStage.enabled = true;
        this.btnStageShadow.enabled = true;
    }
}
