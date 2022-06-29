using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private Vector3 startpos;
    public GameObject camera;
    public float parallaxEffect;

    private float offset;

    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        // length = GetComponent<SpriteRenderer>().bounds.size.x;

        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEffect));
        float distX = (camera.transform.position.x * parallaxEffect);
        float distY = (camera.transform.position.y * parallaxEffect);
        // The Y position below can be set to "DistY" to only apply horizontal parallax, "camera.transform.position.y" for both.
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);

        mat.SetTextureOffset("_MainTex", new Vector2(distX * (parallaxEffect / 5), 0));

        // if (temp > startpos + length) {
        //     startpos += length;
        //     Debug.Log("Right");
        // } else if (temp < startpos - length) {
        //      startpos -= length;
        //      Debug.Log("Left");
        // }
    }
}
