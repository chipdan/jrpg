using BLINK.RPGBuilder.LogicMono;
using BLINK.RPGBuilder.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCast : MonoBehaviour
{
    [SerializeField] public int[] abilityID;
    CombatNode caster;
    int ID;
    // Start is called before the first frame update
    public void UseAbility()
    {
        CombatManager.Instance.InitAbility(CombatManager.playerCombatNode, RPGBuilderUtilities.GetAbilityFromID(abilityID[ID]), false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ExampleGestureHandler>().ID_Draw == "horizontal")
        {
            Debug.Log("1");
            ID = 0;
            UseAbility();
            GetComponent<ExampleGestureHandler>().ID_Draw = null;
            
        }
        if (GetComponent<ExampleGestureHandler>().ID_Draw == "down")
        {
            Debug.Log("2");
            ID = 1;
            UseAbility();
            GetComponent<ExampleGestureHandler>().ID_Draw = null;
            
        }
    }
}
