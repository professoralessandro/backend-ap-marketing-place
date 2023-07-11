using basecs.Dtos.Usuarios;
using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using basecs.Interfaces.Services.IUsuariosService;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Business.Usuarios
{
    public class UsuariosBusiness : IUsuariosBusiness
    {
        //#region ATTRIBUTES
        //private readonly IUsuariosService _usuariosService;
        //#endregion

        //#region CONSTRUCTORES
        //public UsuariosBusiness(IUsuariosService usuariosService)
        //{
        //    _usuariosService = usuariosService;
        //}
        //#endregion

        #region INSERT
        public async Task<string> InsertValidation(InsertUserDto model, IUsuariosService _usuariosService)
        {
            string validation = "";

            if (!string.IsNullOrEmpty(model.Nome))
            {
                model.Nome = Validators.RemoveInjections(model.Nome);
                if (model.Nome.Length < 3)
                {
                    validation += "Nome contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                if (model.Email.Length < 3)
                {
                    validation += "Email contem menos de três caracteres\n";
                }

                if (!model.Email.Contains("@"))
                {
                    validation += "Email nao contem @\n";
                }
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            var user = await _usuariosService.ReturnListWithParametersPaginated(null, null, null, model.Email, null, 1, 1);

            if (user.Any())
            {
                validation += "Ja existe este usuario com este email cadastrado na base de dados.\n";
            }

            user = await _usuariosService.ReturnListWithParametersPaginated(null, null, model.NmrDocumento, null, null, 1, 1);

            if (user.Any())
            {
                validation += "Ja existe este usuario com este numero de documento cadastrado na base de dados.\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Usuario model)
        {
            string validation = "";

            if (model.UsuarioId == 0)
            {
                validation += "Identificação do avaliação invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Nome))
            {
                model.Nome = Validators.RemoveInjections(model.Nome);
                if (model.Nome.Length < 3)
                {
                    validation += "Nome contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                model.Email = Validators.RemoveInjections(model.Email);
                if (model.Email.Length < 3)
                {
                    validation += "Email contem menos de três caracteres\n";
                }

                if (!model.Email.Contains("@"))
                {
                    validation += "Email nao contem @\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id == 0)
            {
                validation += "Identificação do avaliação invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
