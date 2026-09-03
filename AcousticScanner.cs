using UnityEngine;
using System.Collections.Generic;

public class StrataManager : MonoBehaviour
{
    public enum TemporalLayer { Past, Present, Future }
    public TemporalLayer currentLayer = TemporalLayer.Present;

    [System.Serializable]
    public struct LayerData
    {
        public TemporalLayer layer;
        public Material environmentMaterial;
        public GameObject layerRootObject;
    }

    public List<LayerData> layers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ShiftLayer(TemporalLayer.Past);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ShiftLayer(TemporalLayer.Present);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ShiftLayer(TemporalLayer.Future);
    }

    public void ShiftLayer(TemporalLayer newLayer)
    {
        currentLayer = newLayer;
        
        foreach (var data in layers)
        {
            bool isActive = (data.layer == currentLayer);
            if (data.layerRootObject != null)
            {
                data.layerRootObject.SetActive(isActive);
            }
        }

        Debug.Log("Passato allo strato temporale: " + currentLayer);
    }
}
