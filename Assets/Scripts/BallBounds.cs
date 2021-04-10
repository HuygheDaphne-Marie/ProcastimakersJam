using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounds : MonoBehaviour
{
    private GameObject[] _possibleBallSpawns;

    public GameObject _leftBound;
    public GameObject _topBound;
    public GameObject _rightBound;
    public GameObject _bottomBound;

    // Start is called before the first frame update
    void Start()
    {
        _possibleBallSpawns = GameObject.FindGameObjectsWithTag("BallSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        // Left & right
        if(transform.position.x < _leftBound.transform.position.x)
        {
            RespawnBall();
        }
        if (transform.position.x > _rightBound.transform.position.x)
        {
            RespawnBall();
        }

        // Top & bottom
        if (transform.position.z > _topBound.transform.position.z)
        {
            RespawnBall();
        }
        if (transform.position.z < _bottomBound.transform.position.z)
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
