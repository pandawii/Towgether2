using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using UnityEngine;

public class SkinsManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<AnimatorOverrideController> skins = new List<AnimatorOverrideController>();
    public static  int selectedSkin = 0;
    public GameObject PlayerObject;

    [SerializeField]  GameObject PurchaseSkinButton;
    [SerializeField] GameObject priceOfSkin;
    [SerializeField] GameObject priceOfSkinIAP;
    [SerializeField] GameObject EquipButtonObject;
    [SerializeField] GameObject RestorePurchaseBtn;

    bool Owned;
    CurrentSkin currentSkin;
    int CurrentMoney;

    
    public static int Is_Third_SkinPurchased;
    public static int Is_fourth_SkinPurchased;
    public static int Is_fifth_SkinPurchased;
    public static int Is_sixth_SkinPurchased;
    public static int Is_seventh_SkinPurchased;
    int isskinspurchased;
  void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("CurrentScore", 100000);
        DisableRestorePurchaseBtn();
        isSkinPurcahsed();       
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
        currentSkin = new CurrentSkin(skins, Owned, PlayerObject, PurchaseSkinButton, priceOfSkin, EquipButtonObject, priceOfSkinIAP);
        PurchaseSkinButton.SetActive(false);
        priceOfSkin.SetActive(false);
        EquipButtonObject.SetActive(true);
        CurrentMoney = PlayerPrefs.GetInt("CurrentScore", 0);

        isskinspurchased= PlayerPrefs.GetInt("isskinspurchased", 0);

        if (isskinspurchased == 1)
        {
            priceOfSkinIAP.SetActive(false);

        }
        else if(isskinspurchased == 0)
        {
            priceOfSkinIAP.SetActive(true);

        }
    }
    //com.kemstroarab.towerjump.getallskins
    private string AllskinId = "ccom.abdelhakimmohamed.towgether.getall";
    void disableiapbutton()
    {
        priceOfSkinIAP.SetActive(false);
        PlayerPrefs.SetInt("isskinspurchased", 1);
        isskinspurchased = 1;

    }
    private void Update()
    {
        isskinspurchased = PlayerPrefs.GetInt("isskinspurchased", 0);

        if (isskinspurchased == 1)
        {
            priceOfSkinIAP.SetActive(false);

        }
        else
        {
            priceOfSkinIAP.SetActive(true);

        }
    }
    public void OnPurchaseComplete(Product product)
    {

        if (product.definition.id == AllskinId)
        {
            Debug.Log("pruchased");
            PlayerPrefs.SetInt("Is_Third_SkinPurchased", 1);
            PlayerPrefs.SetInt("Is_fourth_SkinPurchased", 1);
            PlayerPrefs.SetInt("Is_fifth_SkinPurchased", 1);
            PlayerPrefs.SetInt("Is_sixth_SkinPurchased", 1);
            PlayerPrefs.SetInt("Is_seventh_SkinPurchased", 1);
            Is_Third_SkinPurchased = 1;
            Is_fourth_SkinPurchased = 1;
            Is_fifth_SkinPurchased = 1;
            Is_sixth_SkinPurchased = 1;
            Is_seventh_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            priceOfSkin.SetActive(false);
            //PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;       
            SoundManager.PlaySound(SoundManager.Sound.BuySkin);
            PlayerPrefs.Save();
            Invoke(nameof(disableiapbutton), 1f);
        }

    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("purchace Failed");
    }


    public void PurcahseButton()
    {
        if (selectedSkin == 2&& CurrentMoney>= 5000)
        {
            SoundManager.PlaySound(SoundManager.Sound.BuySkin);

            PlayerPrefs.SetInt("Is_Third_SkinPurchased", 1);
            Is_Third_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            priceOfSkin.SetActive(false);
            priceOfSkinIAP.SetActive(false);
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);          
            CurrentMoney -= 5000;
            priceOfSkinIAP.SetActive(false);

            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();

        }
        if (selectedSkin == 3&& CurrentMoney >= 10000)
        {
            SoundManager.PlaySound(SoundManager.Sound.BuySkin);
            priceOfSkinIAP.SetActive(false);

            PlayerPrefs.SetInt("Is_fourth_SkinPurchased", 1);
            Is_fourth_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            priceOfSkin.SetActive(false);
            priceOfSkinIAP.SetActive(false);
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);          
            CurrentMoney -= 10000;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();
        }
        if (selectedSkin == 4 && CurrentMoney >= 15000)
        {
            SoundManager.PlaySound(SoundManager.Sound.BuySkin);
            priceOfSkinIAP.SetActive(false);

            PlayerPrefs.SetInt("Is_fifth_SkinPurchased", 1);
            Is_fifth_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            priceOfSkin.SetActive(false);
            priceOfSkinIAP.SetActive(false);

            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);  
            CurrentMoney -= 15000;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();
        }
        if (selectedSkin == 5 && CurrentMoney >= 20000)
        {
            SoundManager.PlaySound(SoundManager.Sound.BuySkin);
            priceOfSkinIAP.SetActive(false);

            PlayerPrefs.SetInt("Is_sixth_SkinPurchased", 1);
            Is_sixth_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            priceOfSkin.SetActive(false);
            priceOfSkinIAP.SetActive(false);

            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);
           
            CurrentMoney -= 20000;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();
        }
        if (selectedSkin == 6 && CurrentMoney >= 30000)
        {
            SoundManager.PlaySound(SoundManager.Sound.BuySkin);
            priceOfSkinIAP.SetActive(false);

            PlayerPrefs.SetInt("Is_seventh_SkinPurchased", 1);
            Is_seventh_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            priceOfSkin.SetActive(false);
            priceOfSkinIAP.SetActive(false);
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);           
            CurrentMoney -= 30000;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();
        }
    }

    public void isSkinPurcahsed()
    {
       
        Is_Third_SkinPurchased = PlayerPrefs.GetInt("Is_Third_SkinPurchased", 0);

        PlayerPrefs.SetInt(" Is_Third_SkinPurchased", Is_Third_SkinPurchased);
        PlayerPrefs.Save();

        Is_fourth_SkinPurchased = PlayerPrefs.GetInt("Is_fourth_SkinPurchased", 0);

        PlayerPrefs.SetInt(" Is_fourth_SkinPurchased", Is_fourth_SkinPurchased);
        PlayerPrefs.Save();

        Is_fifth_SkinPurchased = PlayerPrefs.GetInt("Is_fifth_SkinPurchased", 0);

        PlayerPrefs.SetInt(" Is_fifth_SkinPurchased", Is_fifth_SkinPurchased);
        PlayerPrefs.Save();

        Is_sixth_SkinPurchased = PlayerPrefs.GetInt("Is_sixth_SkinPurchased", 0);

        PlayerPrefs.SetInt(" Is_sixth_SkinPurchased", Is_sixth_SkinPurchased);
        PlayerPrefs.Save();

        Is_seventh_SkinPurchased = PlayerPrefs.GetInt("Is_seventh_SkinPurchased", 0);
       
        PlayerPrefs.SetInt(" Is_seventh_SkinPurchased", Is_seventh_SkinPurchased);
        PlayerPrefs.Save();

    }
    

    public void EquipButton()
    {
        currentSkin.EquipButton();
    }
    public void NextOption()
    {
        SoundManager.PlaySound(SoundManager.Sound.nextskin);

        currentSkin.NextSkin();
        currentSkin.SetSkin();
       
    }
    public void BackOption()
    {
        SoundManager.PlaySound(SoundManager.Sound.previousskin);

        currentSkin.previusSkin();
        currentSkin.SetSkin();

    }
   
    private class CurrentSkin
    {
        List<AnimatorOverrideController> skinsList = new List<AnimatorOverrideController>();
        bool IsOwned;
        GameObject PlayerObject;
        GameObject PurchaseSkinButton;
        GameObject priceOfSkin;
        GameObject priceOfSkinIAP;
        GameObject equipbutton;
     
        public CurrentSkin(List<AnimatorOverrideController> skinsList, bool isOwned,GameObject Player, GameObject PurchaseSkinButton, GameObject priceOfSkin,GameObject equipbutton, GameObject priceOfSkinIAP)
        {
            this.skinsList = skinsList;
            IsOwned = isOwned;
            this.PlayerObject = Player;
            this.PurchaseSkinButton = PurchaseSkinButton;
            this.priceOfSkin = priceOfSkin;
            this.equipbutton = equipbutton;
            this.priceOfSkinIAP = priceOfSkinIAP;
        }
       bool isowned()
        {
            switch (selectedSkin)
            {
                case 0:
                    return true;
                   
                case 1:
                    return true;
                    
                case 2:
                    return intToBool(Is_Third_SkinPurchased);
                   
                case 3:
                    return intToBool(Is_fourth_SkinPurchased);
                   
                case 4:
                    return intToBool(Is_fifth_SkinPurchased);
                   
                case 5:
                    return intToBool(Is_sixth_SkinPurchased);
                    
                case 6:
                    return intToBool(Is_seventh_SkinPurchased);                                      
            }
            return true;
        }


        public void SetSkin()
        {
            if (!isowned())
            {
                PlayerObject.GetComponent<SpriteRenderer>().color = Color.black;
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skinsList[selectedSkin] as RuntimeAnimatorController;
                PurchaseSkinButton.SetActive(true);
                priceOfSkin.SetActive(true);
                priceOfSkinIAP.SetActive(true);
                equipbutton.SetActive(false);    
                if (selectedSkin == 2)
                {
                    priceOfSkin.GetComponent<Text>().text = " 5000";

                }
                if (selectedSkin == 3)
                {
                    priceOfSkin.GetComponent<Text>().text = " 10000";

                }
                if (selectedSkin == 4)
                {
                    priceOfSkin.GetComponent<Text>().text = " 15000";

                }
                if (selectedSkin == 5)
                {
                    priceOfSkin.GetComponent<Text>().text = " 20000";

                }
                if (selectedSkin == 6)
                {
                    priceOfSkin.GetComponent<Text>().text = " 30000";

                }
            }
            else if (isowned())
            {
                equipbutton.SetActive(true);
                priceOfSkin.SetActive(false);
                PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
                PurchaseSkinButton.SetActive(false);
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skinsList[selectedSkin] as RuntimeAnimatorController;
            }
            

        }
        public void NextSkin()
        {
            
            selectedSkin += 1;
            
            if (selectedSkin == skinsList.Count)
            {
                selectedSkin = 0;
            }
        }
        public void previusSkin()
        {
            
            selectedSkin -= 1;
          
            if (selectedSkin < 0)
            {
                selectedSkin = 6;
            }
            
        }
        public void EquipButton()
        {
                PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
                PurchaseSkinButton.SetActive(false);
                priceOfSkin.SetActive(false);
                priceOfSkinIAP.SetActive(false);
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skinsList[selectedSkin] as RuntimeAnimatorController;
                equipbutton.SetActive(false);
                PlayerPrefs.SetInt("selectedSkin", selectedSkin);
                PlayerPrefs.Save();
        }
    }



    public static bool intToBool(int num)
    {
        if (num > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void DisableRestorePurchaseBtn()
    {
        if(Application.platform != RuntimePlatform.IPhonePlayer)
        {
            RestorePurchaseBtn.SetActive(false);
        }
    }
}
