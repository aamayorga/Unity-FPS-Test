using UnityEngine;
using System.Collections;

public class GameMasterCursor : MonoBehaviour {

    private bool isCursorLocked;

	// Use this for initialization
	void Start () {
        ToggleCursorState();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForInput();
        CheckCursorLock();
	}

    void CheckForInput() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleCursorState();
        }
    }

    void ToggleCursorState() {
        isCursorLocked = !isCursorLocked;
    }

    void CheckCursorLock() {
        if (isCursorLocked) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
