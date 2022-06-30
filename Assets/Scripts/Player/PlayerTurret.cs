using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public GameObject Turret;

    public float offset = 0f;

    private Transform turretTransform;

    private void Awake() {
        turretTransform = Turret.GetComponent<Transform>();
    }

    private void Start() {
        
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        turretTransform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    private void OnDrawGizmos() {
        
    }
}
