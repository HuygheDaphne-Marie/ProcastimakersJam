using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float maxDashCooldownTimer = 2f;
    public float maxInputCooldownTimer = 0.5f;
    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _rotationSpeed = 15f;
    [SerializeField]
    float _dashSpeedIncrease = 4f;

    Vector2 _velocity;
    Vector2 _rotation;
    Rigidbody _rigidBody;
    bool _hasDashed = false;
    float _inputCooldownTimer = 0f;
    float _dashCooldownTimer = 0f;
    bool _allowInput = true;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
        _dashCooldownTimer = maxDashCooldownTimer;
        _inputCooldownTimer = maxInputCooldownTimer;
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
                _dashCooldownTimer = maxDashCooldownTimer;
            }

            _inputCooldownTimer -= Time.deltaTime;
            if(_inputCooldownTimer <= 0f)
            {
                _allowInput = true;
                _inputCooldownTimer = maxInputCooldownTimer;
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
        if (_allowInput)
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
        _allowInput = false;
        HandleDash();
    }
}
