using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] bool onAxisZ = false;
    [SerializeField, Range(0f, 1f)] float followPower = 0.9f;
    [SerializeField] float followMultiplier = 0.9f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 follow = target.position;
        
        if (!onAxisZ)
        {
            follow.z = transform.localPosition.z;
        }
        transform.localPosition = transform.localPosition + ((follow - transform.localPosition )*followPower*followMultiplier * Time.deltaTime);
    }
}
