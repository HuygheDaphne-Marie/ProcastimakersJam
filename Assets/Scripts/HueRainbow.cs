using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueRainbow : MonoBehaviour
{

    public float TimeSpentPerHue = 1.0f;
    private float _currentHueTime = 0.0f;

    private int _currentHueIndex = 0;
    private Color[] _rainbowHues = { 
        new Color(255, 0, 0, 1),
        new Color(255, 0, 255, 1),
        new Color(0, 0, 255, 1),
        new Color(0, 255, 255, 1),
        new Color(0, 255, 0, 1),
        new Color(255, 255, 0, 1)
    };

    private Material _material;

    //Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _currentHueTime += Time.deltaTime;
        if(_currentHueTime > TimeSpentPerHue)
        {
            _currentHueTime -= TimeSpentPerHue;
            _currentHueIndex++;
            if(_currentHueIndex >= _rainbowHues.Length)
            {
                _currentHueIndex = 0;
            }
        }

        int nextHueIndex = _currentHueIndex + 1;
        if(nextHueIndex >= _rainbowHues.Length)
        {
            nextHueIndex = 0;
        }

        float timeFraction = (_currentHueTime / TimeSpentPerHue);
        Color lerpedColor = Color.Lerp(_rainbowHues[_currentHueIndex], _rainbowHues[nextHueIndex], timeFraction);
        _material.SetColor("Color_var", lerpedColor);

    }
}
