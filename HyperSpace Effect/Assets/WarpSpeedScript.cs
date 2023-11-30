using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class WarpSpeedScript : MonoBehaviour
{

    public VisualEffect WarpSpeedVFX;

    public float rate = 0.02f;

    private bool warpActive;

    // Start is called before the first frame update
    void Start()
    {
        WarpSpeedVFX.Stop();
        WarpSpeedVFX.SetFloat("WarpAmount", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            warpActive = true;
            StartCoroutine(ActivateParticles());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            warpActive = false;
            StartCoroutine(ActivateParticles());
        }
    }

    IEnumerator ActivateParticles()
    {
        if (warpActive) 
        { 
            WarpSpeedVFX.Play();

            float amount = WarpSpeedVFX.GetFloat("WarpAmount");

            while (amount < 1 & warpActive)
            {
                amount =+ rate;
                WarpSpeedVFX.SetFloat("WarpAmount", amount);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {

            float amount = WarpSpeedVFX.GetFloat("WarpAmount");

            while (amount > 0 & !warpActive)
            {
                amount = +rate;
                WarpSpeedVFX.SetFloat("WarpAmount", amount);
                yield return new WaitForSeconds(0.1f);

                if (amount <= 0 + rate)
                {
                    amount = 0;
                    WarpSpeedVFX.SetFloat("WarpAmount", amount);
                    WarpSpeedVFX.Stop();
                }
            }

            WarpSpeedVFX.Stop();

        }
    }
}
