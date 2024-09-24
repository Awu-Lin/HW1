using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    private Renderer ballRenderer;
    // Start is called before the first frame update
    void Start()
    {
        ballRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value);
        ballRenderer.material.color = newColor;
    }
}
