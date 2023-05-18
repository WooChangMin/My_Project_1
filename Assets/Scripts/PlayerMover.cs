using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpPower;


    private Rigidbody rb;
    private Vector3 moveDir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        Move();
        Rotate();

    }

    private void Move()
    {
        transform.Translate(Vector3.forward * moveDir.z * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * moveDir.x * rotateSpeed * Time.deltaTime, Space.Self);
    }
    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private void OnJump(InputValue value)
    {
        Jump();
    }
}
