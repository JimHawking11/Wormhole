using UnityEngine;
using System.Collections;

public class StrobeLightController : MonoBehaviour {

	public float maxIntensity = 1.25f;
	public float minIntensity = 0;
	public float smooth = 2f;
	
	private float targetIntensity = 0f;
	private float changeMargin = 0.2f;
	
	// Update is called once per frame
	void Awake ()
    {
		light.intensity = 1.25f;
    }
	
	void Update () 
	{
		light.intensity = Mathf.Lerp(light.intensity, targetIntensity, smooth * Time.deltaTime);
		
		CheckTargetIntensity();		
	}
	
	void CheckTargetIntensity ()
    {
        if(Mathf.Abs(targetIntensity - light.intensity) < changeMargin)
        {
            if(targetIntensity == maxIntensity)
                targetIntensity = minIntensity;
            else
                targetIntensity = maxIntensity;
        }
    }
}
