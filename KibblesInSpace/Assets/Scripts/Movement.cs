using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Range(1f, 50f)]
    [SerializeField] float movementSpeed = 1f;
    Vector2 moveVal;

    private void Update()
    {
        transform.Translate(new Vector3(moveVal.x, 0, 0) * movementSpeed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        moveVal.x = value.Get<float>();
    }
}
