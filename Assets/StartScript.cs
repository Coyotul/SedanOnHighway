using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript: MonoBehaviour
{
    public string sceneName; // Numele scenei către care dorim să schimbăm

    // Funcția apelată atunci când apăsăm pe butonul de start
    public void OnStartButtonClicked()
    {
        // Schimbăm scena folosind numele scenei specificat
        SceneManager.LoadScene(sceneName);
    }
}