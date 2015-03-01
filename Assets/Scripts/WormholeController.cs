using UnityEngine;
using System.Collections;

public class WormholeController : MonoBehaviour {
	
	public float rotateSpeed = 90f;
	public float delayPeriod = 1;
	
	public GameObject wormholePair; 
		
	void Awake ()
    {
    }
	
	// Update is called once per frame
	void Update ()
	{
    	transform.Rotate (0, rotateSpeed * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
	}
	
	void OnTriggerStay (Collider other)
    {
		if(other.name.Contains("AI")){
			return;
		}
		Vector3 normVelocity = other.rigidbody.velocity.normalized;
		Vector3 scaledVelocity = new Vector3(normVelocity.x * .8f, normVelocity.y * .8f, normVelocity.z * .8f);
        other.transform.position = (wormholePair.transform.position + scaledVelocity);
    }
	
	public void OnParticleCollision(GameObject other)
    {
		Debug.Log("Hit");
        other.transform.position = (wormholePair.transform.position);
    }
}
