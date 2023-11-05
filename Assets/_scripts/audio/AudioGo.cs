using System;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioGo : MonoBehaviour
{

    private PARAMETER_DESCRIPTION ParametrDiscription;
    private PARAMETER_ID poverhnostID;

    private string str;
    [SerializeField] private EventReference _stepsEventReference;

    public string texture => str;

    private void Start()
    {
        const string nameParam = "Poverhnost";
        RuntimeManager.StudioSystem.getParameterDescriptionByName(nameParam, out ParametrDiscription);
        poverhnostID = ParametrDiscription.id;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, -transform.up, Color.red );
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Renderer render = hit.collider.GetComponent<Renderer>();
            Terrain hitTerrain = hit.collider.GetComponent<Terrain>();//null
            if (hitTerrain)
            {
                PlayFootstepSoundFromTerrain(hitTerrain, hit.point);
                //RuntimeManager.StudioSystem.setParameterByIDWithLabel(poverhnostID, str);// ��������
            }
            else
            {
                PlayFootMaterial(render);
            }
        }
    }
    private void PlayFootstepSoundFromTerrain(Terrain terrain, Vector3 HitPoint)
    {
        Vector3 terrainPosition = HitPoint - terrain.transform.position;
        Vector3 splatMapPosition = new Vector3(
            terrainPosition.x / terrain.terrainData.size.x,
            0,
            terrainPosition.z / terrain.terrainData.size.z);
        int x = Mathf.FloorToInt(splatMapPosition.x * terrain.terrainData.alphamapWidth);
        int z = Mathf.FloorToInt(splatMapPosition.z * terrain.terrainData.alphamapHeight);
        float[,,] alphaMap = terrain.terrainData.GetAlphamaps(x, z, 1, 1);

        int primeryIndex = 0;
        for (int i = 1; i < alphaMap.Length; i++)
        {

            if (alphaMap[0, 0, i] > alphaMap[0, 0, primeryIndex])
            {
                primeryIndex = i;
            }
        }
        str = terrain.terrainData.terrainLayers[primeryIndex].name;

    }
    private void PlayFootMaterial(Renderer renderer)
    {
        str = renderer.material.GetTexture("_MainTex").name;
    }

    internal void PlaySteps()
    {
        Debug.Log($"Audio Go: texture is {texture}");
        RuntimeManager.StudioSystem.setParameterByIDWithLabel(poverhnostID, texture);
        RuntimeManager.PlayOneShot(_stepsEventReference, gameObject.transform.position);
    }


}
