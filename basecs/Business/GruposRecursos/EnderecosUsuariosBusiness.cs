namespace basecs.Business.GruposRecursos
{
    public class GruposRecursosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.GrupoRecurso model)
        {
            string validation = "";

            if (model.GrupoRecursoId > 0)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.GrupoId < 1)
            {
                validation += "Identificação do grupo que incluiu e invalido\n";
            }

            if (model.RecursoId < 1)
            {
                validation += "Identificação do recurso que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.GrupoRecurso model)
        {
            string validation = "";

            if (model.GrupoRecursoId < 1)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.GrupoId < 1)
            {
                validation += "Identificação do grupo que incluiu e invalido\n";
            }

            if (model.RecursoId < 1)
            {
                validation += "Identificação do recurso que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id < 1)
            {
                validation += "Identificação da configuração invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
