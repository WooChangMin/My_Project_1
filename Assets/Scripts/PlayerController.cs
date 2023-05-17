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


    private Animator animator;
    private Rigidbody rb;
    private Vector3 moveDir;
    private Vector2 rotateDir;
    private void Awake()
    {
        animator = GetComponent<Animator>();
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
        
    public void Fire()
    {
        Instantiate(BulletPrefabs, ShootingPoint.position, ShootingPoint.rotation);
        animator.SetTrigger("Fire");
    }
    public void OnFire(InputValue value)
    {
        Fire();
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
}
