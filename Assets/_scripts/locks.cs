using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class locks : MonoBehaviour
{
    [SerializeField]
    private string code;
    public string curCode;
    [SerializeField]
    private UnityEvent open;
    [SerializeField]
    private Text txt;
    [SerializeField]
    private GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void inputKey(int c)
    {
        if (curCode.Length <= 3)
        {
            curCode += c;
            txt.text = curCode;
        }
        else
        {

        }
    }
    public void deleteLastChar()
    {
        //curCode.Remove(curCode.Length);
        curCode = "";
        txt.text = curCode;
    }
    public void AplyPassword()
    {
        if(curCode.Length == 4)
        {
            if(curCode == code)
            {
              open.Invoke();
            }
            else
            {
                curCode = "";
                txt.text = curCode;
            }
        }
    }
}
