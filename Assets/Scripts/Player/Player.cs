using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Boss boss;
    [SerializeField] private UI ui;
    [SerializeField] private float steps = 16;
    [SerializeField][Range(0, UI.BeatInterval / 2)] private float maxBeatOffset;
    [SerializeField] private Color missColor;
    [SerializeField] private Color hitColor;
    [SerializeField] private float colorChangeTime = 0.3f;

    private float angle;
    private int combo;

    // Start is called before the first frame update
    void Start()
    {
        angle = 360 / steps;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.A) && CanPerformAction())
        {
            transform.RotateAround(boss.transform.position, Vector3.up, angle);
        }
        else if (Input.GetKeyDown(KeyCode.D) && CanPerformAction())
        {
            transform.RotateAround(boss.transform.position, Vector3.up, -angle);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && CanPerformAction())
        {
            boss.Hit(combo);
        }
    }

    private bool CanPerformAction()
    {
        bool canPerformAction = UI.BeatOffset < maxBeatOffset;

        GameObject closestRythmBar = ui.GetRythmBarNextToTarget();

        if (closestRythmBar == null) { return false; }

        Color originalColor = closestRythmBar.GetComponent<Image>().color;

        if (canPerformAction)
        {
            closestRythmBar.GetComponent<Image>().color = hitColor;
            combo++;
        }
        else
        {
            closestRythmBar.GetComponent<Image>().color = missColor;
            combo = 0;
        }

        CoroutineHelper.DelayTime(colorChangeTime, () =>
        {
            if(closestRythmBar == null) { return; }
            closestRythmBar.GetComponent<Image>().color = originalColor;
        });

        return canPerformAction;
    }
}
