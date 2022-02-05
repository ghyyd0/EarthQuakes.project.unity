using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeController : MonoBehaviour
{
    [SerializeField] AnimationCurve _earthQuakeGraph;

    [SerializeField, Range(0, 5)] float _earthQukaeTimeOn = 0;
    [SerializeField, Range(0, 15)] float _magnitude = 1;
    [SerializeField] GameObject _sphere;

    private void Start()
    {
        _sphere = transform.GetChild(0).gameObject;
        _earthQukaeTimeOn = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        _earthQukaeTimeOn = _earthQukaeTimeOn + Time.deltaTime / 15;
        var value = _earthQuakeGraph.Evaluate(_earthQukaeTimeOn);
        var direction =   Vector3.one * value * Random.Range(-5,5)*  _magnitude;
        other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(direction,ForceMode.Impulse);
        _sphere.transform.localScale = direction/ 150;
    }
}
