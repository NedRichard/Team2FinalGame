using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public static bool enemyClose = false;

    public static bool areaUIText = false;

    //UI Texts
    public GameObject InteractionText;
    public GameObject LoungeKeyText;
    public GameObject GeneratorPartText;
    public GameObject LobbyText;

    //UI for locked environments
    public GameObject LobbyLockedText;
    public GameObject LoungeLockedText;
    public GameObject FuseMissingText;

    //Player UI Texts
    public GameObject PlayerHideText;
    public GameObject CrouchingText;


    //Map trigger zones and collectibles

    //public static bool interact = false;
    public static bool keyCollected = false;
    public static bool loungeDoorOpened = false;
    public static bool partCollected = false;
    public static bool generatorFixed = false;

    void Awake() {
        Instance = this;
        //GameManager.Instance.InteractionText.SetActive(false);
    }

    void Update() {

        if(!enemyClose) {
            PlayerHideText.SetActive(false);
        } else {
            PlayerHideText.SetActive(true);
        }

        /**
        if(PlayerMovement.playerCrouch) {
            CrouchingText.SetActive(true);
        } else {
            CrouchingText.SetActive(false);
        }
        **/

    }

    //For Interaction UI
    public static void ShowInteractiveText() {
        GameManager.Instance.InteractionText.SetActive(true);
    }
    public static void HideInteractiveText() {
        GameManager.Instance.InteractionText.SetActive(false);
    }

    //For Lounge Key UI
    public static void ShowLoungeKeyText() {
        GameManager.Instance.LoungeKeyText.SetActive(true);
    }
    public static void HideLoungeKeyText() {
        GameManager.Instance.LoungeKeyText.SetActive(false);
    }

    //For Generator Fuse UI
    public static void ShowGeneratorPartText() {
        GameManager.Instance.GeneratorPartText.SetActive(true);
    } 
    public static void HideGeneratorPartText() {
        GameManager.Instance.GeneratorPartText.SetActive(false);
    }

    //For Lobby Opened UI
    public static void ShowLobbyText() {
        GameManager.Instance.LobbyText.SetActive(true);
    }
    public static void HideLobbyText() {
        GameManager.Instance.LobbyText.SetActive(false);
    }

    //Lobby Locked UI
    public static void ShowLobbyLockedText() {
        GameManager.Instance.LobbyLockedText.SetActive(true);
    }
    public static void HideLobbyLockedText() {
        GameManager.Instance.LobbyLockedText.SetActive(false);
    }

    //Generator Fuse Missing UI
    public static void ShowFuseMissingText() {
        GameManager.Instance.FuseMissingText.SetActive(true);
    }
    public static void HideFuseMissingText() {
        GameManager.Instance.FuseMissingText.SetActive(false);
    }

    //Lounge Door locked UI
    public static void ShowLoungeLockedText() {
        GameManager.Instance.LoungeLockedText.SetActive(true);
    }
    public static void HideLoungeLockedText() {
        GameManager.Instance.LoungeLockedText.SetActive(false);
    }

}
