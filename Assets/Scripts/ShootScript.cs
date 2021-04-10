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

    public bool _isHolding;
    float _holdCooldown = 0.5f;
    [SerializeField]
    float _maxHoldCooldown = 1.0f;
    bool _canHold = true;
    GameObject _ball;
    float _timeBallHeld = 0f;

    // Start is called before the first frame update
    void Start()
    {
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
        if(_timeBallHeld <= 0)
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && _canHold)
        {
            _isHolding = true;
            _timeBallHeld = _maxTimeBallCanBeHeld;
            _ball.GetComponent<Collider>().enabled = false;
        }
    }

    private void Shoot()
    {
        if (_isHolding)
        {
            _isHolding = false;
            _timerImage.fillAmount = 0;
            _ball.GetComponent<Collider>().enabled = true;
            _ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            _ball.GetComponent<Rigidbody>().AddForce((this.gameObject.transform.forward * _shootForce), ForceMode.Impulse);
            _ball.GetComponent<BallColourChange>().OnShoot();
            _canHold = false;
        }
    }

    private void OnShoot(InputValue value)
    {
        Shoot();
        Debug.Log("Shoot");
    }


}
