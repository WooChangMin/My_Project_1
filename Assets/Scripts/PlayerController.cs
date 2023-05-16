using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float repeatSpeed;
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private GameObject BulletPrefabs;


    private Rigidbody rb;
    private Vector3 moveDir;
    private Vector2 rotateDir;
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
        transform.Translate(Vector3.forward* moveDir.z * moveSpeed*Time.deltaTime);
        transform.Translate(Vector3.right * moveDir.x * moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up *moveDir.x *rotateSpeed * Time.deltaTime,Space.Self);
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

    private void Fire(InputValue value)
    {
        Instantiate(BulletPrefabs, transform.position, transform.rotation);
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
}
