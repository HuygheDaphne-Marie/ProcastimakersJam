using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour
{
    GameObject _PauseMenu;

    public static bool _isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        _PauseMenu = GameObject.Find("PauseUI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPauseGame(InputValue value)
    {
        if (!_isPaused)
        {
            Time.timeScale = 0;
            _isPaused = true;
            _PauseMenu.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            _isPaused = false;
            Time.timeScale = 1;
            _PauseMenu.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
