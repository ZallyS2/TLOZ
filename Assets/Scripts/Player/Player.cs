using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public float rotationSpeed;
    public CharacterController controller;
    Vector3 moveDirection;


    void Start()
    {

        //controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }


    void Move() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical);

        if(moveDirection != Vector3.zero)
        {
            //Calcula onde o personagem ta olhando e rotaciona ele suavemente
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        }
         
 
    }
}
