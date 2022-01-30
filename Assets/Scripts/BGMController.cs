using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{

  [SerializeField] AudioClip[] audioClips;
  [SerializeField] AudioSource BGMSource;

    void Start()
    {
    BGMSource.clip = audioClips[Random.Range(0, audioClips.Length)];
    BGMSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
