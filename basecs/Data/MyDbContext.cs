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
        public virtual DbSet<Avaliacao> Avaliacoes { get; set; }
        public virtual DbSet<Bloqueio> Bloqueios { get; set; }
        public virtual DbSet<Caracteristica> Caracteristicas { get; set; }
        public virtual DbSet<CartoesBancario> CartoesBancarios { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Configuracao> Configuracoes { get; set; }
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

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.AvaliacaoId)
                    .HasName("PK__Avaliaco__FC95FF18C11BE5B5");

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
            });

            modelBuilder.Entity<Caracteristica>(entity =>
            {
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CartoesBancario>(entity =>
            {
                entity.HasKey(e => e.CartaoBancarioId)
                    .HasName("PK__CartoesB__CFFCED8462F0C17F");

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
                entity.Property(e => e.CodigoCompra)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPagamento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

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
            });

            modelBuilder.Entity<Configuracao>(entity =>
            {
                entity.HasKey(e => e.ConfiguracaoId)
                    .HasName("PK__Configur__6AAFCF091F8FDDC2");

                entity.Property(e => e.DataInclusao).HasColumnType("datetime");

                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConfiguracoesParametro>(entity =>
            {
                entity.HasKey(e => e.ConfiguracaoParametroId)
                    .HasName("PK__Configur__E21FA04F8D7FE938");

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
                    .HasName("PK__DadosBan__DC8C909A1BC5F2CA");

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
            });

            modelBuilder.Entity<FormasPagamento>(entity =>
            {
                entity.HasKey(e => e.FormaPagamentoId)
                    .HasName("PK__FormasPa__3FBCDE069923437D");

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
                    .HasName("PK__GruposRe__5A5BD2573CD48AEC");

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
                    .HasName("PK__GruposUs__B303C450CDCA92A9");

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
                    .HasName("PK__Imagens__0CBF2AEE31339B2B");

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
                    .HasName("PK__Mensagen__7C0322C677B5D331");

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
                    .HasName("PK__NotasFis__F82B6CF6EE19118D");
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
            });

            modelBuilder.Entity<Reclamaco>(entity =>
            {
                entity.HasKey(e => e.ReclamacaoId)
                    .HasName("PK__Reclamac__EAB68DAEB02A4550");

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
                    .HasName("PK__Situacoe__62444474E66A93FB");

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
                    .HasName("PK__StatusAp__E9CC69FD0AD1DCE1");

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
            });

            modelBuilder.Entity<UsuariosDadosBancario>(entity =>
            {
                entity.HasKey(e => e.UsuarioDadoBancarioId)
                    .HasName("PK__Usuarios__BD9070E210232EC5");

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
                    .HasName("PK__Usuarios__632770F5021DE550");

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}