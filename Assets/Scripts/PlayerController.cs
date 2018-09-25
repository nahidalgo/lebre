using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] private float m_JumpforceX = 300f;
	[SerializeField] private float m_JumpforceY = 450f;
	[SerializeField] private Rigidbody2D m_Rigidbody2D;
	private void Awake() {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	public void Move(float timePressed)
	{
		if(timePressed > 0){
			Vector2 force = new Vector2(m_JumpforceX * 1.05f * timePressed, m_JumpforceY * 1.05f * timePressed);
			m_Rigidbody2D.AddForce(force);
		}
	}

}
