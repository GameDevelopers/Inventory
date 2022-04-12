using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed;
    public float moveSpeed;
    public float atkRange;
    public float fieldOfVision;

    private void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg, float _atkSpeed, float _moveSpeed, float _atkRange, float _fieldOfVision)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
        moveSpeed = _moveSpeed;
        atkRange = _atkRange;
        fieldOfVision = _fieldOfVision;
    }

    public PlayerController player;
    public Animator enemyAnimator;

    void Start()
    {
   
        if (name.Equals("Enemy1"))
        {
            SetEnemyStatus("Enemy1", 100, 10, 1.5f, 2, 1.5f, 7f);
        }


        SetAttackSpeed(atkSpeed);
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (player.attacked)
            {
                nowHp -= player.atkDmg;
                player.attacked = false;
                if (nowHp <= 0) // �� ���
                {
                    Die();
                }
            }
        }
    }

    void Die()
    {
        enemyAnimator.SetTrigger("die");            // die �ִϸ��̼� ����
        GetComponent<EnemyAI>().enabled = false;    // ���� ��Ȱ��ȭ
        GetComponent<Collider2D>().enabled = false; // �浹ü ��Ȱ��ȭ
        Destroy(GetComponent<Rigidbody2D>());       // �߷� ��Ȱ��ȭ
        Destroy(gameObject, 3);                     // 3���� ���� 
    }

    void SetAttackSpeed(float speed)
    {
        enemyAnimator.SetFloat("attackSpeed", speed);
    }
}
