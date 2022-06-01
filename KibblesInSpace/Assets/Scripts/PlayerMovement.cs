using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [Tooltip("How high is this boi jumping")]
    [SerializeField] float _jumpForce = 2f;

    [SerializeField] LayerMask _groundLayerMask;

    Rigidbody2D _rigidbody;
    Collider2D _collider;

    KibblesInSpace _controls;

    private void Awake()
    {
        _controls = new KibblesInSpace();   
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Start()
    {
        //Event binding to function. '_' means we arent passing any parameters to function
        _controls.Player.Jump.performed += _ => Jump();
    }

    private void Update()
    {
        float movementInput = _controls.Player.Move.ReadValue<float>();

        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * _speed * Time.deltaTime;
        transform.position = currentPosition;
    }


    // Checks if Player is on ground by using the colliders position.
    bool IsGrounded()
    {
        Vector2 feetPos = transform.position;
        feetPos.y -= _collider.bounds.extents.y;
        return Physics2D.OverlapCircle(feetPos, .1f, _groundLayerMask);
    }

    void Jump()
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

    }
}
