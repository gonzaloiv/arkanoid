using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PiecePool))]
public class PlayLevelState : LevelState {

  #region Fields

  [SerializeField] GameObject ballPrefab;
  [SerializeField] GameObject levelHUDPrefab;

  private GameObject ball;
  private GameObject levelHUD;

  private List<GameObject> levelPieces;

  #endregion

  #region Mono Behaviour

  protected override void Awake() {
    base.Awake();
    
    ball = Utils.InstantiateAsChild(ballPrefab, transform, false);
    levelHUD = Utils.InstantiateAsChild(levelHUDPrefab, transform, false);
    levelPieces = new List<GameObject>();
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    levelPieces = LevelMaker.Instance.GenerateNewLevel(LevelNumber);
    ball.SetActive(true);
    levelHUD.SetActive(true);
  }

  public override void Exit() {
    base.Enter();

    foreach (GameObject piece in levelPieces)
      piece.SetActive(false);

    ball.SetActive(false);
    levelHUD.SetActive(false);
  }

  protected override void AddListeners() {
    EventManager.StartListening<PieceHit>(CheckLevelEnd);
  }

  protected override void RemoveListeners() {
    EventManager.StopListening<PieceHit>(CheckLevelEnd);
  }

  #endregion

  #region Private Behaviour

  private void CheckLevelEnd() {
    foreach (GameObject piece in levelPieces) {
      if (piece.activeInHierarchy && piece.GetComponent<Piece>().PieceType != PieceType.NoHitsPiece)
        return;
    }
    EventManager.TriggerEvent(new EndLevel());
  }

  #endregion

}
