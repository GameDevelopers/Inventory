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


}
