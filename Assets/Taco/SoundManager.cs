using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace Taco
{
    public enum SoundType
    {
        // Put sound names in here
        Walk, Jump, Sit, Bat, Blink, Mouse, Pray, Crack, Howling, Click, Death
    }

    [Serializable]
    public struct SoundList
    {
        [HideInInspector] public string name;
        [Range(0, 1)] public float volume;
        public AudioMixerGroup mixer;
        public AudioClip[] sounds;
    }
    
    [CreateAssetMenu(menuName = "Sounds Asset")]
    public class SoundAsset : ScriptableObject
    {
        public SoundList[] sounds;
    }
    
    public class PlaySoundEnter : StateMachineBehaviour
    {
        [SerializeField] private SoundType sound;
        [SerializeField, Range(0, 1)] private float volume = 1;
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SoundManager.PlaySound(sound, null, volume);
        }
    }
    
    public class PlaySoundExit : StateMachineBehaviour
    {
        [SerializeField] private SoundType sound;
        [SerializeField, Range(0, 1)] private float volume = 1;
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SoundManager.PlaySound(sound, null, volume);
        }
    }
    
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private SoundAsset soundAsset;
        private static SoundManager _instance;
        private AudioSource _audioSource;

        private void Awake()
        {
            if (_instance)
                return;
            
            _instance = this;
            _audioSource = GetComponent<AudioSource>();
        }
        
        /// <summary>
        /// Play a sound at a given volume.
        /// </summary>
        /// <param name="sound">The type of sound to play.</param>
        /// <param name="source">The audio source to play the sound from. If null, the sound is played from the SoundManager.</param>
        /// <param name="volume">The volume to play the sound at. The final volume is the product of this and the volume stored in the SoundAsset.</param>
        public static void PlaySound(SoundType sound, AudioSource source = null, float volume = 1)
        {
            // Get the sound list for the given sound type
            SoundList soundList = _instance.soundAsset.sounds[(int)sound];

            // Get the array of clips associated with the sound
            AudioClip[] clips = soundList.sounds;

            // Choose a random clip from the array
            AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];

            if (source)
            {
                // Set up the audio source and play the sound
                source.outputAudioMixerGroup = soundList.mixer;
                source.clip = randomClip;
                source.volume = volume * soundList.volume;
                source.Play();
            }
            else
            {
                // Set up the audio source on the SoundManager and play the sound
                _instance._audioSource.outputAudioMixerGroup = soundList.mixer;
                _instance._audioSource.PlayOneShot(randomClip, volume * soundList.volume);
            }
        }
    }
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(SoundAsset))]
    public class SoundEditor : Editor
    {
        /// <summary>
        /// Initializes or updates the sound list of the target sound asset.
        /// Ensures that the sound list matches the enum of SoundType, updating elements as necessary.
        /// </summary>
        private void OnEnable()
        {
            // Reference to the sound list of the sound asset
            ref SoundList[] soundList = ref ((SoundAsset)target).sounds;

            // If sound list is null, exit the method
            if (soundList == null)
                return;

            // Get the names of the SoundType enum
            string[] names = Enum.GetNames(typeof(SoundType));
            // Check if the length of names array and soundList are different
            bool differentSize = names.Length != soundList.Length;

            // Dictionary to hold existing sounds for quick lookup
            Dictionary<string, SoundList> sounds = new();

            // Populate the dictionary if sizes are different
            if (differentSize)
            {
                for (int i = 0; i < soundList.Length; ++i)
                {
                    sounds.Add(soundList[i].name, soundList[i]);
                }
            }

            // Resize the soundList to match the number of SoundType names
            Array.Resize(ref soundList, names.Length);
            for (int i = 0; i < soundList.Length; i++)
            {
                string currentName = names[i];
                soundList[i].name = currentName;

                // Ensure volume is set to default if it is zero
                if (soundList[i].volume == 0) soundList[i].volume = 1;

                if (differentSize)
                {
                    // Update sound list elements based on existing dictionary entries
                    if (sounds.TryGetValue(currentName, out SoundList current))
                    {
                        UpdateElement(ref soundList[i], current.volume, current.sounds, current.mixer);
                    }
                    else
                    {
                        // Initialize new elements with default values
                        UpdateElement(ref soundList[i], 1, Array.Empty<AudioClip>(), null);
                    }
                    
                    static void UpdateElement(ref SoundList element, float volume, AudioClip[] sounds, AudioMixerGroup mixer)
                    {
                        element.volume = volume;
                        element.sounds = sounds;
                        element.mixer = mixer;
                    }
                }
            }
        }
    }
    #endif
}