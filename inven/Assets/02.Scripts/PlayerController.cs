using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // 플레이어의 사망 상태 : 죽었는지 살았는지
    private bool isDead = false;
    // 이동에 사용할 리지드바디 컴포넌트
    private Rigidbody2D playerRigidbody;

    //이동구현 
    float moveX, moveY;
    /// <summary>
    /// 점프 힘
    /// </summary>
    public float jumpForce;
    /// <summary>
    /// 점프 횟수
    /// </summary>
    public int jumpCount;

    [Header("이동속도")]
    [SerializeField] [Range(1f, 30f)] float moveSpeed = 6f;

    void Start()
    {
        // 전역변수의 초기화 진행
        // 게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // 플레이어 이동
        PlayerMove();
        jumpControl();
    }

    void PlayerMove()
    {
        //이동 (상 : WS키 혹은 상하이동키)
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
        // 새로운 속도 벡터 생성.
        Vector2 newVelocity;
        // x값은 플레이어의 x속도 값.
        newVelocity.x = playerRigidbody.velocity.x;
        // y값은 점프힘.
        newVelocity.y = jumpForce;

        // 플레이어의 속도를 메서드 초반에 만든 벡터 값으로 초기화.
        playerRigidbody.velocity = newVelocity;

        // 점프 시 점프횟수 -1.
        jumpCount -= 1;
    }
}