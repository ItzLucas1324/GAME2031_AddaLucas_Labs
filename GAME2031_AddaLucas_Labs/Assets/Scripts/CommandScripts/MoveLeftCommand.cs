public class MoveLeftCommand : ICommand
{
    private readonly CommandPlayer player;

    public MoveLeftCommand(CommandPlayer player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.MoveLeft();
    }

    public void Undo()
    {
        player.MoveRight();
    }
}
