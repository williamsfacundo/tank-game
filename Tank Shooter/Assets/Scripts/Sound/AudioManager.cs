using System;
using UnityEngine;

namespace TankGame.Sound 
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        public static string SoundKeyName = "SoundActiveStatus";
        
        [SerializeField] private SoundData[] musicSounds;

        [SerializeField] private SoundData[] sfxSounds;

        [SerializeField] private AudioSource musicAudioSource;

        [SerializeField] private AudioSource sfxAudioSource;

        private void Awake()
        {
            if (Instance == null) 
            {
                Instance = this;

                DontDestroyOnLoad(gameObject);
            }
            else 
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (musicAudioSource != null) 
            {
                musicAudioSource.loop = true;
            }
            else 
            {
                Debug.LogError("No music audio source was assigned!");
            }

            if (sfxAudioSource != null)
            {
                sfxAudioSource.loop = false;
            }
            else
            {
                Debug.LogError("No sfx audio source was assigned!");
            }
        }

        public void SetMusic(string musicName) 
        {
            SoundData sound = Array.Find(musicSounds, x => x.SoundName == musicName);

            if (sound == null)
            {
                Debug.LogWarning("No music sound name matches with " + musicName);
            }
            else 
            {
                musicAudioSource.clip = sound.Clip;
            }
        }

        public void PlayMusic(string musicName) 
        {
            if (musicAudioSource.clip != null) 
            {
                musicAudioSource.Play();
            }
        }

        public void StopMusic()
        {
            if (musicAudioSource.clip != null)
            {
                musicAudioSource.Stop();
            }
        }

        public void PauseMusic()
        {
            if (musicAudioSource.clip != null)
            {
                musicAudioSource.Pause();
            }
        }

        public void SetSfx(string sfxName)
        {
            SoundData sound = Array.Find(sfxSounds, x => x.SoundName == sfxName);

            if (sound == null)
            {
                Debug.LogWarning("No music sound name matches with " + sfxName);
            }
            else
            {
                sfxAudioSource.clip = sound.Clip;
            }
        }

        public void PlaySfx(string musicName)
        {
            if (sfxAudioSource.clip != null)
            {
                sfxAudioSource.Play();
            }
        }

        public void StopSfx()
        {
            if (sfxAudioSource.clip != null)
            {
                sfxAudioSource.Stop();
            }
        }

        public void PauseSfx()
        {
            if (sfxAudioSource.clip != null)
            {
                sfxAudioSource.Pause();
            }
        }
    }
}