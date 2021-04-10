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


    Vector2 _velocity;
    Vector2 _rotation;
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
        if (_velocity != Vector2.zero)
        {
            _rigidBody.velocity = new Vector3(_velocity.x * _speed, 0f, _velocity.y * _speed);
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
        }
    }

    private void HandleRotation()
    {
        if (_rotation != Vector2.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(_rotation.x, 0f, _rotation.y), Vector3.up);

            _rigidBody.rotation = Quaternion.Lerp(_rigidBody.rotation, newRotation, 1f);
        }
        else
        {
            _rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _velocity = inputValue.Get<Vector2>();
    }
    private void OnTurn(InputValue inputValue)
    {
        _rotation = inputValue.Get<Vector2>();
    }
}
