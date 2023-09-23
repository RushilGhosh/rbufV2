using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public Stove stove;
    public Text triggerText;
    
    public string triggerName = "";

    public GameObject bottomBunPrefab;
    public GameObject pattyPrefab;
    public GameObject cheesePrefab;
    public GameObject topBunPrefab;
    
    public GameObject heldItem;
    public string heldItemName;

    public int completedCount = 0;

    // Update is called once per frame
    void Update()
    {
        triggerText.text = "Current trigger: " + triggerName;
        
        if (Input.GetKeyDown("space"))
        {
            if(triggerName == "bottom bun")
            {
                PickUpItem(bottomBunPrefab, "bottomBun");
            }

            if(triggerName == "patty")
            {
                PickUpItem(pattyPrefab, "patty");
            }

            if(triggerName == "cheese")
            {
                PickUpItem(cheesePrefab, "cheese");
            }

            if (triggerName == "top bun")
            {
                PickUpItem(topBunPrefab, "topBun");
            }

            if (triggerName == "stove")
            {
                if(heldItemName == "bottomBun")
                {
                    stove.ToastBottomBun();
                    PlaceHeldItem();
                }

                else if (heldItemName == "patty")
                {
                    stove.CookPatty();
                    PlaceHeldItem();
                }

                else if(heldItemName == "cheese")
                {
                    stove.CookCheese();
                    PlaceHeldItem();
                }

                else if (heldItemName == "topBun")
                {
                    stove.ToastTopBun();
                    PlaceHeldItem();
                }

                else
                {
                    if (stove.cookedFood == "cooked bottom bun" && stove.isCooking == false)
                    {
                        PickUpItem(bottomBunPrefab, "cookedBottomBun");
                        stove.CleanStove();
                    }

                    if(stove.cookedFood == "cooked patty" && stove.isCooking == false)
                    {
                        PickUpItem(pattyPrefab, "cookedPatty");
                        stove.CleanStove();
                    }

                    if (stove.cookedFood == "cooked cheese" && stove.isCooking == false)
                    {
                        PickUpItem(cheesePrefab, "cookedCheese");
                        stove.CleanStove();
                    }

                    if (stove.cookedFood == "cooked top bun" && stove.isCooking == false)
                    {
                        PickUpItem(topBunPrefab, "cookedTopBun");
                        stove.CleanStove();
                    }
                }
            }

            if(triggerName == "Receivers")
            {
                if(heldItemName == "cookedBottomBun")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/burgerCheese/bunBottom").SetActive(true);
                    completedCount++;
                    
                }
                if(heldItemName == "cookedPatty")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/burgerCheese/patty").SetActive(true);
                    completedCount++;
                }
                if (heldItemName == "cookedCheese")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/burgerCheese/cheese").SetActive(true);
                    completedCount++;
                }
                if (heldItemName == "cookedTopBun")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/burgerCheese/bunTop").SetActive(true);
                    completedCount++;
                }

            }
        }

        if(completedCount == 4)
        {
            SceneManager.LoadScene(1);
        }
        
    }



    private void PickUpItem(GameObject itemPrefab, string itemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0, 2, 2);
        heldItemName = itemName;
    }
    
    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }
}
