namespace loginCheckerClass
{
    public class LoginCheckMethod
    {
        public static bool loginCheker(string login)
        {
            if (login.Contains('?') || login.Contains('#') || login.Contains('<') || login.Contains('>') || login.Contains('%') || login.Contains('@') || login.Contains('/'))
            {

                return false;

            } else return true;
        }
    }
}