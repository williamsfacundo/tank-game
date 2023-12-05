using System;

using UnityEngine;

namespace TankGame.Sound 
{
    [Serializable]
    public class SoundData
    {
        [SerializeField] private string soundName;

        [SerializeField] private AudioClip clip;

        public string SoundName 
        {
            get
            {
                return soundName;
            }
        }

        public AudioClip Clip 
        {
            get 
            { 
                return clip; 
            }
        }
    }
}