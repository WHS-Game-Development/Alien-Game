using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {
	public int score;
	public bool isLevelCleared;
	public bool isPaused = false;
	private bool isGameMenuOpen = false;
	
	// UI attachments
	[SerializeField] private Text scoreUI;
	[SerializeField] private GameObject levelCompleteUI;
	[SerializeField] private GameObject gameMenuUI;
	[SerializeField] private GameObject pauseUI;
	[SerializeField] private Button weapon1Button;
	[SerializeField] private Button weapon2Button;
	[SerializeField] private Button weapon3Button;
	[SerializeField] private Sprite pauseImage;
    [SerializeField] private Sprite playImage;
	[SerializeField] private Image pausePlayButtonImage;
	[SerializeField] private GameObject[] weaponPrefabs;
	
	public GameObject currentWeaponPrefab;
	
	// Use this for initialization
	void Start () {
		score =0;
		isLevelCleared = false;
		levelCompleteUI.SetActive( false);
		gameMenuUI.SetActive( isGameMenuOpen );
		pauseUI.SetActive( false);
	    changeWeapon(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void levelCleared()
	{
		isLevelCleared = true;
		levelCompleteUI.SetActive(true);
		Time.timeScale = 0.01f;
		
	}
	
	public void toggleMenu () {
		isGameMenuOpen = !isGameMenuOpen;
		gameMenuUI.SetActive(isGameMenuOpen);
	}
	
	
	public void togglePause() {
		isPaused = !isPaused;
		pauseUI.SetActive( isPaused );
		if (isPaused)
		{
			Time.timeScale = 0.0f;
			pausePlayButtonImage.sprite = playImage;
		}
		else{
			Time.timeScale = 1f;
			pausePlayButtonImage.sprite = pauseImage;
		}
	}
	
	public void changeWeapon(int weapon) {
		
		if( weapon == 1 )
		{
			currentWeaponPrefab = weaponPrefabs[0];	
			weapon1Button.GetComponent<Image>().color =  new Color32(255, 255, 255,255);
			weapon2Button.GetComponent<Image>().color =  new Color32(99, 99, 99,255);
			weapon3Button.GetComponent<Image>().color =  new Color32(99, 99, 99,255);
		}
		else if( weapon == 2 )
		{
			currentWeaponPrefab = weaponPrefabs[1];
			weapon2Button.GetComponent<Image>().color =  new Color32(255, 255, 255,255);
			weapon1Button.GetComponent<Image>().color =  new Color32(99, 99, 99,255);
			weapon3Button.GetComponent<Image>().color =  new Color32(99, 99, 99,255);
		}
		else if( weapon == 3 )
		{
			currentWeaponPrefab = weaponPrefabs[2];
			weapon3Button.GetComponent<Image>().color =  new Color32(255, 255, 255,255);
			weapon2Button.GetComponent<Image>().color =  new Color32(99, 99, 99,255);
			weapon1Button.GetComponent<Image>().color =  new Color32(99, 99, 99,255);
		}
	}	
}
