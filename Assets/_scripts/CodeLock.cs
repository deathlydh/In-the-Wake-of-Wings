using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{
    public string password;
    [SerializeField]
    private UnityEvent open;
    [SerializeField]
    private Text txt;
    [SerializeField]
    private GameObject UI;

    public Transform camera_TR;
    private RaycastHit hit;
    // public Door _Door;
    string entered_password;
    public LayerMask ray_layermask;

    private void Start()
    {
        print(password);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(camera_TR.position, camera_TR.TransformDirection(Vector3.forward), out hit, 5, ray_layermask))
            {
                if(hit.collider.tag == "Codelock_button")
                {
                    if(hit.collider.name != "Enter")
                    {
                        entered_password = entered_password.Remove(0, 1);
                        entered_password = entered_password.Insert(password.Length - 1, hit.collider.name);
                        print(hit.collider.name);
                        print("Ввели " + entered_password);
                    }
                    else
                    {
                        print("Проверка пароля");
                        if(entered_password == password)
                        {
                            print("Замок открыт ");
                            Destroy(this);
                        }
                        else
                        {
                            print("Неверный пароль");
                        }
                    }
                }
            }
        }
    }





}
