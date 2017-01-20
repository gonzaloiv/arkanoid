using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour {

  #region Fields

  public PieceInfo PieceInfo { get { return pieceInfo; } set { pieceInfo = value; } }
  public PieceType PieceType { get { return pieceInfo.type; } }

  private PieceInfo pieceInfo;
  private Material material;

  #endregion

  #region Mono Behaviour

  void Awake() {
    material = GetComponent<Renderer>().material;
  }

  void OnEnable() {
    SetPieceColor();
  }

  void OnCollisionEnter(Collision collision) {
    switch (pieceInfo.type) {
      case PieceType.OneHitPiece:
        gameObject.SetActive(false);
        EventManager.TriggerEvent(new PieceHit());
        break;
      case PieceType.TwoHitPiece:
        pieceInfo.type = PieceType.OneHitPiece;
        SetPieceColor();
        break;
      case PieceType.NoHitsPiece:
        break;
    }
  }

  #endregion

  #region Mono Behaviour

  private void SetPieceColor() {
    material.color = pieceInfo.color;
  }

  #endregion

}
