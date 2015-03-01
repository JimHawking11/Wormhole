using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {
	
	public float lifespan = 2f;
	
	void Awake(){
		Destroy(gameObject, lifespan);
	}
	
	
}
