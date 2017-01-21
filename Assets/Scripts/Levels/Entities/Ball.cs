﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

  #region Fields

  private Rigidbody rigidBody;
  private Animator animator;
  private Vector3 direction;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rigidBody = GetComponent<Rigidbody>(); 
    animator =  GetComponent<Animator>();
  }

  // EXPLANATION : ball.setActive(true) -misteriously- doesn't always trigger OnEnable()...
  void OnEnable() {
    Reset();
  }

  void OnDisable() {
    Reset();
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.name != "Ground") { 
      direction = Vector3.Reflect(direction, collision.contacts[0].normal);
      rigidBody.velocity = direction * Config.BallInitialVelocity;
    }
  } 

  void OnTriggerEnter(Collider collider) {
    if (collider.name == "BorderBottom") {
      EventManager.TriggerEvent(new PaddleMiss());
      SetInitialPosition();
      animator.Play("Blink");
    }
  }

  #endregion

  #region Mono Behaviour

  private void Reset() {
    SetInitialPosition();
    direction = Config.BallInitialDirection;
    rigidBody.velocity = direction * Config.BallInitialVelocity;
  }

  private void SetInitialPosition() {
    gameObject.transform.position = Config.BallInitialPosition;
    rigidBody.velocity = Vector3.zero;
  }

  #endregion

}
