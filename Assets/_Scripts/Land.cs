using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public enum LandStatus {
        Soild,
        Farmland,
        Watered
    }

    public LandStatus landStatus;
    public Material soilMat, farmMat, wateredMat;
    new Renderer renderer;
    public GameObject select;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.Soild);
        Select(false);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        landStatus = statusToSwitch;
        Material materialToSwitch = soilMat;
        switch(statusToSwitch)
        {
            case LandStatus.Soild:
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland:
                materialToSwitch = farmMat;
                break;
            case LandStatus.Watered:
                materialToSwitch = wateredMat;
                break;
        }

        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    //Cuando el usuario presiona interacción con tierra seleccionada
    public void Interact()
    {
        SwitchLandStatus(LandStatus.Farmland);
    }
}
