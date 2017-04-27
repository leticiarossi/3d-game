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

	void Start () {
		Button contBtn = continueButton.GetComponent<Button>();
		Button exBtn = exitButton.GetComponent<exitButton> ();
		contBtn.onClick.AddListener(ContinueTaskOnClick);
		exBtn.onClick.AddListener (ExitTaskOnClick);
	}

	void ContinueTaskOnClick(){
		MenuManager.DisablePause (); //references menu manager class using a singleton pattern
	}

	void ExitTaskOnClick(){
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}
}