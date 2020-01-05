using System.Collections.Generic;
using System.Linq;

public class User
{ 
    public Engine Engine { get; set; }
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
    private double[] _interestsVector { get; set; }
    public double[] InterestsVector
    {
        get
        {
            CalculateInterestsVector();
            return _interestsVector;
        }
        set
        {
            _interestsVector = value;
        }
    }
    public User(Engine engine)
    {
        _interestsVector = new double[38];
        Engine = engine;
    }

    private void CalculateInterestsVector()
    {
        _interestsVector[0] = 1 - (FullService.DontCareCounts / FullService.AllCounts);
        _interestsVector[1] = 1 - (SelfService.DontCareCounts / SelfService.AllCounts);
        _interestsVector[2] = 1 - (SmokingFree.DontCareCounts / SmokingFree.AllCounts);
        _interestsVector[3] = 1 - (Food.Burger.DontCareCounts / Food.Burger.AllCounts);
        _interestsVector[4] = 1 - (Food.Vegan.DontCareCounts / Food.Vegan.AllCounts);
        _interestsVector[5] = 1 - (Food.Kosher.DontCareCounts / Food.Kosher.AllCounts);
        _interestsVector[6] = 1 - (Food.Pizza.DontCareCounts / Food.Pizza.AllCounts);
        _interestsVector[7] = 1 - (Food.Snacks.DontCareCounts / Food.Snacks.AllCounts);
        _interestsVector[8] = 1 - (Food.Sushi.DontCareCounts / Food.Sushi.AllCounts);
        _interestsVector[9] = 1 - (Drink.Wine.DontCareCounts / Drink.Wine.AllCounts);
        _interestsVector[10] = 1 - (Drink.Beer.DontCareCounts / Drink.Beer.AllCounts);
        _interestsVector[11] = 1 - (Drink.BeveragePackages.DontCareCounts / Drink.BeveragePackages.AllCounts);
        _interestsVector[12] = 1 - (Drink.Cocktail.DontCareCounts / Drink.Cocktail.AllCounts);
        _interestsVector[13] = 1 - (Drink.Jin.DontCareCounts / Drink.Jin.AllCounts);
        _interestsVector[14] = 1 - (Drink.Whiskey.DontCareCounts / Drink.Whiskey.AllCounts);
        _interestsVector[15] = 1 - (Drink.WideRangeOfBeverages.DontCareCounts / Drink.WideRangeOfBeverages.AllCounts);
        _interestsVector[16] = 1 - (Atmosphere.Irish.DontCareCounts / Atmosphere.Irish.AllCounts);
        _interestsVector[17] = 1 - (Atmosphere.Chill.DontCareCounts / Atmosphere.Chill.AllCounts);
        _interestsVector[18] = 1 - (Atmosphere.Dance.DontCareCounts / Atmosphere.Dance.AllCounts);
        _interestsVector[19] = 1 - (Atmosphere.Party.DontCareCounts / Atmosphere.Party.AllCounts);
        _interestsVector[20] = 1 - (Atmosphere.Shisha.DontCareCounts / Atmosphere.Shisha.AllCounts);
        _interestsVector[21] = 1 - (Atmosphere.Sport.DontCareCounts / Atmosphere.Sport.AllCounts);
        _interestsVector[22] = 1 - (Company.Colleagues.DontCareCounts / Company.Colleagues.AllCounts);
        _interestsVector[23] = 1 - (Company.Dating.DontCareCounts / Company.Dating.AllCounts);
        _interestsVector[24] = 1 - (Company.Friends.DontCareCounts / Company.Friends.AllCounts);
        _interestsVector[25] = 1 - (Company.KidsFriendly.DontCareCounts / Company.KidsFriendly.AllCounts);
        _interestsVector[26] = 1 - (Company.PetsFriendly.DontCareCounts / Company.PetsFriendly.AllCounts);
        _interestsVector[27] = 1 - (Music.Greek.DontCareCounts / Music.Greek.AllCounts);
        _interestsVector[28] = 1 - (Music.Israeli.DontCareCounts / Music.Israeli.AllCounts);
        _interestsVector[29] = 1 - (Music.Jazz.DontCareCounts / Music.Jazz.AllCounts);
        _interestsVector[30] = 1 - (Music.LiveMusic.DontCareCounts / Music.LiveMusic.AllCounts);
        _interestsVector[31] = 1 - (Music.Mainstream.DontCareCounts / Music.Mainstream.AllCounts);
        _interestsVector[32] = 1 - (Music.Mizrahit.DontCareCounts / Music.Mizrahit.AllCounts);
        _interestsVector[33] = 1 - (Music.OpenMic.DontCareCounts / Music.OpenMic.AllCounts);
        _interestsVector[34] = 1 - (Music.Pop.DontCareCounts / Music.Pop.AllCounts);
        _interestsVector[35] = 1 - (Music.Reggaeton.DontCareCounts / Music.Reggaeton.AllCounts);
        _interestsVector[36] = 1 - (Music.StandUp.DontCareCounts / Music.StandUp.AllCounts);
        _interestsVector[37] = 1 - (Music.Trance.DontCareCounts / Music.Trance.AllCounts);
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
        for (int i = 0; i < 38; i++)
        {
            j = UserCatToBarCat(i);
            realRate = UserCatToRate(i, rate);
            if (realRate != 2)
            {
                score += InterestsVector[i] * bar.BarCharacteristics[j] * realRate;
            }
        }
        return score;
    }

