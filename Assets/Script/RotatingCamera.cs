using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour{
	
	public float rotateTime = 0.2f;
	private Transform player;
	private bool isRotating = false;
	
	void Start(){
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update(){
		transform.position = player.position;
		Rotate();
		
	}
	
	void Rotate(){
		if(Input.GetKeyDown(KeyCode.Q) && !isRotating){
			StartCoroutine(RotateAround(-45,rotateTime));
			
		}
		if(Input.GetKeyDown(KeyCode.E) && !isRotating){
			StartCoroutine(RotateAround(45,rotateTime));
		
		}
	
	}
	
	IEnumerator RotateAround(float angle, float time){
		float number = 60 * time;
		float nextAngle = angle / number;
		isRotating = true;
		for(int i = 0; i < number; i++){
			transform.Rotate(new Vector3(0,0,nextAngle));
			yield return new WaitForFixedUpdate();
		}
		isRotating = false;
		
	}
}