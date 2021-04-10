using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float _dashCooldownTimer = 0f;
    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _rotationSpeed = 15f;
    [SerializeField]
    float _dashSpeedIncrease = 10f;

    Vector2 _velocity;
    Vector2 _rotation;
    Rigidbody _rigidBody;
    float _maxDashCooldownTimer = 2f;
    bool _hasDashed = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
        _dashCooldownTimer = _maxDashCooldownTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasDashed)
        {
            _dashCooldownTimer -= Time.deltaTime;
            if (_dashCooldownTimer <= 0f)
            {
                _hasDashed = false;
                _dashCooldownTimer = _maxDashCooldownTimer;
            }
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        if (!_hasDashed)
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
    }

    private void HandleRotation()
    {
        if (_rotation != Vector2.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(_rotation.x, 0f, _rotation.y), Vector3.up);

            _rigidBody.rotation = Quaternion.Lerp(_rigidBody.rotation, newRotation, _rotationSpeed);
        }
        else
        {
            _rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void HandleDash()
    {
        _rigidBody.velocity = new Vector3(_rigidBody.velocity.x * _dashSpeedIncrease, 0f, _rigidBody.velocity.z * _dashSpeedIncrease);
    }

    private void OnMove(InputValue inputValue)
    {
        _velocity = inputValue.Get<Vector2>();
    }
    private void OnTurn(InputValue inputValue)
    {
        _rotation = inputValue.Get<Vector2>();
    }
    private void OnDash(InputValue inputValue)
    {
        _hasDashed = true;
        HandleDash();
    }
}
