using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 23, "Fogo amaldiçoado" },
                    { 2, 67, "Chuva ContraTempoária" },
                    { 3, 16, "Corte Simples | Novo estilo da Sombra" },
                    { 4, 0, "Gás Tóxico | MicroFissura" },
                    { 5, 0, "Pico de força Espartana" },
                    { 6, 0, "Anomalia Temporal" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 114, 183, 59, 130, 96, 106, 125, 95, 178, 168, 31, 14, 170, 1, 181, 110, 9, 212, 203, 55, 27, 102, 224, 108, 216, 73, 187, 220, 129, 112, 47, 2, 183, 126, 11, 116, 168, 85, 191, 2, 40, 104, 185, 249, 193, 166, 0, 162, 155, 253, 48, 235, 5, 204, 156, 223, 221, 35, 225, 228, 5, 30, 249, 238 }, new byte[] { 48, 153, 3, 153, 148, 100, 252, 135, 96, 26, 61, 216, 42, 43, 146, 148, 106, 42, 102, 103, 138, 96, 136, 4, 237, 88, 60, 90, 144, 174, 117, 146, 135, 187, 94, 233, 91, 57, 243, 29, 89, 192, 137, 46, 18, 77, 1, 181, 81, 77, 15, 205, 156, 213, 36, 57, 95, 194, 22, 7, 64, 31, 120, 121, 70, 1, 110, 69, 227, 74, 135, 119, 31, 19, 152, 128, 188, 114, 28, 194, 111, 207, 116, 98, 181, 73, 20, 31, 163, 123, 236, 152, 250, 180, 214, 181, 82, 185, 206, 122, 65, 3, 12, 223, 71, 94, 15, 224, 58, 9, 89, 50, 248, 181, 123, 121, 195, 238, 75, 222, 136, 176, 110, 228, 62, 7, 26, 59 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 5, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 211, 23, 98, 185, 137, 120, 159, 97, 70, 166, 87, 109, 33, 246, 61, 203, 1, 74, 177, 92, 69, 0, 84, 172, 85, 11, 158, 31, 118, 144, 144, 55, 71, 126, 1, 117, 3, 163, 56, 88, 236, 8, 241, 5, 155, 194, 110, 142, 38, 190, 78, 75, 180, 74, 137, 144, 158, 247, 60, 16, 170, 107, 211, 3 }, new byte[] { 240, 246, 86, 163, 112, 115, 140, 33, 74, 65, 236, 240, 127, 152, 92, 76, 49, 0, 108, 194, 145, 169, 214, 62, 223, 203, 70, 242, 158, 3, 2, 129, 218, 206, 74, 103, 111, 231, 65, 90, 11, 57, 193, 241, 29, 213, 130, 111, 52, 164, 234, 216, 126, 120, 64, 58, 155, 27, 236, 155, 239, 67, 158, 19, 110, 113, 140, 7, 98, 214, 224, 23, 128, 32, 90, 249, 62, 41, 248, 176, 88, 2, 142, 20, 229, 35, 250, 21, 225, 163, 20, 0, 112, 142, 215, 75, 144, 98, 118, 45, 121, 159, 167, 166, 120, 187, 168, 4, 159, 206, 53, 44, 244, 116, 100, 72, 4, 45, 79, 194, 243, 124, 88, 128, 153, 210, 206, 249 } });
        }
    }
}
