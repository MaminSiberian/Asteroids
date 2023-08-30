
public class Asteroid : Obstacle
{
    public void BlowUp()
    {
        this.gameObject.SetActive(false);
    }
}
