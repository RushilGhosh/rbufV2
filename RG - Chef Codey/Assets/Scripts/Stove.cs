using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject cookedBottomBun;
    public GameObject cookedPatty;
    public GameObject cookedCheese;
    public GameObject cookedTopBun;

    [Header("Inventory")]
    public string cookedFood = "";
    public bool isCooking = false;

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;
    
    // Start is called before the first frame update
    void Start()
    {
        cookedBottomBun.SetActive(false);
        cookedPatty.SetActive(false);
        cookedCheese.SetActive(false);
        cookedTopBun.SetActive(false);
    }

    public void ToastBottomBun()
    {
        isCooking = true;
        smoke.Play();
        cookedBottomBun.SetActive(true);
        cookedFood = "cooked bottom bun";
        Invoke("CompleteCooking", 6f);
    }

    public void CookPatty()
    {
        isCooking = true;
        smoke.Play();
        cookedPatty.SetActive(true);
        cookedFood = "cooked patty";
        Invoke("CompleteCooking", 4f);
    }

    public void CookCheese()
    {
        isCooking = true;
        smoke.Play();
        cookedCheese.SetActive(true);
        cookedFood = "cooked cheese";
        Invoke("CompleteCooking", 7f);
    }

    public void ToastTopBun()
    {
        isCooking = true;
        smoke.Play();
        cookedTopBun.SetActive(true);
        cookedFood = "cooked top bun";
        Invoke("CompleteCooking", 6f);
    }

    public void CleanStove()
    {
        cookedBottomBun.SetActive(false);
        cookedPatty.SetActive(false);
        cookedCheese.SetActive(false);
        cookedTopBun.SetActive(false);
        cookedFood = "";
        complete.Stop();
    }

    private void CompleteCooking()
    {
        isCooking = false;
        smoke.Stop();
        complete.Play();
    }
        
}
