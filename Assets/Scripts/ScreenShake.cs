using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float _shake;
    private Vector3 _startPos;


    // Start is called before the first frame update
    void Start()
    {
        _startPos = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        _shake = Mathf.Lerp(_shake, 0, Time.deltaTime * 5);
        transform.position = _startPos + new Vector3(Random.Range(-_shake, _shake), Random.Range(-_shake, _shake), 0);
    }

    public void Shake(float shake)
    {
        _shake += shake;
    }
}
