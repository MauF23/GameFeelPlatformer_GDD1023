using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer
{
	public class GameManager : MonoBehaviour
	{
		public int coinsCounter = 0;

		//tiempo predeterminado de efectos de trasición
		public float defaultFadeTime = 3;

		public GameObject playerGameObject;
		private PlayerController player;
		public GameObject deathPlayerPrefab;
		public Text coinText;
		public CanvasGroup uiCanvasGroup;

		private const float RELOAD_WAIT_TIME = 3;

		//definir variable estática del manager
		public static GameManager gameManagerInstance;

		private void Awake()
		{
			//crear la instancia en la función awake
			if (gameManagerInstance == null)
			{
				gameManagerInstance = this;
				DontDestroyOnLoad(gameObject);
			}

		}

		void Start()
		{
			player = GameObject.Find("Player").GetComponent<PlayerController>();
		}

		public void GameOver()
		{
			playerGameObject.SetActive(false);
			GameObject deathPlayer = Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
			deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
			player.deathState = false;
			StartCoroutine(ReloadLevelRoutine(RELOAD_WAIT_TIME));
		}

		public void CollectCoin()
		{
			coinsCounter++;
			coinText.text = coinsCounter.ToString();
		}

		public void TogglePlayerMovement(bool movementValue)
		{
			float endCanvasValue = movementValue ? 1 : 0;
			uiCanvasGroup.DOFade(endCanvasValue, 0.25f);
			player.canMove = movementValue;
		}

		IEnumerator ReloadLevelRoutine(float waitTime)
		{
			yield return new WaitForSeconds(waitTime);
			ReloadLevel(SceneManager.GetActiveScene().buildIndex);
		}

		private void ReloadLevel(int levelIndex)
		{
			SceneManager.LoadScene(levelIndex);
		}
	}
}
