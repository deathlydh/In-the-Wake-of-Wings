using UnityEngine;

public class TestCutscene : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CutsceneManager.Instance.StartCutscene("Cutscene_1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CutsceneManager.Instance.StartCutscene("Cutscene_2");
        }
    }
}
