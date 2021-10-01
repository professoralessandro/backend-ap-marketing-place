using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using basecs.Models;
using Microsoft.EntityFrameworkCore;

namespace basecs.Data
{
    public partial class MyDbContext : DbContext
    {
        #region CONTRUTORES
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        #endregion

        #region DBCONTEXT
        public virtual DbSet<Avaliaco> Avaliacoes { get; set; }
        public virtual DbSet<Bloqueio> Bloqueios { get; set; }
        public virtual DbSet<Caracteristica> Caracteristicas { get; set; }
        public virtual DbSet<CartoesBancario> CartoesBancarios { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Configuraco> Configuracoes { get; set; }
        public virtual DbSet<ConfiguracoesParametro> ConfiguracoesParametros { get; set; }
        public virtual DbSet<DadosBancario> DadosBancarios { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<FormasPagamento> FormasPagamentos { get; set; }
        public virtual DbSet<Garantia> Garantias { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<GruposRecurso> GruposRecursos { get; set; }
        public virtual DbSet<GruposUsuario> GruposUsuarios { get; set; }
        public virtual DbSet<Imagen> Imagens { get; set; }
        public virtual DbSet<Lancamento> Lancamentos { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Mensagen> Mensagens { get; set; }
        public virtual DbSet<NotasFiscai> NotasFiscais { get; set; }
        public virtual DbSet<Pagamento> Pagamentos { get; set; }
        public virtual DbSet<Parametro> Parametros { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Reclamaco> Reclamacoes { get; set; }
        public virtual DbSet<Recurso> Recursos { get; set; }
        public virtual DbSet<Situaco> Situacoes { get; set; }
        public virtual DbSet<StatusAprovaco> StatusAprovacoes { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<TipoBloqueio> TiposBloqueios { get; set; }
        public virtual DbSet<TipoCaracteristica> TiposCaracteristicas { get; set; }
        public virtual DbSet<TipoConfiguracao> TiposConfiguracoes { get; set; }
        public virtual DbSet<TipoDado> TiposDados { get; set; }
        public virtual DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public virtual DbSet<TipoEmail> TiposEmails { get; set; }
        public virtual DbSet<TipoEndereco> TiposEnderecos { get; set; }
        public virtual DbSet<TipoEntrega> TiposEntregas { get; set; }
        public virtual DbSet<TipoGarantia> TiposGarantias { get; set; }
        public virtual DbSet<TipoLancamento> TiposLancamentos { get; set; }
        public virtual DbSet<TipoNotaFiscal> TiposNotasFiscais { get; set; }
        public virtual DbSet<TipoParametro> TiposParametros { get; set; }
        public virtual DbSet<TipoProduto> TiposProdutos { get; set; }
        public virtual DbSet<TipoTelefone> TiposTelefones { get; set; }
        public virtual DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<TipoWorkFlow> TiposWorkFlows { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuariosDadosBancario> UsuariosDadosBancarios { get; set; }
        public virtual DbSet<UsuariosLancamento> UsuariosLancamentos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<WorkFlow> WorkFlows { get; set; }
        #endregion

        #region METHODS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Avaliaco>(entity =>
            {
                entity.HasKey(e => e.AvaliacaoId)
                    .HasName("PK__Avaliaco__FC95FF18DF328EDE");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Avaliacos)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avaliacoes_ProdutoId");

                entity.HasOne(d => d.Vendedor)
                    .WithMany(p => p.Avaliacos)
                    .HasForeignKey(d => d.VendedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avaliacoes_VendedorId");
            });

            modelBuilder.Entity<Bloqueio>(entity =>
            {
                entity.Property(e => e.DataFim).HasColumnType("datetime");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataInicio).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.IsBloqueiaAcesso).HasColumnName("isBloqueiaAcesso");

                entity.Property(e => e.NomeBloqueio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoBloqueio)
                    .WithMany(p => p.Bloqueios)
                    .HasForeignKey(d => d.TipoBloqueioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bloqueios_TipoBloqueioId");
            });

            modelBuilder.Entity<Caracteristica>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoCaracteristica)
                    .WithMany(p => p.Caracteristicas)
                    .HasForeignKey(d => d.TipoCaracteristicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caracteristicas_TipoCaracteristicaId");
            });

            modelBuilder.Entity<CartoesBancario>(entity =>
            {
                entity.HasKey(e => e.CartaoBancarioId)
                    .HasName("PK__CartoesB__CFFCED846A558D74");

                entity.Property(e => e.Bandeira)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodSeg)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.NomeNoCartao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Validade)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.CartoesBancarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartoesBancarios_UsuarioId");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.IsAvaliado).HasColumnName("isAvaliado");

                entity.Property(e => e.IsEntregue).HasColumnName("isEntregue");

                entity.Property(e => e.IsPago).HasColumnName("isPago");

                entity.HasOne(d => d.Avaliacao)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.AvaliacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_AvaliacaoId");

                entity.HasOne(d => d.Comprador)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.CompradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_CompradorId");

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.EnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_EnderecoId");

                entity.HasOne(d => d.Entrega)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.EntregaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_EntregaId");

                entity.HasOne(d => d.FormaPagamento)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.FormaPagamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_FormaPagamentoId");

                entity.HasOne(d => d.Garantia)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.GarantiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_GarantiaId");

                entity.HasOne(d => d.LancamentoPai)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.LancamentoPaiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_LancamentoPaiId");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_ProdutoId");

                entity.HasOne(d => d.StatusCompra)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.StatusCompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_StatusCompraId");
            });

