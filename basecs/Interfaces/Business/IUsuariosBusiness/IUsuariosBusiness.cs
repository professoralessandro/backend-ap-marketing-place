using basecs.Dtos.Usuarios;
using basecs.Interfaces.Services.IUsuariosService;
using System;
using System.Threading.Tasks;

namespace basecs.Interfaces.Business.IAvaliacoesBusiness
{
    public interface IUsuariosBusiness
    {
        #region INSERT
        public Task<string> InsertValidation(InsertUserDto model, IUsuariosService _usuariosService);
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Usuario model);
        #endregion

        #region DELETE
        public string DeleteValidation(Guid id);
        #endregion
    }
}
