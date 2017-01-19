using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class NextLevelScreen : MonoBehaviour, IPointerClickHandler {

  #region IPointerClickHandler Implementation

  public void OnPointerClick(PointerEventData eventData) {
    EventManager.TriggerEvent(new NextLevel());
  }
    
  #endregion

}
