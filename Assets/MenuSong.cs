using UnityEngine;

public class MenuSong : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        // Make sure the AudioSource component is attached in the inspector
        if (audioSource != null)
        {
            // Set loop to true for repeated playback of the song
            audioSource.loop = true;

            // Play the song
            audioSource.Play();
        }
    }
}