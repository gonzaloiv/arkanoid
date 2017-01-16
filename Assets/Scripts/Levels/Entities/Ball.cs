using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
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

  void Start() {
    direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(.3f, .6f));
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
