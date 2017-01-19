﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OpeningScreen : MonoBehaviour, IPointerClickHandler {

  #region IPointerClickHandler Implementation

  public void OnPointerClick(PointerEventData eventData) {
    EventManager.Instance.TriggerEvent(new StartGame());
  }
    
  #endregion

}
