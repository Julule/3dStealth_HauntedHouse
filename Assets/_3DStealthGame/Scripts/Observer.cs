using Unity.VisualScripting;
using UnityEngine;

public class Observer : MonoBehaviour
{
    bool playerIsInside;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform player; 
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {  
        playerIsInside = true;
        player = other.transform;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInside = false;   
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsInside)
        {
            Vector3 direction = player.position - transform.position; // position du player - position de ce script-ci
            Debug.DrawRay(transform.position, player.position*10f,Color.red);
            // pour typer une variable de dir de vecteur vertic
            direction += Vector3.up;
            Ray ray = new(transform.position, player.position);
            RaycastHit hit; 


            // la fonction reçoit ray, et rempli le out ("panier" que la fonction rempli)
            if(Physics.Raycast(ray, out hit ))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Got you !!!!");
                }
            }       
        }
    }
}
