using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float repeatSpeed;
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private GameObject BulletPrefabs;

    public UnityEvent OnFired;

    private Animator animator;
    private Rigidbody rb;

    private Vector2 rotateDir;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void Fire()
    {
        Instantiate(BulletPrefabs, ShootingPoint.position, ShootingPoint.rotation);
        animator.SetTrigger("Fire");
        GameManager.Data.AddShootCount(1);
        OnFired?.Invoke();
    }
    public void OnFire(InputValue value)
    {
        Fire();
    }
}
