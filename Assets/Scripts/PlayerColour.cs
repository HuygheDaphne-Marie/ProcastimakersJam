using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColour : MonoBehaviour
{
    [ColorUsage(true, true)]
    public Color TeamColour;

    // Start is called before the first frame update
    void Start()
    {
        //TeamColour = transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = TeamColour;
            other.gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_EmissionColor", TeamColour);
        }
    }
}
