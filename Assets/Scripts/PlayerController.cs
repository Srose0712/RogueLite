using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rbody;
    private Vector2 moveVelocity;

    public Animator animation;

    public List<GameObject> lives;
    public float speed;

    //[SerializeField]
    //private ParticleSystem flares;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private AudioSource laserSound;
   

	// Use this for initialization
	void Start () 
    {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Gets Input for player movement
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        // Sets Speed parameter for animations
        animation.SetFloat("Speed", Input.GetAxis("Horizontal") * speed);

        FireLaser();

        // Sets Player death and audio
        if(lives.Count == 0)
        {
            AudioSource explodeSound = GameObject.Find("GameManager").GetComponent<AudioSource>();
            explodeSound.Play();

            Destroy(this.gameObject);
            GameObject explosionClone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosionClone, 0.5f);
        }
	}

    void FixedUpdate()
    {
        rbody.MovePosition(rbody.position + moveVelocity * Time.fixedDeltaTime);
    }


    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            laserSound.Play();
            Transform spawnArea = gameObject.transform.GetChild(1).transform;
            GameObject laserClone = Instantiate(laser, spawnArea.position, spawnArea.rotation);

            laserClone.GetComponent<Rigidbody2D>().AddForce(this.transform.up * 1000);

            Destroy(laserClone, 1.0f);
        }
        
   }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid"){

            Destroy(lives[0].gameObject);
            lives.Remove(lives[0]);
        }
    }

}
