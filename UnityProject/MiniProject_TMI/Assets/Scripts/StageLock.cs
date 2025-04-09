using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class StageLock : MonoBehaviour
{
    [SerializeField] GameObject stageLock;
    [SerializeField] Button btnStage;
    [SerializeField] Shadow btnStageShadow;
    [SerializeField] int stageNum;
    [SerializeField] AnimatorController animController;
    [SerializeField] Animator anim;



    private void OnEnable()
    {
        // 해당 스크립트를 갖고 있는 Stage가 클리어 된 적있는지 체크
        // 정보가 없다면 Lock
        bool stageClear = PlayerPrefs.GetInt($"Stage{this.stageNum - 1}_Clear", 0) == 1;
        
        if (GameManager.Instance != null) // null 체크
        {
            if (GameManager.Instance.curStage + 1 == this.stageNum)
            {
                if (stageClear) { GameManager.Instance.OnEnableStageLock(this); }
            }
            else { if (stageClear) { Unlock();} }
        }
        else
        {
            // 최초 실행
            if (stageClear)
            {
                // GameManager가 Instance화 되지 않았다는 것은 처음 실행했다는 것이므로
                // 애니메이션을 재생할 필요가 없음.
                Unlock();
            }
        }
    }
   
    public void Unlock()
    {
        // Lock 오브젝트 비활성화, 버튼 기능 활성화, Shadow 활성화(가시성)
        this.stageLock.SetActive(false);
        this.btnStage.enabled = true;
        this.btnStageShadow.enabled = true;
    }

    public void PlayUnlockAnim()
    {
        anim.SetBool("isUnLock", true);
        Invoke("InvokeUnLock", 2f);
        //StartCoroutine(UnlockAnim());
    }

    void InvokeUnLock()
    {
        this.anim.SetBool("isUnLock", false);
        Unlock();
    }

    //IEnumerator UnlockAnim()
    //{
    //    if (anim == null)
    //        anim = GetComponentInChildren<Animator>();

    //    yield return null;

    //    anim.runtimeAnimatorController = animController;

    //    if (anim.runtimeAnimatorController != null)
    //    {
    //        //anim.SetBool("isUnLock", true);
    //        anim.SetTrigger("IsUnlockAnim");
    //    }
    //    else
    //    {
    //        Debug.LogWarning("AnimatorController가 아직 안 붙었어요!");
    //    }

    //    yield return new WaitForSeconds(2f);

    //    // Lock 오브젝트 비활성화, 버튼 기능 활성화, Shadow 활성화(가시성)

    //    //anim.SetBool("isUnLock", false);
    //    this.stageLock.SetActive(false);
    //    this.btnStage.enabled = true;
    //    this.btnStageShadow.enabled = true;

        

    //    yield break;
    //}
}
