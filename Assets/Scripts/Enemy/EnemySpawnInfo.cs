using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnInfo 
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The name of the enemy")]
    private string m_Name;
    public string EnemyName
    {
        get
        {
            return m_Name;
        }
    }
    [SerializeField]
    [Tooltip("Prefab of enemy")]
    private GameObject m_EnemyGO;
    public GameObject EnemyGO
    {
        get
        {
            return m_EnemyGO;
        }
    }
    [SerializeField]
    [Tooltip("Number of secs before enemy is spawned")]
    private float m_TimeToNextSpawn;
    public float TimeToNextSpawn
    {
        get
        {
            return m_TimeToNextSpawn;
        }
    }

    [SerializeField]
    [Tooltip("Num of enemies to spawn, if zero will spawn indefinitely")]
    private int m_NumberToSpawn;
    public int NumberToSpawn
    {
        get
        {
            return m_NumberToSpawn;
        }
    }
    #endregion


}
