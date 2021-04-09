using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    float _speed = 5f;
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if(movement != Vector3.zero)
        {
            _rigidBody.velocity = new Vector3(movement.x * _speed, 0f, movement.z * _speed);
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
        }
    }
}
