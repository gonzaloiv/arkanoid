using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayLevelState))]
[RequireComponent(typeof(NextLevelState))]
public class Level : StateMachine {

  #region Fields

  [SerializeField] GameObject boardPrefab;
  [SerializeField] GameObject paddlePrefab;


  private GameObject board;
  private GameObject paddle;

  public int LevelNumber { get { return levelNumber; } }
  private int levelNumber = 1;

  #endregion

  #region Mono Behaviour

  void Awake() {
    Utils.InstantiateAsChild(boardPrefab, transform);
    Utils.InstantiateAsChild(paddlePrefab, transform);
  }

  void Start() {
    ChangeState<NextLevelState>();
  }

  void OnEnable() {
    EventManager.StartListening<NextLevel>(ToPlayLevelState);
    EventManager.StartListening<EndLevel>(ToNextLevelState);
  }

  void OnDisable() {
    EventManager.StopListening<NextLevel>(ToPlayLevelState);
    EventManager.StopListening<EndLevel>(ToNextLevelState);
  }

  #endregion

  #region Private Behaviour

  private void ToPlayLevelState() {
    if (CurrentState is NextLevelState)
      ChangeState<PlayLevelState>();
  }

  private void ToNextLevelState() {
    if (CurrentState is PlayLevelState) {
      levelNumber += 1; 
      if(levelNumber > Config.MaxLevelNumber)
        EventManager.TriggerEvent(new EndGame());
      ChangeState<NextLevelState>();
    }
  }

  #endregion

}
