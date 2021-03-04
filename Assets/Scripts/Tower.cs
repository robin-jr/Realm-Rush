using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] GameObject objectToPan, lazer;
    ParticleSystem lazerParticleSystem;
    Enemy currentTarget;
    void Start()
    {
        lazerParticleSystem = lazer.GetComponent<ParticleSystem>();
    }
    void FindNearestTarget()
    {
        var targets = FindObjectsOfType<Enemy>();
        if(targets.Length<1){
            currentTarget=null;
            return;
        }
        currentTarget = targets[0];
        var temp = currentTarget;
        if (currentTarget)
            foreach (var item in targets)
            {
                var distance = Vector3.Distance(item.transform.position, transform.position);
                if (distance < Vector3.Distance(temp.transform.position, transform.position))
                    temp = item;
            }
        currentTarget = temp;
    }
    void Update()
    {
        FindNearestTarget();
        if (currentTarget)
        {
            objectToPan.transform.LookAt(currentTarget.transform.Find("Body"));
            var emission= lazerParticleSystem.emission;
            emission.enabled=true;

        }
        else
        {
            var emission=lazerParticleSystem.emission;
            emission.enabled=false;
        }
    }
}
