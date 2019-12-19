using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform hitPointTextSpawn;
    [SerializeField] private GameObject hitParticleGameObject;
    [SerializeField] private GameObject hitPointTextGameObject;

    public void Hit(int combo)
    {
        Instantiate(hitParticleGameObject, transform.position, transform.rotation);
        GameObject gameObject = Instantiate(hitPointTextGameObject, transform.position, transform.rotation).gameObject;
        gameObject.GetComponent<FloatingText>().TextMesh.text = "Damage: " + combo;
    }
}
