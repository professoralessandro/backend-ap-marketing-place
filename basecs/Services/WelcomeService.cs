using basecs.Interfaces.Services.IWelcomeService;
using System;

namespace basecs.Services
{
    public class WelcomeService : IWelcomeService
    {
        #region RETURN WELCOME MESSAGE
        public string ReturnWelcomeMessage()
        {
            try
            {
                return "Welcome to Alessandro Programming API";
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por boas vindas: " + ex.Message);
            }

        }
        #endregion
    }
}