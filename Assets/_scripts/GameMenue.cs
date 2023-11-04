using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            IsOpenMenue = !IsOpenMenue;
            OpenCloseMenue();
        }
    }
    private void OpenCloseMenue()
    {
        Menue.SetActive(IsOpenMenue);
        camY.enabled = !IsOpenMenue;
        camX.enabled = !IsOpenMenue;
        if (IsOpenMenue)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
}
