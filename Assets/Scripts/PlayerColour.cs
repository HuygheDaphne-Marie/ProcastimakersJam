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

    private MeshRenderer _bodyRenderer;
    private MeshRenderer _baseRenderer;
    private TrailRenderer _trailRenderer;
    private Image _timerImage;

    private PlayerInputManager _playerInputManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();

        _bodyRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        _baseRenderer = transform.GetChild(1).GetComponent<MeshRenderer>();
        _trailRenderer = GetComponent<TrailRenderer>();
        _timerImage = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>(); // dot hell

        if (_playerInputManager.playerCount % 2 != 0)
        {
            _myColor = TeamOneColor;
            _myTeamMaterial = TeamOneMaterial;
            _myTeamBodyMaterials = TeamOneBodyMaterials;
        }
        else
        {
            _myColor = TeamTwoColor;
            _myTeamMaterial = TeamTwoMaterial;
            _myTeamBodyMaterials = TeamTwoBodyMaterials;
        }

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
    }
}
