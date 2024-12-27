using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BalleDuo : MonoBehaviour
{
    // Alias
    Transform transfo;
    Rigidbody2D rB;
    public AudioSource sons;
    public AudioSource musique;

    // Sons
    public AudioClip sonMurs;
    public AudioClip sonPalette;
    public AudioClip sonPoints;
    public AudioClip arcade;


    // Pointage
    public TextMeshPro tmPRODroit;
    public TextMeshPro tmPROGauche;

    // Definir le pointage initial
    public int pointageMaximal = 10;
    // Declarer les compteurs de points
    int pointsD;
    int pointsG;

    // Position perte de point
    float posPertePointD = 10.0f;
    float posPertePointG = -10.0f;


    // Vitesse de la balle a modifier dans la fenetre Inspector
    public float vitesse = 7.0f;
    float vitesseInitiale;

    // Ecrans 
    public GameObject ecranAccueil;
    public GameObject jeuDuo;

    void Awake()
    {
        // Initialiser les composants
        transfo = gameObject.transform;
        rB = gameObject.GetComponent<Rigidbody2D>();

        // Musique
        musique.clip = arcade;

        // Stocker la vitesse initiale
        vitesseInitiale = vitesse;
    }

    // Fonction qui permet d'executer les actions lors de l'activation du jeu
    private void OnEnable()
    {
        // Jouer la musique
        musique.Play();

        // Repositionner la balle au centre de l'ecran
        transfo.position = Vector2.zero;
        // Eviter l'acceleration cumulative de la balle 
        rB.velocity = Vector2.zero;

        // Remettre la vitesse a sa valeur initiale
        vitesse = vitesseInitiale;

        // Initialiser point
        pointsD = 0;
        pointsG = 0;

        // Convertir les points (entiers) et string (chaine de caracteres) et les afficher
        tmPRODroit.text = pointsD.ToString();
        tmPROGauche.text = pointsG.ToString();

        // Impulsion initiale : Appliquer a la balle une force instentanee en direction diagonale
        // (vers coin droit), d'une amplitude equivalente a la vitesse de deplacement souhaitee 
        rB.AddForce(Vector2.one * vitesse, ForceMode2D.Impulse);
    }

    // Fonction qui permet d'executer les actions lors de la desactivation du jeu
    private void OnDisable()
    {
        // Arreter la musique 
        musique.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Si la position de la balle depasse la limite de perte de points cote Droit
        if (transfo.position.x > posPertePointD)
        {
            // Jouer le son perte de points (Buzz)
            sons.PlayOneShot(sonPoints);
            // Repositionner la balle au centre de l'ecran
            transfo.position = Vector2.zero;
            // Eviter l'acceleration cumulative de la balle 
            rB.velocity = Vector2.zero;
            // La vitesse de la balle augmente de 10%
            vitesse *= 1.1f;
            // Decrementer le pointage
            pointsG = Mathf.Min(pointsG + 1, pointageMaximal);
            tmPROGauche.text = pointsG.ToString();
            // Redonner l'impulsion a la balle une fois repositionnee vers le coin superieur droit
            rB.AddForce(Vector2.one * vitesse, ForceMode2D.Impulse);
        }

        // Si la position de la balle depasse la limite de perte de points cote Gauche
        else if (transfo.position.x < posPertePointG)
        {
            // Jouer le son perte de points (Buzz)
            sons.PlayOneShot(sonPoints);
            // Repositionner la balle au centre de l'ecran
            transfo.position = Vector2.zero;
            // Eviter l'acceleration cumulative de la balle 
            rB.velocity = Vector2.zero;
            // La vitesse de la balle augmente de 10%
            vitesse *= 1.1f;
            // Decrementer le pointage
            pointsD = Mathf.Min(pointsD + 1, pointageMaximal);
            tmPRODroit.text = pointsD.ToString();
            // Redonner l'impulsion a la balle une fois repositionnee vers le coin superieur droit
            rB.AddForce(new Vector2(-1, 1) * vitesse, ForceMode2D.Impulse);
        }

        // Si on atteint le pointage maximal d'un cote ou de l'autre (fin du jeu)
        if (pointsD >= pointageMaximal || pointsG >= pointageMaximal)
        {
            // Afficher l'ecran d'accueil et desactiver l'ecran jeu
            ecranAccueil.SetActive(true);
            jeuDuo.SetActive(false);
        }
    }

    // Fonction qui permet d'executer les actions lorsque deux objets entrent en collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la balle entre en collision avec les palettes
        if (collision.transform.name == "PaletteD" || collision.transform.name == "PaletteG")
        {
            // Jouer une fois l'autre son, qui est specifie dans l'inspecteur (Beep)
            sons.PlayOneShot(sonPalette);
        }
        // Si la collision est avec un autre objet
        else
        {
            // Jouer le son Bleep
            sons.PlayOneShot(sonMurs);
        }
    }
}
