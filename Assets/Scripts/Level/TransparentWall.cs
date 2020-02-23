using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    public Material transparentMat; 
    public Transform parent; 
    private Renderer[] renderers; 
    private int playersInTrigger; 
    private Dictionary<GameObject, Material> originalMaterials = new Dictionary<GameObject,Material>();

    private void Awake()
    {
        renderers = parent.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            Material mat = new Material(Shader.Find("Specular"));
            mat.CopyPropertiesFromMaterial(renderer.material);
            originalMaterials.Add(renderer.gameObject, mat); 
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag != Consts.TAG_PLAYER) return; 
        playersInTrigger++;
        ChangeTransparency(.05f);
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag != Consts.TAG_PLAYER) return;

        playersInTrigger--;
        playersInTrigger = Mathf.Clamp(playersInTrigger, 0, int.MaxValue);
        
        if(playersInTrigger > 0) return; 
        ChangeTransparency(1f);   
    }

    private void ChangeTransparency(float alpha)
    {
        foreach (var renderer in renderers)
        {
            renderer.material = (alpha == 1) ? originalMaterials[renderer.gameObject] : transparentMat;
            Color transparent = new Color(renderer.material.color.r,renderer.material.color.g, renderer.material.color.b, alpha);
            renderer.material.color = transparent;
        }
    }
}
