using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaDeLaboratorio.Migrations
{
    /// <inheritdoc />
    public partial class PopularReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Reservas (ReservaId, ProfessorId, TurmaId, LaboratorioId, Data, HoraInicio, DuracaoEmMinutos) " +
       "VALUES (1, 1, 1, 1, '2025-07-15', '08:00:00', 50)");

            mb.Sql("INSERT INTO Reservas (ReservaId, ProfessorId, TurmaId, LaboratorioId, Data, HoraInicio, DuracaoEmMinutos) " +
                   "VALUES (2, 2, 2, 2, '2025-07-15', '10:00:00', 100)"); // aula estendida

            mb.Sql("INSERT INTO Reservas (ReservaId, ProfessorId, TurmaId, LaboratorioId, Data, HoraInicio, DuracaoEmMinutos) " +
                   "VALUES (3, 3, 3, 3, '2025-07-16', '14:00:00', 50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Reservas WHERE ReservaId IN (1, 2, 3)");
        }
    }
}
