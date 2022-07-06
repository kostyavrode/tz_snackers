using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerPart playerPart))
        {
            other.GetComponentInParent<PlayerPartController>().RemovePart(other.gameObject);
        }
    }
}
