using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WarningAudioController : MonoBehaviour
{
  [SerializeField] private AudioClip warningSFX;
  [Range(0.0f, 1.0f)]
  [SerializeField] float warningVolume;

  private AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    audioSource.clip = warningSFX;
    audioSource.volume = warningVolume;
    audioSource.loop = true;

    GameStateManager.OnWarningBarrierEnter += PlayWarningNoise;
    GameStateManager.OnWarningBarrierExit += PauseWarningNoise;
  }

  void OnDestroy()
  {
    GameStateManager.OnWarningBarrierEnter -= PlayWarningNoise;
    GameStateManager.OnWarningBarrierExit -= PauseWarningNoise;
  }

  private void PlayWarningNoise(CharacterType character)
  {
    audioSource.Play();
  }

  private void PauseWarningNoise(CharacterType character)
  {
    audioSource.Stop();
  }
}
