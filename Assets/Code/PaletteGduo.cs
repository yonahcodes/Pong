using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteGduo : MonoBehaviour
{
    // Alias pour composant Transform
    Transform transfo;

    // Limites bordures de l'axe Y
    float limiteDeplacement = 3.5f;

    // Vitesse de deplacement a modifier dans la fenetre Inspector
    public float vitesseDeplacement = 1.0f;

    void Start()
    {
        // Initialiser l'alias Transform
        transfo = gameObject.transform;
    }

    void Update()
    {
        // Stocker la position actuelle de la palette
        Vector3 posPalette = transfo.position;

        // Calculer le deplacement en utilisant le types de saisies defines dans l'input manager
        posPalette.y += vitesseDeplacement * Time.deltaTime * Input.GetAxis("VerticalGauche");

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
