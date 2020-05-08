using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject BladeTrail;

    GameObject currentBladeTrail;

    CircleCollider2D circlcollider;

    Vector2 previousPosition;
    public float minVelocity = 0.001f;

    bool isCutting = false;
    private Rigidbody2D rb;

    Camera cam; 

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circlcollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }

    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(BladeTrail, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circlcollider.enabled = false;
    }


    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 1.5f);
        circlcollider.enabled = false;
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

        if(velocity > minVelocity)
        {
            circlcollider.enabled = true;
        }
        else
        {
            circlcollider.enabled = false;
        }
        previousPosition = newPosition;
    }
}
