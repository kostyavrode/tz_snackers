using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool isFollowing = true;
    private void OnEnable()
    {
        Finish.onFinishEntered += StopFollow;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnDisable()
    {
        Finish.onFinishEntered -= StopFollow;
    }
    private void FixedUpdate()
    {
        if (isFollowing)
        {
            Vector3 lepredPos = Vector3.Lerp(transform.position, target.position + offset, 1f * Time.fixedDeltaTime);
            transform.position = new Vector3(lepredPos.x, target.position.y + offset.y, target.position.z + offset.z);
        }
    }
    private void StopFollow()
    {
        isFollowing = false;
    }
}
