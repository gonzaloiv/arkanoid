﻿using UnityEngine;
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

  [HideInInspector] private int levelNumber = 1;

  #endregion

  #region Mono Behaviour

  void Awake() {
    Utils.InstantiateAsChild(boardPrefab, transform);
    Utils.InstantiateAsChild(paddlePrefab, transform);
  }

  void Start() {
    ChangeState<PlayLevelState>();
  }

  void OnEnable() {
    EventManager.StartListening("NextLevel", ToPlayLevelState);
    EventManager.StartListening("EndLevel", ToNextLevelState);
  }

  void OnDisable() {
    EventManager.StopListening("NextLevel", ToPlayLevelState);
    EventManager.StopListening("EndLevel", ToNextLevelState);
  }

  #endregion

  #region Private Behaviour

  private void ToPlayLevelState() {
    if (CurrentState is NextLevelState)
      ChangeState<PlayLevelState>();
  }

  private void ToNextLevelState() {
    if (CurrentState is PlayLevelState) {
      // TODO: evento para fin de juego en caso de superar el máximo de niveles
      levelNumber = levelNumber < Config.MaxLevelNumber ? levelNumber += 1 : levelNumber += 1;
      ChangeState<NextLevelState>();
    }
  }

  #endregion

}
