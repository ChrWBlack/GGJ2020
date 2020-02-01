using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    public SpriteRenderer HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(Camera.main.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(float current, float maximum)
    {
        HealthBar.size = new Vector2(Mathf.Clamp01(current / maximum), 1.0f);
    }

    public void AngleToCamera()
    {
        transform.LookAt(Camera.main.transform);
    }
}
