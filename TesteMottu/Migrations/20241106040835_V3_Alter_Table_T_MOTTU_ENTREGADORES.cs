﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteMottu.Migrations
{
    /// <inheritdoc />
    public partial class V3_Alter_Table_T_MOTTU_ENTREGADORES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "T_MOTTU_ENTREGADORES",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "T_MOTTU_ENTREGADORES",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
