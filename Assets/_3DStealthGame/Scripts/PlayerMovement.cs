using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;
    public float walkSpeed = 1.0f; // pourquoi pas double : c'est 2fois l'espace mem. ! f pour éviter qu'il trans en double par défaut

    public float turnSpeed = 20f;
    Rigidbody playerRigidbody; // déclaration d'un variable de type Rigidbody (private par defaut)
    Animator animator;

    void Start()
    {   
        playerRigidbody = GetComponent<Rigidbody>();
        moveAction.Enable();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() // Update qui va à la même vitesse tout le temps
    {
        Vector2 direction = moveAction.ReadValue<Vector2>(); // renvoie un vecteur2 (2d)
        if(direction != Vector2.zero)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        float horizontal = direction.x;
        float vertical = direction.y;

        Vector3 movement = new(horizontal, 0f, vertical);
        movement.Normalize(); // on remet la longueur à parcourir à 1

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.fixedDeltaTime, 0f);

        Quaternion rotation = Quaternion.LookRotation(desiredForward);

        playerRigidbody.MoveRotation(rotation);
        playerRigidbody.MovePosition(playerRigidbody.position + movement * walkSpeed * Time.fixedDeltaTime); // on calcule le déplacement vie l'opération : positionactuelle + movement*rapidité*temps

    }
    
}
