using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameOverScreen : MonoBehaviour, IPointerClickHandler {

  #region IPointerClickHandler Implementation

  public void OnPointerClick(PointerEventData eventData) {    
    EventManager.TriggerEvent("StartGame");
  }
    
  #endregion

}
