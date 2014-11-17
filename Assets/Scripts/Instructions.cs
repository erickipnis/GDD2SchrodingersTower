using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour
{

	private GUISkin skin;

	void Start () 
	{
		skin = Resources.Load("ButtonGUI") as GUISkin;
	}

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