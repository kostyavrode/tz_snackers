using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScaleChanger : MonoBehaviour
{
    public static void NiceScaleChanging(GameObject newObj,float scaleLimit=1f)
    {
        bool isSizeOk = false;
        newObj.transform.localScale = Vector3.one / 10;
        Observable.EveryFixedUpdate().TakeWhile(x => !isSizeOk).Subscribe(x =>
        {
            if (newObj.transform.localScale.x! <= scaleLimit)
            {
                newObj.transform.localScale += Vector3.one / 50;
            }
            else
            {
                isSizeOk = true;
                newObj.transform.localScale = Vector3.one*scaleLimit;
            }
        });
    }
    public static void NiceScaleDecrease(GameObject newObj, float scaleLimit = 0.01f)
    {
        bool isSizeOk = false;
        Observable.EveryFixedUpdate().TakeWhile(x => !isSizeOk).Subscribe(x =>
        {
            if (newObj.transform.localScale.x >= scaleLimit)
            {
                newObj.transform.localScale -= Vector3.one / 50;
            }
            else
            {
                isSizeOk = true;
                Destroy(newObj);
            }
        });
    }
}
