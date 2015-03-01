using UnityEngine;
using System.Collections;

public class DroneProximity : MonoBehaviour {

	public float speed = 4f;
	public float droneAcceleration = 1f;
	public float droneMaxSpeed = 2f;
	public Light alertLight;
	
	private bool isAlerted = false;
	
	void Update() {
		if(isAlerted)
		{
			if(transform.parent.gameObject.layer != LayerMask.NameToLayer("Drone"))
			{
				ChangeLayersRecursively(transform.parent.gameObject, "Drone");
			}
		}
    }
	
	void OnTriggerStay (Collider other)
    {	
		if(other.name.Contains("Player")){
			isAlerted = true;
			
			transform.parent.transform.LookAt(other.transform);
					
			Vector3 targetDirection = transform.parent.forward;
			float curSpeed = transform.parent.rigidbody.velocity.magnitude;
		
			transform.parent.rigidbody.AddForce(targetDirection * droneAcceleration);
		
			if(curSpeed > droneMaxSpeed ){
				transform.parent.rigidbody.AddForce(-transform.parent.rigidbody.velocity * droneAcceleration * (droneMaxSpeed/curSpeed));
			}
		}
    }
	
	void OnTriggerExit( Collider other)
	{
		if(other.name.Contains("Player")){
			ChangeLayersRecursively(transform.parent.gameObject, "Default");
			isAlerted = false;
		}
	}
	
	void ChangeLayersRecursively(GameObject gameObject, string name)
	{
		if (null == gameObject)
        {
            return;
        }
		
		gameObject.layer = LayerMask.NameToLayer(name);
	    Debug.Log("Layer Changeed to " + LayerMask.NameToLayer(name));
		
		foreach (Transform child in gameObject.transform)
	    {
			if (null == child)
        	{
            	continue;
        	}
	        ChangeLayersRecursively(child.gameObject, name);
	    }
	}
}
