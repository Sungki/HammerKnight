using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(HammerAttack))]
public class PlayerController : MovableObject, IPlayerFSM
{
    [HideInInspector] public Jump jump;
    [HideInInspector] public HammerAttack hammer;

    public State e;
    private bool _isNewState = false;
    private Rigidbody2D rb;
    public InventoryObject inventory = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
        hammer = GetComponentInChildren<HammerAttack>();
        
        if(ToolBox.GetInstance().GetManager<LevelManager>().currentScreen == ScreenState.Level1)
        {
            inventory.items.Clear();
            inventory.myArmor = null;
            inventory.myHammer = null;
        }

        if (inventory.myArmor) ArmorEquip(inventory.myArmor);
        if (inventory.myHammer) HammerEquip(inventory.myHammer);

        ToolBox.GetInstance().GetManager<GameManager>().ShowHUD();

        SetState(State.Idle);
        StartCoroutine(FSMMain());
    }

    public void SetState(State newState)
    {
        if (e != newState)
        {
            _isNewState = true;
            e = newState;
        }
    }

    public void HammerEquip(EquipmentItemObject obj)
    {
        this.attack = obj.attack;
        inventory.myHammer = obj;
        SetHammerColor(obj.color);
    }

    public void ArmorEquip(EquipmentItemObject obj)
    {
        this.defense = obj.defense;
        inventory.myArmor = obj;
        SetColor(obj.color);
    }

    private void SetColor(Color color)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    private void SetHammerColor(Color color)
    {
        transform.GetChild(1).GetComponentInChildren<Renderer>().material.SetColor("_Color", color);
    }

    IEnumerator FSMMain()
    {
        while (true)
        {
            _isNewState = false;
            yield return StartCoroutine(e.ToString());
        }
    }

    public IEnumerator Idle()
    {
        do
        {
            yield return null;
            if (_isNewState) break;
        } while (!_isNewState);
    }

    public IEnumerator Walk()
    {
        do
        {
            yield return null;
            if (_isNewState) break;
        } while (!_isNewState);
    }

    public IEnumerator Jump()
    {
        do
        {
            yield return null;
            if (_isNewState) break;
        } while (!_isNewState);
    }

    public IEnumerator Attack()
    {
        hammer.fj.enabled = false;
        hammer.hj.enabled = true;

        do
        {
            yield return null;
            if (_isNewState) break;

        } while (!_isNewState);

        hammer.rb.velocity = Vector2.zero;
        hammer.hj.enabled = false;
        hammer.fj.enabled = true;
    }

    public IEnumerator Hurt()
    {
        float timeSpan = 0.0f;
        float checkTime = 0.5f;

        rb.constraints = 0;
        velocity = Vector3.zero;
        rb.AddForce(Vector2.left * 30f, ForceMode2D.Impulse);

        do
        {
            yield return null;
            if (_isNewState) break;

            timeSpan += Time.deltaTime;
            if (timeSpan > checkTime)
            {
                timeSpan = 0;
                SetState(State.Idle);
            }

        } while (!_isNewState);

        rb.velocity = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}