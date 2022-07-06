using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float moveSpeed;

    private Rigidbody rigidbody;
    private void Awake()
    {
        Finish.onFinishEntered += StopMove;
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigidbody.velocity.y, 0f);
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
    }
    private void StopMove()
    {
        moveSpeed = 0f;
    }
}
