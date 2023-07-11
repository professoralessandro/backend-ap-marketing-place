using basecs.Data;
using basecs.Dtos.Usuarios;
using basecs.Interfaces.Repository;
using Dapper;
using System;
using System.Threading.Tasks;

namespace basecs.Repository
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
            var Params = new {
                Usuario = model.Usuario,
                NmrDocumento = model.NmrDocumento,
                TipoDocumento = model.TipoDocumento,
                Senha = model.Senha,
                Nome = model.Nome,
                DataNascimento = model.DataNascimento,
                Sexo = model.Sexo,
                EstadoCivil = model.EstadoCivil,
                Email = model.Email,
                TrocaSenha = false,
                Bloqueado = false,
                UsuarioInclusaoId = model.UsuarioInclusaoId,
                UsuarioUltimaAlteracaoId = model.UsuarioInclusaoId,
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
                DataUltimaTrocaSenha = DateTime.Now,
                DataUltimoLogin = model.DataUltimoLogin,
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
                Id = model.Id,
                Usuario = model.Usuario,
                NmrDocumento = model.NmrDocumento,
                TipoDocumento = model.TipoDocumento,
                Senha = model.Senha,
                Nome = model.Nome,
                DataNascimento = model.DataNascimento,
                Sexo = model.Sexo,
                EstadoCivil = model.EstadoCivil,
                Email = model.Email,
                TrocaSenha = model.TrocaSenha,
                Bloqueado = model.Bloqueado,
                UsuarioUltimaAlteracaoId = model.UsuarioUltimaAlteracaoId,
                DataUltimaAlteracao = model.DataUltimaAlteracao,
                DataUltimaTrocaSenha = model.DataUltimaTrocaSenha,
                DataUltimoLogin = model.DataUltimoLogin,
                Ativo = model.Ativo,
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
