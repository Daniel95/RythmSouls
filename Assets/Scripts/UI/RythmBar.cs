using System.Collections.Generic;
using UnityEngine;

public class RythmBar : MonoBehaviour
{
    public static List<GameObject> Rythmbars = new List<GameObject>();

    private float speed = 5;

    private float xBorder;

    private void OnEnable()
    {
        Rythmbars.Add(gameObject);
    }
    private void OnDisable()
    {
        Rythmbars.Remove(gameObject);
    }

    public void SetSpeed(float a_Speed)
    {
        speed = a_Speed;
    }

    public void SetXBorder(float a_XBorder)
    {
        xBorder = a_XBorder;
    }

    private void Update()
    {
       transform.Translate(Vector3.left * speed * Time.deltaTime);

       if (transform.position.x < xBorder)
       {
           Destroy(gameObject);
       }
    }
}
