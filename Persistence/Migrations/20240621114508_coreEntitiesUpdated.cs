using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class coreEntitiesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserOperationClaims",
                newName: "BaseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_BaseUserId",
                table: "UserOperationClaims",
                column: "BaseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_BaseUsers_BaseUserId",
                table: "UserOperationClaims",
                column: "BaseUserId",
                principalTable: "BaseUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_BaseUsers_BaseUserId",
                table: "UserOperationClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_BaseUserId",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.RenameColumn(
                name: "BaseUserId",
                table: "UserOperationClaims",
                newName: "UserId");
        }
    }
}
