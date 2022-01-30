using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterAudioController : MonoBehaviour
{
  [SerializeField] private AudioClip jumpSFX;
  [Range(0.0f, 1.0f)]
  [SerializeField] float jumpVolume;
  [SerializeField] private AudioClip landingSFX;
  [Range(0.0f, 1.0f)]
  [SerializeField] float landingVolume;

  [Range(0.0f, 2.0f)]
  [SerializeField] float sourcePitch;
  private AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    audioSource.pitch = sourcePitch;

    CharacterMovement.OnJump += PlayJumpSFX;
    CharacterMovement.OnLandFromJump += PlayLandingSFX;
  }

  private void PlayJumpSFX(GameObject sourceActor)
  {
    if (this.gameObject.Equals(sourceActor))
    {
      audioSource.PlayOneShot(jumpSFX, jumpVolume);
    }
  }

  private void PlayLandingSFX(GameObject sourceActor)
  {
    if (this.gameObject.Equals(sourceActor))
    {
      audioSource.PlayOneShot(landingSFX, landingVolume);
    }
  }
}
