using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	private GUISkin skin;
	
	// Use this for initialization
	void Start () 
	{
		skin = Resources.Load("Instructions") as GUISkin;
	}
	
	// Update is called once per frame
	void OnGUI() 
	{
		const int buttonWidth = 200;
		const int buttonHeight = 65;
		
		GUI.skin = skin;
		
		if(GUI.Button(new Rect(Screen.width/2 - (buttonWidth / 2), (2 * Screen.height / 3 + 150) - (buttonHeight / 2), buttonWidth, buttonHeight), "Back"))
		{
			Application.LoadLevel("StartScreen");	
		}

	}
}
