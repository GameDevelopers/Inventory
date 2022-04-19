using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // �̵����� ���� ����
    float moveX, moveY;

    public bool talk = false;
    public string[] sentences;
    float lastSpaceTime = 0f;
    float spaceTime = 0.5f;

    // �̵��ӵ� 
    [Header("�̵��ӵ�")]
    // �̵� �ӵ� ���� ���� ����
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 6f;

    // ĳ���� �̵�
    private void Update()
    {
        PlayerMove();
        if(talk) NPCTalk();

    }

    void PlayerMove()
    {
        moveY = Input.GetAxis("Vertical") * moveSpeed;
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime;
    }

    void NPCTalk()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastSpaceTime + spaceTime)
        {
            lastSpaceTime = Time.time;
            //if (DialogManager.instance.dialoggroup.alpha == 0 && !DialogManager.instance.istyping)
            //{
            //    DialogManager.instance.Ondialog(sentences);
            //}
            //else if (DialogManager.instance.dialoggroup.alpha == 1 && DialogManager.instance.sentences.Count != 0)
            //{
            //    DialogManager.instance.NextSentence();
            //    //if (DialogManager.instance.istyping) DialogManager.instance.jump = true;
            //    //DialogManager.instance.jump = true;
            //}
            switch (DialogManager.instance.dialoggroup.alpha)
            {
                case 0:
                    if (!DialogManager.instance.istyping)
                    {
                        DialogManager.instance.Ondialog(sentences);
                    }
                    break;
                case 1:
                    if(DialogManager.instance.sentences.Count != 0)
                    {
                        DialogManager.instance.NextSentence();
                    }
                    else
                    {
                        if (DialogManager.instance.jump) DialogManager.instance.NextSentence();
                        else DialogManager.instance.jump = true;
                        //DialogManager.instance.jump = true;
                    }
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
    }


}
