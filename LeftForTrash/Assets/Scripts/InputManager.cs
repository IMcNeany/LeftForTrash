using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public int playerNumber;

	private float Horizontal, Vertical;
	private bool[] buttons = new bool[4];

	// Update is called once per frame
	void Update () {
		Horizontal = Input.GetAxis("Horizontal_" + playerNumber);
		Vertical = Input.GetAxis("Vertical_" + playerNumber);

		buttons[0] = Input.GetButton("A_" + playerNumber);
		buttons[1] = Input.GetButton("B_" + playerNumber);
		buttons[2] = Input.GetButton("X_" + playerNumber);
		buttons[3] = Input.GetButton("Y_" + playerNumber);
	}

	public float getHorizontal(){ return Horizontal; }
	public float getVertical(){ return Vertical; }

	/*0 - A, 1 - B, 2 - X, 3 - Y */
	public bool getButtons(int num){
		return buttons[num];
	}
}


