using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour {

  #region Fields

  public PieceType PieceType { get { return pieceType; } set { pieceType = value; } }

  private PieceType pieceType;
  private Material material;

  #endregion

  #region Mono Behaviour

  void OnEnable() {
    GetComponent<Renderer>().material.color = Config.PieceColors[pieceType];
  }

  void OnCollisionEnter(Collision collision) {
    switch (pieceType) {
      case PieceType.OneHitPiece:
        gameObject.SetActive(false);
        EventManager.TriggerEvent(new PieceHit());
        break;
      case PieceType.TwoHitPiece:
        pieceType = PieceType.OneHitPiece;
        break;
      case PieceType.NoHitsPiece:
        break;
    }
  }

  #endregion

}
