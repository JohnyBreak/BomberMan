using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private Image m_Image;
    [SerializeField] private float m_FadeDuration;
    [SerializeField] private AnimationCurve m_FadeOutCurve;
    [SerializeField] private AnimationCurve m_FadeInCurve;
    [SerializeField] private RectTransform m_Canvas;
    [SerializeField] private RectTransform m_ImageTransform;

    private Material m_TargetMaterial;
    private int m_CircleSize = Shader.PropertyToID("_CircleSize");
    private int m_Offset = Shader.PropertyToID("_Offset");
    private Coroutine m_Routine;
    private float m_MaxCircleSize = 1;
    private Action m_CallBack;

    private void Awake()
    {
        m_TargetMaterial = m_ImageTransform.GetComponent<Image>().materialForRendering;
        m_TargetMaterial.SetFloat(m_CircleSize, 0);
        SetOffset(Vector2.zero);
        DisableInteraction();
    }

    public void FadeIn(Action callBack = null)
    {
        m_CallBack = callBack;
        StopRoutine();
        m_Routine = StartCoroutine(FadeRoutine(0, m_FadeInCurve));
    }

    public void FadeOut(Action callBack = null)
    {
        m_CallBack = callBack;
        StopRoutine();
        m_Routine = StartCoroutine(FadeRoutine(m_MaxCircleSize, m_FadeOutCurve));
    }

    public void SetValue(float value)
    {
        value = Mathf.Clamp(value, 0, m_MaxCircleSize);

        m_TargetMaterial.SetFloat(m_CircleSize, value);
    }

    public void SetTarget(Transform target)
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(target.position);

        var rect = m_Canvas.rect;
        float height = rect.height;
        float width = rect.width;

        float x = (screenPoint.x / Screen.width) * width;
        float y = (screenPoint.y / Screen.height) * height;

        var playerCanvasPos = new Vector2(x, y);


        float squareValue = 0;
        if (width > height) // Landscape
        {
            squareValue = width;
            playerCanvasPos.y += (width - height) * 0.5f;
        }
        else // Portrait
        {
            squareValue = height;
            playerCanvasPos.x += (height - width) * 0.5f;
        }

        playerCanvasPos /= squareValue;
        playerCanvasPos -= new Vector2(0.5f, 0.5f);

        m_MaxCircleSize = 1 + Mathf.Abs(playerCanvasPos.x) + Mathf.Abs(playerCanvasPos.y);

        m_ImageTransform.sizeDelta = new Vector2(squareValue, squareValue);
        SetOffset(playerCanvasPos);
    }

    private void StopRoutine()
    {
        if (m_Routine != null)
        {
            StopCoroutine(m_Routine);
            m_Routine = null;
        }
    }

    private IEnumerator FadeRoutine(float to, AnimationCurve curve)
    {
        if (to == 0) 
        {
            DisableInteraction();
        }

        float timeElapsed = 0;
        while (timeElapsed < m_FadeDuration)
        {
            float t = timeElapsed / m_FadeDuration;
            float lerpedValue = curve.Evaluate(t) * m_MaxCircleSize;
            timeElapsed += Time.deltaTime;
            SetValue(lerpedValue);
            yield return null;
        }

        SetValue(to);
        m_CallBack?.Invoke();
        
        if (to != 0)
        {
            EnableInteraction();
        }
    }

    private void EnableInteraction() 
    {
        m_Image.raycastTarget = false;
    }

    private void DisableInteraction()
    {
        m_Image.raycastTarget = true;
    }

    private void SetOffset(Vector2 offset)
    {
        float x = Mathf.Clamp(offset.x, -.5f, .5f);
        float y = Mathf.Clamp(offset.y, -.5f, .5f);

        offset = new Vector2(x, y);

        m_TargetMaterial.SetVector(m_Offset, offset);
    }
}