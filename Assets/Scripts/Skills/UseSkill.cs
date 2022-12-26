using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public GameObject skillPrefab;
    public float time = 10f;
    
    public void SkillActivate()
    {
        GameObject Meteor = Instantiate(skillPrefab);
        Destroy(Meteor, time);
    }
}