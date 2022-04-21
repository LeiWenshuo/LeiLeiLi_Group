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
            //Input.GetAxis("Horizontal")为获取X(横轴)轴方向的值给horizontal
            horizontal = Input.GetAxis("Horizontal");
            //Input.GetAxis("Vertical")为获取Z(纵轴)轴方向的值给Vertical
            vertical = Input.GetAxis("Vertical");

            //transform为本物体所在位置，forward是向前的一个分量
                     
            Player_Move = (transform.forward * vertical + transform.right * horizontal) * MoveSpeed;

            //判断玩家是否按下空格键
            if (Input.GetAxis("Jump") == 1)
            {
                //按下空格键，给其竖直方向添加一个向上的数度，使其跳起
               
                Player_Move.y = Player_Move.y + JumpSpeed;
            }
        }

        //模拟重力下降的效果，让向上的量减去重力下降的量
            
        Player_Move.y = Player_Move.y - gravity * Time.deltaTime;

        //PlayerController下的.Move为实现物体运动的函数
        //Move()括号内放入一个Vector3类型的量，本例中为Player_Move
        PlayerController.Move(Player_Move * Time.deltaTime);
    }
}
