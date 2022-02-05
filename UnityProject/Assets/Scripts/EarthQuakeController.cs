using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeController : MonoBehaviour
{
    [SerializeField] AnimationCurve _earthQuakeGraph;

    [SerializeField, Range(0, 5)] float _earthQukaeTimeOn = 0;

    private void Start()
    {
        _earthQukaeTimeOn = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        _earthQukaeTimeOn = _earthQukaeTimeOn + Time.deltaTime / 15;
        Vector3 directionOfForce = other.transform.position - transform.position;
        directionOfForce = directionOfForce * _earthQuakeGraph.Evaluate(_earthQukaeTimeOn) * 10;
        other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(directionOfForce, ForceMode.Impulse);
    }
}
