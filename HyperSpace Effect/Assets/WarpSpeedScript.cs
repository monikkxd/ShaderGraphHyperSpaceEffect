using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class WarpSpeedScript : MonoBehaviour
{

    public VisualEffect WarpSpeedVFX;

    private bool warpActive;

    // Start is called before the first frame update
    void Start()
    {
        WarpSpeedVFX.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            warpActive = true;
            StartCoroutine(ActivateParticles());
        }
    }

    IEnumerator ActivateParticles()
    {
        if (warpActive) 
        { 
            WarpSpeedVFX.Play();

            float amount = WarpSpeedVFX.GetFloat("WarpAmount");
        }
        else
        {
            WarpSpeedVFX.Stop();

        }
    }
}
