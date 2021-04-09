using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShootScript : MonoBehaviour
{
    [SerializeField]
    Transform HoldPosition;
    bool _isHolding;
    float _holdCooldown = 0.5f;
    bool _canHold = true;
    GameObject _ball;
    [SerializeField]
    float _shootForce = 100;

    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if(_isHolding)
        {
            _ball.transform.position = HoldPosition.position;
        }
        if(!_canHold)
        {
            _holdCooldown -= Time.deltaTime;
            if(_holdCooldown <= 0)
            {
                _canHold = true;
                _holdCooldown = 0.5f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball" && _canHold)
        {
            _isHolding = true;
            _ball.GetComponent<Collider>().enabled = false;
        }
    }

    private void Shoot()
    {
        if(_isHolding)
        {
        _isHolding = false;
        _ball.GetComponent<Collider>().enabled = true;
        _ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        _ball.GetComponent<Rigidbody>().AddForce((this.gameObject.transform.forward * _shootForce), ForceMode.Impulse);
            _canHold = false;
        }
    }

    private void OnShoot(InputValue value)
    {
        Shoot();
        Debug.Log("Shoot");
    }


}
