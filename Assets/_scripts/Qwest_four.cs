using UnityEngine;

public class Qwest_four : MonoBehaviour
{
    public GameObject redCube;
    public GameObject blueCube;
    public GameObject greenCube;
    private bool isRedCubeHit, isBlueCubeHit, isGreenCubeHit;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            swappingElment();
        }
    }
    private void swappingElment()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject == redCube)
            {
                blueCube.SetActive(false);
                greenCube.SetActive(true);
                isBlueCubeHit = true;
                isGreenCubeHit = false;

            }
            else if (hitObject == blueCube)
            {
                greenCube.SetActive(false);
                blueCube.SetActive(false);

                isBlueCubeHit = true;
                isGreenCubeHit = true;

            }
            else if (hitObject == greenCube)
            {
                redCube.SetActive(false);
                blueCube.SetActive(true);

                isRedCubeHit = true;
                isBlueCubeHit = false;

            }
            if (isRedCubeHit && isBlueCubeHit && isGreenCubeHit)
            {
                CallMethod();
            }
        }
    }
    private void CallMethod()
    {
        Debug.Log("check");
    }
}

