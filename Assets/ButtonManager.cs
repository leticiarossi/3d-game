using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This class controls the continue button within the pause panel
 */
public class ButtonManager : MonoBehaviour {

	public Button continueButton; 
	public Button exitButton;
	public Button restartButton;

	void Start () {
		Button contBtn = continueButton.GetComponent<Button>();
		Button exBtn = exitButton.GetComponent<Button> ();
		Button rstrtBtn = restartButton.GetComponent<Button> ();
		contBtn.onClick.AddListener(ContinueTaskOnClick);
		exBtn.onClick.AddListener (ExitTaskOnClick);
		rstrtBtn.onClick.AddListener (RestartTaskOnClick);
	}

	void ContinueTaskOnClick(){
		MenuManager.DisablePause (); //references menu manager class using a singleton pattern
	}

	void ExitTaskOnClick(){
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

	void RestartTaskOnClick(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}
}