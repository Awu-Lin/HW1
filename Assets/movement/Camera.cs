using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera: MonoBehaviour
{
    public Transform player; // transform
    public Vector3 offest; //dis between cube and c


    private void Start()
    {
        offest = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offest;
    }
}
