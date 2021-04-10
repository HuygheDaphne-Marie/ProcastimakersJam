using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounds : MonoBehaviour
{
    private GameObject[] _bounds; // left, top, right, bottom
    private GameObject[] _possibleBallSpawns;

    // Start is called before the first frame update
    void Start()
    {
        _bounds = GameObject.FindGameObjectsWithTag("Bound");
        _possibleBallSpawns = GameObject.FindGameObjectsWithTag("BallSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        // Left & right
        if(transform.position.x < _bounds[0].transform.position.x)
        {
            RespawnBall();
        }
        if (transform.position.x > _bounds[2].transform.position.x)
        {
            RespawnBall();
        }

        // Top & bottom
        if (transform.position.y > _bounds[1].transform.position.y)
        {
            RespawnBall();
        }
        if (transform.position.y < _bounds[3].transform.position.y)
        {
            RespawnBall();
        }
    }

    void RespawnBall()
    {
        Debug.Log("Respawning Ball!");
        int randomIndex = Random.Range(0, _possibleBallSpawns.Length - 1);
        transform.position = _possibleBallSpawns[randomIndex].transform.position;
        GetComponent<BallColourChange>().SetColourToNeutral();
    }
}