            modelBuilder.Entity<Configuraco>(entity =>
            {
                entity.HasKey(e => e.ConfiguracaoId)
                    .HasName("PK__Configur__6AAFCF091E0D2AB3");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoConfiguracao)
                    .WithMany(p => p.Configuracos)
                    .HasForeignKey(d => d.TipoConfiguracaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Configuracoes_TipoConfiguracaoId");
            });

            modelBuilder.Entity<ConfiguracoesParametro>(entity =>
            {
                entity.HasKey(e => e.ConfiguracaoParametroId)
                    .HasName("PK__Configur__E21FA04F81782B86");

                entity.HasOne(d => d.Configuracao)
                    .WithMany(p => p.ConfiguracoesParametros)
                    .HasForeignKey(d => d.ConfiguracaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracoesParametros_ConfiguracaoId");

                entity.HasOne(d => d.Parametro)
                    .WithMany(p => p.ConfiguracoesParametros)
                    .HasForeignKey(d => d.ParametroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracoesParametros_ParametroId");
            });

            modelBuilder.Entity<DadosBancario>(entity =>
            {
                entity.HasKey(e => e.DadoBancarioId)
                    .HasName("PK__DadosBan__DC8C909AC522734E");

                entity.Property(e => e.Agencia)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Banco)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Conta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.DadosBancarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DadosBancarios_UsuarioId");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.Assunto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Destinatario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEmail)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.TipoEmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emails_TipoEmailId");

                entity.HasOne(d => d.UsuarioEnvio)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.UsuarioEnvioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emails_UsuarioEnvioId");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEndereco)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.TipoEnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enderecos_TipoEnderecoId");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.Property(e => e.DataEfetivaEnrega).HasColumnType("datetime");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataPrevistaEntrega).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.IsEntregueTitular).HasColumnName("isEntregueTitular");

                entity.Property(e => e.NmrDocumento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeRecebedor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ResponsavelEntrega)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.ResponsavelEntregaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entregas_ResponsavelEntregaId");

