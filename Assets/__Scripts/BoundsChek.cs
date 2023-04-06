using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Предотвращает выход игрового объекта за границы экрана.
/// Важно: работает ТОЛЬКО с ортографической камерой Main Camera в [ 0, 0, 0 ]
/// </summary>

public class BoundsChek : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;
    [Header("Ser Dynamically")]
    public float camWidth;
    public float camHeight;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LastUpdate()
    {
        Vector3 pos = transform.position;
        if(pos.x > camWidth-radius) pos.x = camWidth-radius;
        if(pos.x< -camWidth+radius) pos.x = -camWidth+radius;
        if(pos.y> camHeight -radius) pos.y = camHeight-radius;
        if (pos.y< -camHeight+radius) pos.y = -camHeight+radius;
        transform.position = pos;
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 BoundSize = new Vector3(camWidth*2, camHeight*2, 0.1f);
        OnDrawGizmos().DrawWireCube(Vector3.zero, boundSize);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
