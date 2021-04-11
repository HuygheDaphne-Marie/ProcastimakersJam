using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField]
    AudioClip _bounceSound;
    [SerializeField]
    AudioClip _neutralSound;
    [SerializeField]
    AudioClip _grabSound;
    [SerializeField]
    AudioClip _shootSound;
    [SerializeField]
    AudioClip _dashSound;
    [SerializeField]
    AudioClip _powerupSound;
    // Start is called before the first frame update
    public void PlayBounce()
    {
        this.GetComponent<AudioSource>().PlayOneShot(_bounceSound);
    }
    public void PlayNeutral()
    {
        this.GetComponent<AudioSource>().PlayOneShot(_neutralSound);

    }
    public void PlayGrab()
    {
        this.GetComponent<AudioSource>().PlayOneShot(_grabSound);
    }
    public void PlayShoot()
    {
        this.GetComponent<AudioSource>().PlayOneShot(_shootSound);
    }
    public void PlayDash()
    {
        this.GetComponent<AudioSource>().PlayOneShot(_dashSound);
    }
    public void PlayPowerup()
    {
        this.GetComponent<AudioSource>().PlayOneShot(_powerupSound);
    }
}
