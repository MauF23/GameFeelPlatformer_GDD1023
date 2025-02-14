using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System;
using DG.Tweening;
using Unity.VisualScripting;

public class PostProcessingManager : MonoBehaviour
{
	public Volume postProcessingVolume;
	public Vignette vignette;
	public FilmGrain filmGrain;
	private float vignetteTweenTime = 0.3f;
	Action myAction;
	public static PostProcessingManager instance;

	private void Awake()
	{
		instance = this;
	}

	void Start()
	{
		postProcessingVolume.profile.TryGet(out vignette);
		postProcessingVolume.profile.TryGet(out filmGrain);
		SetVignetteIntensity(0.75f);
	}

	//()=>vignette.intensity.value
	float GetVignetteIntensity()
	{
		return vignette.intensity.value;
	}

	//x => vignette.intensity.value = x
	void VignetteIntesitySetter(float myValue)
	{
		vignette.intensity.value = myValue;
	}


	public void SetVignetteIntensity(float targetValue)
	{
		Action onCompleteAction = delegate
		{
			SayHello();
			SayGoodbye();
		};
		DOTween.To(() => vignette.intensity.value, x => vignette.intensity.value = x, targetValue, vignetteTweenTime)
			.OnComplete(onCompleteAction.Invoke)
			.SetLoops(2, LoopType.Yoyo)
			.SetDelay(3);

	}

	void SayHello()
	{
		Debug.Log("Hello");
	}

	void SayGoodbye()
	{
		Debug.Log("Goodbye");
	}



}
