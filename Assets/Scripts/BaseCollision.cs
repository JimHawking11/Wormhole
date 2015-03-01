using UnityEngine;
using System.Collections;

public class BaseCollision : MonoBehaviour {

	void OnTriggerEnter (Collider other)
    {	
		CollisionTriggered(other);
    }
	
	public virtual void CollisionTriggered (Collider other)
	{
		ProcessCollision(other);
		
		BaseCollision cScript = other.GetComponent<BaseCollision>();
		
		if(cScript != null){
			cScript.ProcessCollision(other);
		}
	}
	
	public virtual void ProcessCollision (Collider other)
	{
		
	}
}
