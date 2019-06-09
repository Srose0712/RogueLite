using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour {

    [SerializeField]
    private GameObject text;

    private Text scoreText;

    public int scoreNum = 0;

	// Use this for initialization
	void Start () {

        scoreText = text.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        scoreText.text = "Score " + scoreNum.ToString();
	}
}
