namespace basecs.Interfaces.Business.IAvaliacoesBusiness
{
    public interface IComprasBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Compra model);
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Compra model);
        #endregion

        #region DELETE
        public string DeleteValidation(int id);
        #endregion
    }
}
