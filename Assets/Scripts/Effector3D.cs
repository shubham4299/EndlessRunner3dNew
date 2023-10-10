using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector3D : MonoBehaviour
{
    [SerializeField] GameObject Pos;
    [SerializeField] float force;
    [SerializeField] Rigidbody RB;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        RB.AddExplosionForce(force, Pos.transform.position, 10);
    }
}
