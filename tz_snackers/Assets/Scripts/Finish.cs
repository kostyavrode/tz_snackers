using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UniRx;
public class Finish : MonoBehaviour
{
   
    public static Action onFinishEntered;
    [SerializeField] private GameObject finishBallPrefab;
    [SerializeField] private Transform finalPos;
    [SerializeField] private Transform finalCameraPos;

    private GameObject finishBall;
    private bool isFirtStime = true;
    private GameObject camera;
    private Rigidbody finalBallRb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerPart playerPart))
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera");
            camera.transform.DOMove(finalCameraPos.position, 4f);
            onFinishEntered?.Invoke();
            List<GameObject> changeList=playerPart.GetComponentInParent<PlayerPartController>().playerParts;
            for(int i=0;i<changeList.Count;i++)
            {
                if(isFirtStime)
                {
                    isFirtStime = false;
                    changeList[i].transform.DOMove(finalPos.position, 1f);
                    finishBall =CreateFinishBall();
                    finalBallRb = finishBall.GetComponent<Rigidbody>();
                    finalBallRb.isKinematic = true;
                    finishBall.transform.position = finalPos.position;
                    Observable.Timer(System.TimeSpan.FromSeconds(1f)).TakeUntilDisable(this).Subscribe(x => Destroy(changeList[i]));
                    
                }
                else
                    Destroy(changeList[i]);
            }
            finishBall.transform.DOScale(Vector3.one * changeList.Count/5, 4f);
            Observable.Timer(System.TimeSpan.FromSeconds(2f)).TakeUntilDisable(this).Subscribe(x =>
            {
                
                finishBall.GetComponent<Rigidbody>().isKinematic = false;
                finalBallRb.velocity = Vector3.forward * 100f;
            });
            
        }
    }
    private GameObject CreateFinishBall()
    {
        return Instantiate(finishBallPrefab);
    }
}
