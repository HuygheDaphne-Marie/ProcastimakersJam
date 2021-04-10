using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerColour : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color MyTeamColor;

    [ColorUsage(true, true)]
    public Color TeamOneColor;
    [ColorUsage(true, true)]
    public Color TeamTwoColor;

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
            MyTeamColor = TeamOneColor;
        }
        else
        {
            MyTeamColor = TeamTwoColor;
        }

        SetInstanceColorToTeamColor();
    }

    //// Update is called once per frame
    //void Update()
    //{
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            ChangeBallColorToTeamColor(other.gameObject);
        }
    }

    private void SetInstanceColorToTeamColor()
    {
        _bodyRenderer.material.color = MyTeamColor;
        _bodyRenderer.material.SetColor("_EmissionColor", MyTeamColor);

        _armRenderer.material.color = MyTeamColor;
        _armRenderer.material.SetColor("_EmissionColor", MyTeamColor);
    }

    private void ChangeBallColorToTeamColor(GameObject ball)
    {
        ball.GetComponent<MeshRenderer>().sharedMaterial.color = MyTeamColor;
        ball.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_EmissionColor", MyTeamColor);
    }
}
