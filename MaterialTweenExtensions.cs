using DG.Tweening;
using UnityEngine;

public static class MaterialTweenExtensions
{
    public static Tweener DOFloat(this Material material, string property, float endValue, float duration)
    {
        return DOTween.To(
            () => material.GetFloat(property),
            value => material.SetFloat(property, value),
            endValue,
            duration);
    }

    public static Tweener DOColor(this Material material, string property, Color endValue, float duration)
    {
        return DOTween.To(
            () => material.GetColor(property),
            value => material.SetColor(property, value),
            endValue,
            duration);
    }

    public static Tweener DOVector(this Material material, string property, Vector4 endValue, float duration)
    {
        return DOTween.To(
            () => material.GetVector(property),
            value => material.SetVector(property, value),
            endValue,
            duration);
    }

    public static Tweener DOTextureOffset(this Material material, string property, Vector2 endValue, float duration)
    {
        return DOTween.To(
            () => material.GetTextureOffset(property),
            value => material.SetTextureOffset(property, value),
            endValue,
            duration);
    }

    public static Tweener DOTextureScale(this Material material, string property, Vector2 endValue, float duration)
    {
        return DOTween.To(
            () => material.GetTextureScale(property),
            value => material.SetTextureScale(property, value),
            endValue,
            duration);
    }
}