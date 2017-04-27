using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

	public static MenuManager instance;
	public GameObject PauseMenu;

	void Awake ()
	{
		instance = this;
		PauseMenu.SetActive (false);
	}

	public static void EnablePause(){
		instance.PauseMenu.SetActive (true);
		Time.timeScale = 0; //pause background when panel is present
	}

	public static void DisablePause(){
		instance.PauseMenu.SetActive (false);
		Time.timeScale = 1; //unpause background when panel goes away
	}
}