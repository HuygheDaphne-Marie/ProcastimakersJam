using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject[] _playerSpawns;
    private PlayerInputManager _playerInputManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();
        _playerSpawns = GameObject.FindGameObjectsWithTag("Respawn");

        transform.position = _playerSpawns[_playerInputManager.playerCount - 1].transform.position;
    }
}
