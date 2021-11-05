using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory {
    public class Item {
        public WorldItem worldItem { get; private set; }
        private GameObject _uiItem;
        private Sprite _uiSprite;

        public Item(WorldItem worldRepresentation, int slot) {
            worldItem = worldRepresentation;
            _uiSprite = worldRepresentation.GetComponent<SpriteRenderer>().sprite;

            GameObject canvas = Object.FindObjectOfType<IngameMenu.GUICanvas>().gameObject;
            _uiItem = GameObject.Instantiate(worldItem.uiItem);
            _uiItem.GetComponent<Image>().sprite = _uiSprite;
            _uiItem.transform.SetParent(canvas.GetComponentInChildren<IngameMenu.GUIItems>().transform.GetChild(slot));
            var rt = _uiItem.GetComponent<RectTransform>();
            //rt.localPosition = new Vector3();
           // rt.localScale = new Vector3(1, 1, 1);

            worldItem.gameObject.SetActive(false); // deactivate the world representation, leaving the UI one only
        }

        public void DoDrop(Vector2 playerPosition) {
            worldItem.gameObject.SetActive(true);
            worldItem.GetComponent<Rigidbody2D>().isKinematic = false;
            worldItem.transform.position = playerPosition + new Vector2(0, 1);
            worldItem.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value * 5, Random.value * 5);
        }
        public void PaintFrame(Color color) {
            _uiItem.GetComponent<Image>().color = color;
        }
    }
}