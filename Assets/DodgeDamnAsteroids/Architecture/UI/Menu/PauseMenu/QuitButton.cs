
public class QuitButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        SceneDirector.ReturnToMainMenu();
    }
}
