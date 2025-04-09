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
        // �ش� ��ũ��Ʈ�� ���� �ִ� Stage�� Ŭ���� �� ���ִ��� üũ
        // ������ ���ٸ� Lock
        bool stageClear = PlayerPrefs.GetInt($"Stage{this.stageNum - 1}_Clear", 0) == 1;
        
        if (GameManager.Instance != null) // null üũ
        {
            if (GameManager.Instance.curStage + 1 == this.stageNum)
            {
                if (stageClear) { GameManager.Instance.OnEnableStageLock(this); }
            }
            else { if (stageClear) { Unlock();} }
        }
        else
        {
            // ���� ����
            if (stageClear)
            {
                // GameManager�� Instanceȭ ���� �ʾҴٴ� ���� ó�� �����ߴٴ� ���̹Ƿ�
                // �ִϸ��̼��� ����� �ʿ䰡 ����.
                Unlock();
            }
        }
    }
   
    public void Unlock()
    {
        // Lock ������Ʈ ��Ȱ��ȭ, ��ư ��� Ȱ��ȭ, Shadow Ȱ��ȭ(���ü�)
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
    //        Debug.LogWarning("AnimatorController�� ���� �� �پ����!");
    //    }

    //    yield return new WaitForSeconds(2f);

    //    // Lock ������Ʈ ��Ȱ��ȭ, ��ư ��� Ȱ��ȭ, Shadow Ȱ��ȭ(���ü�)

    //    //anim.SetBool("isUnLock", false);
    //    this.stageLock.SetActive(false);
    //    this.btnStage.enabled = true;
    //    this.btnStageShadow.enabled = true;

        

    //    yield break;
    //}
}
