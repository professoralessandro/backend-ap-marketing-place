using basecs.Data;
using basecs.Dtos.Usuarios;
using basecs.Interfaces.Repository;
using Dapper;
using System;
using System.Threading.Tasks;

namespace basecs.Repository.Usuarios
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private APDConnector _session;

        public UsuariosRepository(APDConnector session)
        {
            _session = session;
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            string query = string.Empty;

            query = @"
                DELETE FROM [seg].[Usuarios]
                WHERE [UsuarioId]=@Id;
            ";

            return await _session.Connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<int> InsertUserAsync(InsertUserDto model)
        {
            var Params = new
            {
                model.Usuario,
                model.NmrDocumento,
                model.TipoDocumento,
                model.Senha,
                model.Nome,
                model.DataNascimento,
                model.Sexo,
                model.EstadoCivil,
                model.Email,
                TrocaSenha = false,
                Bloqueado = false,
                model.UsuarioInclusaoId,
                UsuarioUltimaAlteracaoId = model.UsuarioInclusaoId,
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
                DataUltimaTrocaSenha = DateTime.Now,
                model.DataUltimoLogin,
                Ativo = true,
            };

            string query = string.Empty;

            query = @"
                INSERT INTO [seg].[Usuarios]([Usuario], [NmrDocumento], [TipoDocumento], [Senha], [Nome], [DataNascimento], [Sexo], [EstadoCivil], [Email], [TrocaSenha], [Bloqueado], [UsuarioInclusaoId], [UsuarioUltimaAlteracaoId], [DataInclusao], [DataUltimaAlteracao], [DataUltimaTrocaSenha], [DataUltimoLogin], [Ativo])
                VALUES (@Usuario, @NmrDocumento, @TipoDocumento, @Senha, @Nome, @DataNascimento, @Sexo, @EstadoCivil, @Email, @TrocaSenha, @Bloqueado, @UsuarioInclusaoId, @UsuarioUltimaAlteracaoId, @DataInclusao, @DataUltimaAlteracao, @DataUltimaTrocaSenha, @DataUltimoLogin, @Ativo)
            ";

            return await _session.Connection.ExecuteAsync(query, Params);
        }

        public async Task<int> UpdateValidation(EditUserDto model)
        {
            var Params = new
            {
                model.Id,
                model.Usuario,
                model.NmrDocumento,
                model.TipoDocumento,
                model.Senha,
                model.Nome,
                model.DataNascimento,
                model.Sexo,
                model.EstadoCivil,
                model.Email,
                model.TrocaSenha,
                model.Bloqueado,
                model.UsuarioUltimaAlteracaoId,
                model.DataUltimaAlteracao,
                model.DataUltimaTrocaSenha,
                model.DataUltimoLogin,
                model.Ativo,
            };

            string query = string.Empty;

            query = @"
                UPDATE APDBDev.seg.Usuarios
                SET
                    Usuario=@Usuario,
                    NmrDocumento=@NmrDocumento,
                    TipoDocumento=@TipoDocumento,
                    Senha=@Senha,
                    Nome=@Nome,
                    DataNascimento=@DataNascimento,
                    Sexo=@Sexo,
                    EstadoCivil=@EstadoCivil,
                    Email=@Email,
                    TrocaSenha=@TrocaSenha,
                    Bloqueado=@Bloqueado,
                    UsuarioUltimaAlteracaoId=@UsuarioUltimaAlteracaoId,
                    DataUltimaAlteracao=@DataUltimaAlteracao,
                    DataUltimaTrocaSenha=@DataUltimaTrocaSenha,
                    DataUltimoLogin=@DataUltimoLogin,
                    Ativo=@Ativo
                WHERE UsuarioId=@Id;
            ";

            return await _session.Connection.ExecuteAsync(query, Params);
        }
    }
}
