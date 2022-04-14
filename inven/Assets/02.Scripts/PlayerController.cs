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


}
