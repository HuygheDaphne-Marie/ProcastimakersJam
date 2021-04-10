using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallColourChange : MonoBehaviour
{

    [ColorUsage(true, true)]
    public Color NeutralColor;

    public float NeutralCountdown = 5.0f;
    private float _neutralTimer = 0.0f;
    private bool _isShot = false;

    // Start is called before the first frame update
    void Start()
    {
        SetColourToNeutral();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!IsBallNeutral() && _isShot)
        {
            //Debug.Log("updating timer");
            _neutralTimer += Time.deltaTime;
            if (NeutralCountdown < _neutralTimer)
            {
                //Debug.Log("Changing Colour to neutral!");
                SetColourToNeutral();
                _neutralTimer = 0.0f;
            }
        }
    }

    public bool IsBallNeutral()
    {
        return GetComponent<MeshRenderer>().sharedMaterial.color == NeutralColor;
    }

    void SetColourToNeutral()
    {
        GetComponent<MeshRenderer>().sharedMaterial.color = NeutralColor;
        GetComponent<MeshRenderer>().sharedMaterial.SetColor("_EmissionColor", NeutralColor);
        _isShot = false;
    }

    public void OnShoot()
    {
        //Debug.Log("Is Shot!");
        _isShot = true;
    }

    public void OnCatch()
    {
        _neutralTimer = 0.0f;
        _isShot = false;
    }
}
