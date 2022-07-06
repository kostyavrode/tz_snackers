using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerPart : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.DORotate(new Vector3(180f, 0f, 0f), 0.3f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
