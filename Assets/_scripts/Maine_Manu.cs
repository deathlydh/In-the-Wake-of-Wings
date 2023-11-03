using UnityEngine;
using UnityEngine.SceneManagement;

public class Maine_Manu : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void load()
    {
        //ну мне бл что объйаснйать
    }
    public void Settings()
    {
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
