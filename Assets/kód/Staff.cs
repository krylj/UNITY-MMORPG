using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float Range;
    public float attackCooldown;
    public float abilityCooldown;
    public float Damage;

    private float attackTimer;
    private float abilityTimer;
    private Transform Target;

    void Start()
    {
        float attackTimer = attackCooldown;
        float abilityTimer = abilityCooldown;
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && attackTimer <= 0)
        {
            attackTimer = attackCooldown;
            Shoot();
        }
        else if (Input.GetButtonDown("Fire2") && abilityTimer <= 0)
        {
            abilityTimer = abilityCooldown;
            Ability();

        }
        attackTimer -= Time.deltaTime;
        abilityTimer -= Time.deltaTime;
        Mathf.Clamp(attackTimer, 0, attackCooldown);
        Mathf.Clamp(abilityTimer, 0, abilityCooldown);
    }

    void SetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray.origin = firePoint.position;
        if (Physics.Raycast(ray, out RaycastHit hit, Range))
        {
            Target = hit.transform;
        }
        else
        {
            Target.position = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z + Range);
        }
    }
    public virtual void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile proj = projectile.GetComponent<Projectile>();
        SetTarget();
        proj.Damage = Damage;
        proj.Target = Target;
    }
    public virtual void Ability()
    {
        //Ability code
    }
}
