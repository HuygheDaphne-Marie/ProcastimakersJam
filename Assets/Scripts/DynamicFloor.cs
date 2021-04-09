using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFloor : MonoBehaviour
{
    public float WalkableTime = 5.0f;
    public float UnwalkableTime = 2.0f;
    private float _timePassed = 0.0f;
    private bool _isWalkable = true;
    private Collider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        _timePassed += Time.deltaTime;
        if (_isWalkable)
        {
            if (_timePassed > WalkableTime)
            {
                ToggleWalkable();
                _timePassed -= WalkableTime;
            }
        }
        else
        {
            if (_timePassed > UnwalkableTime)
            {
                ToggleWalkable();
                _timePassed -= UnwalkableTime;
            }
        }
    }

    void ToggleWalkable()
    {
        _isWalkable = !_isWalkable;
        _collider.enabled = _isWalkable;
    }
}
