using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        // Find the PlayerController script in the scene and call the RestartGame method
        FindObjectOfType<PlayerController>()?.RestartGame();
    }
}