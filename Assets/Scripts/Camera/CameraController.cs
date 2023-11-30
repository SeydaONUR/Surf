using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    private float halfHeight, halfWidth;
    public BoxCollider2D bound;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x,bound.bounds.min.x+ halfWidth,bound.bounds.max.x-halfWidth),
            Mathf.Clamp(player.transform.position.y,bound.bounds.min.y+halfHeight,bound.bounds.max.y-halfHeight),
            transform.position.z);
    }
}
