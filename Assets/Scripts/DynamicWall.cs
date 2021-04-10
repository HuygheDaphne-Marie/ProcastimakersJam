using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWall : MonoBehaviour
{
    Transform _platform;
    Transform _point1;
    Transform _point2;
    Vector3 _moveToTarget;
    public float Speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        _point1 = this.transform.GetChild(0).transform;
        _point2 = this.transform.GetChild(1).transform;
        _platform = this.transform.GetChild(2).transform;
        _moveToTarget = _point1.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveToVector = _moveToTarget - this.transform.position;
        moveToVector.Normalize();
        _platform.transform.Translate(moveToVector * Speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(_platform.transform.position, _moveToTarget) <= 0.5f)
        {
            if(_moveToTarget == _point1.position)
            {
                _moveToTarget = _point2.position;
            }
            else
            {
                _moveToTarget = _point1.position;
            }
        }
    }
}
