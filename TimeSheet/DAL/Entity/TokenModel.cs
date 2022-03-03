namespace TimeSheet.API.DAL.Entity
{
    public class TokenModel
    {
        internal static string _secretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";
        string AccessToken { get; set; }
        string UpdateToken { get; set; }
    }
}