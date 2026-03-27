using UnityEngine;

public class ChangeColorCommand : ICommand
{
    private readonly CommandPlayer player;
    private readonly Color newColor;
    private Color oldColor;

    public ChangeColorCommand(CommandPlayer player, Color newColor)
    {
        this.player = player;
        this.newColor = newColor;
    }

    public void Execute()
    {
        oldColor = player.currentColor;
        player.ChangeColor(newColor);
    }

    public void Undo()
    {
        player.ChangeColor(oldColor);
    }
}
