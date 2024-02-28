using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerPosition;
    public float offsetZ = 5f;
    public float smoothing = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(playerPosition.position.x, transform.position.y, playerPosition.position.z - offsetZ);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
