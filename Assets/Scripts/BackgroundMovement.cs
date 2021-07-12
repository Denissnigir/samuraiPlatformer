using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] GameObject camera;

    private void Update()
    {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, 0);
    }
}
