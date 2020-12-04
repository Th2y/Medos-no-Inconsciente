using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    private LineRenderer lr;
    public Transform player;

    public AudioSource laser;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, player.position);

        Vector3 dir = transform.position - player.position;
    }
}