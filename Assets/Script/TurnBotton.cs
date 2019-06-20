using Assets.Script.Game_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script {
    class TurnBotton : MonoBehaviour{

        private Button button;
        private bool hidden;
        private Free_Game logic;

        private void Start() {
            hidden = true;
            logic = GameObject.Find("Plane").GetComponent<Free_Game>();
            if (logic == null) {
                this.gameObject.SetActive(false);
            }
            button = GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);
            button.GetComponentInChildren<Text>().text = "show cards";
        }
        void TaskOnClick() {
            if (hidden) {
                logic.cards.ForEach(card => { if (!card.rotated) { card.TurnCard(); } });
                button.GetComponentInChildren<Text>().text = "hide cards";
                hidden = false;
            } else {
                logic.cards.ForEach(card => { if (card.rotated) { card.TurnCard(); } });
                button.GetComponentInChildren<Text>().text = "show cards";
                hidden = true;
            }
        }
    }
}
