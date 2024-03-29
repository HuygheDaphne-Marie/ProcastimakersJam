using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPickupScript : MonoBehaviour
{
    [SerializeField]
    float _timePerPickupSpawn = 10f;
    [SerializeField]
    List<GameObject> _prefabs;

    GameObject[] _pickupSpawns;
    Vector3 _previousSpawnLocation;
    private PlayerInputManager _playerInputManager;
    float _currentTime;

    enum TypeOfPickup : int
    {
        Speed = 0,

    };
    // Start is called before the first frame update
    void Start()
    {
        _pickupSpawns = GameObject.FindGameObjectsWithTag("PickupSpawn");
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInputManager.playerCount <= 0 && _playerInputManager.playerCount > 1) // we only want to spawn pickups if there are > 1 players on the field
        {
            return;
        }

        if (GameObject.FindGameObjectsWithTag("Pickup").Length == 0) // only try to spawn a pickup if there are none present
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _timePerPickupSpawn)
            {
                _currentTime = 0f;

                Vector3 location;

                if (_previousSpawnLocation == Vector3.zero)
                {
                    location = _pickupSpawns[Random.Range(0, _pickupSpawns.Length)].transform.position;
                }
                else
                {
                    do
                    {
                        location = _pickupSpawns[Random.Range(0, _pickupSpawns.Length)].transform.position;
                    } while (location == _previousSpawnLocation);
                }

                Debug.Log(location);
                GameObject.Instantiate(_prefabs[Random.Range(0, _prefabs.Count)], location, Quaternion.identity);
                _previousSpawnLocation = location;
            }
        }
    }
}
