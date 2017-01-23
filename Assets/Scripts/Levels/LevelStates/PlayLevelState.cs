using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LevelMaker))]
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
    ball = Instantiate(ballPrefab, transform) as GameObject;
    ball.SetActive(false);
    levelHUD = Instantiate(levelHUDPrefab, transform) as GameObject;
    levelHUD.SetActive(false);

    levelPieces = new List<GameObject>();
  }

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    ball.SetActive(true);
    levelHUD.SetActive(true);
    levelPieces = LevelMaker.GenerateNewLevel(LevelNumber);
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
    foreach (GameObject piece in LevelMaker.LevelPieces) {
      if (piece.activeInHierarchy && piece.GetComponent<Piece>().PieceType != PieceType.NoHitsPiece)
        return;
    }
    EventManager.TriggerEvent(new EndLevel());
  }

  #endregion

}
