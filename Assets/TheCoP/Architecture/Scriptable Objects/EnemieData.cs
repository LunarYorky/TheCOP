using System.Collections;
using UnityEngine.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemieData", menuName = "ScriptableObjects/EnemieData")]
public class EnemieData : ScriptableObject
{
    [SerializeField] private string enemieName;
    [SerializeField] private RuntimeAnimatorController animatorController;

    public string EnemieName => enemieName;
    public RuntimeAnimatorController AnimatorController => animatorController;
}
