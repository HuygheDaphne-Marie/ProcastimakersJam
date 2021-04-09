using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _rotationSpeed = 15f;
    Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        var gamepad = Gamepad.current;
        Vector2 movement = gamepad.leftStick.ReadValue();

        if (movement != Vector2.zero)
        {
            _rigidBody.velocity = new Vector3(movement.x * _speed, 0f, movement.y * _speed);
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
        }
    }

    private void HandleRotation()
    {
        var gamepad = Gamepad.current;
        Vector2 rotation = gamepad.rightStick.ReadValue();

        Quaternion quaternion = Quaternion.Euler(new Vector3(0f, rotation.x * _rotationSpeed, 0f));

        _rigidBody.MoveRotation(_rigidBody.rotation * quaternion);
    }
}
