using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallColourChange : MonoBehaviour
{

    public Material NeutralMaterial;
    private GameObject[] _dynamicWalls;

    public float NeutralCountdown = 5.0f;
    private float _neutralTimer = 0.0f;
    private bool _isShot = false;

    // Start is called before the first frame update
    void Start()
    {
        _dynamicWalls = GameObject.FindGameObjectsWithTag("Wall");

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
        return GetComponent<Renderer>().material == NeutralMaterial;
    }

    public void SetDynamicMaterials(Material material)
    {
        GetComponent<Renderer>().material = material;
        GetComponent<TrailRenderer>().material = material;
        GetComponent<ParticleSystemRenderer>().material = material;

        foreach (GameObject wall in _dynamicWalls)
        {
            wall.transform.GetChild(2).GetComponent<Renderer>().material = material;
        }
    }

    public void SetColourToNeutral()
    {
        GetComponent<Renderer>().material = NeutralMaterial;
        GetComponent<TrailRenderer>().material = NeutralMaterial;
        GetComponent<ParticleSystemRenderer>().material = NeutralMaterial;

        foreach (GameObject wall in _dynamicWalls)
        {
            wall.transform.GetChild(2).GetComponent<Renderer>().material = NeutralMaterial;
        }

        GameObject.Find("SoundManager").GetComponent<AudioSource>().pitch = 1;
        GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().PlayNeutral();
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
