using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class Gate : MonoBehaviour
{
    public enum GateType
    {
        additive,
        multiplier,
        negative
    }
    public GateType gateType;
    [SerializeField] private int size;
    private TextMesh textMesh;
    private MeshRenderer meshRenderer;
    private bool isGateActive;
    private void Awake()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        meshRenderer = GetComponent<MeshRenderer>();
        isGateActive = true;
        ViewGateType();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isGateActive)
        {
            if (other.TryGetComponent(out PlayerPart playerPart))
            {
                TurnOffGate();
                AffectOnPlayer(playerPart);
            }
        }
    }
    private void AffectOnPlayer(PlayerPart playerPart)
    {
        PlayerPartController playerPartController=playerPart.GetComponentInParent<PlayerPartController>();
        switch (gateType)
        {
            case GateType.additive:
                playerPartController.AddPlayerPart(size);
                break;
            case GateType.multiplier:
                playerPartController.MultiplyPlayerPart(size);
                break;
            case GateType.negative:
                playerPartController.MinusPlayerPart(size);
                break;
        }
    }
    private void TurnOffGate()
    {
        GetComponentInParent<GatePartController>().TurnOffColision();
        meshRenderer.enabled = false;
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        isGateActive = false;
    }
    private void ViewGateType()
    {
        switch(gateType)
        {
            case GateType.additive:
                textMesh.text = "+" + size;
                break;
            case GateType.multiplier:
                textMesh.text = "*" + size;
                break;
            case GateType.negative:
                textMesh.text = "-" + size;
                break;
        }
    }
}
