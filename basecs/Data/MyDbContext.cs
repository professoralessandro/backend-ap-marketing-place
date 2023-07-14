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
        public virtual DbSet<Recurso> Recursos { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuariosDadosBancario> UsuariosDadosBancarios { get; set; }
        public virtual DbSet<UsuariosLancamento> UsuariosLancamentos { get; set; }
        public virtual DbSet<WorkFlow> WorkFlows { get; set; }
        #endregion

        #region METHODS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.AvaliacaoId).HasName("PK__Avaliaco__FC95FF186496CDCA");

                entity.Property(e => e.AvaliacaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.ProdutoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.VendedorId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Produto).WithMany(p => p.Avaliacos)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avaliacoes_ProdutoId");

                entity.HasOne(d => d.Vendedor).WithMany(p => p.Avaliacos)
                    .HasForeignKey(d => d.VendedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avaliacoes_VendedorId");
            });

            modelBuilder.Entity<Bloqueio>(entity =>
            {
                entity.HasKey(e => e.BloqueioId).HasName("PK__Bloqueio__8B0DFCB138DAC66D");

                entity.Property(e => e.BloqueioId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataFim).HasColumnType("datetime");
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataInicio).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.IsBloqueiaAcesso).HasColumnName("isBloqueiaAcesso");
                entity.Property(e => e.NomeBloqueio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Caracteristica>(entity =>
            {
                entity.HasKey(e => e.CaracteristicaId).HasName("PK__Caracter__E52941177A869B60");

                entity.Property(e => e.CaracteristicaId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CartoesBancario>(entity =>
            {
                entity.HasKey(e => e.CartaoBancarioId).HasName("PK__CartoesB__CFFCED84F7013DDD");

                entity.Property(e => e.CartaoBancarioId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Validade)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario).WithMany(p => p.CartoesBancarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartoesBancarios_UsuarioId");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.CompraId).HasName("PK__Compras__067DA7453AB8F940");

                entity.Property(e => e.CompraId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.AvaliacaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.CodigoCompra)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CodigoPagamento)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.CompradorId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.EnderecoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.EntregaId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.GarantiaId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.LancamentoPaiId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ProdutoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.VendedorId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Avaliacao).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.AvaliacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_AvaliacaoId");

                entity.HasOne(d => d.Comprador).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.CompradorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_CompradorId");

                entity.HasOne(d => d.Endereco).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.EnderecoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_EnderecoId");

                entity.HasOne(d => d.Entrega).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.EntregaId)
                    .HasConstraintName("FK_Compras_EntregaId");

                entity.HasOne(d => d.Garantia).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.GarantiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_GarantiaId");

                entity.HasOne(d => d.LancamentoPai).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.LancamentoPaiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_LancamentoPaiId");

                entity.HasOne(d => d.Produto).WithMany(p => p.Compras)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_ProdutoId");
            });

            modelBuilder.Entity<Configuracao>(entity =>
            {
                entity.HasKey(e => e.ConfiguracaoId).HasName("PK__Configur__6AAFCF0928CD0F39");

                entity.Property(e => e.ConfiguracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ConfiguracoesParametro>(entity =>
            {
                entity.HasKey(e => e.ConfiguracaoParametroId).HasName("PK__Configur__E21FA04FCCC8A3D8");

                entity.Property(e => e.ConfiguracaoParametroId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ConfiguracaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ParametroId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Configuracao).WithMany(p => p.ConfiguracoesParametros)
                    .HasForeignKey(d => d.ConfiguracaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracoesParametros_ConfiguracaoId");

                entity.HasOne(d => d.Parametro).WithMany(p => p.ConfiguracoesParametros)
                    .HasForeignKey(d => d.ParametroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracoesParametros_ParametroId");
            });

            modelBuilder.Entity<DadosBancario>(entity =>
            {
                entity.HasKey(e => e.DadoBancarioId).HasName("PK__DadosBan__DC8C909A5A966969");

                entity.Property(e => e.DadoBancarioId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Usuario).WithMany(p => p.DadosBancarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DadosBancarios_UsuarioId");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.EmailId).HasName("PK__Emails__7ED91ACF34C79F87");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                    .IsUnicode(false);
                entity.Property(e => e.NomeEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.UsuarioEnvioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.UsuarioEnvio).WithMany(p => p.Emails)
                    .HasForeignKey(d => d.UsuarioEnvioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emails_UsuarioEnvioId");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.EnderecoId).HasName("PK__Endereco__B9D946CF1201FD0B");

                entity.Property(e => e.EnderecoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Bairro)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEP");
                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Complemento)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.PontoReferencia)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasKey(e => e.EntregaId).HasName("PK__Entregas__D9AD2303C4928827");

                entity.Property(e => e.EntregaId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ResponsavelEntregaId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.ResponsavelEntrega).WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.ResponsavelEntregaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entregas_ResponsavelEntregaId");
            });

            modelBuilder.Entity<FormasPagamento>(entity =>
            {
                entity.HasKey(e => e.FormaPagamentoId).HasName("PK__FormasPa__3FBCDE06FF77CA80");

                entity.Property(e => e.FormaPagamentoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Garantia>(entity =>
            {
                entity.HasKey(e => e.GarantiaId).HasName("PK__Garantia__3552F8347842A418");

                entity.Property(e => e.GarantiaId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Detalhes)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.Fim).HasColumnType("datetime");
                entity.Property(e => e.Inicio).HasColumnType("datetime");
                entity.Property(e => e.Periodo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.TipoGarantia)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.GrupoId).HasName("PK__Grupos__556BF04088800226");

                entity.ToTable("Grupos", "seg");

                entity.Property(e => e.GrupoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.Grupo1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Grupo");
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GruposRecurso>(entity =>
            {
                entity.HasKey(e => e.GrupoRecursoId).HasName("PK__GruposRe__5A5BD257FBFC83EC");

                entity.ToTable("GruposRecursos", "seg");

                entity.Property(e => e.GrupoRecursoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.GrupoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.RecursoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Grupo).WithMany(p => p.GruposRecursos)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposRecursos_GrupoId");

                entity.HasOne(d => d.Recurso).WithMany(p => p.GruposRecursos)
                    .HasForeignKey(d => d.RecursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposRecursos_RecursoId");
            });

            modelBuilder.Entity<GruposUsuario>(entity =>
            {
                entity.HasKey(e => e.GrupoUsuarioId).HasName("PK__GruposUs__B303C45053BAA17F");

                entity.ToTable("GruposUsuarios", "seg");

                entity.Property(e => e.GrupoUsuarioId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.GrupoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Grupo).WithMany(p => p.GruposUsuarios)
                    .HasForeignKey(d => d.GrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposUsuarios_GrupoId");

                entity.HasOne(d => d.Usuario).WithMany(p => p.GruposUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GruposUsuarios_UsuarioId");
            });

            modelBuilder.Entity<Imagen>(entity =>
            {
                entity.HasKey(e => e.ImagemId).HasName("PK__Imagens__0CBF2AEEF87E0BEE");

                entity.Property(e => e.ImagemId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.HasKey(e => e.LancamentoId).HasName("PK__Lancamen__687DA99B957A5204");

                entity.Property(e => e.LancamentoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.ValorLancamento).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ValorParcela).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Usuario).WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lancamentos_UsuarioId");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.LogId).HasName("PK__Logs__5E548648A8689DEB");

                entity.ToTable("Logs", "log");

                entity.Property(e => e.LogId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.Property(e => e.UserAddedId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.UserAdded).WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserAddedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Logs_UserAddedId");
            });

            modelBuilder.Entity<Mensagen>(entity =>
            {
                entity.HasKey(e => e.MensagemId).HasName("PK__Mensagen__7C0322C6B793103A");

                entity.Property(e => e.MensagemId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(e => e.RemetenteId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Remetente).WithMany(p => p.Mensagens)
                    .HasForeignKey(d => d.RemetenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mensagens_RemetenteId");
            });

            modelBuilder.Entity<NotasFiscai>(entity =>
            {
                entity.HasKey(e => e.NotaFiscalId).HasName("PK__NotasFis__F82B6CF6CB912265");

                entity.Property(e => e.NotaFiscalId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(e => e.PagamentoId).HasName("PK__Pagament__977DE7F33C355F9C");

                entity.Property(e => e.PagamentoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.ParametroId).HasName("PK__Parametr__2B3CE652CEA8586F");

                entity.Property(e => e.ParametroId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.HasKey(e => e.ProdutoId).HasName("PK__Produtos__9C8800E3A49A87F8");

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
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.HasKey(e => e.RecursoId).HasName("PK__Recursos__82F2B184DC0AC9E8");

                entity.ToTable("Recursos", "seg");

                entity.Property(e => e.RecursoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B87C5B4C3E");

                entity.ToTable("Usuarios", "seg");

                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
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
                entity.Property(e => e.NmrTelefone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
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
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<UsuariosDadosBancario>(entity =>
            {
                entity.HasKey(e => e.UsuarioDadoBancarioId).HasName("PK__Usuarios__BD9070E265618398");

                entity.Property(e => e.UsuarioDadoBancarioId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DadoBancarioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.DadoBancario).WithMany(p => p.UsuariosDadosBancarios)
                    .HasForeignKey(d => d.DadoBancarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosDadosBancarios_DadoBancarioId");

                entity.HasOne(d => d.Usuario).WithMany(p => p.UsuariosDadosBancarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosDadosBancarios_UsuarioId");
            });

            modelBuilder.Entity<UsuariosLancamento>(entity =>
            {
                entity.HasKey(e => e.UsuarioLancamentoId).HasName("PK__Usuarios__632770F531912A50");

                entity.Property(e => e.UsuarioLancamentoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.LancamentoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Lancamento).WithMany(p => p.UsuariosLancamentos)
                    .HasForeignKey(d => d.LancamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosLancamentos_LancamentoId");

                entity.HasOne(d => d.Usuario).WithMany(p => p.UsuariosLancamentos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosLancamentos_UsuarioId");
            });

            modelBuilder.Entity<WorkFlow>(entity =>
            {
                entity.HasKey(e => e.WorkFlowId).HasName("PK__WorkFlow__F98B18EE0E4A5447");

                entity.ToTable("WorkFlows", "seg");

                entity.Property(e => e.WorkFlowId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.DataInclusao).HasColumnType("datetime");
                entity.Property(e => e.DataUltimaAlteracao).HasColumnType("datetime");
                entity.Property(e => e.DataWorkFlow).HasColumnType("datetime");
                entity.Property(e => e.DataWorkFlowVerificacao).HasColumnType("datetime");
                entity.Property(e => e.Observacao).IsUnicode(false);
                entity.Property(e => e.UsuarioInclusaoId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UsuarioUltimaAlteracaoId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}