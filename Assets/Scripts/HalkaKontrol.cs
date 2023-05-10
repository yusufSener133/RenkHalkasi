using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalkaKontrol : MonoBehaviour
{
    [Header("Degiskenler")]
    public float _donmeHizi = 100f;
    [SerializeField] bool _solaDon, _sagaDon;

    private void FixedUpdate()
    {
        if (_solaDon)
        {
            transform.Rotate(0, 0, _donmeHizi * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -_donmeHizi * Time.deltaTime);
        }

    }
}/**/
