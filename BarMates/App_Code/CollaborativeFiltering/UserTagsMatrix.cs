using System.Collections.Generic;

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
    public UserTagsMatrix()
    {
        
    }
}