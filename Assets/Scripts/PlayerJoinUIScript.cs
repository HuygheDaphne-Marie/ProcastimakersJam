using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerJoinUIScript : MonoBehaviour
{
    [SerializeField]
    float _timeToJoin = 10f;

    private PlayerInputManager _playerInputManager;
    Transform _upperLeftPanel;
    Transform _upperRightPanel;
    Transform _lowerLeftPanel;
    Transform _lowerRightPanel;
    float _currentTime = 0f;
    bool _hasUIBeenDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();
        var canvas = GameObject.Find("Canvas");
        _upperLeftPanel = canvas.transform.GetChild(0);
        _upperRightPanel = canvas.transform.GetChild(1);
        _lowerLeftPanel = canvas.transform.GetChild(2);
        _lowerRightPanel = canvas.transform.GetChild(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hasUIBeenDisabled)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeToJoin)
            {
                DisabeAllUI();
                _hasUIBeenDisabled = true;
            }
            else
            {
                if (_playerInputManager.playerCount >= 1)
                {
                    _upperLeftPanel.GetComponent<Image>().enabled = false;
                }
                if (_playerInputManager.playerCount >= 2)
                {
                    _upperRightPanel.GetComponent<Image>().enabled = false;
                }
                if (_playerInputManager.playerCount >= 3)
                {
                    _lowerLeftPanel.GetComponent<Image>().enabled = false;
                }
                if (_playerInputManager.playerCount >= 4)
                {
                    _lowerRightPanel.GetComponent<Image>().enabled = false;
                    _hasUIBeenDisabled = true;
                }
            }
        }
    }

    private void DisabeAllUI()
    {
        _upperLeftPanel.GetComponent<Image>().enabled = false;
        _upperRightPanel.GetComponent<Image>().enabled = false;
        _lowerLeftPanel.GetComponent<Image>().enabled = false;
        _lowerRightPanel.GetComponent<Image>().enabled = false;
    }
}
