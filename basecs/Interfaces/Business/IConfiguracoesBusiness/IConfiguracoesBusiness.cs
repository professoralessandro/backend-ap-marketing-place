using System;

namespace basecs.Interfaces.Business.IAvaliacoesBusiness
{
    public interface IConfiguracoesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Configuracao model);
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Configuracao model);
        #endregion

        #region DELETE
        public string DeleteValidation(Guid id);
        #endregion
    }
}
