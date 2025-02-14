using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;
using System;

public class PostProcessingFX : MonoBehaviour
{
	public Volume postVolume;
	private Vignette vignette;


	void Start()
	{
		postVolume.profile.TryGet(out vignette);
	}

	#region action and func examples

	//Func<float> vignetteGetter = () => vignette.intensity.value;
	//Action<float> vignetteSetter = x => vignette.intensity.value = x;
	//Func<float, float, float> multiply = (num1, num2) => num1 * num2;

	float GetIntensity() { return vignette.intensity.value; }

	void SetIntensity(float x) { vignette.intensity.value = x; }
	#endregion


}
