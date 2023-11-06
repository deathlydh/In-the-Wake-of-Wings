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
    public TextMeshProUGUI txt;
    private bool flag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        FuncSub();
    }
    public void FuncSub()
    {
	if (!flag)
	{
	StartCoroutine(c_Text());
    	flag = true;
	}
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
