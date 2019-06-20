using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Script {
    class SpriteSheet {

        public static Sprite GetSprite(string path, int index) {
            UnityEngine.Object[] sprites = Resources.LoadAll("Sprites/Cards/Fruit", typeof(Sprite));

            if (sprites == null)
                return null;

            return (Sprite)sprites[index];
        }

    }
}
