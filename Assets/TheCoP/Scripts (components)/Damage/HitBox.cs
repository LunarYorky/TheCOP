using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheCoP.Scripts__components_.Damage
{
    public class HitBox : MonoBehaviour
    {
        public float rotationTime;
        public float rotationAngle;
        public float damage;

        private float _speed;
        private Vector3 _parentPosition;
        private readonly List<Collider2D> _hitedTargets = new(5);
        private readonly List<Collider2D> _collider2Ds = new(5);
        private readonly List<bool> _interrupt = new(5);
        private readonly List<float> _distances = new(5);

        private void Start()
        {
            _parentPosition = transform.parent.position;

            _speed = Mathf.Abs(rotationAngle) / rotationTime;

            if (rotationAngle > 0)
            {
                _speed *= -1;
            }

            StartCoroutine(Rotator());
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator Rotator()
        {
            while (rotationTime > 0)
            {
                Hiting();

                transform.Rotate(0, 0, Time.deltaTime * _speed);
                rotationTime -= Time.deltaTime;

                yield return new WaitForFixedUpdate();
            }

            Destroy(gameObject);
        }

        private void Hiting()
        {
            for (int i = 0; i < _distances.Count; i++)
            {
                var element = LowElementIn(_distances);
                if (_interrupt[element])
                {
                    Debug.Log("Hitbox tick");
                    // прерывание атаки
                    Destroy(gameObject);
                    break;
                }

                if (!_hitedTargets.Contains(_collider2Ds[element]))
                {
                    _hitedTargets.Add(_collider2Ds[element]);

                    //логика отправки сообщения о попадании
                    var stats = _collider2Ds[element].GetComponent<Statistics>();
                    if (stats != null)
                        Debug.Log("Hit");
                    //TODO: dealing damage
                }

                _collider2Ds.RemoveAt(element);
                _distances.RemoveAt(element);
                _interrupt.RemoveAt(element);
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
            _collider2Ds.Add(col);
            _interrupt.Add(col.tag is "Wall" or "Solid");
            _distances.Add(Vector3.Distance(_parentPosition, col.transform.position));
        }
    }
}