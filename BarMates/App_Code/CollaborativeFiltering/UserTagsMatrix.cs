using System.Collections.Generic;
using System.Linq;
public class UserTagsMatrix
{
    public double[][] GetUsersTagsMatrix(List<User> users)
    {
        int n = users.Count;
        int len = users[0].InterestsVector.Length;
        double[][] matrix = new double[n][];
        for(int i = 0; i <n ; i++)
        {
            matrix[i] = new double[len + 1];
            matrix[i][0] = users[i].UserId;
            for(int j = 1; j < len + 1; j++)
            {
                matrix[i][j] = users[i].InterestsVector[j];
            }
        }
        return matrix;
    }

    public Matrix GetSimilarUsers(int numSimilar, User user, Matrix userTagsMatrix)
    {
        Matrix similarUsers = new Matrix();
        int n = userTagsMatrix.IDS.Length;
        double[] userDistance = new double[n];
        double tempMax = 0;
        int tempInd = 0;
        for (int i = 0; i < n; i++)
        {
            userDistance[i] = Helpers.VectorDistance(user.InterestsVector, userTagsMatrix.CharMatrix[i]);
        }
        for (int i = 0; i < numSimilar; i++)
        {
            tempMax = userDistance.Max();
            tempInd = userDistance.ToList().IndexOf(tempMax);
            similarUsers.IDS[i] = userTagsMatrix.IDS[tempInd];
            similarUsers.CharMatrix[i] = userTagsMatrix.CharMatrix[tempInd];
            userDistance[tempInd] = -1;
        }
        return similarUsers;
    }
    public UserTagsMatrix()
    {
        
    }
}