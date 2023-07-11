namespace basecs.Interfaces.Business.IAvaliacoesBusiness
{
    public interface IProdutosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Produto model);
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Produto model);
        #endregion

        #region DELETE
        public string DeleteValidation(int id);
        #endregion
    }
}
