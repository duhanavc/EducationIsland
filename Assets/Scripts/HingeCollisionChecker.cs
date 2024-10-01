using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class HingeCollisionChecker : MonoBehaviour
{

    [Header("Ray Info")]
    public float rayLength;

    Transform rayCastTarget;
    private RaycastHit hit;
    private Vector3 rayDir;
    [SerializeField]
    GameObject theWheel;

    [SerializeField]
    private LayerMask hitLayer;

    [SerializeField]
    private Rigidbody wheelPointerRb;
    private Rigidbody wheelRb;

    [SerializeField]
    private float RotationSpeedBuffer;

    [SerializeField]
    private float forceAmount;

    [SerializeField]
    RotateObject rotObj;

    private int ForceChecker = 1;
    void Start()
    {
         wheelRb = theWheel.GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        //Debug.Log(wheelRb.angularVelocity);

        //if (mathf.abs(rotobj.currentrotationspeedz))
        //{

        //}

        if (Physics.Raycast(transform.position, rayDir, out hit, rayLength, hitLayer))
        {
          
            if (hit.collider.CompareTag("WheelBoard") && ForceChecker == 1 ) 
            {
                applyForceFromBottom();
                ForceChecker = 2;

            }
            
            if(hit.collider.CompareTag("WheelBoard2") && ForceChecker == 2)
            {
                applyForceFromBottom();
                ForceChecker = 1;
            }

        }
        
    }

    void OnDrawGizmosSelected()
    {
        rayDir = transform.TransformDirection(Vector3.forward);
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, rayDir * rayLength);
    }

    void applyForceFromBottom()
    {
        
        // Kuvvetin uygulanacaðý yön: saða ve yukarý doðru
        Vector3 forceDirection = new Vector3(1f, 0f, 0f); // Saða doðru kuvvet uyguluyoruz

        // Alt kýsmýndaki pozisyonu hesapla (kendi objenin boyutuna göre ayarlayabilirsin)
        Vector3 bottomPosition = wheelPointerRb.transform.position - new Vector3(0, wheelPointerRb.transform.localScale.y / 2, 0);

        // Alt kýsýmdan saða doðru kuvvet uygula
        wheelPointerRb.AddForceAtPosition(forceDirection * forceAmount, bottomPosition, ForceMode.Impulse);
        
        
    }
}