                entity.HasOne(d => d.TipoEntrega)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.TipoEntregaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entregas_TipoEntregaId");
            });

            modelBuilder.Entity<FormasPagamento>(entity =>
            {
                entity.HasKey(e => e.FormaPagamentoId)
                    .HasName("PK__FormasPa__3FBCDE067166253B");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Garantia>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Periodo).HasColumnType("datetime");

                entity.Property(e => e.PrecoVenda).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.TipoGarantia)
                    .WithMany(p => p.Garantia)
                    .HasForeignKey(d => d.TipoGarantiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Garantias_GarantiaId");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("Grupos", "seg");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Grupo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Grupo");
            });

            modelBuilder.Entity<GruposRecurso>(entity =>
            {
                entity.HasKey(e => e.GrupoRecursoId)
                    .HasName("PK__GruposRe__5A5BD2570AB22767");

                entity.ToTable("GruposRecursos", "seg");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.GruposRecursos)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposRecursos_GrupoId");

                entity.HasOne(d => d.Recurso)
                    .WithMany(p => p.GruposRecursos)
                    .HasForeignKey(d => d.RecursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposRecursos_RecursoId");
            });

            modelBuilder.Entity<GruposUsuario>(entity =>
            {
                entity.HasKey(e => e.GrupoUsuarioId)
                    .HasName("PK__GruposUs__B303C45011BD02C3");

                entity.ToTable("GruposUsuarios", "seg");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.GruposUsuarios)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposUsuarios_GrupoId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.GruposUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposUsuarios_UsuarioId");
            });

            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.HasKey(e => e.ImagemId)
                    .HasName("PK__Imagens__0CBF2AEE439EA2F4");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.Property(e => e.DataBaixa).HasColumnType("datetime");

                entity.Property(e => e.DataMovimento).HasColumnType("datetime");

                entity.Property(e => e.NroAutenticacao)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NroAutorizacao)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NroComprovante)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NroPedido)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.Property(e => e.Referencia)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ValorLancamento).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ValorParcela).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Situacao)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.SituacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lancamentos_SituacaoId");

                entity.HasOne(d => d.TipoLancamento)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.TipoLancamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lancamentos_TipoLancamentoId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lancamentos_UsuarioId");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Logs", "log");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Request)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserAdded)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserAddedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Logs_UserAddedId");
            });

            modelBuilder.Entity<Mensagen>(entity =>
            {
                entity.HasKey(e => e.MensagemId)
                    .HasName("PK__Mensagen__7C0322C6F1A88EBA");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Remetente)
                    .WithMany(p => p.Mensagens)
                    .HasForeignKey(d => d.RemetenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mensagens_RemetenteId");
            });

            modelBuilder.Entity<NotasFiscai>(entity =>
            {
                entity.HasKey(e => e.NotaFiscalId)
                    .HasName("PK__NotasFis__F82B6CF6F0D2DF14");

                entity.HasOne(d => d.TipoNotaFiscal)
                    .WithMany(p => p.NotasFiscais)
                    .HasForeignKey(d => d.TipoNotaFiscalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotasFiscais_TipoNotaFiscalId");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoDado)
                    .WithMany(p => p.Parametros)
                    .HasForeignKey(d => d.TipoDadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parametros_TipoDadoId");

                entity.HasOne(d => d.TipoParametro)
                    .WithMany(p => p.Parametros)
                    .HasForeignKey(d => d.TipoParametroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parametros_TipoParametroId");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Marca).IsUnicode(false);

                entity.Property(e => e.MargemLucro).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecoCusto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecoVenda).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.TipoProduto)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.TipoProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produtos_ProdutoId");
            });

            modelBuilder.Entity<Reclamaco>(entity =>
            {
                entity.HasKey(e => e.ReclamacaoId)
                    .HasName("PK__Reclamac__EAB68DAE21225291");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable("Recursos", "seg");

                entity.Property(e => e.Chave)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsSubMenu).HasColumnName("isSubMenu");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Route).IsUnicode(false);

                entity.Property(e => e.ToolTip)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Situaco>(entity =>
            {
                entity.HasKey(e => e.SituacaoId)
                    .HasName("PK__Situacoe__624444745274AA80");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusAprovaco>(entity =>
            {
                entity.HasKey(e => e.StatusAprovacaoId)
                    .HasName("PK__StatusAp__E9CC69FD25870925");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Telefone1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Telefone");

                entity.HasOne(d => d.TipoTelefone)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.TipoTelefoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Telefones_TipoTelefoneId");
            });

            modelBuilder.Entity<TipoBloqueio>(entity =>
            {
                entity.HasKey(e => e.TipoBloqueioId)
                    .HasName("PK__TiposBlo__28FFD75344A8FE50");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCaracteristica>(entity =>
            {
                entity.HasKey(e => e.TipoCaracteristicaId)
                    .HasName("PK__TiposCar__F96B55CEAF4EAB78");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoConfiguracao>(entity =>
            {
                entity.HasKey(e => e.TipoConfiguracaoId)
                    .HasName("PK__TiposCon__5851DEED2A5AF625");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDado>(entity =>
            {
                entity.HasKey(e => e.TipoDadoId)
                    .HasName("PK__TiposDad__3E94B2BAE2928EA9");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.TipoDocumentoId)
                    .HasName("PK__TiposDoc__A329EA872489761F");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEmail>(entity =>
            {
                entity.HasKey(e => e.TipoEmailId)
                    .HasName("PK__TiposEma__1C0DC5CAB7C8073A");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEndereco>(entity =>
            {
                entity.HasKey(e => e.TipoEnderecoId)
                    .HasName("PK__TiposEnd__F24E38AEC156202E");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoEntrega>(entity =>
            {
                entity.HasKey(e => e.TipoEntregaId)
                    .HasName("PK__TiposEnt__9D702849D524D466");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoGarantia>(entity =>
            {
                entity.HasKey(e => e.TipoGarantiaId)
                    .HasName("PK__TiposGar__E388A1F9CBB48684");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoLancamento>(entity =>
            {
                entity.HasKey(e => e.TipoLancamentoId)
                    .HasName("PK__TiposLan__F18FA8296888E752");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoNotaFiscal>(entity =>
            {
                entity.HasKey(e => e.TipoNotaFiscalId)
                    .HasName("PK__TiposNot__2F0C24E8AEC3ECEA");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoParametro>(entity =>
            {
                entity.HasKey(e => e.TipoParametroId)
                    .HasName("PK__TiposPar__AD0BF6ED045FC073");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.HasKey(e => e.TipoProdutoId)
                    .HasName("PK__TiposPro__99B538CBC710B41B");

                entity.ToTable("TiposProdutos", "seg");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoTelefone>(entity =>
            {
                entity.HasKey(e => e.TipoTelefoneId)
                    .HasName("PK__TiposTel__3D0BC17BE9B15E00");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.TipoUsuarioId)
                    .HasName("PK__TiposUsu__7F22C722633220B9");

                entity.ToTable("TiposUsuarios", "seg");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoWorkFlow>(entity =>
            {
                entity.HasKey(e => e.TipoWorkFlowId)
                    .HasName("PK__TiposWor__12D351932CAA35B2");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios", "seg");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaTrocaSenha).HasColumnType("datetime");

                entity.Property(e => e.DataUltimoLogin).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NmrDocumento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_TipoDocumentoId");
            });

            modelBuilder.Entity<UsuariosDadosBancario>(entity =>
            {
                entity.HasKey(e => e.UsuarioDadoBancarioId)
                    .HasName("PK__Usuarios__BD9070E2FA1B4754");

                entity.HasOne(d => d.DadoBancario)
                    .WithMany(p => p.UsuariosDadosBancarios)
                    .HasForeignKey(d => d.DadoBancarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosDadosBancarios_DadoBancarioId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuariosDadosBancarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosDadosBancarios_UsuarioId");
            });

            modelBuilder.Entity<UsuariosLancamento>(entity =>
            {
                entity.HasKey(e => e.UsuarioLancamentoId)
                    .HasName("PK__Usuarios__632770F5B62A5534");

                entity.HasOne(d => d.Lancamento)
                    .WithMany(p => p.UsuariosLancamentos)
                    .HasForeignKey(d => d.LancamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosLancamentos_LancamentoId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuariosLancamentos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosLancamentos_UsuarioId");
            });

            modelBuilder.Entity<Venda>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vendas_UsuarioId");
            });

            modelBuilder.Entity<WorkFlow>(entity =>
            {
                entity.ToTable("WorkFlows", "seg");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.DataWorkFlow).HasColumnType("datetime");

                entity.Property(e => e.DataWorkFlowVerificacao).HasColumnType("datetime");

                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.HasOne(d => d.StatusAprovacao)
                    .WithMany(p => p.WorkFlows)
                    .HasForeignKey(d => d.StatusAprovacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlows_StatusAprovacaoId");

                entity.HasOne(d => d.TipoWorkflow)
                    .WithMany(p => p.WorkFlows)
                    .HasForeignKey(d => d.TipoWorkflowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkFlows_TipoWorkflowId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}