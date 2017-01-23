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
  private Animator animator;

  #endregion

  #region Mono Behaviour

  void Awake() {
    material = GetComponent<Renderer>().material;
    animator = GetComponent<Animator>();
  }

  void OnEnable() {
    SetPieceColor();
  }

  void OnCollisionEnter(Collision collision) {
    switch (pieceInfo.type) {
      case PieceType.OneHitPiece:
        EventManager.TriggerEvent(new PieceHit());
        animator.Play("Vanish");
        break;
      case PieceType.TwoHitPiece:
        ChangePieceType(PieceType.OneHitPiece);
        break;
      case PieceType.NoHitsPiece:
        break;
    }
  } 

  #endregion

  #region Mono Behaviour

  private void ChangePieceType (PieceType pieceType) {
    pieceInfo = LevelConfig.PieceTypes[pieceType];
    SetPieceColor();
  }

  private void SetPieceColor() {
    if(pieceInfo != null)
      material.color = pieceInfo.color;
  }

  private void Disable() {
    gameObject.SetActive(false);
  }

  #endregion

}
