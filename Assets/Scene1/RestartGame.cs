using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField] InterstitialAd _interstitialAd;
    public void OnRestartButtonClicked()
    {
        _interstitialAd.LoadAd();
        // Find the PlayerController script in the scene and call the RestartGame method
        FindObjectOfType<PlayerController>()?.RestartGame();
    }
}