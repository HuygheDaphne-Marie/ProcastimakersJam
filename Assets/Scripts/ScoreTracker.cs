using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField]
    int _scorePerTick = 5;
    [SerializeField]
    float _tickDuration = 0.5f;

    [SerializeField]
    public static float GameTime = 10;


    MeshRenderer _ballMeshRenderer;
    public static int TeamOneScore = 0;
    public static int TeamTwoScore = 0;
    float _currentTickDuration = 0.0f;
    private PlayerInputManager _playerInputManager;
    bool _startGame = false;
    bool _teamColoursSet = false;
    Material _teamOneMaterial;
    Material _teamTwoMaterial;

    public static bool HasScoreBeenAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        _ballMeshRenderer = GameObject.FindGameObjectWithTag("Ball").GetComponent<MeshRenderer>();
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HasScoreBeenAdded = false;

        if (_startGame)
        {
            GameTime -= Time.deltaTime;
            if(GameTime <= 0f)
            {
                SceneManager.LoadScene("EndScreen");
            }
        }

        if (!_teamColoursSet && _playerInputManager.playerCount > 0)
        {
            _startGame = true;
            _teamColoursSet = true;
            var playercolour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerColour>();
            _teamOneMaterial = playercolour.TeamOneMaterial;
            _teamTwoMaterial = playercolour.TeamTwoMaterial;
        }

        bool isNotNeutral = false;
        bool doesTeamOneHoldTheBall = false;

        if (!PlayerColour.IsBallNeutral)
        {
            isNotNeutral = true;
            if (PlayerColour.DoesTeamOneHoldBall)
            {
                doesTeamOneHoldTheBall = true;
            }
        }

        if (isNotNeutral)
        {
            _currentTickDuration += Time.deltaTime;
            if (_currentTickDuration >= _tickDuration)
            {
                if (doesTeamOneHoldTheBall)
                {
                    TeamOneScore += _scorePerTick;
                }
                else
                {
                    TeamTwoScore += _scorePerTick;
                }
                HasScoreBeenAdded = true;
                _currentTickDuration = 0f;
            }
        }
        else
        {
            _currentTickDuration = 0f;
        }
    }
}
