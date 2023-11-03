using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
   private AudioSource _sfxAudioSource;
   private AudioSource _musicAudioSource;
   
   [SerializeField] protected AudioClip[] levelMusic;
   [SerializeField] private float musicVolume = 0.15f;
   [SerializeField] private float sfxVolume = 0.55f;
   
   public bool isSoundOn = true;
   public bool isPaused = false;

   private void Awake()
   {
      //Seperating SFX and Music Audio Sources allows you to tweak volumes for each individually
      _sfxAudioSource = gameObject.AddComponent<AudioSource>();
      _musicAudioSource = gameObject.AddComponent<AudioSource>();
	  
	  // pick a random song for the level
	  int i = Random.Range(0, levelMusic.Length - 1);   
	  PlayMusic( levelMusic[ i ]);
   }

   /// <summary>
   /// Plays Sound Effects
   /// </summary>
   /// <param name="audioClip">The Audio Clip to play</param>
   public void PlaySFX(AudioClip audioClip)
   {
      if (_sfxAudioSource != null && isSoundOn)
      {
		 _sfxAudioSource.volume = sfxVolume;
         _sfxAudioSource.PlayOneShot(audioClip);
      }

   }
   
   public void PlayMusic(AudioClip audioClip)
   {
      if (_musicAudioSource != null && isSoundOn)
      {
		 _musicAudioSource.volume = musicVolume;
		 _musicAudioSource.loop = true;
         _musicAudioSource.PlayOneShot(audioClip);
      }

   }
   
   public void StopMusic() {
	  if (_musicAudioSource != null)
      {
         _musicAudioSource.Stop();
      }
   }
   
   public bool ToggleSound() {
	   isSoundOn = !isSoundOn;
	   if (isSoundOn)
	   {
		   _sfxAudioSource.volume = sfxVolume;
		   int i = Random.Range(0, levelMusic.Length - 1); 
		   PlayMusic( levelMusic[i]);
	   }
	   else {
		   _sfxAudioSource.volume = 0f;
		   StopMusic();
	   }
	   return isSoundOn;
   }
   
   public bool TogglePauseVolume() {
	   isPaused = !isPaused;
	   if (isPaused) {
		   _musicAudioSource.volume = 0.1f;
	   }
	   else {
		   _musicAudioSource.volume = musicVolume;
	   }
	   return isPaused;
   }

}
