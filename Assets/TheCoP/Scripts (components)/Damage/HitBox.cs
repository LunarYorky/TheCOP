using System.Collections;
using System.Collections.Generic;
using TheCoP.Scripts__components_;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float rotationTime;
    public float rotationAngle;
    public float damage;

    private float speed;
    private Vector3 parentPosition;
    private List<Collider2D> hitedTargets = new(5);
    private List<Collider2D> targets = new(5);
    private List<bool> interrupt = new(5);
    private List<float> distances = new(5);

    void Start()
    {
        parentPosition = transform.parent.position;

        speed = Mathf.Abs(rotationAngle) / rotationTime;

        if (rotationAngle > 0)
        {
            speed *= -1;
        }

        StartCoroutine(Rotator());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator Rotator()
    {
        while (rotationTime > 0)
        {
            hiting();

            transform.Rotate(0, 0, Time.deltaTime * speed);
            rotationTime -= Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }

    private void hiting()
    {
        for (int i = 0; i < distances.Count; i++)
        {
            var element = LowElementIn(distances);
            if (interrupt[element])
            {
                Debug.Log("123");
                // прерывание атаки
                Destroy(gameObject);
                break;
            }

            if (!hitedTargets.Contains(targets[element]))
            {
                hitedTargets.Add(targets[element]);

                //логика отправки сообщения о попадании
                var stats = targets[element].GetComponent<Statistics>();
                if (stats != null)
                    Debug.Log("Hit");
            }

            targets.RemoveAt(element);
            distances.RemoveAt(element);
            interrupt.RemoveAt(element);
        }
    }

    private int LowElementIn(List<float> list)
    {
        if (list.Count < 2)
        {
            return 0;
        }

        float min = list[0];
        int element = 0;

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] < min)
            {
                min = list[i];
                element = i;
            }
        }

        return element;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("TriggerEnter");
        targets.Add(col);
        interrupt.Add(col.tag == "Wall" || col.tag == "Solid" ? true : false);
        distances.Add(Vector3.Distance(parentPosition, col.transform.position));
    }
}
