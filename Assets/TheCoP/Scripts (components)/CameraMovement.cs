using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    private void LateUpdate()
    {
        Vector2 vector2 = Vector2.Lerp(gameObject.transform.position, target.transform.position, 0.05f);
        gameObject.transform.position = new Vector3(vector2.x, vector2.y, -10);
    }
}
