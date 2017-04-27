using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
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
		UnityEngine.Application.LoadLevel (1);
	}

	void quitTaskOnClick()
	{
		Application.Quit ();
	}
}