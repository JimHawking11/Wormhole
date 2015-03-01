using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public float fireSpeed = 1;
	public float shipAcceleration = 1f;
	public float shipMaxSpeed = 10f;
	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
	public Rigidbody projectile;
	
	private float coolDownTime = 0f;
	
	void Update() {
		
		//Reduce Cooldown
		coolDownTime -= Time.deltaTime;
		
		//Fire Lasers
        if (Input.GetButton("Fire1") && coolDownTime <= 0) {
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(projectile, transform.position - transform.forward, Quaternion.LookRotation(transform.forward, Vector3.up));
			clone.transform.forward = transform.forward;
			clone.velocity = -transform.forward * 8;
			coolDownTime = fireSpeed;
        }
    }
	
	void FixedUpdate ()
    {
        // Cache the inputs.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        MovementManagement(h, v);
    }
	
	void MovementManagement (float horizontal, float vertical)
    {
        // If there is some axis input...
        if(horizontal != 0f || vertical != 0f)
        {
            // ... set the players rotation and set the speed parameter to 5.5f.
            Rotating(horizontal, vertical);
        }
		
		Moving(horizontal, vertical);
		
    }
    
    
    void Rotating (float horizontal, float vertical)
    {
        // Create a new vector of the horizontal and vertical inputs.
        Vector3 targetDirection = new Vector3(-horizontal, 0f, -vertical);

        // Create a rotation based on this new vector assuming that up is the global y axis.
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        
        // Create a rotation that is an increment closer to the target rotation from the player's rotation.
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        
        // Change the players rotation to this new rotation.
        rigidbody.MoveRotation(newRotation);
    }
	
	void Moving (float horizontal, float vertical){
       // Create a new vector of the horizontal and vertical inputs.
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		float curSpeed = rigidbody.velocity.magnitude;
		
		rigidbody.AddForce(targetDirection * shipAcceleration);
		
		if(curSpeed > shipMaxSpeed ){
			rigidbody.AddForce(-rigidbody.velocity * shipAcceleration * (shipMaxSpeed/curSpeed));
		}
	}
}
