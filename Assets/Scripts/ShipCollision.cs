using UnityEngine;
using System.Collections;

public class ShipCollision : BaseCollision {

	void OnTriggerEnter (Collider other)
    {
		Debug.Log("Ship Trigger " + other.name);
		CollisionTriggered(other);
    }
	
	public override void ProcessCollision (Collider other)
	{
		Debug.Log("Ship Process " + other.name);
		if(isCollision(other.name)){
			Destroy(gameObject);
		}
	}
	
	bool isCollision(string name)
	{
		string lowName = name.ToLower();

		if(!lowName.Contains("wormhole") && !lowName.Contains("projectile") && !lowName.Contains("drone_p")){
			return true;
		}
		
		return false;
	}
}
