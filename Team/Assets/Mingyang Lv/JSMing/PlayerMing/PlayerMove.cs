using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed;
   
    private float horizontal;
    private float vertical;

     
    private float gravity = 9.8f;

    public float JumpSpeed = 15f;

    public CharacterController PlayerController;

  
    Vector3 Player_Move;
  
    void Update()
    {
        
        if (PlayerController.isGrounded)
        {
            //Input.GetAxis("Horizontal")Ϊ��ȡX(����)�᷽���ֵ��horizontal
            horizontal = Input.GetAxis("Horizontal");
            //Input.GetAxis("Vertical")Ϊ��ȡZ(����)�᷽���ֵ��Vertical
            vertical = Input.GetAxis("Vertical");

            //transformΪ����������λ�ã�forward����ǰ��һ������
                     
            Player_Move = (transform.forward * vertical + transform.right * horizontal) * MoveSpeed;

            //�ж�����Ƿ��¿ո��
            if (Input.GetAxis("Jump") == 1)
            {
                //���¿ո����������ֱ�������һ�����ϵ����ȣ�ʹ������
               
                Player_Move.y = Player_Move.y + JumpSpeed;
            }
        }

        //ģ�������½���Ч���������ϵ�����ȥ�����½�����
            
        Player_Move.y = Player_Move.y - gravity * Time.deltaTime;

        //PlayerController�µ�.MoveΪʵ�������˶��ĺ���
        //Move()�����ڷ���һ��Vector3���͵�����������ΪPlayer_Move
        PlayerController.Move(Player_Move * Time.deltaTime);
    }
}
