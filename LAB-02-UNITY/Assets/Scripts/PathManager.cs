using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] public List<waypoint> path;

    public GameObject prefab;
    int currenPointIndex = 0;

    public List<GameObject> prefabPoints;

    public List<waypoint> GetPath()
    {
        if (path == null)
            path = new List<waypoint>();
        
        return path;
    }

    public void CreateAddPoint()
    {
        waypoint go = new waypoint();
        path.Add(go);
    }

    public waypoint GetNextTarget()
    {
        int nextPointIndex = (currenPointIndex + 1) % (path.Count);
        currenPointIndex = nextPointIndex;
        return path[nextPointIndex];
    }

    private void Start()
    {
        prefabPoints = new List<GameObject>();
        foreach (waypoint p in path)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.pos;
            prefabPoints.Add(go);
        }
    }

    public void Update()
    {
        for(int i=0;i<path.Count;i++)
        {
            waypoint p = path[i];
            GameObject g = prefabPoints[i];
            g.transform.position = p.pos;
        }
    }
}
