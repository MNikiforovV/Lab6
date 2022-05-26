using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    private InteractiveBox next;
    private LineRenderer myLineRenderer;

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }
    // Start is called before the first frame update
    void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (next)
        {
            if (Physics.Raycast(transform.position, next.transform.position - transform.position, out RaycastHit hit, 100f))
            {
                DrawLine(hit.point);
                if (hit.collider.tag == "ObstacleItem")
                {
                    hit.transform.GetComponent<ObstacleItem>().onDestroyObstacle.AddListener(() => ActivateModule());
                    hit.transform.GetComponent<ObstacleItem>().GetDamage(Time.deltaTime);
                }

            }
        }
        else
        {
            myLineRenderer.positionCount = 0;
        }
    }

    void ActivateModule()
    {

    }
    private void DrawLine(Vector3 end_pos)
    {
        if (myLineRenderer.positionCount != 2)
        {
            myLineRenderer.positionCount = 2;
        }
        myLineRenderer.SetPosition(0, transform.position);
        myLineRenderer.SetPosition(1, end_pos);
    }
}
