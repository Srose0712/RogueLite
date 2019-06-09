using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBehaviour : MonoBehaviour {

    [SerializeField]
    private GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision){

        TextBehavior updateScore = GameObject.Find("GameManager").GetComponent<TextBehavior>();
        AudioSource explodeSound = GameObject.Find("GameManager").GetComponent<AudioSource>();

        if (this.gameObject.tag == "Laser" && collision.gameObject.tag == "Asteroid"){

            Destroy(gameObject);

        }

        if(this.gameObject.tag == "Asteroid" && collision.gameObject.tag == "Laser"){

            updateScore.scoreNum += 1;
            explodeSound.Play();

            Destroy(gameObject);
            GameObject explosionClone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosionClone, 0.5f);

        }

        if (this.gameObject.tag == "Asteroid" && collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            GameObject explosionClone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosionClone, 0.5f);

        }
    }
}
