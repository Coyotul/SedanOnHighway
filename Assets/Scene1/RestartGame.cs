using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        FindObjectOfType<PlayerController>()?.RestartGame();
    }
}