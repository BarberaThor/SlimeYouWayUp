using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform player;
    public Transform room;
    public bool dead = false;

    // Update is called once per frame
    void Update()
    {
        var minPosY = room.GetComponent<BoxCollider2D>().bounds.min.y;
        var maxPosY = room.GetComponent<BoxCollider2D>().bounds.max.y;
        var minPosX = room.GetComponent<BoxCollider2D>().bounds.min.x;
        var maxPosX = room.GetComponent<BoxCollider2D>().bounds.max.x;

        if (!dead)
        {
            Vector3 clampedPos = new Vector3(
            Mathf.Clamp(player.position.x, minPosX, maxPosX),
            Mathf.Clamp(player.position.y, minPosY, maxPosY),
            Mathf.Clamp(player.position.z, -10f, -10f)
            );

            transform.position = new Vector3(clampedPos.x, clampedPos.y, -10f);
        }
        
    }
}
