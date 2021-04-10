using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerColour : MonoBehaviour
{
    private Material _myTeamMaterial;
    public Material TeamOneMaterial;
    public Material TeamTwoMaterial;

    public Material[] _myTeamBodyMaterials;
    public Material[] TeamOneBodyMaterials;
    public Material[] TeamTwoBodyMaterials;

    private MeshRenderer _bodyRenderer;
    private MeshRenderer _baseRenderer;
    private TrailRenderer _trailRenderer;
    private PlayerInputManager _playerInputManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();

        _bodyRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        _baseRenderer = transform.GetChild(1).GetComponent<MeshRenderer>();
        _trailRenderer = GetComponent<TrailRenderer>();

        if (_playerInputManager.playerCount % 2 == 0)
        {
            _myTeamMaterial = TeamOneMaterial;
            _myTeamBodyMaterials = TeamOneBodyMaterials;
        }
        else
        {
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
        _trailRenderer.material = _myTeamMaterial;
        _baseRenderer.material = _myTeamBodyMaterials[_myTeamBodyMaterials.Length - 1];

        Material[] uppMaterials = { _myTeamBodyMaterials[0], _myTeamBodyMaterials[1], _myTeamBodyMaterials[2]};
        _bodyRenderer.materials = uppMaterials;
        //for (int i = 0; i < _myTeamBodyMaterials.Length - 1; i++)
        //{
        //    _bodyRenderer.materials[i] = _myTeamBodyMaterials[i];
        //}
    }

    private void ChangeBallColorToTeamColor(GameObject ball)
    {
        ball.GetComponent<BallColourChange>().SetDynamicMaterials(_myTeamMaterial);
    }
}
