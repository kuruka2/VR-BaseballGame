using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody projectile;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;
    public LineRenderer lineVisual;
    public int lineSegement;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        lineVisual.positionCount = lineSegement;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
    }
    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 vo = CalculateVelocity(hit.point, shootPoint.position, 1f);

            Visualize(vo);

            transform.rotation = Quaternion.LookRotation(vo);

            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody obj = Instantiate(projectile, shootPoint.position, Quaternion.identity);
                obj.velocity = vo;

            }
        }

    }
    void Visualize(Vector3 vo)
    {
        for (int i = 0; i < lineSegement; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, i / (float)lineSegement);
            lineVisual.SetPosition(i, pos);
        }
    }
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0f;

        float sY = distance.y;
        float sXz = distanceXz.magnitude;

        float Vxz = sXz * time;
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
    Vector3 CalculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        Vector3 result = shootPoint.position + vo * time;

        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shootPoint.position.y;

        result.y = sY;

        return result;
    }
}
