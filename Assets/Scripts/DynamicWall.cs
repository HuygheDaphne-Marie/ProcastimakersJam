using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWall : MonoBehaviour
{
    Transform _point1;
    Transform _point2;
    public float Speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        _point1 = this.transform.GetChild(0).transform;
        _point2 = this.transform.GetChild(1).transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
