using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script {
    class Game : MonoBehaviour{

        public static List<Card> cards = new List<Card>();

        static string player1 = "Martijn";
        static string player2 = "dave";

        static string currentPlayer;
        static List<Card> cardsPlayed =  new List<Card>();

        static int p1Points;
        static int p2Points;

        private void Start() {

            currentPlayer = player1;
            GameObject.Find("Turn").GetComponent<Text>().text = "beurt : " + player1;

            for (int i = 0; i < transform.childCount; i++) {
                cards.Add(transform.GetChild(i).GetComponent<Card>());
            }

            for (int i = 0; i < cards.Count; i++) {
                int randomIndex = UnityEngine.Random.Range(i, cards.Count);
                Card temp = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = temp;
            }

            int sets = cards.Count / 2;

            for (int i = 0; i < sets; i++) {
                cards[i * 2].SetSprite(SpriteSheet.GetSprite("Assets/Sprites/Cards/Fruit", i), i.ToString());
                cards[(i * 2) + 1].SetSprite(SpriteSheet.GetSprite("Assets/Sprites/Cards/Fruit", i), i.ToString());
            }
        }

        private void Update() {

          
  
            

        }
  
        public static void TakeTurn(Card card) {

            if (cardsPlayed.Count > 0 && card == cardsPlayed[0] || card.isPlayed) {
                return;
            }

            if (cardsPlayed.Count < 2) {
                card.TurnCard();
                cardsPlayed.Add(card);
                return;
            }

            if (!currentPlayer.Equals(player1)) {
                
                
                if (cardsPlayed[0].image == cardsPlayed[1].image) {
                    cardsPlayed[0].isPlayed = true;
                    cardsPlayed[1].isPlayed = true;
                    cardsPlayed.Clear();
                    p2Points++;
                 
                } else {
                    cardsPlayed[0].TurnCard();
                    cardsPlayed[1].TurnCard();
                    cardsPlayed.Clear();
                    currentPlayer = player1;
                }

            } else if (!currentPlayer.Equals(player2)) {
    
              
                if (cardsPlayed[0].image == cardsPlayed[1].image) {
                    cardsPlayed[0].isPlayed = true;
                    cardsPlayed[1].isPlayed = true;
                    cardsPlayed.Clear();
                    p1Points++;
                } else {
                    cardsPlayed[0].TurnCard();
                    cardsPlayed[1].TurnCard();
                    cardsPlayed.Clear();
                    currentPlayer = player2;
                }
            } else {
                card.TurnCard();
            }
            GameObject.Find("Player1").GetComponent<Text>().text = player1 + " heeft " + p1Points + " punten";
            GameObject.Find("Player2").GetComponent<Text>().text = player2 + " heeft " + p2Points + " punten";
            GameObject.Find("Turn").GetComponent<Text>().text = "beurt : " + currentPlayer;
        }
    

    }

   
}
