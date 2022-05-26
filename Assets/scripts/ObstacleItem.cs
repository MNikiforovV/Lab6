using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    private float currentValue;

    public UnityEvent onDestroyObstacle;

    private UnityAction destroy;
    void Start()
    {
        destroy += DestroyThis;
        onDestroyObstacle.AddListener(destroy);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue <= 0)
        {
            onDestroyObstacle.Invoke();
        }
    }

    public void GetDamage(float value)
    {
        currentValue = currentValue - value;
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
