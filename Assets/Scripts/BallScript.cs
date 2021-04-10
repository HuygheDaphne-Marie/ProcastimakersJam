using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    ParticleSystem _particles;
    ScreenShake _shakeScript;
    // Start is called before the first frame update
    void Start()
    {
        _particles = this.GetComponent<ParticleSystem>();
        _shakeScript = Camera.main.GetComponent<ScreenShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        _particles.Play();
        _shakeScript.Shake(0.2f);
        SoundManagerScript script = GameObject.Find("SoundManager").GetComponent<SoundManagerScript>();
        script.PlayBounce();
        GameObject.Find("SoundManager").GetComponent<AudioSource>().pitch = Random.Range(0.5f, 2.0f);
    }
}
