using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

  #region Fields

  private Rigidbody rigidBody;
  private Renderer renderer;
  private Vector3 direction;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rigidBody = GetComponent<Rigidbody>(); 
    renderer = GetComponent<Renderer>(); 
  }

  void Start() {
    gameObject.transform.position = Config.BallInitialPosition;
    direction = Config.BallInitialDirection;
    rigidBody.velocity = direction * Config.BallInitialVelocity;
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name == "BorderBottom") {
      EventManager.Instance.TriggerEvent(new PaddleMiss());
      StartCoroutine(Respawn());
    }
    if (collision.gameObject.name != "Ground") { 
      direction = Vector3.Reflect(direction, collision.contacts[0].normal);
      rigidBody.velocity = direction * Config.BallInitialVelocity;
    }
  }

  #endregion

  #region Mono Behaviour

  private IEnumerator Respawn() {
    gameObject.transform.position = Config.BallInitialPosition;
    rigidBody.velocity = direction * Config.BallInitialVelocity;

    float endTime = Time.time + .6f;
    while(Time.time < endTime){
      renderer.enabled = false;
      yield return new WaitForSeconds(.1f);
      renderer.enabled = true;
      yield return new WaitForSeconds(.1f);
    }
  }

  #endregion

}
