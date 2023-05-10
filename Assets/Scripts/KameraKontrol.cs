using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    [Header("Atamalar")]
    [SerializeField] Transform _topTransform;

    private void LateUpdate()
    {
        if (_topTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, _topTransform.position.y,transform.position.z);
        }
    }
}/**/
