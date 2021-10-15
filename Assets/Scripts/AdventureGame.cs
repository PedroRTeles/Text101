using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState;
        UpdateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = currentState.GetNextStates();

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index) || Input.GetKeyDown(KeyCode.Keypad1 + index))
            {
                currentState = nextStates[index];
            }
        }

        UpdateStory();
    }

    private void UpdateStory()
    {
        textComponent.text = currentState.GetStateStory();
    }
}
