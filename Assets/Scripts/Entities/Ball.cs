﻿using UnityEngine;
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
    direction = Util.GetRandomBallDirection();
	}

  void FixedUpdate() {
//    if(rigidBody.velocity.x < Config.BallMaxVelocity.x && rigidBody.velocity.z < Config.BallMaxVelocity.z)
//      rigidBody.AddForce(direction * Config.BallInitialVelocity, ForceMode.Force);
      rigidBody.velocity = direction * Config.BallInitialVelocity;
  }

  void OnCollisionEnter(Collision collision) {
    if(collision.gameObject.name != "Ground")
      direction = Vector3.Reflect(direction, collision.contacts[0].normal);
  }

	#endregion
  
}