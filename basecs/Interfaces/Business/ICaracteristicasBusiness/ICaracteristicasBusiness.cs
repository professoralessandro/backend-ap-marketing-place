namespace basecs.Interfaces.Business.AvaliacoesBusiness
{
    public interface ICaracteristicasBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Caracteristica model);
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Caracteristica model);
        #endregion

        #region DELETE
        public string DeleteValidation(int id);
        #endregion
    }
}
