using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3( 10, 0, 10 ), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
