using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PiecePool))]
public class PlayLevelState : LevelState {

  #region Fields

  [SerializeField] GameObject ballPrefab;

  private List<GameObject> levelPieces;
  private GameObject ball;

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    levelPieces = new List<GameObject>();
    levelPieces = LevelMaker.Instance.GenerateNewLevel();
    ball = Utils.InstantiateAsChild(ballPrefab, transform);
  }

  public override void Exit() {
    base.Enter();

    foreach(GameObject piece in levelPieces)
      piece.SetActive(false);

    Destroy(ball);
  }

  protected override void AddListeners() {
    EventManager.StartListening("PieceHit", CheckLevelEnd);
  }

  protected override void RemoveListeners() {
    EventManager.StopListening("PieceHit", CheckLevelEnd);
  }

  #endregion

  #region Private Behaviour

  private void CheckLevelEnd(){
    foreach(GameObject piece in levelPieces) {
      if(piece.activeInHierarchy)
        return;
    }
    EventManager.TriggerEvent("EndLevel");
  }

  #endregion

}
