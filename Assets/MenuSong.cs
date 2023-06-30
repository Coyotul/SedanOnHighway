using UnityEngine;

public class MenuSong : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        // Asigurați-vă că componenta AudioSource este atașată în inspector
        if (audioSource != null)
        {
            // Setați loop-ul pe adevărat pentru redarea repetată a melodiei
            audioSource.loop = true;

            // Redați melodia
            audioSource.Play();
        }
    }
}