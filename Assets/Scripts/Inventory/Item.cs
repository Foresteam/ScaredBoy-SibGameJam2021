using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Assets.Scripts;

namespace Assets.Scripts.Inventory {
    public class Item {
        public WorldItem worldItem { get; private set; }
        public GameObject uiItem { get; private set; }
        private Sprite _uiSprite;

        public Item(WorldItem worldRepresentation, int slot) {
            worldItem = worldRepresentation;
            _uiSprite = worldRepresentation.GetComponent<SpriteRenderer>().sprite;

            GameObject canvas = Object.FindObjectOfType<IngameMenu.GUICanvas>().gameObject;
            uiItem = GameObject.Instantiate(worldItem.uiItem);
            uiItem.transform.parent = canvas.GetComponentInChildren<IngameMenu.GUIItems>().transform.GetChild(slot);
            var rt = uiItem.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x + rt.sizeDelta.x * slot, rt.anchoredPosition.y);

            worldItem.gameObject.SetActive(false); // deactivate the world representation, leaving the UI one only
        }

        public void DoDrop(Vector2 playerPosition) {
            worldItem.gameObject.SetActive(true);
            worldItem.GetComponent<Rigidbody2D>().isKinematic = false;
            worldItem.transform.position = playerPosition + new Vector2(0, 1);
            worldItem.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value * 5, Random.value * 5);
        }
        public void PaintFrame(Color color) {
            uiItem.GetComponent<Image>().color = color;
        }
    }
}