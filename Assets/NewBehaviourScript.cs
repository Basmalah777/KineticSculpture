using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int columnHeight = 10; // عدد المكعبات في العمود
    public float spacing = 1.1f; // المسافة بين المكعبات
    public float waveSpeed = 2f; // سرعة الموجة
    public float waveHeight = 2f; // ارتفاع الموجة
    public float rotationSpeed = 50f; // سرعة دوران المكعبات

    private GameObject[] cubes;

    void Start()
    {
        // إنشاء مجموعة من المكعبات
        cubes = new GameObject[columnHeight];
        for (int i = 0; i < columnHeight; i++)
        {
            // إنشاء مكعب جديد
            cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubes[i].transform.parent = transform;  // تعيين العمود كأب للمكعب
            cubes[i].transform.localPosition = new Vector3(0, i * spacing, 0); // تحديد موضع المكعب في العمود
        }
    }

    void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            GameObject cube = cubes[i];
            
            // الحركة الموجية
            float offset = i * 0.5f; // تعويض المرحلة للمكعبات
            float wave = Mathf.Sin(Time.time * waveSpeed + offset) * waveHeight;

            // تطبيق الحركة
            cube.transform.localPosition = new Vector3(0, i * spacing + wave, 0);
            
            // الدوران
            cube.transform.localRotation = Quaternion.Euler(0, Time.time * rotationSpeed + i * 10, 0);
        }
    }
}
