using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // �̵����� ���� ����
    float moveX, moveY;

    // �̵��ӵ� 
    [Header("�̵��ӵ�")]
    // �̵� �ӵ� ���� ���� ����
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 6f;

    // �÷��̾� �Ӽ� ü��, ���ݵ�����, ���ݼӵ�, ���ݿ���
    public int maxHp;
    public int nowHp;
    public int atkDmg;
//    public float atkSpeed = 1;
    public bool attacked = false;
    //public Image nowHpbar;

    private void Start()
    {
        maxHp = 50;
        nowHp = 50;
        atkDmg = 10;  
    }

    // ĳ���� �̵�
    private void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveY = Input.GetAxis("Vertical") * moveSpeed;
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime;
    }

    // ����
    void AttackTrue()
    {
        attacked = true;
    }
    // ���� ����
    void AttackFalse()
    {
        attacked = false;
    }

}
