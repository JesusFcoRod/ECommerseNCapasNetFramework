﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JRodriguezProgramacionNcapasEntities : DbContext
    {
        public JRodriguezProgramacionNcapasEntities()
            : base("name=JRodriguezProgramacionNcapasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Colonia> Colonias { get; set; }
        public virtual DbSet<Departamento> Departamentoes { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<MetodoPago> MetodoPagoes { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Producto> Productoes { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<rol> rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<VentaProducto> VentaProductoes { get; set; }
    
        public virtual int DepartamenteDelete(Nullable<int> idDepartamento)
        {
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("idDepartamento", idDepartamento) :
                new ObjectParameter("idDepartamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DepartamenteDelete", idDepartamentoParameter);
        }
    
        public virtual int DepartamentoAdd(string nombre, Nullable<int> idArea)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("idArea", idArea) :
                new ObjectParameter("idArea", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DepartamentoAdd", nombreParameter, idAreaParameter);
        }
    
        public virtual int DepartamentoUpdate(string nombre, Nullable<int> idArea, Nullable<int> idDepartamento)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idAreaParameter = idArea.HasValue ?
                new ObjectParameter("idArea", idArea) :
                new ObjectParameter("idArea", typeof(int));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("idDepartamento", idDepartamento) :
                new ObjectParameter("idDepartamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DepartamentoUpdate", nombreParameter, idAreaParameter, idDepartamentoParameter);
        }
    
        public virtual int UsuarioUDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUDelete", idUsuarioParameter);
        }
    
        public virtual ObjectResult<ColoniaGetByIdMunicipio_Result> ColoniaGetByIdMunicipio(Nullable<int> idMunicipio)
        {
            var idMunicipioParameter = idMunicipio.HasValue ?
                new ObjectParameter("idMunicipio", idMunicipio) :
                new ObjectParameter("idMunicipio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ColoniaGetByIdMunicipio_Result>("ColoniaGetByIdMunicipio", idMunicipioParameter);
        }
    
        public virtual ObjectResult<EstadoGetByIdPais_Result> EstadoGetByIdPais(Nullable<int> idPais)
        {
            var idPaisParameter = idPais.HasValue ?
                new ObjectParameter("idPais", idPais) :
                new ObjectParameter("idPais", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoGetByIdPais_Result>("EstadoGetByIdPais", idPaisParameter);
        }
    
        public virtual ObjectResult<MunicipioGetByIdEstado_Result> MunicipioGetByIdEstado(Nullable<int> idEstado)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("idEstado", idEstado) :
                new ObjectParameter("idEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MunicipioGetByIdEstado_Result>("MunicipioGetByIdEstado", idEstadoParameter);
        }
    
        public virtual ObjectResult<PaisGetAll_Result> PaisGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PaisGetAll_Result>("PaisGetAll");
        }
    
        public virtual int UsuarioAdd(string userName, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string password, string fechaNacimiento, string sexo, string telefono, string celular, string cURP, Nullable<int> idRol, string imagen, string calle, string numeroInterior, string numeroExterior, Nullable<int> idColonia)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("idRol", idRol) :
                new ObjectParameter("idRol", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("idColonia", idColonia) :
                new ObjectParameter("idColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", userNameParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, passwordParameter, fechaNacimientoParameter, sexoParameter, telefonoParameter, celularParameter, cURPParameter, idRolParameter, imagenParameter, calleParameter, numeroInteriorParameter, numeroExteriorParameter, idColoniaParameter);
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual int UsuarioUpdate(string userName, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string password, string fechaNacimiento, string sexo, string telefono, string celular, string cURP, Nullable<int> idRol, Nullable<int> idUsuario, string imagen, string calle, string numeroInterior, string numeroExterior, Nullable<int> idColonia)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("idRol", idRol) :
                new ObjectParameter("idRol", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("idColonia", idColonia) :
                new ObjectParameter("idColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdate", userNameParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, passwordParameter, fechaNacimientoParameter, sexoParameter, telefonoParameter, celularParameter, cURPParameter, idRolParameter, idUsuarioParameter, imagenParameter, calleParameter, numeroInteriorParameter, numeroExteriorParameter, idColoniaParameter);
        }
    
        public virtual ObjectResult<RolGetAll_Result> RolGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RolGetAll_Result>("RolGetAll");
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual ObjectResult<AreaGetAll_Result> AreaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AreaGetAll_Result>("AreaGetAll");
        }
    
        public virtual int ProductoAdd(string nombre, Nullable<decimal> precioUnitario, Nullable<int> stock, Nullable<int> idProveedor, Nullable<int> idDepartamento, string descripcion, string imagen)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var precioUnitarioParameter = precioUnitario.HasValue ?
                new ObjectParameter("PrecioUnitario", precioUnitario) :
                new ObjectParameter("PrecioUnitario", typeof(decimal));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("idProveedor", idProveedor) :
                new ObjectParameter("idProveedor", typeof(int));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("idDepartamento", idDepartamento) :
                new ObjectParameter("idDepartamento", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", nombreParameter, precioUnitarioParameter, stockParameter, idProveedorParameter, idDepartamentoParameter, descripcionParameter, imagenParameter);
        }
    
        public virtual ObjectResult<ProductoGetAll_Result> ProductoGetAll(Nullable<int> departamento)
        {
            var departamentoParameter = departamento.HasValue ?
                new ObjectParameter("Departamento", departamento) :
                new ObjectParameter("Departamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetAll_Result>("ProductoGetAll", departamentoParameter);
        }
    
        public virtual ObjectResult<ProductoGetById_Result> ProductoGetById(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetById_Result>("ProductoGetById", idProductoParameter);
        }
    
        public virtual int ProductoUpdate(Nullable<int> idProducto, string nombre, Nullable<decimal> precioUnitario, Nullable<int> stock, Nullable<int> idProveedor, Nullable<int> idDepartamento, string descripcion, string imagen)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var precioUnitarioParameter = precioUnitario.HasValue ?
                new ObjectParameter("PrecioUnitario", precioUnitario) :
                new ObjectParameter("PrecioUnitario", typeof(decimal));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("idProveedor", idProveedor) :
                new ObjectParameter("idProveedor", typeof(int));
    
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("idDepartamento", idDepartamento) :
                new ObjectParameter("idDepartamento", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoUpdate", idProductoParameter, nombreParameter, precioUnitarioParameter, stockParameter, idProveedorParameter, idDepartamentoParameter, descripcionParameter, imagenParameter);
        }
    
        public virtual ObjectResult<ProveedorGetAll_Result> ProveedorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProveedorGetAll_Result>("ProveedorGetAll");
        }
    
        public virtual int UsuarioChangeStatus(Nullable<int> idUsuario, Nullable<bool> status)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioChangeStatus", idUsuarioParameter, statusParameter);
        }
    
        public virtual ObjectResult<UsuarioGetByUserName_Result> UsuarioGetByUserName(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetByUserName_Result>("UsuarioGetByUserName", userNameParameter);
        }
    
        public virtual ObjectResult<DepartamentoGetAll_Result> DepartamentoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DepartamentoGetAll_Result>("DepartamentoGetAll");
        }
    
        public virtual ObjectResult<DepartamentoGetByID_Result> DepartamentoGetByID(Nullable<int> idDepartamento)
        {
            var idDepartamentoParameter = idDepartamento.HasValue ?
                new ObjectParameter("idDepartamento", idDepartamento) :
                new ObjectParameter("idDepartamento", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DepartamentoGetByID_Result>("DepartamentoGetByID", idDepartamentoParameter);
        }
    }
}
