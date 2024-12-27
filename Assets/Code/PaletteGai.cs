using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteGai : MonoBehaviour
{
    // Alias pour composant Transform
    Transform transfo;

    // Reference vers le transform de la balle a definir dans inspector
    public Transform transfoBalle;

    // Limites bordures de l'axe Y
    float limiteDeplacement = 3.5f;

    // Vitesse de suivi de la balle
    public float vitesseSuivi = 5f;

    // Distance vers la balle
    float distanceBalle;
    float deplacement;

    void Start()
    {
        // Initialiser l'alias Transform
        transfo = gameObject.transform;
    }

    void Update()
    {
        // Stocker la position actuelle de la palette
        Vector3 posPalette = transfo.position;

        // Calculer la distance entre la palette et la balle
        distanceBalle = transfoBalle.position.y - posPalette.y;

        // Calculer le deplacement vers la balle
        deplacement = distanceBalle * vitesseSuivi * Time.deltaTime;

        // Mettre a jour la position de la palette
        posPalette.y += deplacement;

        // Comparer la position de la palette avec la limite superieure
        // et stocker la valeur la plus petite
        posPalette.y = Mathf.Min(posPalette.y, limiteDeplacement);

        // Comparer la position de la palette avec la limite inferieure
        // et stocker la valeur la plus grande 
        posPalette.y = Mathf.Max(posPalette.y, -limiteDeplacement);

        // Mettre a jour la position de la palette
        transfo.position = posPalette;
    }
}
