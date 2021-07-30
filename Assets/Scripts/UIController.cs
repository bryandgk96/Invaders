using UnityEngine;
// ReSharper disable All

public class UIController : MonoBehaviour
{
    public static UIController instance;
    
    public GameObject loginUser;
    public GameObject gameUser;
    public GameObject scoreboardUI;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
    }

    public void Limpiar()
    {
        loginUser.SetActive(false);
        gameUser.SetActive(false);
        scoreboardUI.SetActive(false);
    }

    public void LoginScreen()
    {
        Limpiar();
        loginUser.SetActive(true);
    }
    public void GameScreen()
    {
        Limpiar();
        gameUser.SetActive(true);
    }
    public void ScoreboardScreen()
    {
        Limpiar();
        scoreboardUI.SetActive(true);
    }
}
