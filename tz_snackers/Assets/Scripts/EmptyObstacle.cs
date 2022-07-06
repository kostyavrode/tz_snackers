using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

public class EmptyObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerPart playerPart))
        {
            PlayerPartController PPCScript = other.GetComponentInParent<PlayerPartController>();
            other.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.transform.DOMoveY(-2, 1f);
            Observable.Timer(System.TimeSpan.FromSeconds(1.1f)).TakeUntilDisable(this).Subscribe(x => PPCScript.RemovePart(playerPart.gameObject));
        }
    }
}
