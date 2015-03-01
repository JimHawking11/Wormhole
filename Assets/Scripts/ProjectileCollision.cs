using UnityEngine;
using System.Collections;

public class ProjectileCollision : BaseCollision {
	
	void OnTriggerEnter (Collider other)
    {
		Debug.Log("Projectile Trigger " + other.name);
		CollisionTriggered(other);
    }
	
	public override void ProcessCollision (Collider other)
	{
		Debug.Log("Projectile Process " + other.name);
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
