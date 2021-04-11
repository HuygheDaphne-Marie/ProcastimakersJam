using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    Transform _panel;
    Transform _controls;
    Transform _tutorial;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        var canvas = GameObject.Find("Canvas");
        _panel = canvas.transform.GetChild(0);
        _controls = canvas.transform.GetChild(1);
        _tutorial = canvas.transform.GetChild(2);

        _controls.gameObject.SetActive(false);
        _tutorial.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnControlsPress()
    {
        _controls.gameObject.SetActive(true);
        _panel.gameObject.SetActive(false);

        _controls.GetComponentInChildren<Button>().Select();
    }

    public void OnTutorialPress()
    {
        _tutorial.gameObject.SetActive(true);
        _panel.gameObject.SetActive(false);

        _tutorial.GetComponentInChildren<Button>().Select();
    }

    public void OnBackPress()
    {
        _controls.gameObject.SetActive(false);
        _tutorial.gameObject.SetActive(false);

        _panel.gameObject.SetActive(true);

        _panel.GetComponentInChildren<Button>().Select();
    }
}
