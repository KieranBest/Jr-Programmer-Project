using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_currentPile=null;
    public float ProductivityMultiplier = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void BuildingInRange()
    {
        if(m_currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if(pile != null)
            {
                m_currentPile = pile;
                m_currentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (m_currentPile != null)
        {
            m_currentPile.ProductionSpeed /= ProductivityMultiplier;
            m_currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }
}
