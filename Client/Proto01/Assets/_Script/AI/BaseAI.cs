using UnityEngine;
using System.Collections;

public class BaseAI : MonoBehaviour, IAIController
{
    private bool m_bIngUpdate;

    public void AIOn()
    {
        m_bIngUpdate = true;
    }
    public void AIOff()
    {
        m_bIngUpdate = false;
    }

    private void Update()
    {
        if (m_bIngUpdate)
            UpdateAI();
    }

    public virtual void UpdateAI()
    {

    }
}
