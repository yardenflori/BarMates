using System.Collections.Generic;
using System.Linq;

public class UserTagsMatrix
{
    public UserTagsMatrix()
    {
    }
    
    private static Matrix GetUsersTagsMatrix(List<User> users)
    {
        int n = users.Count;
        Matrix matrix = new Matrix();
        matrix.IDS = new int[n];
        matrix.CharMatrix = new double[n][];
        for (int i = 0; i <n ; i++)
        {
            matrix.IDS[i] = users[i].UserId;
            matrix.CharMatrix[i] = users[i].InterestsVector;
        }
        return matrix;
    }

    public static List<int> GetSimilarUsers(int numSimilar, User user, List<User> users)
    {
        var similarUsers = new List<int>();
        var userTagsMatrix = GetUsersTagsMatrix(users);
        int n = userTagsMatrix.IDS.Length;
        double[] userDistance = new double[n];
        double tempMin = 0;
        int tempInd = 0;
        for (int i = 0; i < n; i++)
        {
            userDistance[i] = Helpers.VectorDistance(user.InterestsVector, userTagsMatrix.CharMatrix[i]);
        }
        for (int i = 0; i < numSimilar; i++)
        {
            tempMin = userDistance.Min();
            tempInd = userDistance.ToList().IndexOf(tempMin);
            similarUsers.Add(userTagsMatrix.IDS[tempInd]);
            userDistance[tempInd] = double.MaxValue;
        }
        return similarUsers;
    }
    
    public Matrix SimilarUsersScoreForAllBars(Bar[] bars, Matrix similarUsers)
    {
        Matrix scoreMatrix = new Matrix();
        int n = similarUsers.IDS.Length;
        scoreMatrix.IDS = similarUsers.IDS;
        scoreMatrix.CharMatrix = new double[n][];
        for(int i = 0; i < n; i++)
        {
            scoreMatrix.CharMatrix[i] = new double[bars.Length];
            var user = Engine.GetUserByUserID(scoreMatrix.IDS[i]);
            var rates = Engine.GetRatesByUser(user);
            for(int j = 0; j < bars.Length; j++)
            {
                var possibleRate = (rates.Where(x => (x.BarId == bars[j].BarId)).ToList());
                if(possibleRate.Count > 0)
                {
                    Rate rate = possibleRate[0];
                    scoreMatrix.CharMatrix[i][j] = user.CalculateScoreForBar(bars[j], rate);
                }
                else
                {
                    scoreMatrix.CharMatrix[i][j] = int.MinValue;
                }
            }
        }
        return scoreMatrix;
    }


}