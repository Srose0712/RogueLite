using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rbody;

    public List<GameObject> lives;

    [SerializeField]
    private ParticleSystem flares;
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private AudioSource laserSound;
   

	// Use this for initialization
	void Start () {

        rbody = this.gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        FireLaser();

        bool goForward = Input.GetKey(KeyCode.W);
        bool turnLeft = Input.GetKey(KeyCode.A);
        bool turnRight = Input.GetKey(KeyCode.D);

        if(goForward){
            rbody.AddForce(this.transform.up * 2);

            flares.Emit(1);
        }
        else if(turnLeft){
            rbody.AddTorque(500);
        }
        else if(turnRight){
            rbody.AddTorque(-500);
        }

        if(lives.Count == 0){

            AudioSource explodeSound = GameObject.Find("GameManager").GetComponent<AudioSource>();
            explodeSound.Play();

            Destroy(this.gameObject);
            GameObject explosionClone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosionClone, 0.5f);
        }
	}

    void FireLaser(){

        if (Input.GetKeyDown(KeyCode.Space)){

            laserSound.Play();
            Transform spawnArea = gameObject.transform.GetChild(1).transform;
            GameObject laserClone = Instantiate(laser, spawnArea.position, spawnArea.rotation);

            laserClone.GetComponent<Rigidbody2D>().AddForce(this.transform.up * 1000);

            Destroy(laserClone, 1.0f);
        }
        
   }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.tag == "Asteroid"){

            Destroy(lives[0].gameObject);
            lives.Remove(lives[0]);
        }
    }

}
