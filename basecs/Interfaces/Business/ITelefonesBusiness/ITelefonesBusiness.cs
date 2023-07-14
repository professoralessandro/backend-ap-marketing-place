using System;

namespace basecs.Interfaces.Business.IAvaliacoesBusiness
{
    public interface ITelefonesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Telefone model);
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Telefone model);
        #endregion

        #region DELETE
        public string DeleteValidation(Guid id);
        #endregion
    }
}
