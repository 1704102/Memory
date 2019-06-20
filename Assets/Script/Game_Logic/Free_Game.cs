using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Game_Logic {
    class Free_Game : MonoBehaviour, GameLogic  {

        public List<Card> cards;

        private void Start() {
            for (int i = 0; i < GameObject.Find("Left_Panel").transform.childCount; i++) {
                GameObject.Find("Left_Panel").transform.GetChild(i).gameObject.SetActive(false);
            }


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

        public void CheckRules() {
            throw new NotImplementedException();
        }

        public void TakeTurn(Card card) {
            card.TurnCard();
        }
    }
}
