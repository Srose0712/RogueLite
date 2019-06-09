using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    private Transform playerTrans;
    private float smoothTime = 2.5f;
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        playerTrans = GameObject.Find("PlayerShip").transform;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

	}
}
