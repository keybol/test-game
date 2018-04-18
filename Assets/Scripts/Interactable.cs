﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;

	bool isFocus = false;
	bool hasInteracted = false;
	Transform player;
	public Transform interactionTransform; 

	public virtual void Interact(){
	
		//this method is overwritten
		Debug.Log("Interacting with" + transform.name);
	}

	void Update(){

		if(isFocus && !hasInteracted){
			
			float distance = Vector3.Distance (player.position, interactionTransform.position);
			if(distance <= radius){

				Interact ();
				hasInteracted = true;
			}

		}
	}

	public void OnFocused (Transform playerTransform){

		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	
	}

	public void OnDefocused (){
	
		isFocus = false;
		player = null;
		hasInteracted = false;
	
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (interactionTransform.position, radius);
	}
}
