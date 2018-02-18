using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {


	private GameObject parentCanvas;
	private GameObject pausePanel; 

	void Start(){
		parentCanvas = GameObject.Find ("Canvas");
		pausePanel = parentCanvas.transform.Find("PausePanel").gameObject;
		TogglePausePanelOff ();
	}

	public void LoadScene(string name){
		SceneManager.LoadScene(name);
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void ResumeGame(){
	}

	public void TogglePausePanelOn(){		
		pausePanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void TogglePausePanelOff(){
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}
}
