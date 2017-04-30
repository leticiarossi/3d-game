using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This class controls the continue button within the pause panel
 */
public class EndScreen : MonoBehaviour {

	public Button mainMenu; 

	void Start () { 
		Button btn = mainMenu.GetComponent<Button>();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene (0); 
	}
}
