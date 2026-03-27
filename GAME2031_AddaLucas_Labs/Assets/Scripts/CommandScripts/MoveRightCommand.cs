public class MoveRightCommand : ICommand
{
    private readonly CommandPlayer player;

    public MoveRightCommand(CommandPlayer player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.MoveRight();
    }

    public void Undo()
    {
        player.MoveLeft();
    }
}
