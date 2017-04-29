using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveMenuManager : MonoBehaviour {

	public Texture2D pause;
	public Texture2D restart;

	void OnGUI () {
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width - 50,0,50,50),pause)) {
			MenuManager.EnablePause ();
		}

		// Make the second button.
		if(GUI.Button(new Rect(Screen.width - 100,0,50,50),restart)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex, LoadSceneMode.Single);
		}
	}
}

