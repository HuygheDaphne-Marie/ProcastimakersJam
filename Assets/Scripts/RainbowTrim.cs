using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTrim : MonoBehaviour
{
    public GameObject[] _toChange;
    public Material _material;
    public GameObject Center;
    public AudioClip Song;

    private float _timer;
    public float WaitTime = 10f;
    bool _hasChanged = false;

    // Update is called once per frame
    void Update()
    {
        if (!ScoreTracker.HasScoreBeenAdded)
            _timer += Time.deltaTime;
        else
            _timer = 0;

        if (_timer >= WaitTime)
        {
            if(!_hasChanged)
            {
                foreach(GameObject o in _toChange)
                {
                    o.GetComponent<Renderer>().material = _material;
                }
                Material[] mats = Center.GetComponent<Renderer>().materials;
                mats[1] = _material;
                Center.GetComponent<Renderer>().materials = mats;
                _hasChanged = true;
                GameObject.Find("SoundManager").GetComponents<AudioSource>()[1].clip = Song;
                GameObject.Find("SoundManager").GetComponents<AudioSource>()[1].Play();
            }
            

        }
    }
}
