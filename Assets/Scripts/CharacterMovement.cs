using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
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
    [SerializeField]
    Image _dashTimerImage;



    Vector2 _inputMovement;
    Vector2 _inputRotation;
    Rigidbody _rigidBody;
    bool _hasDashed = false;
    float _inputCooldownTimer = 0f;
    float _dashCooldownTimer = 0f;
    bool _allowInput = true;
    bool _MustDash = false;
    ShootScript _shootScript;
    TrailRenderer _trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody>();
        _shootScript = this.transform.GetComponent<ShootScript>();
        _dashCooldownTimer = maxDashCooldownTimer;
        _inputCooldownTimer = maxInputCooldownTimer;
        _trailRenderer = this.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasDashed)
        {
            _dashCooldownTimer -= Time.deltaTime;
            _dashTimerImage.fillAmount = _dashCooldownTimer / maxDashCooldownTimer;

            if (_dashCooldownTimer <= 0f)
            {
                _hasDashed = false;
                _dashCooldownTimer = maxDashCooldownTimer;
            }

            _inputCooldownTimer -= Time.deltaTime;
            if (_inputCooldownTimer <= 0f)
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
        HandleDash();
    }

    private void HandleMovement()
    {
        if (_allowInput)
        {
            if (_inputMovement != Vector2.zero)
            {
                _rigidBody.velocity = new Vector3((_inputMovement.x * _speed) + _rigidBody.velocity.x, 0f, (_inputMovement.y * _speed) + _rigidBody.velocity.z);
            }
            else
            {
                _rigidBody.velocity = Vector3.zero;
            }
        }
    }

    private void HandleRotation()
    {
        if (_inputRotation != Vector2.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(_inputRotation.x, 0f, _inputRotation.y), Vector3.up);

            _rigidBody.rotation = Quaternion.Lerp(_rigidBody.rotation, newRotation, _rotationSpeed);
        }
        else
        {
            _rigidBody.angularVelocity = Vector3.zero;
        }
    }

    private void HandleDash()
    {
        if (_MustDash && !_hasDashed)
        {
            // _rigidBody.velocity.Normalize();
            // _rigidBody.velocity = new Vector3(_rigidBody.velocity.x * _dashSpeedIncrease, 0f, _rigidBody.velocity.z * _dashSpeedIncrease);
            // Debug.Log(_rigidBody.velocity);

            _hasDashed = true;
            _MustDash = false;

            Vector3 currentVelocity = _rigidBody.velocity;
            currentVelocity.Normalize();
            _rigidBody.velocity = Vector3.zero;
            _rigidBody.AddForce(new Vector3(currentVelocity.x * _dashSpeedIncrease, currentVelocity.y, currentVelocity.z * _dashSpeedIncrease), ForceMode.Impulse);
        }
    }

    public void AddSpeedBoost(float multiplier)
    {
        _speed *= multiplier;
        _trailRenderer.enabled = true;
    }
    public void RemoveSpeedBoost(float multiplier)
    {
        _speed /= multiplier;
        _trailRenderer.enabled = false;
    }

    private void OnMove(InputValue inputValue)
    {
        if (_allowInput)
        {
            _inputMovement = inputValue.Get<Vector2>();
        }
    }
    private void OnTurn(InputValue inputValue)
    {
        _inputRotation = inputValue.Get<Vector2>();
    }
    private void OnDash(InputValue inputValue)
    {
        if (!_hasDashed && !_shootScript._isHolding)
        {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().pitch = 1;
            GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().PlayDash();
            //_hasDashed = true;
            _allowInput = false;
            _MustDash = true;
        }
    }
}
