using UnityEngine;

public class Qwest_four : MonoBehaviour
{
    public GameObject redCube;
    public GameObject blueCube;
    public GameObject greenCube;
    public GameObject YellowCube;
    public GameObject WhithCibe;

    private bool isRedCubeHit, isBlueCubeHit, isGreenCubeHit, isYellowCubeHit, isWhithCibeHit;
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
                blueCube.SetActive(true);
                greenCube.SetActive(true);
                YellowCube.SetActive(true);
                WhithCibe.SetActive(true);

                isYellowCubeHit = false;
                isWhithCibeHit = false;
                isBlueCubeHit = false;
                isGreenCubeHit = false;

            }
            else if (hitObject == blueCube)
            {
                blueCube.SetActive(false);
                greenCube.SetActive(true);

                isBlueCubeHit = true;
                isGreenCubeHit = false;

            }
            else if (hitObject == greenCube)
            {
                greenCube.SetActive(false);
                redCube.SetActive(false);

                isGreenCubeHit = true;
                isRedCubeHit = true;

            }
            //hard
            else if (hitObject == YellowCube)
            {
                greenCube.SetActive(false);
                blueCube.SetActive(true);
                YellowCube.SetActive(false);

                isGreenCubeHit = true;
                isYellowCubeHit = true;
                isBlueCubeHit = false;


            }
            else if (hitObject == WhithCibe)
            {
                blueCube.SetActive(false);
                WhithCibe.SetActive(false);

                isBlueCubeHit = true;
                isWhithCibeHit = true;

            }
            if (isRedCubeHit && isBlueCubeHit && isGreenCubeHit && isWhithCibeHit && isYellowCubeHit)
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

