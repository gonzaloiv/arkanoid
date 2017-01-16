using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour {

  #region Mono Behaviour

  void OnCollisionEnter(Collision collision) {
    gameObject.SetActive(false);
  }

  #endregion

}
