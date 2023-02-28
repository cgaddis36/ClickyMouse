using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRigidbody;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRigidbody = GetComponent<Rigidbody>();

        targetRigidbody.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
        targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = new Vector3(RandomPosition(), -6);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad")) { gameManager.GameOver(); }
    }

    float RandomTorque()
    {
        var maxTorque = 10;
        return Random.Range(-maxTorque, maxTorque);
    }

    float RandomForce()
    {
        var minForce = 12;
        var maxForce = 16;
        return Random.Range(minForce, maxForce);
    }

    float RandomPosition()
    {
        var maxRange = 4;
        return Random.Range(-maxRange, maxRange);
    }
}
