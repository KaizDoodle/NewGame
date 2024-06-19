using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Enemyattack : MonoBehaviour
{

    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float timeBtwAttacks = 0f;
    
    public bool ShouldBeDamaging {get; private set;} = false;
    
    private RaycastHit2D[] hits;

    private List<IDamageable> iDamageables = new List<IDamageable>();

    private Animator anim;

    private float attackTimeCounter;


    private void Start(){

        anim = GetComponent<Animator>();
        attackTimeCounter = timeBtwAttacks;

    }
    
    private void Update()
    {
         if (Enemy.canAttack && attackTimeCounter >= timeBtwAttacks ){  
             attackTimeCounter = 0f;
            anim.SetTrigger("attack");
         }
         attackTimeCounter += Time.deltaTime;
    }

    public IEnumerator DamageWhileSlashIsActive(){
        
        ShouldBeDamaging = true;

        while (ShouldBeDamaging){
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);
            
            for (int i = 0; i < hits.Length; i++){
                
                IDamageable iDamageable = hits [i].collider.gameObject.GetComponent<IDamageable>();

                if (iDamageable !=null && !iDamageable.HasTakenDamage){
                    iDamageable.Damage(damageAmount);
                    iDamageables.Add(iDamageable);
                }
            }
            yield return null;
        }

        ReturnAttackablesToDamageable();
    }

    private void ReturnAttackablesToDamageable(){
        foreach(IDamageable thingThatWasDamaged in iDamageables){
            thingThatWasDamaged.HasTakenDamage = false;
        }
        iDamageables.Clear();
    }

    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackTransform.position,attackRange);
    }
    #region Anamation Triggers 

    public void ShouldBeDamagingToTrue(){
        ShouldBeDamaging = true;
    }

    public void ShouldBeDamagingToFalse(){
        ShouldBeDamaging = false;
    }




    #endregion



}
