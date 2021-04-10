using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerColour : MonoBehaviour
{
    private Material _myTeamMaterial;
    public Material TeamOneMaterial;
    public Material TeamTwoMaterial;

    private MeshRenderer _bodyRenderer;
    private MeshRenderer _armRenderer;

    private PlayerInputManager _playerInputManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerInputManager = GameObject.Find("PlayerInputManager").GetComponent<PlayerInputManager>();

        _bodyRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        _armRenderer = _bodyRenderer.transform.GetChild(0).GetComponent<MeshRenderer>();

        if (_playerInputManager.playerCount % 2 == 0)
        {
            _myTeamMaterial = TeamOneMaterial;
        }
        else
        {
            _myTeamMaterial = TeamTwoMaterial;
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
        _bodyRenderer.material = _myTeamMaterial;
        _armRenderer.material = _myTeamMaterial;

    }

    private void ChangeBallColorToTeamColor(GameObject ball)
    {
        ball.GetComponent<BallColourChange>().SetDynamicMaterials(_myTeamMaterial);
    }
}
