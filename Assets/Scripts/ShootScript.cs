using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ShootScript : MonoBehaviour
{
    [SerializeField]
    Transform HoldPosition;
    [SerializeField]
    float _shootForce = 100;
    [SerializeField]
    float _maxTimeBallCanBeHeld = 5f;
    [SerializeField]
    Image _timerImage;
    [SerializeField]
    float _rumbleTime = 0.3f;
    [SerializeField]
    float _rumbleStrength = 0.1f;

    public bool _isHolding;
    float _holdCooldown = 0.5f;
    [SerializeField]
    float _maxHoldCooldown = 1.0f;
    bool _canHold = true;
    GameObject _ball;
    float _timeBallHeld = 0f;
    float _currentRumbleTimer = 0f;
    bool _isRumbling = false;
    Gamepad _gamepad;

    Animator _bodyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _bodyAnimator = transform.GetChild(0).GetComponent<Animator>();
        _ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (_isHolding)
        {
            _ball.transform.position = HoldPosition.position;
            _timeBallHeld -= Time.deltaTime;
            _timerImage.fillAmount = _timeBallHeld / _maxTimeBallCanBeHeld;
        }
        if (_timeBallHeld <= 0)
        {
            Shoot();
        }
        if (!_canHold)
        {
            _holdCooldown -= Time.deltaTime;
            if (_holdCooldown <= 0)
            {
                _canHold = true;
                _holdCooldown = _maxHoldCooldown;
            }
        }
        if (_isRumbling)
        {
            _currentRumbleTimer += Time.deltaTime;
            if (_currentRumbleTimer >= _rumbleTime)
            {
                _currentRumbleTimer = 0f;
                _isRumbling = false;
                _gamepad.PauseHaptics();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && _canHold)
        {
            GameObject.Find("SoundManager").GetComponent<AudioSource>().pitch = 1;
            GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().PlayGrab();
            _bodyAnimator.SetTrigger("Catch");
            _isHolding = true;
            _timeBallHeld = _maxTimeBallCanBeHeld;
            _ball.GetComponent<Collider>().enabled = false;
            _ball.GetComponent<BallColourChange>().OnCatch();
        }
    }

    private void Shoot()
    {
        if (_isHolding)
        {
            _bodyAnimator.SetTrigger("Shoot");
            _isHolding = false;
            _timerImage.fillAmount = 0;
            _ball.GetComponent<Collider>().enabled = true;
            _ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            _ball.GetComponent<Rigidbody>().AddForce((_bodyAnimator.gameObject.transform.forward * _shootForce), ForceMode.Impulse);
            _ball.GetComponent<BallColourChange>().OnShoot();
            GameObject.Find("SoundManager").GetComponent<AudioSource>().pitch = 1;
            GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().PlayShoot();
            _canHold = false;
        }
    }

    private void OnShoot(InputValue value)
    {
        var gamepads = Gamepad.all;
        foreach (Gamepad element in gamepads)
        {
            if(element.leftTrigger.wasPressedThisFrame)
            {
                _gamepad = element;
            }
        }
        _gamepad.SetMotorSpeeds(_rumbleStrength, _rumbleStrength);
        _isRumbling = true;
        Shoot();
    }


}
