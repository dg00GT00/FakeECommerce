using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Identity.Migrations
{
    public partial class ChangeToSQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "Dev",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                schema: "Dev",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "Dev",
                table: "AspNetUserTokens",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Dev",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Dev",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Dev",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "Dev",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "Dev",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LockoutEnabled",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailConfirmed",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Dev",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccessFailedCount",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Dev",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                schema: "Dev",
                table: "AspNetUserRoles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Dev",
                table: "AspNetUserRoles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Dev",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderDisplayName",
                schema: "Dev",
                table: "AspNetUserLogins",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Dev",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Dev",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Dev",
                table: "AspNetUserClaims",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimValue",
                schema: "Dev",
                table: "AspNetUserClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                schema: "Dev",
                table: "AspNetUserClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "AspNetUserClaims",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                schema: "Dev",
                table: "AspNetRoles",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "AspNetRoles",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "Dev",
                table: "AspNetRoles",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Dev",
                table: "AspNetRoles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                schema: "Dev",
                table: "AspNetRoleClaims",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimValue",
                schema: "Dev",
                table: "AspNetRoleClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                schema: "Dev",
                table: "AspNetRoleClaims",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "AspNetRoleClaims",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                schema: "Dev",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                schema: "Dev",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "Dev",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Dev",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Dev",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "Dev",
                table: "Address",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                schema: "Dev",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "Address",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Dev",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Dev",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "Dev",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                schema: "Dev",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                schema: "Dev",
                table: "AspNetUserTokens",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Dev",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Dev",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "Dev",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "TwoFactorEnabled",
                schema: "Dev",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                schema: "Dev",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PhoneNumberConfirmed",
                schema: "Dev",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Dev",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "Dev",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "Dev",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "Dev",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LockoutEnd",
                schema: "Dev",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "LockoutEnabled",
                schema: "Dev",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "EmailConfirmed",
                schema: "Dev",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Dev",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                schema: "Dev",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "Dev",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccessFailedCount",
                schema: "Dev",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Dev",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                schema: "Dev",
                table: "AspNetUserRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Dev",
                table: "AspNetUserRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Dev",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderDisplayName",
                schema: "Dev",
                table: "AspNetUserLogins",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Dev",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Dev",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Dev",
                table: "AspNetUserClaims",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ClaimValue",
                schema: "Dev",
                table: "AspNetUserClaims",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                schema: "Dev",
                table: "AspNetUserClaims",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "AspNetUserClaims",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                schema: "Dev",
                table: "AspNetRoles",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Dev",
                table: "AspNetRoles",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                schema: "Dev",
                table: "AspNetRoles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Dev",
                table: "AspNetRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                schema: "Dev",
                table: "AspNetRoleClaims",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ClaimValue",
                schema: "Dev",
                table: "AspNetRoleClaims",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClaimType",
                schema: "Dev",
                table: "AspNetRoleClaims",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "AspNetRoleClaims",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                schema: "Dev",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                schema: "Dev",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "Dev",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "Dev",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "Dev",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "Dev",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                schema: "Dev",
                table: "Address",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                    name: "Id",
                    schema: "Dev",
                    table: "Address",
                    type: "integer",
                    nullable: false,
                    oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Dev",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Dev",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);
        }
    }
}