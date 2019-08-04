using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCredits : MonoBehaviour
{
    public float startHeight;
    public float endHeight;
    public float time;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.up * (endHeight - startHeight) / time * Time.deltaTime;

        if (transform.localPosition.y >= endHeight)
        {
            SceneSwapper.swapper.GoToNextLevel();
        }
    }
}
