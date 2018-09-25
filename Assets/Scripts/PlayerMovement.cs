using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public PlayerController controller;
	private float m_timePressed = 0;
	private float startTime = 0f;
	private Vector2 touchOrigin = -Vector2.one;
	
	private void Awake() {
		controller = GetComponent<PlayerController>();	
	}

	private void FixedUpdate() {
		controller.Move(m_timePressed);
		m_timePressed = 0;
	}

	private void Update() {
		CheckMovement();
	}

	private void CheckMovement(){  //checks the amount of time the player has presssed the button
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			startTime = Time.time;
		}	
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			m_timePressed = Time.time - startTime;

			if(m_timePressed < 1 && m_timePressed > 0)
				m_timePressed = 1;
			else if (m_timePressed >= 3)
				m_timePressed = 0f;

			// Debug.Log(m_timePressed);
			// Debug.Log(m_timePressed);
			
		}

		if(Input.touchCount > 0)  //assures that there is a touch been registered
		{
			Touch touch = Input.touches[0];       //grabs the first touch and uses it
			if(touch.phase == TouchPhase.Began)   //if touch is begining
			{
				touchOrigin = touch.position;
				startTime = Time.time;
			}
			else if(touch.phase == TouchPhase.Ended && touchOrigin.x >= Screen.width/2 && touchOrigin.x >= 0)  //if the touch is in the right side of the screen
			{
				m_timePressed = Time.time - startTime;

				if(m_timePressed < 1 && m_timePressed > 0)
					m_timePressed = 1;
				else if (m_timePressed >= 3)
					m_timePressed = 0f;
			}
		}
	}
}
