using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    private float _timeBetweenShots;
    public float _startTimeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotatrionZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotatrionZ + offset);
        if(_timeBetweenShots <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                _timeBetweenShots = _startTimeBetweenShots;
            }
        }
        else
        {
            _timeBetweenShots -= Time.deltaTime;
        }
    }
}
