using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Body : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CurrentStar;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        RandomizeTrailRendererColor();
    }

    void Start()
    {
        CurrentStar = FindNearestStar();
        
        InitialVelocity();
    }

    private GameObject FindNearestStar()
    {
        GameObject bestStar = null;
        var closestDistanceSqrt = Mathf.Infinity;
        var currentPosition = transform.position;
        
        foreach (GameObject potentialStar in SolarSystem.Instance.starList)
        {
            var directionToTarget = potentialStar.transform.position - currentPosition;
            var dSqrtToTarget = directionToTarget.sqrMagnitude;

            if (dSqrtToTarget < closestDistanceSqrt)
            {
                closestDistanceSqrt = dSqrtToTarget;
                bestStar = potentialStar;
            }
        }

        return bestStar;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CurrentStar != null)
        {
            Gravity();
        }
        
        CurrentStar = FindNearestStar();
    }

    private void Gravity()
    {
        float m1 = this.GetComponent<Rigidbody>().mass;
        float m2 = CurrentStar.GetComponent<Rigidbody>().mass;
        float r = Vector3.Distance(transform.position, CurrentStar.transform.position);
                    
        GetComponent<Rigidbody>().AddForce((CurrentStar.transform.position - transform.position).normalized *
                                             (SolarSystem.Instance.G * (m1 * m2) / (r * r)));
    }
    
    void InitialVelocity()
    {
        float m2 = CurrentStar.GetComponent<Rigidbody>().mass;
        float r = Vector3.Distance(transform.position, CurrentStar.transform.position);
        transform.LookAt(CurrentStar.transform);

        GetComponent<Rigidbody>().velocity += transform.right * Mathf.Sqrt((SolarSystem.Instance.G * m2) / r);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    private void RandomizeTrailRendererColor()
    {
        _trailRenderer.startColor = new Color(Random.value, Random.value, Random.value);
        _trailRenderer.endColor = new Color(Random.value, Random.value, Random.value);
    }
}
