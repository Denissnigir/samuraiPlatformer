using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 4f, player.transform.position.y + 2.22f, -10f);
    }
}
