using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Platformer;
using UnityEngine.SceneManagement; // importar asset DOTween

public class FadeImage : MonoBehaviour
{
  public Image fadeImage;
  public int sceneToLoad;
	public float fadeTime = 1;
  //private GameManager gameManager;

    void Start()
    {
      fadeImage.color = Color.black;
			//gameManager = GameManager.gameManagerInstance;
      FadeOut();
		}

  public void FadeIn()
  {
    //1 = opaco, 0 = transparente
		fadeImage.DOFade(1, fadeTime).OnComplete(ChangeScene);
	}

  public void FadeOut()
  {
		fadeImage.DOFade(0, fadeTime);
	}

  public void ChangeScene()
  {
    SceneManager.LoadScene(sceneToLoad);
  }
}
