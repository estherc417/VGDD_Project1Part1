using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : EnemyController
{
    #region Editor Variables

    [SerializeField]
    [Tooltip("Range of attack of the boss enemy.")]
    public float m_attackRange;
    [SerializeField]
    [Tooltip("How long it takes before attack can be used again")]
    public float m_attackCooldown;
    [SerializeField]
    [Tooltip("Amount of damage attack should have")]
    public int m_attackDamage;


    [SerializeField]
    [Tooltip("Projectile prefab here")]
    public GameObject m_projectile;

    [SerializeField]
    [Tooltip("Time for attack to reload")]
    public float m_timeToReload;

    [SerializeField]
    [Tooltip("How fast the attack should travel")]
    public float m_fireSpeed;

    [SerializeField]
    [Tooltip("The projectile attack for the boss")]
    public PlayerAttackInfo attack;

    #endregion

    #region Private Variables
    private bool inRange = true;
    private float m_attackStartTime;
    private float m_attack_tick;

    #endregion

    #region Cached Components
    private Rigidbody cc_Rb_boss;

    #endregion

    #region Cached References
    private Transform cr_Player_boss;
    private Animator cr_Anim;

    #endregion

    #region Initialization
    public float reloadTimer = 0;

    private void Awake()
    {
        cc_Rb_boss = GetComponent<Rigidbody>();
        cr_Anim = GetComponent<Animator>();

    }
    private void Start()
    {
        cr_Player_boss = FindObjectOfType<PlayerController>().transform;
    }
    #endregion


    #region Main Updates
    private void FixedUpdate()
    {
        Vector3 dir = cr_Player_boss.position - transform.position;
        dir.Normalize();
    }

    private void Update()
    {
        // Set how hard the player is pressing movement button
        //update animation
        //cr_Anim.SetFloat("Speed", Mathf.Clamp01(Mathf.Abs(forward) + Mathf.Abs(right)));
        // check if shooter is reloaded
        /*
        if (reloadTimer > m_timeToReload && cr_Player_boss != null && Vector3.Distance(transform.position, cr_Player_boss.position) <= 10f)
        {
            reloadTimer = 0;
            Vector3 fireDirection = (cr_Player_boss.position - transform.position).normalized;
            cr_Anim.SetTrigger("Projectile");
            GameObject newProjectile = Instantiate(m_projectile, transform.position, Quaternion.identity);
            newProjectile.GetComponent<Rigidbody>().velocity = fireDirection * m_fireSpeed;
            Destroy(newProjectile, 5f);
        }
        else
        {
            reloadTimer += Time.deltaTime;
        }  */
        if (Vector3.Distance(transform.position, cr_Player_boss.position) <= m_attackRange && inRange)
        {
            StartCoroutine(UsePoisonAttack());
        }

        if (Time.time - m_attackStartTime < 4f)
        {
            if (Time.time >= 0.1f)
            {
                cr_Player_boss.GetComponent<PlayerController>().DecreaseHealth(1/10);
                m_attack_tick = Time.time + 0.1f; // Update next tick time
            }
        }
    }

    #endregion


    


    #region Attack Methods
    private IEnumerator UsePoisonAttack()
    {
        m_attackStartTime = Time.time;
        m_attack_tick = m_attackStartTime + 0.1f;

        inRange = false;
        cr_Anim.SetTrigger("ShootMegaLaser");
        Vector3 fireDirection = (cr_Player_boss.position - transform.position).normalized;
        GameObject newProjectile = Instantiate(m_projectile, transform.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody>().velocity = fireDirection * m_fireSpeed;
        Destroy(newProjectile, 5f);
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(transform.position, cr_Player_boss.position) <= m_attackRange)
        {
            cr_Player_boss.GetComponent<PlayerController>().DecreaseHealth(m_attackDamage);
        }
        yield return new WaitForSeconds(m_attackCooldown);
        inRange = true;
    }


    #endregion
}
