using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float deathGameSpeed;
    [SerializeField] float deathInterpolateSpeed;
    public static GameManager Instance;
    public BallController ball;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }
        Instance = this;
    }

    public void EndGame()
    {
        Destroy(ball.gameObject);
    }

    IEnumerator DeathSequence()
    {
        float time = 0;
        while (time < deathInterpolateSpeed)
        {
            yield return null;
            time += Time.deltaTime;
            
        }
    }
}
