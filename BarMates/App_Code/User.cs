
public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public Triple FullService { get; set; }
    public Triple SelfService { get; set; }
    public Triple SmokingFree { get; set; }
    public Food<Triple> Food { get; set; }
    public Drinks<Triple> Drink { get; set; }
    public Atmosphere<Triple> Atmosphere { get; set; }
    public Company<Triple> Company { get; set; }
    public Music<Triple> Music { get; set; }
    public double[] InterestsVector 
    {
        get
        {
            CalculateInterestsVector();
            return InterestsVector;
        }

        set
        {

        }
    }
    public User()
    {
        InterestsVector = new double[38];
    }

    private void CalculateInterestsVector()
    {
        InterestsVector[0] = 1 - (FullService.DontCareCounts / FullService.AllCounts);
        InterestsVector[1] = 1 - (SelfService.DontCareCounts / SelfService.AllCounts);
        InterestsVector[2] = 1 - (Smoking.DontCareCounts / Smoking.AllCounts);
        InterestsVector[3] = 1 - (Food.Burger.DontCareCounts / Food.Burger.AllCounts);
        InterestsVector[4] = 1 - (Food.Irish.DontCareCounts / Food.Irish.AllCounts);
        InterestsVector[5] = 1 - (Food.Kosher.DontCareCounts / Food.Kosher.AllCounts);
        InterestsVector[6] = 1 - (Food.Pizza.DontCareCounts / Food.Pizza.AllCounts);
        InterestsVector[7] = 1 - (Food.Snacks.DontCareCounts / Food.Snacks.AllCounts);
        InterestsVector[8] = 1 - (Food.Sushi.DontCareCounts / Food.Sushi.AllCounts);
        InterestsVector[9] = 1 - (Food.Vegan.DontCareCounts / Food.Vegan.AllCounts);
        InterestsVector[10] = 1 - (Drink.Beer.DontCareCounts / Drink.Beer.AllCounts);
        InterestsVector[11] = 1 - (Drink.BeveragePackages.DontCareCounts / Drink.BeveragePackages.AllCounts);
        InterestsVector[12] = 1 - (Drink.Cocktail.DontCareCounts / Drink.Cocktail.AllCounts);
        InterestsVector[13] = 1 - (Drink.Jin.DontCareCounts / Drink.Jin.AllCounts);
        InterestsVector[14] = 1 - (Drink.Whiskey.DontCareCounts / Drink.Whiskey.AllCounts);
        InterestsVector[15] = 1 - (Drink.WideRangeOfBeverages.DontCareCounts / Drink.WideRangeOfBeverages.AllCounts);
        InterestsVector[16] = 1 - (Drink.Wine.DontCareCounts / Drink.Wine.AllCounts);
        InterestsVector[17] = 1 - (Atmosphere.Chill.DontCareCounts / Atmosphere.Chill.AllCounts);
        InterestsVector[18] = 1 - (Atmosphere.Dance.DontCareCounts / Atmosphere.Dance.AllCounts);
        InterestsVector[19] = 1 - (Atmosphere.Party.DontCareCounts / Atmosphere.Party.AllCounts);
        InterestsVector[20] = 1 - (Atmosphere.Shisha.DontCareCounts / Atmosphere.Shisha.AllCounts);
        InterestsVector[21] = 1 - (Atmosphere.Sport.DontCareCounts / Atmosphere.Sport.AllCounts);
        InterestsVector[22] = 1 - (Company.Colleagues.DontCareCounts / Company.Colleagues.AllCounts);
        InterestsVector[23] = 1 - (Company.Dating.DontCareCounts / Company.Dating.AllCounts);
        InterestsVector[24] = 1 - (Company.Friends.DontCareCounts / Company.Friends.AllCounts);
        InterestsVector[25] = 1 - (Company.KidsFriendly.DontCareCounts / Company.KidsFriendly.AllCounts);
        InterestsVector[26] = 1 - (Company.PetsFriendly.DontCareCounts / Company.PetsFriendly.AllCounts);
        InterestsVector[27] = 1 - (Music.Greek.DontCareCounts / Music.Greek.AllCounts);
        InterestsVector[28] = 1 - (Music.Israeli.DontCareCounts / Music.Israeli.AllCounts);
        InterestsVector[29] = 1 - (Music.Jazz.DontCareCounts / Music.Jazz.AllCounts);
        InterestsVector[30] = 1 - (Music.LiveMusic.DontCareCounts / Music.LiveMusic.AllCounts);
        InterestsVector[31] = 1 - (Music.Mainstream.DontCareCounts / Music.Mainstream.AllCounts);
        InterestsVector[32] = 1 - (Music.Mizrahit.DontCareCounts / Music.Mizrahit.AllCounts);
        InterestsVector[33] = 1 - (Music.OpenMic.DontCareCounts / Music.OpenMic.AllCounts);
        InterestsVector[34] = 1 - (Music.Pop.DontCareCounts / Music.Pop.AllCounts);
        InterestsVector[35] = 1 - (Music.Reggaeton.DontCareCounts / Music.Reggaeton.AllCounts);
        InterestsVector[36] = 1 - (Music.StandUp.DontCareCounts / Music.StandUp.AllCounts);
        InterestsVector[37] = 1 - (Music.Trance.DontCareCounts / Music.Trance.AllCounts);
    }


}
