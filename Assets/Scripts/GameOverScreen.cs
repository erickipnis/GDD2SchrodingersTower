using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour
{

	private GUISkin skin;

	void Start () {

		skin = Resources.Load("ButtonGUI") as GUISkin;
	}

	void OnGUI() 
	{
		const int buttonWidth = 200;
		const int instrButtonWidth = 250;
		const int buttonHeight = 65;
		
		GUI.skin = skin;
		
		if(GUI.Button(new Rect(Screen.width/2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "Play Again?"))
		{
			Application.LoadLevel("GameScene");	
		}
		
		if(GUI.Button(new Rect(Screen.width/2 - (instrButtonWidth / 2), (2 * Screen.height / 2.5f) - (buttonHeight / 2), instrButtonWidth, buttonHeight), "Return to Title"))
		{
			Application.LoadLevel("Start");
		}
	}
}
