using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] public TextMesh TextMesh;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.LookAt(Camera.main.transform.position);
    }
}
