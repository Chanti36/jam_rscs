using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
    Vector3 camPosition;
	    
	[SerializeField] private float f_intensityVal;

	private float f_intensity;
	private float f_startIntensity;
	private float f_endIntensity;

	private float f_timer;
	private float f_dur;


	void Start()
    {
        camPosition = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        CamShake();
    }

	public void DoCamShake(float f_time)
	{
		f_timer = 0;
		f_dur = f_time;
		f_startIntensity = f_intensityVal;
		f_endIntensity = f_intensityVal;
	}

	public void DoCamShake(float f_time, float f_start, float f_end)
	{
		f_timer = 0;
		f_dur = f_time;
		f_startIntensity = f_start;
		f_endIntensity = f_end;
	}



	void CamShake()
    {
		if (f_timer > f_dur)
			return;

        f_timer += Time.deltaTime;
		f_intensity = Mathf.Lerp(f_startIntensity, f_endIntensity, f_timer/f_dur);
		transform.position = camPosition + new Vector3(Random.Range(-f_intensity, f_intensity), Random.Range(-f_intensity, f_intensity), 0);
	}
}
