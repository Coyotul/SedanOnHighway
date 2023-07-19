using UnityEngine;

public class track : MonoBehaviour
{
    public float speed;
    public static bool IsActive;

    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize variables or perform any necessary setup
    }

    // Update is called once per frame
    void Update()
    {
        IsActive = true;
        // Calculate the texture offset based on time and speed
        offset = new Vector2(0, Time.time * speed);
        // Set the texture offset of the Renderer component's material
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}