using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    CharacterController controller;

    float variant = 10f;
    float speed = 10f;
    float rotSpeedX = 6f;
    float rotSpeedY = 3f;

    float roll = 0;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

  
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 moveDir = transform.forward * speed * variant;

        Vector3 yaw = Input.GetAxisRaw("Horizontal") * transform.right * rotSpeedX * Time.deltaTime * variant;
        Debug.Log("Yaw - " + yaw);
        Vector3 pitch = Input.GetAxisRaw("Vertical") * transform.up * rotSpeedY * Time.deltaTime * variant;
        Debug.Log("Pitch - " + pitch);
        Vector3 dir = yaw + pitch;

        float maxX = Quaternion.LookRotation(moveDir + dir).eulerAngles.x;

        if (maxX < 90 && maxX > 60 || maxX >260 && maxX <290)
        {

        }
        else
        {
            moveDir += dir;
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
        GetRoll(Input.GetAxisRaw("Horizontal"));
        Debug.Log(roll);
        transform.Rotate(0, 0, roll);
        controller.Move(moveDir * Time.deltaTime);
    }

    void GetRoll(float axis)
    {
        
        //Voltar para a rotação inicial
        if (axis == 0)
        {
            if (roll < 0)
            {
                roll += 1;
            }
            else if(roll > 0)
            {
                roll -= 1;
            }
        //Rotacionar para a direita
        }else if(axis > 0)
        {
            if (roll > -30)
            {
                roll -= axis;
            }
        }
        //Rotacionar para a esquerda
        else
        {
            if (roll < 30)
            {
                roll -= axis;
            }

        }

    }
}
