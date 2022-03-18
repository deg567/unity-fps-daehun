using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    CharacterController  cc;
    
    // 중력 변수 
    float gravity = -20f;

    // 수직 속력 변수
    float yVelocity = 0;

    // 점프력 변수 
    public float jumpPower = 10f;
    public int limitJump = 2;
    private int currentJump = 0;

    // 점프 상태 변수
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //A~D
        float v = Input.GetAxis("Vertical"); //W~S

        // 이동 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        // 메인 카메라를 기준으로 방향 변경
        dir = Camera.main.transform.TransformDirection(dir);
        
        // 점프 중이고, 바닥에 착지했다면
        if(isJumping  && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
            currentJump = 0;
        }

        if(limitJump>currentJump)
        {
            isJumping = false;
        }

        // 점프 구현
        if(Input.GetButtonDown("Jump") && !isJumping) 
        {
            yVelocity = jumpPower;
            isJumping = true;
            currentJump += 1;               
        }

        // 이동 속도 설정
        transform.position += dir * moveSpeed * Time.deltaTime;

        // 캐릭터의 수직 속도에 중력 값 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 이동 함수 
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }
}
