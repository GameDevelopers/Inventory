using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // �÷��̾��� ��� ���� : �׾����� ��Ҵ���
    private bool isDead = false;
    // �̵��� ����� ������ٵ� ������Ʈ
    private Rigidbody2D playerRigidbody;

    //�̵����� 
    float moveX, moveY;
    /// <summary>
    /// ���� ��
    /// </summary>
    public float jumpForce;
    /// <summary>
    /// ���� Ƚ��
    /// </summary>
    public int jumpCount;

    [Header("�̵��ӵ�")]
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 6f;

    void Start()
    {
        // ���������� �ʱ�ȭ ����
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // �÷��̾� �̵�
        PlayerMove();
        jumpControl();
    }

    void PlayerMove()
    {
        //�̵� (�� : WSŰ Ȥ�� �����̵�Ű)
        //moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * moveSpeed;
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

        //transform.position.y += (moveY*moveSpeed*Time.deltaTime;
        transform.position += new Vector3(moveX, moveY, 0) * Time.deltaTime;

    }
    private void jumpControl()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            jump();
        }
  
    }

    
    private void jump()
    {
        // ���ο� �ӵ� ���� ����.
        Vector2 newVelocity;
        // x���� �÷��̾��� x�ӵ� ��.
        newVelocity.x = playerRigidbody.velocity.x;
        // y���� ������.
        newVelocity.y = jumpForce;

        // �÷��̾��� �ӵ��� �޼��� �ʹݿ� ���� ���� ������ �ʱ�ȭ.
        playerRigidbody.velocity = newVelocity;

        // ���� �� ����Ƚ�� -1.
        jumpCount -= 1;
    }
}