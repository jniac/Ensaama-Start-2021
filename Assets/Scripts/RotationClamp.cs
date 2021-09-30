using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationClamp : MonoBehaviour
{
    public bool clampX = true;
    [Range(0, 360f)]
    public float fovX = 45;
    [Range(-180f, 180f)]
    public float angleX = 0;

    public bool clampY = false;
    [Range(0, 360f)]
    public float fovY = 60;
    [Range(-180f, 180f)]
    public float angleY = 0;

    public static float mod180(float x) {
        x %= 360f;
        if (x > 180f) {
            return x - 360f;
        }
        if (x < -180f) {
            return x + 360f;
        }
        return x;
    } 

    void LateUpdate() {
        if (clampX || clampY) {
            Vector3 euler = transform.eulerAngles;

            if (clampX) {
                euler.x -= angleX;
                euler.x = Mathf.Clamp(mod180(euler.x), -fovX * 0.5f, fovX * 0.5f);
                euler.x += angleX;
            }

            if (clampY) {
                euler.y -= angleY;
                euler.y = Mathf.Clamp(mod180(euler.y), -fovY * 0.5f, fovX * 0.5f);
                euler.y += angleY;
            }
            
            transform.eulerAngles = euler;
        }
    }

    public float gizmosSize = 2f;
    void OnDrawGizmos() {
        Vector3 d = new Vector3();
        void DrawX(float a) {
            d.x = 0;
            d.y = -Mathf.Sin(a * Mathf.Deg2Rad);
            d.z = -Mathf.Cos(a * Mathf.Deg2Rad);
            Gizmos.DrawRay(transform.position, d * gizmosSize);
        }
        void DrawY(float a) {
            d.x = Mathf.Sin(a * Mathf.Deg2Rad);
            d.y = 0;
            d.z = Mathf.Cos(a * Mathf.Deg2Rad);
            Gizmos.DrawRay(transform.position, d * gizmosSize);
        }
        float step = 3f;
        int count;
        if (clampX) {
            Gizmos.color = Color.red;
            count = Mathf.CeilToInt(fovX / step);
            for (int i = 0; i <= count; i++) {
                DrawX(angleX + fovX * (-0.5f + (float)i / count));
            }
        }
        if (clampY) {
            Gizmos.color = Color.green;
            count = Mathf.CeilToInt(fovY / step);
            for (int i = 0; i <= count; i++) {
                DrawY(angleY + fovY * (-0.5f + (float)i / count));
            }
        }
    }
}
