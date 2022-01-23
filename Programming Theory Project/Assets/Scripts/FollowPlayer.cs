using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 1, -7);

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
