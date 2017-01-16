using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SphereCollider))]
[RequireComponent (typeof (Rigidbody))]
public class Ball : MonoBehaviour {

  #region Fields

	private SphereCollider sphereCollider;
  private Rigidbody rigidBody;

  private Vector3 direction;

  #endregion

	#region Mono Behaviour

	void Awake() {
    sphereCollider = GetComponent<SphereCollider>();
    rigidBody = GetComponent<Rigidbody>();
	}
	
	void Start () {
    direction = Helper.GetRandomDirection();
	}

  void FixedUpdate() {
    if(rigidBody.velocity.x < Config.BallMaxVelocity.x && rigidBody.velocity.z < Config.BallMaxVelocity.z)
      rigidBody.AddForce(direction * Config.BallInitialForce, ForceMode.Force);
  }

  void OnCollisionEnter(Collision collision) {
    Debug.Log(collision.gameObject);
    if(collision.gameObject.name != "Ground")
      direction = Vector3.Reflect(direction, collision.contacts[0].normal);
  }

	#endregion
  
}
