using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track : MonoBehaviour
{
    public float speed;
    public static bool IsActive;

    private Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsActive = true;
        offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
