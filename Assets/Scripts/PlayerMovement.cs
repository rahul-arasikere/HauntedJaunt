using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 1f;
    private Animator animator;
    private bool _IsWalking;
    private Vector3 movement;
    private Rigidbody rigidbody;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        movement.Set(horiz, 0, vert);
        movement.Normalize();
        _IsWalking = (horiz != 0 || vert != 0);
        Vector3 desiredForwardDirection = Vector3.RotateTowards(
            transform.forward,
            movement,
            rotationSpeed * Time.deltaTime,
            0
        );
        rotation = Quaternion.LookRotation(desiredForwardDirection);
        animator.SetBool("IsWalking", _IsWalking);
    }

    private void OnAnimatorMove()
    {
        rigidbody.MovePosition(rigidbody.position + movement * animator.deltaPosition.magnitude);
        rigidbody.MoveRotation(rotation);
    }
}
