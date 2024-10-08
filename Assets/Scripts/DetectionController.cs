using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    public string _tagTargetDetection = "Player";

    public List<Collider2D> detectedObjs = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == _tagTargetDetection)
        {
            detectedObjs.Add(coll);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == _tagTargetDetection)
        {
            detectedObjs.Remove(coll);
        }
    }

}
