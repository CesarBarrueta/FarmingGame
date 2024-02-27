using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    PlayerController playerController;
    Land selectedLand = null;

    // Start is called before the first frame update
    void Start()
    {
        //Access to the parent PlayerController
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down,out hit,  1))
        {
            OnInteractableHit(hit);
        }
    }

    //Maneja lo que pasa cuando el raycast toca alguna interacción 
    public void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;
        if(other.tag == "Land")
        {
            Land land = other.GetComponent<Land>();
            SelectLand(land);
            return;
        }

        //Deselecciona la tierra si el personaje no está junto a ella
        if(selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }
    }

    //Maneja como se selecciona un pedazo de tierra
    public void SelectLand(Land land)
    {
        if(selectedLand != null)
        {
            selectedLand.Select(false);
        }
        selectedLand = land;
        land.Select(true);
    }

    //Se ejecuta cuando el usuario presiona la tecla de interacción
    public void Interact()
    {
        if(selectedLand != null)
        {
            selectedLand.Interact();
            return;
        }
        Debug.Log("No hay tierra");   
    }
}
