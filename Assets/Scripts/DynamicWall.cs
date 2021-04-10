using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicWall : MonoBehaviour
{
    public float Distance = 10.0f;
    //public float MaxSpeed = 10.0f; //Speed is being a bitch, need to increase frequency of the wave without changing the amplitude
    public bool IsMovingVertically = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 translation = new Vector3();
        float distanceToMove = Distance * Mathf.Sin(Time.time) * Time.deltaTime;

        if (IsMovingVertically)
        {
            translation.y = distanceToMove;
        }
        else
        {
            translation.x = distanceToMove;
        }

        transform.Translate(translation);
    }
}
