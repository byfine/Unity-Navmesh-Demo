using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    private NavMeshAgent[] navAgents;

    void Start()
    {
        navAgents = FindObjectsOfType(typeof(NavMeshAgent)) as NavMeshAgent[];
    }

    void UpdateTargets(Vector3 targetPosition)
    {
        foreach (NavMeshAgent agent in navAgents)
        {
            agent.destination = targetPosition;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Vector3 targetPosition = hitInfo.point;
                UpdateTargets(targetPosition);
                transform.position = targetPosition + new Vector3(0, 3, 0);
            }
        }
    }

}
