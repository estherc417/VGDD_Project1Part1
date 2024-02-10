using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttackInfo
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("A name for this attack")]
    private string m_Name;
    public string AttackName
    {
        get
        {
            return m_Name;
        }
    }
    [SerializeField]
    [Tooltip("The button to press to use this attack. This button must be in input settings.")]
    private string m_button;
    public string Button
    {
        get
        {
            return m_button;
        }
    }
    [SerializeField]
    [Tooltip("The trigger string to use to activate this attack in the animation")]
    private string m_TriggerName;
    public string TriggerName
    {
        get
        {
            return m_TriggerName;
        }
    }

    [SerializeField]
    [Tooltip("The prefab of the game object representing this attack in the animator")]
    private GameObject m_AbilityGO;
    public GameObject AbilityGO
    {
        get
        {
            return m_AbilityGO;
        }
    }

    [SerializeField]
    [Tooltip("Where to spawn the ability game object in respect to player")]
    private Vector3 m_offset;
    public Vector3 Offset
    {
        get
        {
            return m_offset;
        }
    }

    [SerializeField]
    [Tooltip("How long to wait until this attack should be activated after the button is pressed")]
    private float m_WindUpTime;
    public float WindUpTime
    {
        get
        {
            return m_WindUpTime;
        }
    }

    [SerializeField]
    [Tooltip("How long to wait until player can do anything again")]
    private float m_FrozenTime;
    public float FrozenTime
    {
        get
        {
            return m_FrozenTime;
        }
    }

    [SerializeField]
    [Tooltip("How long to wait until player can use this ability again")]
    private float m_Cooldown;

    [SerializeField]
    [Tooltip("The amount of health this ability costs")]
    private int m_HealthCost;
    public int HealthCost
    {
        get
        {
            return m_HealthCost;
        }
    }

    [SerializeField]
    [Tooltip("The color to change to when using this ability")]
    private Color m_Color;
    public Color AbilityColor
    { 
        get
        {
            return m_Color;
        }
    }
    #endregion

    #region Public Variables
    public float Cooldown {
        get;
        set;
    }

    #endregion


    #region Cooldown Methods
    public void ResetCooldown()
    {
        Cooldown = m_Cooldown; 
    }

    public bool IsReady() {
        return Cooldown <= 0;
    }

    #endregion

}
