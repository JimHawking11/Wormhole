using UnityEngine;
using System.Collections;

public class DroneCollision : BaseCollision {
	
	public GameObject deathObject; 
	
	void OnTriggerEnter (Collider other)
    {
		Debug.Log("Drone Trigger " + other.name);
		CollisionTriggered(other);
    }
	
	public override void ProcessCollision (Collider other)
	{
		Debug.Log("Drone Process " + other.name);
		if(isCollision(other.name)){		
			Instantiate(deathObject, transform.position, transform.rotation);
			
			DestroyObject(transform.parent.gameObject);
		}
	}
	
	bool isCollision(string name)
	{
		string lowName = name.ToLower();

		if(!lowName.Contains("drone") && !lowName.Contains("wall") && !lowName.Contains("wormhole")){
			return true;
		}
		
		return false;
	}
}
