﻿/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading the Code Monkey Utilities
    I hope you find them useful in your projects
    If you have any questions use the contact form
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using UnityEngine;

namespace CodeMonkey.Utils {

    /*
     * Bar in the World, great for quickly making a health bar
     * */
    public class World_Bar {
        
        private Outline outline;
        private GameObject gameObject;
        private Transform transform;
        private Transform background;
        private Transform bar;

        public static int GetSortingOrder(Vector3 position, int offset, int baseSortingOrder = 5000) {
            return (int)(baseSortingOrder - position.y) + offset;
        }

        public class Outline {
            public float size = 1f;
            public Color color = Color.black;
        }

   
        
     

        private void SetupParent(Transform parent, Vector3 localPosition) {
            gameObject = new GameObject("World_Bar");
            transform = gameObject.transform;
            transform.SetParent(parent);
            transform.localPosition = localPosition;
        }

     
        public void SetLocalScale(Vector3 localScale) {
            // Outline
            if (transform.Find("Outline") != null) {
                // Has outline
                transform.Find("Outline").localScale = localScale + new Vector3(outline.size, outline.size);
            }

            //Background
            background.localScale = localScale;

            // Set Bar Scale
            bar.localPosition = new Vector3(-localScale.x / 2f, 0, 0);
            Transform barIn = bar.Find("BarIn");
            barIn.localScale = localScale;
            barIn.localPosition = new Vector3(localScale.x / 2f, 0);
        }
        
        public void SetSortingOrder(int sortingOrder) {
            bar.Find("BarIn").GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
            if (background != null) background.GetComponent<SpriteRenderer>().sortingOrder = sortingOrder - 1;
            if (transform.Find("Outline") != null) transform.Find("Outline").GetComponent<SpriteRenderer>().sortingOrder = sortingOrder - 2;
        }

        public void SetSortingLayerName(string sortingLayerName) {
            bar.Find("BarIn").GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
            if (background != null) background.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
            if (transform.Find("Outline") != null) transform.Find("Outline").GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
        }

        public void SetRotation(float rotation) {
            transform.localEulerAngles = new Vector3(0, 0, rotation);
        }

        public void SetSize(float sizeRatio) {
            bar.localScale = new Vector3(sizeRatio, 1, 1);
        }

        public void SetColor(Color color) {
            bar.Find("BarIn").GetComponent<SpriteRenderer>().color = color;
        }

        public void SetActive(bool isActive) {
            gameObject.SetActive(isActive);
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

    }
    
}
