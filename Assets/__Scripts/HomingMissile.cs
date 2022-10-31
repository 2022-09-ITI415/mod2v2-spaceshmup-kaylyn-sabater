using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingMissile : MonoBehaviour
{
 [Header("Set in Inspector")]
public float center = 0;
public float radius = 45;
public GameObject Hero;

[Header("Set Dynamically")]
GameObject closestEnemy=null;

//public Transform target;
//static public bool enemyHit = false;
 
void Start() {

	Hero = GameObject.Find("_Hero");

	Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

	 
	 float closestDistance = 10000000f;
	 GameObject rootGo=null;

     for (int i = 0; i < hitColliders.Length; i++)
     {
         GameObject hitCollider = hitColliders[i].gameObject;
		 rootGo = hitCollider.transform.root.gameObject;
		 if(rootGo.CompareTag("Enemy")) {
			Debug.Log(hitCollider.name + " " + rootGo.transform.position + " " + (Hero.transform.position-rootGo.transform.position).magnitude);

			float distanceToHero = (Hero.transform.position-rootGo.transform.position).magnitude;
			if (distanceToHero < closestDistance) {
				closestDistance = distanceToHero;
				closestEnemy = rootGo;
			}


		 }
	Debug.Log("Closest Object is "+ closestEnemy.name +" at distance " +closestDistance);

//void OnTriggerEnter(Collider other) {
		

//	if (other.gameObject.FindObjectWithTag("Enemy").transform){
	
//		HomingMissile.enemyHit = true;
//		other.gameObject.SetActive (false); }}
 
}


}}

