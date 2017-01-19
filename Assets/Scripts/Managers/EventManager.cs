using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class EventManager : Singleton<EventManager> {

  #region Fields

  private Dictionary <string, UnityEvent> eventStringDictionary = new Dictionary<string, UnityEvent>();
  private Dictionary <System.Type, UnityEvent> eventTypeDictionary = new Dictionary<System.Type, UnityEvent>();

  #endregion

  #region Public Behaviour

  /// <summary>
  /// Lanzamiento y escucha de eventos a partir de nombre
  /// </summary>
  public void StartListening(string eventName, UnityAction listener) {
    UnityEvent thisEvent = null;
    if (eventStringDictionary.TryGetValue(eventName, out thisEvent)) {
      thisEvent.AddListener(listener);
    } else {
      thisEvent = new UnityEvent();
      thisEvent.AddListener(listener);
      eventStringDictionary.Add(eventName, thisEvent);
    }
  }

  public void StopListening(string eventName, UnityAction listener) {
    if (instance == null)
      return;
    UnityEvent thisEvent = null;
    if (eventStringDictionary.TryGetValue(eventName, out thisEvent))
      thisEvent.RemoveListener(listener);
  }

  public void TriggerEvent(string eventName) {
    UnityEvent thisEvent = null;
    if (eventStringDictionary.TryGetValue(eventName, out thisEvent))
      thisEvent.Invoke();
  }

  /// <summary>
  /// Lanzamiento y escucha de eventos a partir de tipo
  /// </summary>
  public void StartListening<T>(UnityAction listener) where T : UnityEvent {
    UnityEvent thisEvent = null;
    if (eventTypeDictionary.TryGetValue(typeof(T), out thisEvent)) {
      thisEvent.AddListener(listener);
    } else {
      thisEvent = new UnityEvent();
      thisEvent.AddListener(listener);
      eventTypeDictionary.Add(typeof(T), thisEvent);
    }
  }

  public void StopListening<T>(UnityAction listener) where T : UnityEvent {
    if (instance == null)
      return;
    UnityEvent thisEvent = null;
    if (eventTypeDictionary.TryGetValue(typeof(T), out thisEvent))
      thisEvent.RemoveListener(listener);
  }


  public void TriggerEvent(UnityEvent e) {
    UnityEvent thisEvent = null;
    if (eventTypeDictionary.TryGetValue(e.GetType(), out thisEvent))
      thisEvent.Invoke();
  }

  #endregion

}
