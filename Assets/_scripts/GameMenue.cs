using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenue : MonoBehaviour
{
    [SerializeField]
    private bool IsOpenMenue;
    [SerializeField]
    private GameObject Menue;
    [SerializeField]
    private Mause_Luck camY;
    [SerializeField]
    private Mause_Luck camX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            OpenCloseMenue(IsOpenMenue);
        }
    }
    public void OpenCloseMenue(bool p_isOpen)
    {
        IsOpenMenue = !IsOpenMenue;
        Menue.SetActive(p_isOpen);
        camY.enabled = !p_isOpen;
        camX.enabled = !p_isOpen;
        cursorEnabled(p_isOpen);


    }
   public void GoToScene()
    {
        SceneManager.LoadScene("Main_Manu");
    }
    public void cursorEnabled(bool isEnable)
    {
        if (isEnable)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
