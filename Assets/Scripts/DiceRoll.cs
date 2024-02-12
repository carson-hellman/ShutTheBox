using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DiceRoll : MonoBehaviour
{
    Rigidbody body;

    [SerializeField] private float maxRandomForceValue, startRollingForce;

    private float forceX, forceY, forceZ;

    public int diceFaceNum;

    private void Awake()
    {
        Initialize();
    }

    // Update is called once per frame
    private void Update()
    {
        if (body != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RollDice();
            }
        }
    }

    private void RollDice()
    {
        body.isKinematic=false;

        forceX = Random.Range(0, maxRandomForceValue);
        forceY = Random.Range(0, maxRandomForceValue);
        forceZ = Random.Range(0, maxRandomForceValue);

        body.AddForce(Vector3.up * startRollingForce);
        body.AddTorque(forceX, forceY, forceZ);
    }

    private void Initialize()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }
}
