using System.Collections;
using TMPro;
using UnityEngine;
public class Dialog : MonoBehaviour
{
    [SerializeField]
    [TextArea] string[] output;
    public float time = 0.5f;
    //public bool flag = false;
    public float timescale = 1f;
    TextMeshProUGUI txt;
    public void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();

        StartCoroutine(c_Text());
    }
    IEnumerator c_Text()
    {
        for (int i = 0; i < output.Length; i++)
        {
            string dialog = output[i]; 
            yield return new WaitForSecondsRealtime(timescale);
            for (int j = 0; j < dialog.Length; ++j)
            {
                txt.text += dialog[j];

                yield return new WaitForSecondsRealtime(time);
            }
            txt.text = "";
        }
    }
}