    public List<Bar> GetBestBars(int numOfBest, List<Bar> bars)
    {
        var rates = new List<Rate>();
        int n = bars.Count();
        var scores = new double[n];
        double tempMax;
        int tempInd;
        var resultBars = new List<Bar>();
        for (int i = 0; i < n; i++)
        {
            var tempRate = rates.Where(x => (x.BarId == bars[i].BarId)).ToList();
            if (tempRate.Count() > 0)
            {
                scores[i] = CalculateScoreForBar(bars[i], tempRate[0]) * (3 / 4);
            }
            else
            {
                scores[i] = GuessScoreForBar(bars[i]);
            }
        }

        for (int i = 0; i < numOfBest; i++)
        {
            tempMax = scores.Max();
            tempInd = scores.ToList().IndexOf(tempMax);
            resultBars.Add(bars[tempInd]);
            scores[tempInd] = double.MinValue;
        }
        return resultBars;
    }

    public Rate GetRateFromUser(Bar bar)
    {
        var rates = Engine.GetRatesByUser(this);
        var possibleRate = (rates.Where(x => (x.BarId == bar.BarId)).ToList());
        if (possibleRate.Count > 0)
        {
            return possibleRate[0];
        }
        else
        {
            return null;
        }
    }
    
    private double ScoreBarUserByUser(Bar bar)
    {
        var users = UserTagsMatrix.GetSimilarUsers(10, this, Engine.Users);
        int cnt = 0;
        double score = 0;
        for (int i = 0; i < 10; i++)
        {
            User user = Engine.GetUserByUserID(users[i]);
            Rate rate = GetRateFromUser(bar);
            if(rate != null)
            {
                cnt++;
                score += CalculateScoreForBar(bar, rate);
            }
        }
        if(cnt > 0)
        {
            return score / cnt;
        }
        return 0;
    }

    private double ScoreBarItemByItem(Bar bar)
    {
        var bars = BarsTagsMatrix.GetSimilarBars(10, bar, Engine.Bars);
        int cnt = 0;
        double score = 0;
        for (int i = 0; i < 10; i++)
        {
            //Add get GetBarByBarID
            Bar tempBar = Engine.GetBarByBarID(bars[i]);
            Rate rate = GetRateFromUser(bar);
            if (rate != null)
            {
                cnt++;
                score += CalculateScoreForBar(bar, rate);
            }
        }
        if (cnt > 0)
        {
            return score / cnt;
        }
        return 0;
    }

    private double GuessScoreForBar(Bar bar)
    {
        double scoreItemByItem = ScoreBarItemByItem(bar);
        double scoreUserByUser = ScoreBarUserByUser(bar);
        return (scoreItemByItem + scoreUserByUser) / 2;
    }
}
