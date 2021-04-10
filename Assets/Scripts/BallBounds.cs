using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounds : MonoBehaviour
{
    private GameObject[] _bounds; // left, top, right, bottom
    private GameObject[] _possibleBallSpawns;

    private GameObject _leftBound;
    private GameObject _topBound;
    private GameObject _rightBound;
    private GameObject _bottomBound;

    // Start is called before the first frame update
    void Start()
    {
        _possibleBallSpawns = GameObject.FindGameObjectsWithTag("BallSpawn");
        _bounds = GameObject.FindGameObjectsWithTag("Bound");
        AssignBounds();
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
        if (transform.position.y > _topBound.transform.position.y)
        {
            RespawnBall();
        }
        if (transform.position.y < _bottomBound.transform.position.y)
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

    void AssignBounds()
    {
        int indexWithSmallestX = 0;
        int indexWithBiggestX = 0;
        int indexWithSmallestY = 0;
        int indexWithBiggestY = 0;

        for(int index = 1; index < _bounds.Length; index++)
        {
            GameObject boundAtIndex = _bounds[index];
            
            if(boundAtIndex.transform.position.x < _bounds[indexWithSmallestX].transform.position.x)
            {
                indexWithSmallestX = index;
            }
            if (boundAtIndex.transform.position.x > _bounds[indexWithBiggestX].transform.position.x)
            {
                indexWithBiggestX = index;
            }

            if (boundAtIndex.transform.position.y < _bounds[indexWithSmallestY].transform.position.y)
            {
                indexWithSmallestY = index;
            }
            if (boundAtIndex.transform.position.y > _bounds[indexWithBiggestY].transform.position.y)
            {
                indexWithBiggestY = index;
            }
        }

        _leftBound = _bounds[indexWithSmallestX];
        _rightBound = _bounds[indexWithBiggestX];
        _topBound = _bounds[indexWithBiggestY];
        _bottomBound = _bounds[indexWithSmallestY];
    }
}
