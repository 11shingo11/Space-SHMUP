using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������������� ����� �������� ������� �� ������� ������.
/// �����: �������� ������ � ��������������� ������� Main Camera � [ 0, 0, 0 ]
/// </summary>

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;
    
    [Header("Ser Dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;
    [HideInInspector]
    public bool offRigth, offLeft, offUp, offDown;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRigth = offLeft = offUp = offDown = false;
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRigth = true;
        }
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }
        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            offUp = true;
        }
        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            offDown = true;
        }
        isOnScreen = !(offRigth || offLeft || offUp || offDown);
        if (!isOnScreen && keepOnScreen) 
        {
            transform.position = pos;
            isOnScreen = true;
            offRigth = offLeft = offUp = offDown = false;
        }
        
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth*2, camHeight*2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
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
