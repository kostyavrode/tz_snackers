using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePartController : MonoBehaviour
{
    [SerializeField] private List<GameObject> gates;
    public void TurnOffColision()
    {
        for(int i=0;i<gates.Count;i++)
        {
            gates[i].GetComponent<BoxCollider>().enabled = false;
        }
    }
}
