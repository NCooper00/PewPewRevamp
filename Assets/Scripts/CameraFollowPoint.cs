using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPoint : MonoBehaviour
{
    public GameObject CameraFollow;

    public float offset = 0f;

    private Transform pointTransform;

    public Transform player;

    private void Awake() {
        pointTransform = CameraFollow.GetComponent<Transform>();
    }

    private void Start() {
        
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // pointTransform.rotation = player.rotation;
    }

    private void OnDrawGizmos() {
        
    }
}
