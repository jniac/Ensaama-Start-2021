using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class EaseGraph : MonoBehaviour {

    /// <summary>
    /// https://en.wikipedia.org/wiki/Smoothstep
    /// https://www.desmos.com/calculator/ljlvrusqyu
    /// </summary>
    public static float Smoothstep(float x) => x * x * (3f - 2f * x);

    public static float SmoothClamp(float x, float min = 0, float max = 1) {
        float d = max - min;
        if (x < min) {
            return min;
        }
        if (x > max) {
            return max;
        }
        float t = Smoothstep((x - min) / d);
        return min + t * d;
    }

    public static float Limited (float x, float limit = 1) => x * limit / (x + limit);

    /// <summary>
    /// Cas particulier (p = 4) de la fonction limite, définit par :
    /// https://www.desmos.com/calculator/8k228ynfyy?lang=fr
    /// </summary>
    public static float Limited4 (float x, float limit = 1) {
        float t = x * 0.5f / limit + 1f;
        t *= t;
        t *= t;
        return (2f * t / (t + 1f) - 1f) * limit;
    }

    public static float LimitedClamp01(float x, float margin = 0.2f) {
        if (x < margin) return margin - Limited(margin - x, margin); 
        float max = 1f - margin;
        if (x <= max) return x; 
        return max + Limited(x - max, margin);
    }

    public static float Limited4Clamp01(float x, float margin = 0.4f) {
        if (x < margin) return margin - Limited4(margin - x, margin); 
        float max = 1f - margin;
        if (x <= max) return x; 
        return max + Limited4(x - max, margin);
    }
    
    void DrawCurve(System.Func<float, float> f, float overflow = 0f, int resolution = 100) {
        int count = Mathf.CeilToInt((1f + 2f * overflow) * resolution);
        
        var values = Enumerable.Range(0, count)
            .Select(i => (1f + 2f * overflow) * i / count - overflow)
            .Select(x => new Vector3(x, f(x), 0f))
            .ToArray();

        for (int i = 1; i < count; i++) {
            Gizmos.DrawLine(values[i - 1], values[i]);
        }
    }
    
    [Range(0f, 0.5f)]
    public float margin = 0.2f;
    void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawRay(Vector3.zero, Vector3.right);
        Gizmos.DrawRay(Vector3.up, Vector3.right);
        Gizmos.DrawRay(Vector3.zero, Vector3.up);
        Gizmos.DrawRay(Vector3.right, Vector3.up);
        Gizmos.DrawRay(Vector3.zero, Vector2.one);

        Gizmos.color = Color.red;
        DrawCurve(x => Smoothstep(x), 0.5f);
        Gizmos.color = Color.yellow;
        DrawCurve(x => LimitedClamp01(x, margin), 0.5f);
        Gizmos.color = Color.blue;
        DrawCurve(x => Limited4(x), 0.5f);
        Gizmos.color = Color.cyan;
        DrawCurve(x => Limited4Clamp01(x, margin), 0.5f);
    }
}
