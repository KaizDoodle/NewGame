using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float timeBtwAttacks = 0.75f;
    
    public bool ShouldBeDamaging {get; private set;} = true;
    
    private RaycastHit2D[] hits;

    private List<IDamageable> iDamageables = new List<IDamageable>();

    private Animator anim;

    private float attackTimeCounter;


    private void Start(){

        anim = GetComponent<Animator>();
        attackTimeCounter = timeBtwAttacks;

    }

    private void PlayAttackAnimation(Vector2 direction)
{
    if (direction == Vector2.up)
    {
        anim.SetTrigger("attackUp");
    }
    else if (direction == Vector2.down)
    {
        anim.SetTrigger("attackDown");
    }
    else if (direction == Vector2.left)
    {
        anim.SetTrigger("attackLeft");
    }
    else if (direction == Vector2.right)
    {
        anim.SetTrigger("attackRight");
    }
}
    
    private void Update()
    {
         if (UserInput.WasAttackPressed && attackTimeCounter >= timeBtwAttacks ){  
             attackTimeCounter = 0f;
            anim.SetTrigger("attackTrue");
         }
         attackTimeCounter += Time.deltaTime;
    }
/*
    public void Attack(){
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);
        
        for (int i = 0; i < hits.Length; i++){
            
            IDamageable IDamageable = hits [i].collider.gameObject.GetComponent<IDamageable>();

            if (IDamageable !=null){
                IDamageable.Damage(damageAmount);
            }
        }
    }
*/
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
