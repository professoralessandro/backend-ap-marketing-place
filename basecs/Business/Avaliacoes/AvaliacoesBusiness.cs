using basecs.Data;
using basecs.Helpers.Helpers.Validators;
using basecs.Services;

namespace basecs.Business.Avaliacoes
{
    public class AvaliacoesBusiness
    {
        //#region ATRIBUTES
        //private readonly MyDbContext _context;
        //private readonly ComprasService _comprasService;
        //#endregion

        //#region CONTRUCTORS
        //public AvaliacoesBusiness(MyDbContext context)
        //{
        //    _context = context;
        //    _comprasService = new ComprasService(context);
        //}
        //#endregion

        #region INSERT
        public string InsertValidation(basecs.Models.Avaliacao model)
        {
            string validation = "";

            if (model.AvaliacaoId > 0)
            {
                validation += "Identificação do avaliação invalido\n";
            }

            if (string.IsNullOrEmpty(model.Descricao))
            {
                validation += "Descrição do avaliação nao pode ser vazia\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do avaliação contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (!model.Ativo)
            {
                validation += "Não pode ser adicinada avaliação inativada\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Avaliacao model)
        {
            string validation = "";

            if (model.AvaliacaoId < 1)
            {
                validation += "Identificação do avaliação invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do avaliação contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
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
                validation += "Identificação do avaliação invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
