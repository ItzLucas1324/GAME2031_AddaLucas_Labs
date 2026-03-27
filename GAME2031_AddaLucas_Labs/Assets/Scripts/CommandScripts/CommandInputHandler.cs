using UnityEngine;

public class CommandInputHandler : MonoBehaviour
{
    [SerializeField] private CommandPlayer player;
    private CommandHistory history;

    private void Awake()
    {
        history = new CommandHistory();
    }

    private void Update()
    {
        if (player == null) return;

        if (Input.GetKeyDown(KeyCode.A))
            history.ExecuteCommand(new MoveLeftCommand(player));
        
        if (Input.GetKeyDown(KeyCode.D))
            history.ExecuteCommand(new MoveRightCommand(player));
        
        if (Input.GetKeyDown(KeyCode.C))
            history.ExecuteCommand(new ChangeColorCommand(player, Random.ColorHSV()));
        
        if (Input.GetKeyDown(KeyCode.Z))
            history.Undo();
        
        if (Input.GetKey(KeyCode.Y))
            history.Redo();
        
    }
}
