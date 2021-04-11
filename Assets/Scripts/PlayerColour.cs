using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerColour : MonoBehaviour
{
    private Material _myTeamMaterial;
    public Material TeamOneMaterial;
    public Material TeamTwoMaterial;

    private Color _myColor;
    public Color TeamOneColor;
    public Color TeamTwoColor;

    private Material[] _myTeamBodyMaterials;
    public Material[] TeamOneBodyMaterials;
    public Material[] TeamTwoBodyMaterials;

    private SkinnedMeshRenderer _bodyRenderer;
    private MeshRenderer _baseRenderer;
    private TrailRenderer _trailRenderer;
    private Image _timerImage;
    private Text _playerNumber;
    private Image _panelImage;

    private PlayerInputManager _playerInputManager;

    static public bool IsBallNeutral = true;
    static public bool DoesTeamOneHoldBall = false;
    static private int _blueteamPlayers = 0;
    static private int _redTeamPlayers = 0;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();

        _bodyRenderer = transform.GetChild(0).GetChild(2).GetComponent<SkinnedMeshRenderer>();
        _baseRenderer = transform.GetChild(1).GetComponent<MeshRenderer>();
        _trailRenderer = GetComponent<TrailRenderer>();
        _timerImage = transform.GetChild(2).GetChild(0).GetComponent<Image>(); 
        _playerNumber = transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Text>(); // dot hell
        _panelImage = transform.GetChild(2).GetChild(2).GetComponent<Image>(); // dot hell

        if (_playerInputManager.playerCount % 2 != 0)
        {
            _myColor = TeamOneColor;
            _myTeamMaterial = TeamOneMaterial;
            _myTeamBodyMaterials = TeamOneBodyMaterials;
            _blueteamPlayers++;
            _playerNumber.text = _blueteamPlayers.ToString();
            
        }
        else
        {
            _myColor = TeamTwoColor;
            _myTeamMaterial = TeamTwoMaterial;
            _myTeamBodyMaterials = TeamTwoBodyMaterials;
            _redTeamPlayers++;
            _playerNumber.text = _redTeamPlayers.ToString();

        }
        _panelImage.color = _myColor;
        SetInstanceColorToTeamColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ChangeBallColorToTeamColor(other.gameObject);
        }
    }

    private void SetInstanceColorToTeamColor()
    {
        _timerImage.color = _myColor;
        _trailRenderer.material = _myTeamMaterial;
        _baseRenderer.material = _myTeamBodyMaterials[_myTeamBodyMaterials.Length - 1];

        Material[] uppMaterials = { _myTeamBodyMaterials[0], _myTeamBodyMaterials[1], _myTeamBodyMaterials[2]};
        _bodyRenderer.materials = uppMaterials;
    }

    private void ChangeBallColorToTeamColor(GameObject ball)
    {
        ball.GetComponent<BallColourChange>().SetDynamicMaterials(_myTeamMaterial);
        if(_myTeamMaterial == TeamOneMaterial)
        {
            DoesTeamOneHoldBall = true;
            Debug.Log("Team One!");
        }
        else
        {
            DoesTeamOneHoldBall = false;
            Debug.Log("Team Two!");
        }
        IsBallNeutral = false;
    }
}
