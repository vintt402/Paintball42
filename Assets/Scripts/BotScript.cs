using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
    //Das Ziel soll immer ein anderes GameObject sein. Wenn der Bot nah am Spieler ist soll er den Spieler töten, wenn nicht, dann soll er die Flagge holen.
   //public GameObject Ziel;
   //public float Abstand_Player;
   public float Rotate_speed = 200f;
   //Wenn der Bott richtig ausgerichtet ist, dann wird die Variable auf true gesetzt und der Bott fährt nach forne bis sie false ist.
   public bool Ausrichtung = false;
   public float Richtung = 1f;
   //Speed soll die Geschwindigkeit sein, mit der der Bot forwärts geht.
   public float speed = 5f;
   public Transform playerTransform;
    public float wallDistance = 1f;
    public LayerMask obstacleLayer;
    private Rigidbody2D rb2d;
    private bool isFacingRight = true;
public float vilocity = 5f;
public Vector2 playerDirecion;

void Start()
{
    rb2d = GetComponent<Rigidbody2D>();
}
void FixedUpdate()
{
    Vector2 playerDirection = (Vector2)(playerTransform.position - transform.position);

    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, wallDistance, obstacleLayer);
    if (hit.collider != null)
    {
        Vector2 normal = hit.normal;
        Vector2 reflectDirection = Vector2.Reflect(playerDirecion.normalized, normal);
        transform.right = reflectDirection;
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        //Ausrichtung = false;
        transform.Rotate(0f, Rotate_speed, 0f);
    }
}
   void Update()
   {
   Vector2 playerDirection = (Vector2)(playerTransform.position - transform.position);
    //Überprüfung, ob der Bot den Player anschaut
    Vector2 playerDirecion = (Vector2)(playerTransform.position - transform.position);
    if (Vector2.Dot(transform.right, playerDirecion) > 0f)
    {
        Ausrichtung = true;
    }
    else
    {
       
        Ausrichtung = false;
    }



//Drehen oder Laufen
    if (Ausrichtung == false)
    {
    transform.Rotate(0, 0, Richtung * Rotate_speed * Time.deltaTime);
    }
    if (Ausrichtung == true)
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

   }
    
}
