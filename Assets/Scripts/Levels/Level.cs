using UnityEngine;
using System.Collections;

public class Level : StateMachine {

  #region Fields

  [SerializeField] GameObject boardPrefab;
  [SerializeField] GameObject ballPrefab;
  [SerializeField] GameObject paddlePrefab;

  private GameObject board;
  private GameObject ball;
  private GameObject paddle;
 
  #endregion

  #region Mono Behaviour
  void Awake() {
    Instantiate(boardPrefab).transform.parent = transform;
    Instantiate(ballPrefab).transform.parent = transform;
    Instantiate(paddlePrefab).transform.parent = transform;
  }

  void Start() {
    ChangeState<PlayLevelState>();
  }

  void OnEnable() {
    EventManager.StartListening("NextLevel", ChangeState<PlayLevelState>);
    EventManager.StartListening("EndLevel", ChangeState<NextLevelState>);
  }

  void OnDisable() {
    EventManager.StopListening("NextLevel", ChangeState<PlayLevelState>);
    EventManager.StopListening("EndLevel", ChangeState<NextLevelState>);
  }

  #endregion

}
