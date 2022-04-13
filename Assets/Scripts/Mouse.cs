using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mouse : MonoBehaviour
{
    public GameObject player; // ���������� � ������� �� �������� �����
    Vector3 rot = new Vector3(0, 0, 0); // ������� ���������� ���������� rot ���� Vectory3 (0,0,0)
    public float speed; // ��� ���������������� ����
    void Start()
    {

    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * speed;
        float MouseY = Input.GetAxis("Mouse Y") * speed;
        rot.x = rot.x - MouseY;
        rot.y = rot.y + MouseX;
        rot.z = 0; // ������������� ��� z ���� �������� ������, ����� ������������� ������ ����� � ������
        transform.eulerAngles = rot; // ����� ����, ��� ��� ����������� �����������,���-���������� = ��������
        player.transform.eulerAngles = new Vector3(0, rot.y, 0);  // ���� ��������� ����� �������� ������ � ������� MouseX, �� ���� ������������� rot.y

        if (rot.x <= -90)
        {
            transform.eulerAngles = new Vector3(-90, rot.y, 0);
            rot.x = -90;
        }
        if (rot.x >= 90)
        {
           transform.eulerAngles = new Vector3(90, rot.y, 0);
            rot.x = 90;
        }

    }
}
