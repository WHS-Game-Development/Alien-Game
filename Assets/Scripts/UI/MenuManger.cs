using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MenuManger : Singleton<MenuManger> {
	[SerializeField] public GameObject MainMenuUI;
	[SerializeField] public GameObject LevelSelectUI;
	[SerializeField] public GameObject OptionsUI;

	
	// Use this for initialization
	void Start () 
	{
        MainMenuUI.SetActive(true);
        LevelSelectUI.SetActive(false);
        OptionsUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Options() {
	}
	
	
	public void BackToMainMenu() {
		MainMenuUI.SetActive(true);
		LevelSelectUI.SetActive(false);
		OptionsUI.SetActive(false);
	}
	
	public void ShowLevelSelect() {
		MainMenuUI.SetActive(false);
		LevelSelectUI.SetActive(true);
		OptionsUI.SetActive(false);
	}
	
	public void ShowOptions() {
		MainMenuUI.SetActive(false);
		LevelSelectUI.SetActive(false);
		OptionsUI.SetActive(true);
	}
	
	public void Quit() {
		Application.Quit();
	}
	
	public void loadMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}
	
    //make more generic to load any level later
	public void LoadLevel1() {
		SceneManager.LoadScene("Level1");
	}
	

	
}
