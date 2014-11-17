using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour
{

	private GUISkin skin;

	void Start () 
	{
		skin = Resources.Load("ButtonGUI") as GUISkin;
	}

	void OnGUI() 
	{
		const int buttonWidth = 100;
		const int instrButtonWidth = 200;
		const int buttonHeight = 45;

		GUI.skin = skin;

		if(GUI.Button(new Rect(Screen.width/2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2) + 75, buttonWidth, buttonHeight), "Start"))
		{
			Application.LoadLevel("GameScene");	
		}

		if(GUI.Button(new Rect(Screen.width/2 - (instrButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2) + 125, instrButtonWidth, buttonHeight), "How to Play"))
		{
			Application.LoadLevel("Instructions");
		}
	}
}
