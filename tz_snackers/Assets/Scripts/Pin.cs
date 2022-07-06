using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerPart playerPart))
        {
            rigidbody.AddForce(Vector3.up * 100);
            playerPart.GetComponentInParent<PlayerPartController>().RemovePart(other.gameObject);
        }
    }
}
