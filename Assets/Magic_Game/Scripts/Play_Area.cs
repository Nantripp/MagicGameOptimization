using System;
using UnityEngine;

public class Play_Area : MonoBehaviour
{

    
    [SerializeField]
    private GameObject fireMonsterPreFab;
    [SerializeField]
    private GameObject WindSpellPreFab;
    [SerializeField]
    private GameObject guardPreFab;
    [SerializeField]
    private GameObject opponent;
    [SerializeField]
    private GameObject guarded; //issue; behöver en guarded Gameobject som blir refererad.  (temp namn)
    [SerializeField]
    private Transform spawn_C;              //NYKOD; gjort en spawner. så att objektet spawnar där kortet har varit!
                                            //private Transform. (Används för insansiate(x,spawnC.LOCATION)
                                            //tar positionen av kortet och spawnar objektet på den.


    private void OnTriggerEnter(Collider other)                      //kollar ifall något rör en ''trigger'' collider. **Other** står för vad som.
    {
        if (other.gameObject.CompareTag("Card"))                     //kollar ifall taggen är ''Card'' och det är bara Card tagg som går att aktivera on trigger eventet under.
        {
            Card card = other.gameObject.GetComponent<Card>();      //kallar på Card scriptet. 

            if (card.CardName == "Fire Monster")                    //kollar ifall kortets namn är ''Fire Monster''. IFALL det är skrivet på kortet/namnet på kortet körs koden nedan.
            {
                
                Instantiate(fireMonsterPreFab, spawn_C.position, Quaternion.identity);  //Spawnar en prefab på ett monster. PÅ bordet.

                Opponent op = opponent.GetComponent<Opponent>();                //Kollar efter Opponent scriptet som ska vara på ett annat game objekt. (IE motståndaren) 

                op.HP = op.HP - card.Damage;                                     //Minskar motståndarens hälsa med skadan från kortet som spelats. (Variabeln card) 

                Destroy(other.gameObject);                                      //Tillslut så tas kortet bort när skadan är gjord. 

                if (op.HP <= 0)                                                  //OM skadan är mer eller = 0 kommer opponent att förstöras/du vann. 
                {
                    Destroy(opponent);

                }
            }
            else if (card.CardName == "Wind Spell")                             //Exakt samma som ovan. Men med spell.
            {
                Instantiate(WindSpellPreFab, other.transform.position, other.transform.rotation);

                Opponent op = opponent.GetComponent<Opponent>();
                                                                                //Debug.Log(op);
                op.HP = op.HP - card.Damage;

                Destroy(other.gameObject);

                if (op.HP <= 0)
                { Destroy(opponent); }

            }
            else if (card.CardName == "Guard")
            {
                Instantiate(guardPreFab, other.transform.position, other.transform.rotation); //koden funkar, glöm inte att apply i unity, inspector.
                
                Player_Information _player = guarded.GetComponent<Player_Information>();  
                
                                                                    //Debug.Log(_player);  checkar för Null(); vilket hände innan.                                                      
                _player.PlayerArmor = _player.PlayerArmor += card.Guard;

                Destroy(other.gameObject);


              

            }

        }
    
    }
   
    
}
    

