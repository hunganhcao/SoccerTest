using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGoal : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            particle.Clear();
            particle.Play();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
