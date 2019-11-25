
public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public Triple FullService { get; set; }
    public Triple SelfService { get; set; }
    public Triple Smoking { get; set; }
    public Food<Triple> Food { get; set; }
    public Drinks<Triple> Drink { get; set; }
    public Atmosphere<Triple> Atmosphere { get; set; }
    public Company<Triple> Company { get; set; }
    public Music<Triple> Music { get; set; }

    public User()
    {
    }


}
