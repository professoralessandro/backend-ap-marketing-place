namespace basecs.Interfaces.Business.AvaliacoesBusiness
{
    public interface IBloqueiosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Bloqueio model);
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Bloqueio model);
        #endregion

        #region DELETE
        public string DeleteValidation(int id);
        #endregion
    }
}
