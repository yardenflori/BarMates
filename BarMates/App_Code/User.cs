using System.Collections.Generic;
using System.Linq;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Score { get; set; }
    public int Age { get; set; }
    public ChallengeUser ChallengeUser { get; set; }
    public Triple SmokingFree { get; set; }
    public Food<Triple> Food { get; set; }
    public Drinks<Triple> Drinks { get; set; }
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
    public User()
    {
        _interestsVector = new double[36];
        Food = new Food<Triple>()
        {
            Burger = new Triple(),
            Pizza = new Triple(),
            Sushi = new Triple(),
            Snacks = new Triple(),
            Vegan = new Triple(),
            Kosher = new Triple()
        };

        Drinks = new Drinks<Triple>()
        {
            Beer = new Triple(),
            Wine = new Triple(),
            Cocktail = new Triple(),
            BeveragePackages = new Triple(),
            Jin = new Triple(),
            Whiskey = new Triple(),
            WideRangeOfBeverages = new Triple()
        };

        Atmosphere = new Atmosphere<Triple>()
        {
            Irish = new Triple(),
            Chill = new Triple(),
            Dance = new Triple(),
            Sport = new Triple(),
            Shisha = new Triple(),
            Party = new Triple()
        };

        Company = new Company<Triple>()
        {
            Dating = new Triple(),
            Friends = new Triple(),
            KidsFriendly = new Triple(),
            PetsFriendly = new Triple(),
            Colleagues = new Triple()
        };

        Music = new Music<Triple>()
        {
            Pop = new Triple(),
            Jazz = new Triple(),
            Mizrahit = new Triple(),
            Greek = new Triple(),
            Trance = new Triple(),
            Mainstream = new Triple(),
            Israeli = new Triple(),
            LiveMusic = new Triple(),
            Reggaeton = new Triple(),
            OpenMic = new Triple(),
            StandUp = new Triple()
        };

        SmokingFree = new Triple();
        ChallengeUser = new ChallengeUser();

    }

    private void CalculateInterestsVector()
    {
        if (SmokingFree.AllCounts != 0)
            _interestsVector[0] = 1 - (SmokingFree.DontCareCounts / SmokingFree.AllCounts);
        if (Food.Burger.AllCounts != 0)
            _interestsVector[1] = 1 - (Food.Burger.DontCareCounts / Food.Burger.AllCounts);
        if (Food.Vegan.AllCounts != 0)
            _interestsVector[2] = 1 - (Food.Vegan.DontCareCounts / Food.Vegan.AllCounts);
        if (Food.Kosher.AllCounts != 0)
            _interestsVector[3] = 1 - (Food.Kosher.DontCareCounts / Food.Kosher.AllCounts);
        if (Food.Pizza.AllCounts != 0)
            _interestsVector[4] = 1 - (Food.Pizza.DontCareCounts / Food.Pizza.AllCounts);
        if (Food.Snacks.AllCounts != 0)
            _interestsVector[5] = 1 - (Food.Snacks.DontCareCounts / Food.Snacks.AllCounts);
        if (Food.Sushi.AllCounts != 0)
            _interestsVector[6] = 1 - (Food.Sushi.DontCareCounts / Food.Sushi.AllCounts);
        if (Drinks.Wine.AllCounts != 0)
            _interestsVector[7] = 1 - (Drinks.Wine.DontCareCounts / Drinks.Wine.AllCounts);
        if (Drinks.Beer.AllCounts != 0)
            _interestsVector[8] = 1 - (Drinks.Beer.DontCareCounts / Drinks.Beer.AllCounts);
        if (Drinks.BeveragePackages.AllCounts != 0)
            _interestsVector[9] = 1 - (Drinks.BeveragePackages.DontCareCounts / Drinks.BeveragePackages.AllCounts);
        if (Drinks.Cocktail.AllCounts != 0)
            _interestsVector[10] = 1 - (Drinks.Cocktail.DontCareCounts / Drinks.Cocktail.AllCounts);
        if (Drinks.Jin.AllCounts != 0)
            _interestsVector[11] = 1 - (Drinks.Jin.DontCareCounts / Drinks.Jin.AllCounts);
        if (Drinks.Whiskey.AllCounts != 0)
            _interestsVector[12] = 1 - (Drinks.Whiskey.DontCareCounts / Drinks.Whiskey.AllCounts);
        if (Drinks.WideRangeOfBeverages.AllCounts != 0)
            _interestsVector[13] = 1 - (Drinks.WideRangeOfBeverages.DontCareCounts / Drinks.WideRangeOfBeverages.AllCounts);
        if (Atmosphere.Irish.AllCounts != 0)
            _interestsVector[14] = 1 - (Atmosphere.Irish.DontCareCounts / Atmosphere.Irish.AllCounts);
        if (Atmosphere.Chill.AllCounts != 0)
            _interestsVector[15] = 1 - (Atmosphere.Chill.DontCareCounts / Atmosphere.Chill.AllCounts);
        if (Atmosphere.Dance.AllCounts != 0)
            _interestsVector[16] = 1 - (Atmosphere.Dance.DontCareCounts / Atmosphere.Dance.AllCounts);
        if (Atmosphere.Party.AllCounts != 0)
            _interestsVector[17] = 1 - (Atmosphere.Party.DontCareCounts / Atmosphere.Party.AllCounts);
        if (Atmosphere.Shisha.AllCounts != 0)
            _interestsVector[18] = 1 - (Atmosphere.Shisha.DontCareCounts / Atmosphere.Shisha.AllCounts);
        if (Atmosphere.Sport.AllCounts != 0)
            _interestsVector[19] = 1 - (Atmosphere.Sport.DontCareCounts / Atmosphere.Sport.AllCounts);
        if (Company.Colleagues.AllCounts != 0)
            _interestsVector[20] = 1 - (Company.Colleagues.DontCareCounts / Company.Colleagues.AllCounts);
        if (Company.Dating.AllCounts != 0)
            _interestsVector[21] = 1 - (Company.Dating.DontCareCounts / Company.Dating.AllCounts);
        if (Company.Friends.AllCounts != 0)
            _interestsVector[22] = 1 - (Company.Friends.DontCareCounts / Company.Friends.AllCounts);
        if (Company.KidsFriendly.AllCounts != 0)
            _interestsVector[23] = 1 - (Company.KidsFriendly.DontCareCounts / Company.KidsFriendly.AllCounts);
        if (Company.PetsFriendly.AllCounts != 0)
            _interestsVector[24] = 1 - (Company.PetsFriendly.DontCareCounts / Company.PetsFriendly.AllCounts);
        if (Music.Greek.AllCounts != 0)
            _interestsVector[25] = 1 - (Music.Greek.DontCareCounts / Music.Greek.AllCounts);
        if (Music.Israeli.AllCounts != 0)
            _interestsVector[26] = 1 - (Music.Israeli.DontCareCounts / Music.Israeli.AllCounts);
        if (Music.Jazz.AllCounts != 0)
            _interestsVector[27] = 1 - (Music.Jazz.DontCareCounts / Music.Jazz.AllCounts);
        if (Music.LiveMusic.AllCounts != 0)
            _interestsVector[28] = 1 - (Music.LiveMusic.DontCareCounts / Music.LiveMusic.AllCounts);
        if (Music.Mainstream.AllCounts != 0)
            _interestsVector[29] = 1 - (Music.Mainstream.DontCareCounts / Music.Mainstream.AllCounts);
        if (Music.Mizrahit.AllCounts != 0)
            _interestsVector[30] = 1 - (Music.Mizrahit.DontCareCounts / Music.Mizrahit.AllCounts);
        if (Music.OpenMic.AllCounts != 0)
            _interestsVector[31] = 1 - (Music.OpenMic.DontCareCounts / Music.OpenMic.AllCounts);
        if (Music.Pop.AllCounts != 0)
            _interestsVector[32] = 1 - (Music.Pop.DontCareCounts / Music.Pop.AllCounts);
        if (Music.Reggaeton.AllCounts != 0)
            _interestsVector[33] = 1 - (Music.Reggaeton.DontCareCounts / Music.Reggaeton.AllCounts);
        if (Music.StandUp.AllCounts != 0)
            _interestsVector[34] = 1 - (Music.StandUp.DontCareCounts / Music.StandUp.AllCounts);
        if (Music.Trance.AllCounts != 0)
            _interestsVector[35] = 1 - (Music.Trance.DontCareCounts / Music.Trance.AllCounts);
    }

    private int UserCatToBarCat(int i)
    {
        switch (i)
        {
            //SmokingFree
            case 0:
                return 0;
            //Food.Burger
            case 1:
                return 9;
            //Food.Vegan
            case 2:
                return 10;
            //Food.Kosher
            case 3:
                return 11;
            //Food.Pizza
            case 4:
                return 12;
            //Food.Snacks
            case 5:
                return 13;
            //Food.Sushi
            case 6:
                return 14;
            //Drink.Wine
            case 7:
                return 21;
            //Drink.Beer
            case 8:
                return 16;
            //Drink.BeveragePackages
            case 9:
                return 17;
            //Drink.Cocktail
            case 10:
                return 18;
            //Drink.Jin
            case 11:
                return 19;
            //Drink.Whiskey
            case 12:
                return 20;
            //Drink.WideRange
            case 13:
                return 15;
            //Atmosphere.Irish
            case 14:
                return 22;
            //Atmosphere.Chill
            case 15:
                return 23;
            //Atmosphere.Dance
            case 16:
                return 24;
            //Atmosphere.Party
            case 17:
                return 25;
            //Atmosphere.Shisha
            case 18:
                return 26;
            //Atmosphere.Sport
            case 19:
                return 27;
            //Company.Colleagues
            case 20:
                return 28;
            //Company.Dating
            case 21:
                return 29;
            //Company.Friends
            case 22:
                return 30;
            //Company.KidsFriendly
            case 23:
                return 31;
            //Company.PetsFriendly
            case 24:
                return 32;
            //Music.Greek
            case 25:
                return 33;
            //Music.Israeli
            case 26:
                return 34;
            //Music.Jazz
            case 27:
                return 35;
            //Music.LiveMusic
            case 28:
                return 36;
            //Music.Mainstream
            case 29:
                return 37;
            //Music.Mizrahit
            case 30:
                return 38;
            //Music.OpenMic
            case 31:
                return 39;
            //Music.Pop
            case 32:
                return 40;
            //Music.Reggaeton
            case 33:
                return 41;
            //Music.StandUp
            case 34:
                return 42;
            //Music.Trance
            case 35:
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
            case 0:
                return rate.SmokingFree;
            //Food.Burger
            case 1:
                return rate.Food.Burger;
            //Food.Vegan
            case 2:
                return rate.Food.Vegan;
            //Food.Kosher
            case 3:
                return rate.Food.Kosher;
            //Food.Pizza
            case 4:
                return rate.Food.Pizza;
            //Food.Snacks
            case 5:
                return rate.Food.Snacks;
            //Food.Sushi
            case 6:
                return rate.Food.Sushi;
            //Drink.Wine
            case 7:
                return rate.Drinks.Wine;
            //Drink.Beer
            case 8:
                return rate.Drinks.Beer;
            //Drink.BeveragePackages
            case 9:
                return rate.Drinks.BeveragePackages;
            //Drink.Cocktail
            case 10:
                return rate.Drinks.Cocktail;
            //Drink.Jin
            case 11:
                return rate.Drinks.Jin;
            //Drink.Whiskey
            case 12:
                return rate.Drinks.Whiskey;
            //Drink.WideRange
            case 13:
                return rate.Drinks.WideRangeOfBeverages;
            //Atmosphere.Irish
            case 14:
                return rate.Atmosphere.Irish;
            //Atmosphere.Chill
            case 15:
                return rate.Atmosphere.Chill;
            //Atmosphere.Dance
            case 16:
                return rate.Atmosphere.Dance;
            //Atmosphere.Party
            case 17:
                return rate.Atmosphere.Party;
            //Atmosphere.Shisha
            case 18:
                return rate.Atmosphere.Shisha;
            //Atmosphere.Sport
            case 19:
                return rate.Atmosphere.Sport;
            //Company.Colleagues
            case 20:
                return rate.Company.Colleagues;
            //Company.Dating
            case 21:
                return rate.Company.Dating;
            //Company.Friends
            case 22:
                return rate.Company.Friends;
            //Company.KidsFriendly
            case 23:
                return rate.Company.KidsFriendly;
            //Company.PetsFriendly
            case 24:
                return rate.Company.PetsFriendly;
            //Music.Greek
            case 25:
                return rate.Music.Greek;
            //Music.Israeli
            case 26:
                return rate.Music.Israeli;
            //Music.Jazz
            case 27:
                return rate.Music.Jazz;
            //Music.LiveMusic
            case 28:
                return rate.Music.LiveMusic;
            //Music.Mainstream
            case 29:
                return rate.Music.Mainstream;
            //Music.Mizrahit
            case 30:
                return rate.Music.Mizrahit;
            //Music.OpenMic
            case 31:
                return rate.Music.OpenMic;
            //Music.Pop
            case 32:
                return rate.Music.Pop;
            //Music.Reggaeton
            case 33:
                return rate.Music.Reggaeton;
            //Music.StandUp
            case 34:
                return rate.Music.StandUp;
            //Music.Trance
            case 35:
                return rate.Music.Trance;
            default:
                break;
        }
        return -2;
    }

    public double CalculateScoreForBar(Bar bar, Rate rate)
    {
        double score = 0;
        int j, realRate;
        for (int i = 0; i < InterestsVector.Length; i++)
        {
            j = UserCatToBarCat(i);
            realRate = UserCatToRate(i, rate);
            if (realRate != 7)
            {
                score += InterestsVector[i] * bar.BarCharacteristics[j] * realRate;
            }
        }
        return score;
    }

    public List<Bar> GetBestBars(int numOfBest, List<Bar> bars)
    {

        int n = bars.Count();
        double[] scores = new double[n];
        double tempMax;
        int tempInd;
        var resultBars = new List<Bar>();
        var rates = Engine.GetRatesByUser(this);
        for (int i = 0; i < n; i++)
        {
            var tempRate = rates.Where(x => (x.BarId == bars[i].BarId)).ToList();
            if (tempRate.Count() > 0)
            {
                double tmp = CalculateScoreForBar(bars[i], tempRate[0]);
                scores[i] = tmp * 0.75;
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
        var users = UserTagsMatrix.GetSimilarUsers(5, this, Engine.Users);
        int cnt = 0;
        double score = 0;
        for (int i = 0; i < 5; i++)
        {
            User user = Engine.GetUserByUserID(users[i]);
            Rate rate = user.GetRateFromUser(bar);
            if (rate != null)
            {
                cnt++;
                score += user.CalculateScoreForBar(bar, rate);
            }
        }
        if (cnt > 0)
        {
            return score / cnt;
        }
        return 0;
    }

    private double ScoreBarItemByItem(Bar bar)
    {
        var bars = BarsTagsMatrix.GetSimilarBars(5, bar, Engine.Bars);
        int cnt = 0;
        double score = 0;
        for (int i = 0; i < 5; i++)
        {
            Bar newBar = Engine.GetBarByBarID(bars[i]);
            Rate rate = GetRateFromUser(newBar);
            if (rate != null)
            {
                cnt++;
                score += CalculateScoreForBar(newBar, rate);
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

    public void UpdateUserByRate(Rate rate)
    {
        int[] help = new int[36];
        if (Engine.Challenges.Dizengoff.Contains(rate.BarId))
        {
            ChallengeUser.Dizengoff[Engine.Challenges.Dizengoff.ToList().IndexOf(rate.BarId)] = true;
            Engine.InsertUpdateDizengoffChallengeUserToDB(this, 1);
        }
        else if (Engine.Challenges.Ibngabirol.Contains(rate.BarId))
        {
            ChallengeUser.Ibngabirol[Engine.Challenges.Ibngabirol.ToList().IndexOf(rate.BarId)] = true;
            Engine.InsertUpdateIbnGabirolChallengeUserToDB(this, 2);
        }
        else if (Engine.Challenges.Rotchild.Contains(rate.BarId))
        {
            ChallengeUser.Rotchild[Engine.Challenges.Rotchild.ToList().IndexOf(rate.BarId)] = true;
            Engine.InsertUpdateRotchildChallengeUserToDB(this, 3);
        }
        else if (Engine.Challenges.MahneYehuda.Contains(rate.BarId))
        {
            ChallengeUser.MahneYehuda[Engine.Challenges.MahneYehuda.ToList().IndexOf(rate.BarId)] = true;
            Engine.InsertUpdateMahneYehudaChallengeUserToDB(this, 4);
        }
        else if (Engine.Challenges.JerusalemCity.Contains(rate.BarId))
        {
            ChallengeUser.JerusalemCity[Engine.Challenges.JerusalemCity.ToList().IndexOf(rate.BarId)] = true;
            Engine.InsertUpdateJerusalemCityChallengeUserToDB(this, 5);
        }
        else if (Engine.Challenges.Italy.Contains(rate.BarId))
        {
            ChallengeUser.Italy[Engine.Challenges.Italy.ToList().IndexOf(rate.BarId)] = true;
            Engine.InsertUpdateItalyChallengeUserToDB(this, 6);
        }
        else if (Engine.Challenges.Irland.Contains(rate.BarId))
        {
            ChallengeUser.Irland[Engine.Challenges.Irland.ToList().IndexOf(rate.BarId)] = true;
            Engine.InsertUpdateIrlandChallengeUserToDB(this, 7);
        }
        for (int i = 0; i < InterestsVector.Length; i++)
        {
            help[i] = UserCatToRate(i, rate);
        }
        //dontcare
        if (help[0] == 0)
            SmokingFree.DontCareCounts++;
        //like
        else if (help[0] == 1)
            SmokingFree.PosCounts++;
        //didnt like
        else if (help[0] == -1)
            SmokingFree.NegCounts++;

        //dontcare
        if (help[1] == 0)
            Food.Burger.DontCareCounts++;
        //like
        else if (help[1] == 1)
            Food.Burger.PosCounts++;
        //didnt like
        else if (help[1] == -1)
            Food.Burger.NegCounts++;

        //dontcare
        if (help[2] == 0)
            Food.Vegan.DontCareCounts++;
        //like
        else if (help[2] == 1)
            Food.Vegan.PosCounts++;
        //didnt like
        else if (help[2] == -1)
            Food.Vegan.NegCounts++;

        //dontcare
        if (help[3] == 0)
            Food.Kosher.DontCareCounts++;
        //like
        else if (help[3] == 1)
            Food.Kosher.PosCounts++;
        //didnt like
        else if (help[3] == -1)
            Food.Kosher.NegCounts++;

        //dontcare
        if (help[4] == 0)
            Food.Pizza.DontCareCounts++;
        //like
        else if (help[4] == 1)
            Food.Pizza.PosCounts++;
        //didnt like
        else if (help[4] == -1)
            Food.Pizza.NegCounts++;

        //dontcare
        if (help[5] == 0)
            Food.Snacks.DontCareCounts++;
        //like
        else if (help[5] == 1)
            Food.Snacks.PosCounts++;
        //didnt like
        else if (help[5] == -1)
            Food.Snacks.NegCounts++;

        //dontcare
        if (help[6] == 0)
            Food.Sushi.DontCareCounts++;
        //like
        else if (help[6] == 1)
            Food.Sushi.PosCounts++;
        //didnt like
        else if (help[6] == -1)
            Food.Sushi.NegCounts++;

        //dontcare
        if (help[7] == 0)
            Drinks.Wine.DontCareCounts++;
        //like
        else if (help[7] == 1)
            Drinks.Wine.PosCounts++;
        //didnt like
        else if (help[7] == -1)
            Drinks.Wine.NegCounts++;

        //dontcare
        if (help[8] == 0)
            Drinks.Beer.DontCareCounts++;
        //like
        else if (help[8] == 1)
            Drinks.Beer.PosCounts++;
        //didnt like
        else if (help[8] == -1)
            Drinks.Beer.NegCounts++;

        //dontcare
        if (help[9] == 0)
            Drinks.BeveragePackages.DontCareCounts++;
        //like
        else if (help[9] == 1)
            Drinks.BeveragePackages.PosCounts++;
        //didnt like
        else if (help[9] == -1)
            Drinks.BeveragePackages.NegCounts++;

        //dontcare
        if (help[10] == 0)
            Drinks.Cocktail.DontCareCounts++;
        //like
        else if (help[10] == 1)
            Drinks.Cocktail.PosCounts++;
        //didnt like
        else if (help[10] == -1)
            Drinks.Cocktail.NegCounts++;

        //dontcare
        if (help[11] == 0)
            Drinks.Jin.DontCareCounts++;
        //like
        else if (help[11] == 1)
            Drinks.Jin.PosCounts++;
        //didnt like
        else if (help[11] == -1)
            Drinks.Jin.NegCounts++;

        //dontcare
        if (help[12] == 0)
            Drinks.Whiskey.DontCareCounts++;
        //like
        else if (help[12] == 1)
            Drinks.Whiskey.PosCounts++;
        //didnt like
        else if (help[12] == -1)
            Drinks.Whiskey.NegCounts++;

        //dontcare
        if (help[13] == 0)
            Drinks.WideRangeOfBeverages.DontCareCounts++;
        //like
        else if (help[13] == 1)
            Drinks.WideRangeOfBeverages.PosCounts++;
        //didnt like
        else if (help[13] == -1)
            Drinks.WideRangeOfBeverages.NegCounts++;

        //dontcare
        if (help[14] == 0)
            Atmosphere.Irish.DontCareCounts++;
        //like
        else if (help[14] == 1)
            Atmosphere.Irish.PosCounts++;
        //didnt like
        else if (help[14] == -1)
            Atmosphere.Irish.NegCounts++;

        //dontcare
        if (help[15] == 0)
            Atmosphere.Chill.DontCareCounts++;
        //like
        else if (help[15] == 1)
            Atmosphere.Chill.PosCounts++;
        //didnt like
        else if (help[15] == -1)
            Atmosphere.Chill.NegCounts++;

        //dontcare
        if (help[16] == 0)
            Atmosphere.Dance.DontCareCounts++;
        //like
        else if (help[16] == 1)
            Atmosphere.Dance.PosCounts++;
        //didnt like
        else if (help[16] == -1)
            Atmosphere.Dance.NegCounts++;

        //dontcare
        if (help[17] == 0)
            Atmosphere.Party.DontCareCounts++;
        //like
        else if (help[17] == 1)
            Atmosphere.Party.PosCounts++;
        //didnt like
        else if (help[17] == -1)
            Atmosphere.Party.NegCounts++;

        //dontcare
        if (help[18] == 0)
            Atmosphere.Shisha.DontCareCounts++;
        //like
        else if (help[18] == 1)
            Atmosphere.Shisha.PosCounts++;
        //didnt like
        else if (help[18] == -1)
            Atmosphere.Shisha.NegCounts++;

        //dontcare
        if (help[19] == 0)
            Atmosphere.Sport.DontCareCounts++;
        //like
        else if (help[19] == 1)
            Atmosphere.Sport.PosCounts++;
        //didnt like
        else if (help[19] == -1)
            Atmosphere.Sport.NegCounts++;

        //dontcare
        if (help[20] == 0)
            Company.Colleagues.DontCareCounts++;
        //like
        else if (help[20] == 1)
            Company.Colleagues.PosCounts++;
        //didnt like
        else if (help[20] == -1)
            Company.Colleagues.NegCounts++;

        //dontcare
        if (help[21] == 0)
            Company.Dating.DontCareCounts++;
        //like
        else if (help[21] == 1)
            Company.Dating.PosCounts++;
        //didnt like
        else if (help[21] == -1)
            Company.Dating.NegCounts++;

        //dontcare
        if (help[22] == 0)
            Company.Friends.DontCareCounts++;
        //like
        else if (help[22] == 1)
            Company.Friends.PosCounts++;
        //didnt like
        else if (help[22] == -1)
            Company.Friends.NegCounts++;

        //dontcare
        if (help[23] == 0)
            Company.KidsFriendly.DontCareCounts++;
        //like
        else if (help[23] == 1)
            Company.KidsFriendly.PosCounts++;
        //didnt like
        else if (help[23] == -1)
            Company.KidsFriendly.NegCounts++;

        //dontcare
        if (help[24] == 0)
            Company.PetsFriendly.DontCareCounts++;
        //like
        else if (help[24] == 1)
            Company.PetsFriendly.PosCounts++;
        //didnt like
        else if (help[24] == -1)
            Company.PetsFriendly.NegCounts++;

        //dontcare
        if (help[25] == 0)
            Music.Greek.DontCareCounts++;
        //like
        else if (help[25] == 1)
            Music.Greek.PosCounts++;
        //didnt like
        else if (help[25] == -1)
            Music.Greek.NegCounts++;

        //dontcare
        if (help[26] == 0)
            Music.Israeli.DontCareCounts++;
        //like
        else if (help[26] == 1)
            Music.Israeli.PosCounts++;
        //didnt like
        else if (help[26] == -1)
            Music.Israeli.NegCounts++;

        //dontcare
        if (help[27] == 0)
            Music.Jazz.DontCareCounts++;
        //like
        else if (help[27] == 1)
            Music.Jazz.PosCounts++;
        //didnt like
        else if (help[27] == -1)
            Music.Jazz.NegCounts++;

        //dontcare
        if (help[28] == 0)
            Music.LiveMusic.DontCareCounts++;
        //like
        else if (help[28] == 1)
            Music.LiveMusic.PosCounts++;
        //didnt like
        else if (help[28] == -1)
            Music.LiveMusic.NegCounts++;

        //dontcare
        if (help[29] == 0)
            Music.Mainstream.DontCareCounts++;
        //like
        else if (help[29] == 1)
            Music.Mainstream.PosCounts++;
        //didnt like
        else if (help[29] == -1)
            Music.Mainstream.NegCounts++;

        //dontcare
        if (help[30] == 0)
            Music.Mizrahit.DontCareCounts++;
        //like
        else if (help[30] == 1)
            Music.Mizrahit.PosCounts++;
        //didnt like
        else if (help[30] == -1)
            Music.Mizrahit.NegCounts++;

        //dontcare
        if (help[31] == 0)
            Music.OpenMic.DontCareCounts++;
        //like
        else if (help[31] == 1)
            Music.OpenMic.PosCounts++;
        //didnt like
        else if (help[31] == -1)
            Music.OpenMic.NegCounts++;

        //dontcare
        if (help[32] == 0)
            Music.Pop.DontCareCounts++;
        //like
        else if (help[32] == 1)
            Music.Pop.PosCounts++;
        //didnt like
        else if (help[32] == -1)
            Music.Pop.NegCounts++;

        //dontcare
        if (help[33] == 0)
            Music.Reggaeton.DontCareCounts++;
        //like
        else if (help[33] == 1)
            Music.Reggaeton.PosCounts++;
        //didnt like
        else if (help[33] == -1)
            Music.Reggaeton.NegCounts++;

        //dontcare
        if (help[34] == 0)
            Music.StandUp.DontCareCounts++;
        //like
        else if (help[34] == 1)
            Music.StandUp.PosCounts++;
        //didnt like
        else if (help[34] == -1)
            Music.StandUp.NegCounts++;

        //dontcare
        if (help[35] == 0)
            Music.Trance.DontCareCounts++;
        //like
        else if (help[35] == 1)
            Music.Trance.PosCounts++;
        //didnt like
        else if (help[35] == -1)
            Music.Trance.NegCounts++;
    }

    private bool IsDizengoffFinished()
    {
        for (int i = 0; i < 7; i++)
        {
            if (!ChallengeUser.Dizengoff[i])
            {
                return false;
            }
        }
        return true;
    }
    private bool IsRotchildFinished()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!ChallengeUser.Rotchild[i])
            {
                return false;
            }
        }
        return true;
    }
    private bool IsIbnGabirolFinished()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!ChallengeUser.Ibngabirol[i])
            {
                return false;
            }
        }
        return true;
    }
    private bool IsJerusalemCityFinished()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!ChallengeUser.JerusalemCity[i])
            {
                return false;
            }
        }
        return true;
    }
    private bool IsMahneYehudaFinished()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!ChallengeUser.MahneYehuda[i])
            {
                return false;
            }
        }
        return true;
    }
    private bool IsItalyFinished()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!ChallengeUser.Italy[i])
            {
                return false;
            }
        }
        return true;
    }
    private bool IsIrlandFinished()
    {
        for (int i = 0; i < 7; i++)
        {
            if (!ChallengeUser.Irland[i])
            {
                return false;
            }
        }
        return true;
    }
    private int IsChallengeFinished(Bar bar)
    {
        if (Engine.Challenges.Dizengoff.Contains(bar.BarId))
        {
            if (IsDizengoffFinished())
                return 7;
        }
        else if (Engine.Challenges.Rotchild.Contains(bar.BarId))
        {
            if (IsRotchildFinished())
                return 5;
        }
        else if (Engine.Challenges.Ibngabirol.Contains(bar.BarId))
        {
            if (IsIbnGabirolFinished())
                return 5;
        }
        else if (Engine.Challenges.Irland.Contains(bar.BarId))
        {
            if (IsIrlandFinished())
                return 7;
        }
        else if (Engine.Challenges.Italy.Contains(bar.BarId))
        {
            if (IsItalyFinished())
                return 5;
        }
        else if (Engine.Challenges.JerusalemCity.Contains(bar.BarId))
        {
            if (IsJerusalemCityFinished())
                return 5;
        }
        else if (Engine.Challenges.MahneYehuda.Contains(bar.BarId))
        {
            if (IsMahneYehudaFinished())
                return 5;
        }
        return 0;
    }

    public void UpdateScoreAfterRating(Bar bar)
    {
        Score += 50;
        Score += 50 * IsChallengeFinished(bar);
        Engine.InsertUpdateScoreByUserName(this, Score);
    }

    public bool IsDeservedAWorldBadge()
    {
        if (IsIrlandFinished() && IsItalyFinished())
        {
            return true;
        }
        return false;
    }
    public bool IsDeservedATLVBadge()
    {
        if (IsDizengoffFinished() && IsIbnGabirolFinished() && IsRotchildFinished())
        {
            return true;
        }
        return false;
    }
    public bool IsDeservedAJerusalemBadge()
    {
        if (IsJerusalemCityFinished() && IsMahneYehudaFinished())
        {
            return true;
        }
        return false;
    }
}

