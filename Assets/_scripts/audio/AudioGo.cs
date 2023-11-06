using System;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class AudioGo : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;//
    [SerializeField] private EventReference _stepsEventReference;
    [SerializeField] private EventReference _jumpEventReference;
    
    private string _surfaceMaterial;

    private PARAMETER_DESCRIPTION _parametrDiscription;
    private PARAMETER_ID _poverhnostID;
    //private bool flag;
    private void Start()
    {
        const string nameParam = "Poverhnost";
        RuntimeManager.StudioSystem.getParameterDescriptionByName(nameParam, out _parametrDiscription);
        _poverhnostID = _parametrDiscription.id;
    }

    void Update()
    {
        SetSurfaceMaterial();
        if(_characterController.velocity.magnitude > 0.1 && _characterController.isGrounded)
        {
            PlaySteps();
        }
        

    }

    private void SetSurfaceMaterial()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, -transform.up, Color.red);
    
        if (Physics.Raycast(ray, out var hit))
        {
            Renderer render = hit.collider.GetComponent<Renderer>();
            Terrain hitTerrain = hit.collider.GetComponent<Terrain>();
            if (hitTerrain)
            {
                SetFootstepTerrainSurface(hitTerrain, hit.point);
            }
            else if(render)
            {
                PlayFootRendererSurface(render);
            }
        }
    }

    private void SetFootstepTerrainSurface(Terrain terrain, Vector3 HitPoint)
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

        _surfaceMaterial = terrain.terrainData.terrainLayers[primeryIndex].name;
        //Debug.Log($"Audio Go: surface texture is {_surfaceMaterial}");
        RuntimeManager.StudioSystem.setParameterByIDWithLabel(_poverhnostID, _surfaceMaterial);
    }

    private void PlayFootRendererSurface(Renderer renderer)
    {
        if(renderer == null|| renderer.material == null)
        {
            return;
        }
        _surfaceMaterial = renderer.material.GetTexture("_MainTex")?.name;
    }

    private void PlaySteps()
    {
        RuntimeManager.PlayOneShot(_stepsEventReference, gameObject.transform.position);
    }
    public void PlayJump()
    {
        RuntimeManager.PlayOneShot(_jumpEventReference, gameObject.transform.position);
    }
}

