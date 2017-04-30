using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
	
	public Button StartButton;
	public Button QuitButton;

	void Start()
	{
		Button strtBtn = StartButton.GetComponent<Button>();
		Button qtBtn = QuitButton.GetComponent<Button> ();
		strtBtn.onClick.AddListener(startTaskOnClick);
		qtBtn.onClick.AddListener (quitTaskOnClick);

	}

	void startTaskOnClick()
	{
		Time.timeScale = 1;
		UnityEngine.Application.LoadLevel (1);
		DontDestroyOnLoad(GameStateManager.Instance);
		GameStateManager.Instance.StartState();
	}

	void quitTaskOnClick()
	{
		Application.Quit ();
	}
}