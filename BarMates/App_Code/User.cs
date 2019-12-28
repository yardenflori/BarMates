
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
        InterestsVector[2] = 1 - (SmokingFree.DontCareCounts / SmokingFree.AllCounts);
        InterestsVector[3] = 1 - (Food.Burger.DontCareCounts / Food.Burger.AllCounts);
        InterestsVector[4] = 1 - (Food.Vegan.DontCareCounts / Food.Vegan.AllCounts);
        InterestsVector[5] = 1 - (Food.Kosher.DontCareCounts / Food.Kosher.AllCounts);
        InterestsVector[6] = 1 - (Food.Pizza.DontCareCounts / Food.Pizza.AllCounts);
        InterestsVector[7] = 1 - (Food.Snacks.DontCareCounts / Food.Snacks.AllCounts);
        InterestsVector[8] = 1 - (Food.Sushi.DontCareCounts / Food.Sushi.AllCounts);
        InterestsVector[9] = 1 - (Drink.Wine.DontCareCounts / Drink.Wine.AllCounts);
        InterestsVector[10] = 1 - (Drink.Beer.DontCareCounts / Drink.Beer.AllCounts);
        InterestsVector[11] = 1 - (Drink.BeveragePackages.DontCareCounts / Drink.BeveragePackages.AllCounts);
        InterestsVector[12] = 1 - (Drink.Cocktail.DontCareCounts / Drink.Cocktail.AllCounts);
        InterestsVector[13] = 1 - (Drink.Jin.DontCareCounts / Drink.Jin.AllCounts);
        InterestsVector[14] = 1 - (Drink.Whiskey.DontCareCounts / Drink.Whiskey.AllCounts);
        InterestsVector[15] = 1 - (Drink.WideRangeOfBeverages.DontCareCounts / Drink.WideRangeOfBeverages.AllCounts);
        InterestsVector[16] = 1 - (Atmosphere.Irish.DontCareCounts / Atmosphere.Irish.AllCounts);
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


    private int UserCatToBarCat(int i)
    {
        switch (i)
        {
            //FullService
            case 0:
                return 7;
            //SelfService
            case 1:
                return 8;
            //SmokingFree
            case 2:
                return 0;
            //Food.Burger
            case 3:
                return 9;
            //Food.Vegan
            case 4:
                return 10;
            //Food.Kosher
            case 5:
                return 11;
            //Food.Pizza
            case 6:
                return 12;
            //Food.Snacks
            case 7:
                return 13;
            //Food.Sushi
            case 8:
                return 14;
            //Drink.Wine
            case 9:
                return 21;
            //Drink.Beer
            case 10:
                return 16;
            //Drink.BeveragePackages
            case 11:
                return 17;
            //Drink.Cocktail
            case 12:
                return 18;
            //Drink.Jin
            case 13:
                return 19;
            //Drink.Whiskey
            case 14:
                return 20;
            //Drink.WideRange
            case 15:
                return 15;
            //Atmosphere.Irish
            case 16:
                return 22;
            //Atmosphere.Chill
            case 17:
                return 23;
            //Atmosphere.Dance
            case 18:
                return 24;
            //Atmosphere.Party
            case 19:
                return 25;
            //Atmosphere.Shisha
            case 20:
                return 26;
            //Atmosphere.Sport
            case 21:
                return 27;
            //Company.Colleagues
            case 22:
                return 28;
            //Company.Dating
            case 23:
                return 29;
            //Company.Friends
            case 24:
                return 30;
            //Company.KidsFriendly
            case 25:
                return 31;
            //Company.PetsFriendly
            case 26:
                return 32;
            //Music.Greek
            case 27:
                return 33;
            //Music.Israeli
            case 28:
                return 34;
            //Music.Jazz
            case 29:
                return 35;
            //Music.LiveMusic
            case 30:
                return 36;
            //Music.Mainstream
            case 31:
                return 37;
            //Music.Mizrahit
            case 32:
                return 38;
            //Music.OpenMic
            case 33:
                return 39;
            //Music.Pop
            case 34:
                return 40;
            //Music.Reggaeton
            case 35:
                return 41;
            //Music.StandUp
            case 36:
                return 42;
            //Music.Trance
            case 37:
                return 43;
            default:
                break;
        }
        return -1;
    }

    private int UserCatToRate(int i, Rate rate)
    {
        switch (i)
        {
            //FullService
           // case 0:
              //  return rate.FullService;
            //SelfService
           // case 1:
            //    return rate.SelfService;
            //SmokingFree
            case 2:
                return rate.SmokingFree;
            //Food.Burger
            case 3:
                return rate.Food.Burger;
            //Food.Vegan
            case 4:
                return rate.Food.Vegan;
            //Food.Kosher
            case 5:
                return rate.Food.Kosher;
            //Food.Pizza
            case 6:
                return rate.Food.Pizza;
            //Food.Snacks
            case 7:
                return rate.Food.Snacks;
            //Food.Sushi
            case 8:
                return rate.Food.Sushi;
            //Drink.Wine
            case 9:
                return rate.Drinks.Wine;
            //Drink.Beer
            case 10:
                return rate.Drinks.Beer;
            //Drink.BeveragePackages
            case 11:
                return rate.Drinks.BeveragePackages;
            //Drink.Cocktail
            case 12:
                return rate.Drinks.Cocktail;
            //Drink.Jin
            case 13:
                return rate.Drinks.Jin;
            //Drink.Whiskey
            case 14:
                return rate.Drinks.Whiskey;
            //Drink.WideRange
            case 15:
                return rate.Drinks.WideRangeOfBeverages;
            //Atmosphere.Irish
            case 16:
                return rate.Atmosphere.Irish;
            //Atmosphere.Chill
            case 17:
                return rate.Atmosphere.Chill;
            //Atmosphere.Dance
            case 18:
                return rate.Atmosphere.Dance;
            //Atmosphere.Party
            case 19:
                return rate.Atmosphere.Party;
            //Atmosphere.Shisha
            case 20:
                return rate.Atmosphere.Shisha;
            //Atmosphere.Sport
            case 21:
                return rate.Atmosphere.Sport;
            //Company.Colleagues
            case 22:
                return rate.Company.Colleagues;
            //Company.Dating
            case 23:
                return rate.Company.Dating;
            //Company.Friends
            case 24:
                return rate.Company.Friends;
            //Company.KidsFriendly
            case 25:
                return rate.Company.KidsFriendly;
            //Company.PetsFriendly
            case 26:
                return rate.Company.PetsFriendly;
            //Music.Greek
            case 27:
                return rate.Music.Greek;
            //Music.Israeli
            case 28:
                return rate.Music.Israeli;
            //Music.Jazz
            case 29:
                return rate.Music.Jazz;
            //Music.LiveMusic
            case 30:
                return rate.Music.LiveMusic;
            //Music.Mainstream
            case 31:
                return rate.Music.Mainstream;
            //Music.Mizrahit
            case 32:
                return rate.Music.Mizrahit;
            //Music.OpenMic
            case 33:
                return rate.Music.OpenMic;
            //Music.Pop
            case 34:
                return rate.Music.Pop;
            //Music.Reggaeton
            case 35:
                return rate.Music.Reggaeton;
            //Music.StandUp
            case 36:
                return rate.Music.StandUp;
            //Music.Trance
            case 37:
                return rate.Music.Trance;
            default:
                break;
        }
        return -2;
    }
    //Warning : Only bars that matches user's age
    public double CalculateScoreForBar(Bar bar, Rate rate)
    {
        double score = 0;
        int j, realRate;
        for(int i = 0; i < 38; i++)
        {
            j = UserCatToBarCat(i);
            realRate = UserCatToRate(i, rate);
            if(realRate != 2)
            {
                score += InterestsVector[i] * bar.BarCharacteristics[j] * realRate;
            }
        }
        return score;
    }
}
