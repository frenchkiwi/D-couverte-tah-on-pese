using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 6f;
    public float jumpspeed = 8f;
    public float gravity = 20f;

    private Vector3 moveD = Vector3.zero;
    private float rotationX = 0f;
    private CharacterController Cac;

    void Start()
    {
        Cac = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Cac.isGrounded)
        {
            moveD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;

            if (Input.GetButton("Jump"))
            {
                moveD.y = jumpspeed;
            }
        }

        moveD.y -= gravity * Time.deltaTime;

        rotationX -= Input.GetAxis("Mouse Y") * Time.deltaTime * speed * 10;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * speed * 10);

        Cac.Move(moveD * Time.deltaTime);
    }
}
