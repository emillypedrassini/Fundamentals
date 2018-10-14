using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Contexto
{
    //classe para configurar a base de dados utilizando code first
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext() : base("ProjetoModeloDDD")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //desabilitar convenções
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  //colocar os nomes das colunas no plural
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();    //deletar em cascata em relação 1-N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();   //deletar em cascata em relação N-N

            //configurar para quando uma propriedade possuir "id" no nome esta seja pk da tabela
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey());

            //configurar para quando a propriedade for string, no banco ela sera varchar e nao nvarchar que é o padrão
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //configurar para quando a propriedade dor string, possuir um tamanho de 100 no banco
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //configurar para seguir oq foi definido na classe ClienteConfiguration ao criar a tabela
            modelBuilder.Configurations.Add(new ClienteConfiguration());

            //configurar para seguir oq foi definido na classe ProdutoConfiguration ao criar a tabela
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }

        public override int SaveChanges()
        {      
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
