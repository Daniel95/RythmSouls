using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static float BeatOffset;

    public const float BeatInterval = 0.8f;

    [SerializeField] private Transform rythmBarPrefab;
    [SerializeField] private Transform rythmBarSpawn;
    [SerializeField] private Transform rythmBarDespawn;
    [SerializeField] private Transform rythmBarBeatTarget;
    [SerializeField] private float scale = 4;

    private float timer;
    private float timeToReachTarget;
    private float rythmBarSpawnToTargetXDistance;
    private int deltaTimeCount;
    private float deltaTimeTotal;

    public GameObject GetRythmBarNextToTarget()
    {
        float closestOffsetX = float.MaxValue;
        GameObject closestRythmBar = null;

        foreach (var rythmbar in RythmBar.Rythmbars)
        {
            float xOffset = Mathf.Abs(rythmbar.transform.position.x - rythmBarBeatTarget.position.x);

            if (xOffset < closestOffsetX)
            {
                closestOffsetX = xOffset;
                closestRythmBar = rythmbar;
            }
        }

        return closestRythmBar;
    }

    private void Start()
    {
        rythmBarSpawnToTargetXDistance = rythmBarSpawn.position.x - rythmBarBeatTarget.position.x;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        BeatOffset = timer > BeatInterval / 2 ? BeatInterval - timer : timer;

        deltaTimeCount++;
        deltaTimeTotal += Time.deltaTime;
        float averageDeltaTime = deltaTimeTotal / deltaTimeCount;

        float speed = (rythmBarSpawnToTargetXDistance / BeatInterval) / scale;

        if (timer > BeatInterval)
        {
            timer = 0;
            GameObject rythmBarGameObject = Instantiate(rythmBarPrefab, rythmBarSpawn.position, rythmBarSpawn.rotation, transform).gameObject;
            RythmBar rythmBar = rythmBarGameObject.GetComponent<RythmBar>();
            rythmBar.SetXBorder(rythmBarDespawn.position.x);
            rythmBar.SetSpeed(speed);
        }
    }
}
