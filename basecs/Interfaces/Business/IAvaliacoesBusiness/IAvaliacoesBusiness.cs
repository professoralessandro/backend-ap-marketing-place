namespace basecs.Interfaces.Business.IAvaliacoesBusiness
{
    public interface IAvaliacoesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Avaliacao model);
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Avaliacao model);
        #endregion

        #region DELETE
        public string DeleteValidation(int id);
        #endregion
    }
}
