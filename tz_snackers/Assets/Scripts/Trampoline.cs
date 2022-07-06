using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Trampoline : MonoBehaviour
{
    private bool isFirstTime = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerPart playerPart)&&isFirstTime)
        {
            isFirstTime = false;
            List<GameObject> newList = playerPart.GetComponentInParent<PlayerPartController>().playerParts;
            for (int i=0;i<newList.Count;i++)
            {
                Rigidbody rb=newList[i].GetComponent<Rigidbody>();
                rb.isKinematic = false;
                Observable.Timer(System.TimeSpan.FromSeconds(2f)).TakeUntilDisable(this).Subscribe(x =>
                {
                    rb.isKinematic = true;
                    other.transform.position = new Vector3(other.transform.position.x, 0f, other.transform.position.z);
                });
            }
        }
    }
}
