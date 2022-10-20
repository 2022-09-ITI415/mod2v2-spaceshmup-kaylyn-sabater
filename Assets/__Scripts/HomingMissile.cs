using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingMissile : MonoBehaviour
{
public Transform target;
static public bool enemyHit = false;
 
void Start() {

	

	void OnTriggerEnter(Collider other) {
	
	//	if (other.gameObject.FindObjectWithTag("Enemy").transform){
			
			HomingMissile.enemyHit = true;
			other.gameObject.SetActive (false); }}
 
 
}

