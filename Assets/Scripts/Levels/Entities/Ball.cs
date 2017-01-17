using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

  #region Fields

  private Rigidbody rigidBody;

  private Vector3 direction;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rigidBody = GetComponent<Rigidbody>(); 
  }

  void Start() {
    direction = Config.BallInitialDirection;
  }

  void FixedUpdate() {
    rigidBody.velocity = direction * Config.BallInitialVelocity;
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name != "Ground")
      direction = Vector3.Reflect(direction, collision.contacts[0].normal);
  }

  #endregion
  
}
