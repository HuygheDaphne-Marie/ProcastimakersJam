using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField]
    AudioClip _buttonSound;
    // Start is called before the first frame update
    public void PlayButtonSound()
    {
        this.GetComponent<AudioSource>().PlayOneShot(_buttonSound);
    }
}
