using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : Singleton<SoundManager> {

  #region Fields

  [SerializeField] private AudioClip[] ballHitSounds;
  [SerializeField] private AudioClip paddleMissSound;
  private AudioSource audioSource; 

  #endregion

  #region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

	void OnEnable () {
    EventManager.StartListening<BallHit>(OnBallHit);
    EventManager.StartListening<PaddleMiss>(OnPaddleMiss);
	}

  void OnDisable () {
    EventManager.StopListening<BallHit>(OnBallHit);
    EventManager.StopListening<PaddleMiss>(OnPaddleMiss);
	}

  #endregion

  #region Private Behaviour

  private void OnBallHit() {
    audioSource.PlayOneShot(ballHitSounds[Random.Range(0, ballHitSounds.Length)]);
  }

  private void OnPaddleMiss() {
    audioSource.PlayOneShot(paddleMissSound);

  }

  #endregion

}
