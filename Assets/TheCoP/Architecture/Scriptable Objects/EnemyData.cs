using System.Collections;
using UnityEngine.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private string enemyName;
    [SerializeField] private RuntimeAnimatorController animatorController;

    public string EnemyName => enemyName;
    public RuntimeAnimatorController AnimatorController => animatorController;
}
