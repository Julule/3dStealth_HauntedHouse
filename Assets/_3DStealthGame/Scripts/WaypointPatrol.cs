using UnityEngine;

public class WaypointPatrol : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform[] waypoints; // on prend un tableau parce qu'il est plus léger et on a pas besoin d'en éditer la longueur dans ce cas. 

    Rigidbody rigidbody;
    int currentWaypointIndex;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() // le jeu continu à mettre à jour les autres objets même si l'un d'eux bug
    {
        Transform currentWaypoint = waypoints[currentWaypointIndex];
        Vector3 currentToTarget = currentWaypoint.position - rigidbody.position; // délacement complet, qui nous ferait spawn à l'arrivée

        if (currentToTarget.magnitude < 0.1f)
        {
            currentWaypointIndex++;
            currentWaypointIndex = currentWaypointIndex % waypoints.Length; // un modulo pour établir la boucle : point0/3 = point0/3 % 3
        }

        Quaternion rotation = Quaternion.LookRotation(currentToTarget); // on calcule la rotation vers la destination
        rigidbody.MoveRotation(rotation); // On s'y tourne

        // ⬇ déplacement par frame                
        rigidbody.MovePosition(rigidbody.position + currentToTarget.normalized * moveSpeed * Time.fixedDeltaTime); 
        // ici currentToTarget nous permet de réduire le déplacement à une direction seulement (via la normalisation, donc 1, sans incidence sur la longueur).
        //              
    }
}
