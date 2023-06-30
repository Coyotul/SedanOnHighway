using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public float minYSpeed;
    public float maxYSpeed;
    [SerializeField] Sprite[] carSprites;
    [SerializeField] private GameObject _player;
    [SerializeField] private BoxCollider2D truckCollider;

    private float speed;
    private SpriteRenderer spriteRenderer;
    private bool isLeft = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Alege un sprite aleatoriu din lista de sprite-uri
        int randomSpriteIndex = Random.Range(0, carSprites.Length);
        spriteRenderer.sprite = carSprites[randomSpriteIndex];
        
        if (spriteRenderer.sprite.name == "truck")
        {
            // Obține referința către collider-ul tirului

            // Mărește dimensiunile collider-ului de două ori
            truckCollider.size *= 2f;
        }
        // Verifică punctul de spawn și setează viteza corespunzătoare
        if (transform.position.x == -2) //spawn1
        {
            isLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            speed = -Random.Range(minYSpeed, maxYSpeed);
        }
        else if (transform.position.x == -0.75) //spawn2
        {
            isLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            speed = -Random.Range(minYSpeed, maxYSpeed);
        }
        else if (transform.position.x == 0.7) //spawn3
        {
            isLeft = false;
            speed = -Random.Range(minYSpeed - 2, minYSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else //spawn4
        {
            isLeft = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            speed = -Random.Range(minYSpeed - 2, minYSpeed);
        }
    }

    private void Update()
    {
        if (isLeft)
            CarMovementLeft();
        else
        {
            CarMovementRight();
        }
    }

    private void CarMovementLeft()
    {
        // Mișcarea mașinii pe axa y
        transform.Translate(-Vector2.up * speed * Time.deltaTime);

        // Distrugerea mașinii când iese din ecran
        if (transform.position.y < -7f || transform.position.y > 7f)
            Destroy(gameObject);
        if (Input.GetKeyDown(KeyCode.G))
            CarSpawner.StopSpawning();
    }

    private void CarMovementRight()
    {
        // Mișcarea mașinii pe axa y
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Distrugerea mașinii când iese din ecran
        if (transform.position.y < -6f || transform.position.y > 6f)
            Destroy(gameObject);
        if (Input.GetKeyDown(KeyCode.G))
            CarSpawner.StopSpawning();
    }
    
}
