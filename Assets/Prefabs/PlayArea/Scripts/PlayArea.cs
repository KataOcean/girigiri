using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{

    [SerializeField]
    private float width = 0.0f;
    [SerializeField]
    private float height = 0.0f;
    private Vector2 Size => new Vector2(width, height);
    private Rect Area => new Rect(transform.position, Size);
    public float XMin => transform.position.x - (width / 2);
    public float XMax => transform.position.x + (width / 2);
    public float YMin => transform.position.y - (height / 2);
    public float YMax => transform.position.y + (height / 2);
    // Use this for initialization
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, Size);
    }
}
