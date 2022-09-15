using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private RaycastHit2D hitWalls;
    public LayerMask colMask;

    public Transform rayPos;
    public ParticleSystem particle;
    public List<GameObject> allSounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject newSound = Instantiate(allSounds[0]);
        newSound.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }
    public void Movement()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        hitWalls = Physics2D.Raycast(rayPos.position, Vector2.right * speed, 0.01f, colMask);
        if (hitWalls == true)
        {
            speed *= -1;
            if (speed > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    public void OnMouseDown()
    {
        
        GameObject newSound = Instantiate(allSounds[1]);
        Destroy(newSound, 3);
        particle.GetComponent<ParticleSystem>().startColor = transform.GetComponent<SpriteRenderer>().color;

        Instantiate(particle, transform.position, Quaternion.identity);        
        Destroy(gameObject);
    }

}
