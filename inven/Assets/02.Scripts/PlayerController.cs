using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // 이동위한 벡터 변수
    float moveX, moveY;

    // 이동속도 
    [Header("이동속도")]
    // 이동 속도 범위 제한 조절
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 6f;

    // 플레이어 속성 체력, 공격데미지, 공격속도, 공격여부
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

    // 캐릭터 이동
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

    // 공격
    void AttackTrue()
    {
        attacked = true;
    }
    // 공격 안함
    void AttackFalse()
    {
        attacked = false;
    }

}
