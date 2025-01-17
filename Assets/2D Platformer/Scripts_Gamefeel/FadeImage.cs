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
		fadeImage.DOFade(1, 3).OnComplete(ChangeScene);
	}

  public void FadeOut()
  {
		fadeImage.DOFade(0, 3);
	}

  public void ChangeScene()
  {
    SceneManager.LoadScene(sceneToLoad);
  }
}
