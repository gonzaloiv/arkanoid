using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelHUD : MonoBehaviour {

  #region Fields

  private Text remainingLivesLabel;
  private string remainingLivesLabelText = "Lives: ";
  private int paddleLives;

  #endregion

  #region Mono Behaviour

  void Awake() {
    remainingLivesLabel = gameObject.transform.GetComponentInChildren<Text>();
  }

  void OnEnable() {
    paddleLives = Config.InitialPaddleLives;
    remainingLivesLabel.text  = remainingLivesLabelText + paddleLives;

    EventManager.StartListening<PaddleMiss>(UpdateLivesLabel);
  }

  void OnDisable() {
    EventManager.StopListening<PaddleMiss>(UpdateLivesLabel);
  }

  #endregion

  #region Mono Behaviour

  private void UpdateLivesLabel() {
    paddleLives--;
    remainingLivesLabel.text = remainingLivesLabelText + paddleLives;
  }
    
  #endregion

}
