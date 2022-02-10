using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // -- Gestion de la position de la camera -- //
    public GameObject targetObject; // Objet suivis par la camera
    public Vector3 positionOffset; // Difference entre la position de la camera et celle de l'objet suivis
    public float timeOffset; // Temps de reaction de la camera

    private Vector3 velocity; // Velocité de la camera

    public void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetObject.transform.position + positionOffset, ref velocity, timeOffset); // Permet de déplacer un endroit en un autre 
    }
}