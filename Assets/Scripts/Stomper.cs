using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public int damageToDeal;
    private Rigidbody2D theRB2D;
    public float bounceForce;
    private SineMovement theMove;
    private BossController theBoss;
    // Start is called before the first frame update
    void Start()
    {
        theRB2D = transform.parent.GetComponent<Rigidbody2D>();
        theMove = FindObjectOfType<SineMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hurtbox")
        {
            other.gameObject.GetComponent<EnemyHP>().TakeDamage(damageToDeal);
            theMove.moveFreq += 1;
            theMove.moveDis += 0.2f;
            theBoss.shotForce += 3;
            theRB2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
    
}
