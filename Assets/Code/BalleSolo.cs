using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BalleSolo : MonoBehaviour
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
    public TextMeshPro tmPRO;
    // Definir le pointage initial
    public int pointageInitial = 10;
    // Declarer le compteur de points
    int points;
    // Position perte de point
    float posPertePoint = 10.0f;

    // Vitesse de la balle a modifier dans la fenetre Inspector
    public float vitesse = 7.0f;

    // Ecrans 
    public GameObject ecranAccueil;
    public GameObject jeuSolo;

    void Awake()
    {
        // Initialiser les composants
        transfo = gameObject.transform;
        rB = gameObject.GetComponent<Rigidbody2D>();

        // Musique
        musique.clip = arcade;
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

        // Impulsion initiale : Appliquer a la balle une force instentanee en direction diagonale
        // (vers coin droit), d'une amplitude equivalente a la vitesse de deplacement souhaitee 
        rB.AddForce(Vector2.one * vitesse, ForceMode2D.Impulse);

        // Initialiser point
        points = pointageInitial;
        // Convertir les points (entiers) et string (chaine de caracteres) et les afficher
        tmPRO.text = points.ToString();
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
        // Si la position de la balle depasse la limite de perte de points
        if (transfo.position.x > posPertePoint)
        {
            // Jouer le son perte de points (Buzz)
            sons.PlayOneShot(sonPoints);

            // Repositionner la balle au centre de l'ecran
            transfo.position = Vector2.zero;
            // Eviter l'acceleration cumulative de la balle 
            rB.velocity = Vector2.zero;

            // La vitesse de la balle augmente de 10%
            vitesse *= 1.1f;

            // Redonner l'impulsion a la balle une fois repositionnee
            rB.AddForce(Vector2.one * vitesse, ForceMode2D.Impulse);

            // Decrementer le pointage
            points--;
            tmPRO.text = points.ToString();

            // Si il n'y a plus de points (fin du jeu)
            if (points == 0)
            {
                // Afficher l'ecran d'accueil et desactiver l'ecran jeu
                ecranAccueil.SetActive(true);
                jeuSolo.SetActive(false);
            }
        }
    }

    // Fonction qui permet d'executer les actions lorsque deux objets entrent en collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la balle entre en collision avec la palette
        if (collision.transform.name == "Palette")
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
