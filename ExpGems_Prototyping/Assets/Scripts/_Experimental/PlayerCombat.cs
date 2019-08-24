using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : ChildBehaviour
{

    // temp
    // box attack settings
    [SerializeField] Vector2 boxArea; // when facing right.

    PlayerMovement movement;

    public Stat dmgItemTest;
    public Stat atkDistanceTest;

    Stack<RaycastHit2D> attacking;

    CharacterAnimator animations;
    public bool NotAttacking { get { return animations == null || !animations.animationPlaying; } }

    // Start is called before the first frame update
    void Start()
    {
        animations = GetAnimations();
        movement = GetPlayerMovement();
        attacking = new Stack<RaycastHit2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && NotAttacking)
        {
            TriggerAttackAnimations();

            // RPG combat v 1 --> raycasting based.
            RaycastHit2D[] hits = Physics2D.BoxCastAll(RootObj.position, boxArea, 0, movement.LastDirection * Stat.GetFloat(atkDistanceTest));

            // filter self.
            for (int i = 0; i < hits.Length; i++)
            {
                if (!hits[i].transform.IsChildOf(RootObj))
                    attacking.Push(hits[i]);
            }

            // -- Do damage to unique targets --
            QuickLog.Msg(name, "basic attacks", attacking.Count);
            Transform lastRoot = null;
            while (attacking.Count > 0)
            {
                RaycastHit2D hit = attacking.Pop();
                //if (!hit.transform.gameObject.CompareTag("Collision"))
                //    continue;

                Collision c = hit.transform.GetComponent<Collision>();
                if (c == null)
                    continue;
                if (lastRoot == c.RootObj)
                    continue;

                lastRoot = c.RootObj;

                // do damage and apply all effects.
                c.GetStats().DoDamage(dmgItemTest);
                Gems.GetExpOnAttack();


                QuickLog.Msg(name, "- Damage", Stat.GetInt(dmgItemTest), "- >", hit.transform.name);
            }
               
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying && isInit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(RootObj.position, boxArea);
            if(movement != null)
                Gizmos.DrawWireCube(RootObj.position+ (Vector3)movement.LastDirection, boxArea);
        }
    }

    void TriggerAttackAnimations()
    {
        Debug.Log(animations);
        animations.ActivateTrigger("Attack");
    }
}
