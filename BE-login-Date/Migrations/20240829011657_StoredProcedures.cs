using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_login_Date.Migrations
{
    public partial class StoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"        
                create procedure listar_sp 
                as
                begin
                 select* from Users where Service = 'Activo'
                end
                ");

            migrationBuilder.Sql(@"
                create procedure obtener_sp(
                @IdUsers int
                )
                as
                begin
                 select* from Users where IdUsers = @IdUsers
                end
                ");

            migrationBuilder.Sql(@"
                create procedure guardar_sp(
                @Name varchar(25),
                @Date date,
                @Service varchar(25)
                )
                as
                begin
                 insert into Users(Name, Date, Service) values(@Name, @Date, @Service)
                end
                ");

            migrationBuilder.Sql(@"
                create procedure editar_sp(
                @IdUsers int,
                @Name varchar(25),
                @Date date,
                @Service varchar(25)
                )
                as
                begin

                    update Users set Name = @Name, Date = @Date, Service = @Service where IdUsers = @IdUsers
                end
                ");

            migrationBuilder.Sql(@"
                create procedure eliminar_sp(
                @IdUsers int
                )
                as
                begin

                    delete from Users where IdUsers = @IdUsers
                end
                ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE listar_sp");
            migrationBuilder.Sql("DROP PROCEDURE obtener_sp");
            migrationBuilder.Sql("DROP PROCEDURE guardar_sp");
            migrationBuilder.Sql("DROP PROCEDURE editar_sp");
            migrationBuilder.Sql("DROP PROCEDURE eliminar_sp");
        }
    }
}