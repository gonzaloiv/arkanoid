﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

  private State currentState;

  public virtual State GetState<T> () where T : State {
    T state = GetComponent<T>();
    if (state == null)
      state = gameObject.AddComponent<T>();
    return state;
  }

  public virtual void ChangeState<T> () where T : State {
    if (currentState != null)
      currentState.Exit();
    currentState = GetState<T>();
    if (currentState != null)
      currentState.Enter();
  }

}