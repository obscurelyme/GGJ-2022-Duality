using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameAudioController : MonoBehaviour
{

  [SerializeField] private AudioClip winSFX;
  [Range(0.0f, 1.0f)]
  [SerializeField] float winVolume;

  [SerializeField] private AudioClip loseSFX;
  [Range(0.0f, 1.0f)]
  [SerializeField] float loseVolume;

  private AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();

    GameStateManager.OnDeath += PlayLoseSFX;
    GameStateManager.OnWin += PlayWinSFX;
  }

  private void PlayLoseSFX()
  {
    audioSource.PlayOneShot(loseSFX, loseVolume);
  }

  private void PlayWinSFX()
  {
    audioSource.PlayOneShot(winSFX, winVolume);
  }
}
