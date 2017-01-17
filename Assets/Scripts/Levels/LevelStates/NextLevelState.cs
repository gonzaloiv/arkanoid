﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NextLevelState : LevelState {

  #region Fields

  [SerializeField] private GameObject nextLevelScreenPrefab;

  private GameObject nextLevelScreen;
  private Text nextLevelScreenLabel;
  private string nextLevelScreenLabelText;

  #endregion

  #region State Behaviour

  public override void Enter() {
    base.Enter();

    if (!nextLevelScreen)
      InitializeNextLevelScreenPrefab();

    nextLevelScreenLabel.text = nextLevelScreenLabelText.Substring(0, nextLevelScreenLabelText.Length - 1) + Level.LevelNumber;
    nextLevelScreen.SetActive(true);
  }

  public override void Exit() {
    base.Exit();

    nextLevelScreen.SetActive(false);
  }

  #endregion

  #region Private Behaviour

  private void InitializeNextLevelScreenPrefab() {
    nextLevelScreen = Utils.InstantiateAsChild(nextLevelScreenPrefab, transform, false);
    nextLevelScreenLabel = nextLevelScreen.transform.GetComponentInChildren<Text>();
    nextLevelScreenLabelText = nextLevelScreenLabel.text;
  }

  #endregion

}