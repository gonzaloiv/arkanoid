using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelHUD : MonoBehaviour {

  #region Fields

  private Text remainingLivesLabel;
  private string remainingLivesLabelText;

  #endregion

  #region Mono Behaviour
  void Awake() {
    remainingLivesLabel = gameObject.transform.GetComponentInChildren<Text>();
  }

  void OnEnable() {
    EventManager.StartListening("PaddleMiss", UpdateLivesLabel);
  }

  void OnDisable() {
    EventManager.StopListening("PaddleMiss", UpdateLivesLabel);
  }

  #endregion

  #region Mono Behaviour

  private void UpdateLivesLabel() {
    remainingLivesLabelText = remainingLivesLabel.text;
    remainingLivesLabel.text = remainingLivesLabelText.Substring(0, remainingLivesLabelText.Length - 1);
  }
    
  #endregion

}
