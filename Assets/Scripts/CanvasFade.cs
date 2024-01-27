using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    public float alpha = 1f;
    public float targetAlpha = 0f;
    public float duration = 1f;
    public bool bDecreaseAlpha = false;

    public float colorBlack = 10f;

    // Use this for initialization
    void Start()
    {
        // do something...
        bDecreaseAlpha = (targetAlpha < alpha);
    }

    // Update is called once per frame
    void Update()
    {
        var durationTime = Time.fixedUnscaledDeltaTime- Time.deltaTime;

        if (colorBlack <= durationTime) {


            //Debug.Log ("duration: "+duration+", alpha: "+alpha+", targetAlpha: "+targetAlpha+", bDecreaseAlpha: "+bDecreaseAlpha);
            if (duration > 0f && ((bDecreaseAlpha && alpha > targetAlpha) || (!bDecreaseAlpha && alpha < targetAlpha)))
            {
                float value = (Time.deltaTime / duration);
                if (bDecreaseAlpha)
                {
                    alpha -= value;
                }
                else
                {
                    alpha += value;
                }
                // set alpha value
                Set(gameObject, alpha);
            }
            else
            {
                // remove component while fade effect stopped
                Destroy(this);
            }
        }
    }

    void initAlpha()
    {
        Renderer render = GetComponent<Renderer>();
        if (render != null)
        {
            alpha = render.material.color.a;
        }
        else
        {
            CanvasRenderer cr = GetComponent<CanvasRenderer>();
            if (cr != null)
            {
                alpha = cr.GetAlpha();
            }
        }
    }

    public static void Set(GameObject obj, float alphaVal)
    {
        Renderer render = obj.GetComponent<Renderer>();
        if (render != null)
        {
            Color c = render.material.color;
            c.a = alphaVal;
            render.material.color = c;
        }
        else
        {
            CanvasRenderer cr = obj.GetComponent<CanvasRenderer>();
            if (cr != null)
            {
                cr.SetAlpha(alphaVal);
            }
        }
    }

    public static void In(GameObject obj, float duration = 1f)
    {
        To(obj, duration, 1f);
    }

    public static void Out(GameObject obj, float duration = 1f)
    {
        To(obj, duration, 0f);
    }

    public static void To(GameObject obj, float duration = 1f, float targetAlphaValue = 0f)
    {
        Fade f = obj.AddComponent<Fade>();
        f.initAlpha();
        f.duration = duration;
        f.targetAlpha = targetAlphaValue;
    }
}