using Amazon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMCoroutine : MonoBehaviour
{
    public static List<IEnumerator> CoroutineList = new List<IEnumerator>();

    void Start()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
    }

    void Update()
    {
        while (IMCoroutine.CoroutineList.Count > 0)
        {
            StartCoroutine(IMCoroutine.CoroutineList[0]);
            IMCoroutine.CoroutineList.RemoveAt(0);
        }
    }
}
