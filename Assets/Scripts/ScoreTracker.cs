using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField]
    int _scorePerTick = 5;
    [SerializeField]
    float _tickDuration = 0.5f;

    [SerializeField]
    public static float _gameTime = 120;



    MeshRenderer _ballMeshRenderer;
    public static int _teamOneScore = 0;
    public static int _teamTwoScore = 0;
    float _currentTickDuration = 0.0f;
    private PlayerInputManager _playerInputManager;
    bool _startGame = false;
    bool _teamColoursSet = false;
    Material _teamOneMaterial;
    Material _teamTwoMaterial;

    // Start is called before the first frame update
    void Start()
    {
        _ballMeshRenderer = GameObject.FindGameObjectWithTag("Ball").GetComponent<MeshRenderer>();
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_startGame)
            _gameTime -= Time.deltaTime;
       
        if(!_teamColoursSet && _playerInputManager.playerCount > 0)
        {
            _startGame = true;
            _teamColoursSet = true;
            var playercolour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerColour>();
            _teamOneMaterial = playercolour.TeamOneMaterial;
            _teamTwoMaterial = playercolour.TeamTwoMaterial;
        }

        bool isTheBallBeingHeld = false;
        bool doesTeamOneHoldTheBall = false;

        if (_ballMeshRenderer.material == _teamOneMaterial)
        {
            isTheBallBeingHeld = true;
            doesTeamOneHoldTheBall = true;
        }
        else if (_ballMeshRenderer.material == _teamTwoMaterial)
        {
            isTheBallBeingHeld = true;
        }
        
        Debug.Log("Team 1 Score: " + _teamOneScore + " Team 2 Score: " + _teamTwoScore);

        if (isTheBallBeingHeld)
        {
            _currentTickDuration += Time.deltaTime;
            if (_currentTickDuration >= _tickDuration)
            {
                if (doesTeamOneHoldTheBall)
                {
                    _teamOneScore += _scorePerTick;
                }
                else
                {
                    _teamTwoScore += _scorePerTick;
                }
                _currentTickDuration = 0f;
            }
        }
        else
        {
            _currentTickDuration = 0f;
        }
    }
}
