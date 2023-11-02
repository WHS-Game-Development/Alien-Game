using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MainMenu : Singleton<MainMenu> {
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
	
	public void LoadLevel() {
		// get the name of the button 
	//	SavedStatesManager.Level = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text.ToString();
	
	//	SceneManager.LoadScene("Level1");
	}
	

	
}
