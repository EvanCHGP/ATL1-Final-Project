using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = transform.position.x;
        transform.position = targetPos;
    }
}
