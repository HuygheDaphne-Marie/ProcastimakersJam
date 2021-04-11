using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    [SerializeField]
    float _speedMultiplier = 2f;
    [SerializeField]
    float _speedBoostDuration = 3f;

    GameObject _boostedPlayer;
    CharacterMovement _playerMovement;
    float _currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_boostedPlayer != null)
        {
            _currentTime += Time.deltaTime;

            if(_currentTime >= _speedBoostDuration)
            {
                _playerMovement.RemoveSpeedBoost(_speedMultiplier);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            _boostedPlayer = collision.collider.gameObject;
            _playerMovement = _boostedPlayer.GetComponent<CharacterMovement>();
            _playerMovement.AddSpeedBoost(_speedMultiplier);
            this.GetComponent<ParticleSystem>().Play();
            GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().PlayPowerup();
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
