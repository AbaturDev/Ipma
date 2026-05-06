using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ipma.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UmowyWspółpracy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataZawarciaKontraktu = table.Column<DateOnly>(type: "date", nullable: false),
                    ZakresPowierzonychZadań = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KlauzulaPoufności = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UmowyWspółpracy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EksperciIpma",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RokUkończeniaSzkoleńPeb = table.Column<int>(type: "int", nullable: false),
                    StatusDostępności = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagaKonfliktuInteresów = table.Column<bool>(type: "bit", nullable: false),
                    DaneOsobowe_Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaneOsobowe_Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaneOsobowe_AdresEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaneOsobowe_NrTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UmowaWspółpracyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EksperciIpma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EksperciIpma_UmowyWspółpracy_UmowaWspółpracyId",
                        column: x => x.UmowaWspółpracyId,
                        principalTable: "UmowyWspółpracy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KontoUżytkownika",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hasło = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusKonta = table.Column<bool>(type: "bit", nullable: false),
                    Rola = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    StatusCzłonkaIpma = table.Column<bool>(type: "bit", nullable: true),
                    Organizacja_NazwaOrganizacji = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organizacja_NumerNip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organizacja_SkrótNazwyOrganizacji = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organizacja_KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaneOsobowe_Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaneOsobowe_Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaneOsobowe_AdresEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaneOsobowe_NrTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagaUprawnieńZarządczych = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkspertIpmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AfiliacjaNaukowaLubBiznesowa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaneOsobowe_Imie1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaneOsobowe_Nazwisko1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaneOsobowe_AdresEmail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaneOsobowe_NrTelefonu1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontoUżytkownika", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KontoUżytkownika_EksperciIpma_EkspertIpmaId",
                        column: x => x.EkspertIpmaId,
                        principalTable: "EksperciIpma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EdycjeKonkursu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RokKalendarzowy = table.Column<int>(type: "int", nullable: false),
                    StatusRealizacji = table.Column<int>(type: "int", nullable: false),
                    NumerEdycji = table.Column<int>(type: "int", nullable: false),
                    PrzewodniczącyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdycjeKonkursu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdycjeKonkursu_KontoUżytkownika_PrzewodniczącyId",
                        column: x => x.PrzewodniczącyId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BiuraNagrody",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdresKorespondencyjny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdycjaKonkursuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiuraNagrody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiuraNagrody_EdycjeKonkursu_EdycjaKonkursuId",
                        column: x => x.EdycjaKonkursuId,
                        principalTable: "EdycjeKonkursu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CzłonekJuryEdycjaKonkursu",
                columns: table => new
                {
                    CzłonkowieJuryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OcenianeKonkursyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CzłonekJuryEdycjaKonkursu", x => new { x.CzłonkowieJuryId, x.OcenianeKonkursyId });
                    table.ForeignKey(
                        name: "FK_CzłonekJuryEdycjaKonkursu_EdycjeKonkursu_OcenianeKonkursyId",
                        column: x => x.OcenianeKonkursyId,
                        principalTable: "EdycjeKonkursu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CzłonekJuryEdycjaKonkursu_KontoUżytkownika_CzłonkowieJuryId",
                        column: x => x.CzłonkowieJuryId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EdycjaKonkursuKategoria",
                columns: table => new
                {
                    EdycjeKonkursuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KategorieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdycjaKonkursuKategoria", x => new { x.EdycjeKonkursuId, x.KategorieId });
                    table.ForeignKey(
                        name: "FK_EdycjaKonkursuKategoria_EdycjeKonkursu_EdycjeKonkursuId",
                        column: x => x.EdycjeKonkursuId,
                        principalTable: "EdycjeKonkursu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EdycjaKonkursuKategoria_Kategorie_KategorieId",
                        column: x => x.KategorieId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Harmonogramy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataOtwarciaAplikacji = table.Column<DateOnly>(type: "date", nullable: false),
                    DataZamknięciaAplikacji = table.Column<DateOnly>(type: "date", nullable: false),
                    TerminWizytStudyjnych = table.Column<DateOnly>(type: "date", nullable: false),
                    DataGaliFinałowej = table.Column<DateOnly>(type: "date", nullable: false),
                    DataWebinariumAplikantow = table.Column<DateOnly>(type: "date", nullable: false),
                    DataWebinariumAsesorow = table.Column<DateOnly>(type: "date", nullable: false),
                    DataWebinariumAsesorowWiodacych = table.Column<DateOnly>(type: "date", nullable: false),
                    DataPierwszegoPosiedzeniaJury = table.Column<DateOnly>(type: "date", nullable: false),
                    DataDrugiegoPosiedzeniaJury = table.Column<DateOnly>(type: "date", nullable: false),
                    EdycjaKonkursuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harmonogramy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Harmonogramy_EdycjeKonkursu_EdycjaKonkursuId",
                        column: x => x.EdycjaKonkursuId,
                        principalTable: "EdycjeKonkursu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projekty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazwaPrzedsięwzięcia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzasTrwaniaWMiesiącach = table.Column<int>(type: "int", nullable: false),
                    WielkośćZespołu = table.Column<int>(type: "int", nullable: false),
                    LiczbaPodwykonawców = table.Column<int>(type: "int", nullable: false),
                    DataUkończenia = table.Column<DateOnly>(type: "date", nullable: false),
                    StanKwalifikacji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiejsceWizytyStudyjnej = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriaWyróżnienia = table.Column<int>(type: "int", nullable: false),
                    ŚredniaOcenaCzłonkówJury = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AplikantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AsesorWiodącyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EdycjaKonkursuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UtworzonyPrzezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZmodyfikowanyPrzezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projekty_EdycjeKonkursu_EdycjaKonkursuId",
                        column: x => x.EdycjaKonkursuId,
                        principalTable: "EdycjeKonkursu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projekty_Kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategorie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projekty_KontoUżytkownika_AplikantId",
                        column: x => x.AplikantId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projekty_KontoUżytkownika_AsesorWiodącyId",
                        column: x => x.AsesorWiodącyId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projekty_KontoUżytkownika_UtworzonyPrzezId",
                        column: x => x.UtworzonyPrzezId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projekty_KontoUżytkownika_ZmodyfikowanyPrzezId",
                        column: x => x.ZmodyfikowanyPrzezId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OcenyIndywidualne",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CzyZatwierdzona = table.Column<bool>(type: "bit", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AsesorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    WynikObszarLudzieICel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarProcesyIZasoby = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarRezultaty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UzasadnienieOceniajacego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanowanaDataOpracowania = table.Column<DateOnly>(type: "date", nullable: false),
                    CzyOcenaSpozniona = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcenyIndywidualne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcenyIndywidualne_KontoUżytkownika_AsesorId",
                        column: x => x.AsesorId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OcenyIndywidualne_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OcenyKońcowe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RekomendacjaFinałowa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OstatecznaNotaPunktowa = table.Column<double>(type: "float", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    WynikObszarLudzieICel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarProcesyIZasoby = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarRezultaty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UzasadnienieOceniajacego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanowanaDataOpracowania = table.Column<DateOnly>(type: "date", nullable: false),
                    CzyOcenaSpozniona = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcenyKońcowe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcenyKońcowe_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OcenyWstępne",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkonsolidowanyWynikPunktowy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CzyOsiągniętoKonsensus = table.Column<bool>(type: "bit", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    WynikObszarLudzieICel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarProcesyIZasoby = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarRezultaty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UzasadnienieOceniajacego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanowanaDataOpracowania = table.Column<DateOnly>(type: "date", nullable: false),
                    CzyOcenaSpozniona = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcenyWstępne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcenyWstępne_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PytanieOdJury",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Treść = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PytanieOdJury", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PytanieOdJury_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaportyAplikacyjne",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WykazZałączników = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDostarczeniaFizycznego = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UtworzonyPrzezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZmodyfikowanyPrzezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaportyAplikacyjne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaportyAplikacyjne_KontoUżytkownika_UtworzonyPrzezId",
                        column: x => x.UtworzonyPrzezId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaportyAplikacyjne_KontoUżytkownika_ZmodyfikowanyPrzezId",
                        column: x => x.ZmodyfikowanyPrzezId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaportyAplikacyjne_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaportyZWizyty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KatalogOdpowiedziDlaJury = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataZłożeniaDokumentu = table.Column<DateOnly>(type: "date", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UtworzonyPrzezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZmodyfikowanyPrzezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaportyZWizyty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaportyZWizyty_KontoUżytkownika_UtworzonyPrzezId",
                        column: x => x.UtworzonyPrzezId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaportyZWizyty_KontoUżytkownika_ZmodyfikowanyPrzezId",
                        column: x => x.ZmodyfikowanyPrzezId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaportyZWizyty_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WnioskiAplikacyjne",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataWprowadzeniaDoSystemu = table.Column<DateOnly>(type: "date", nullable: false),
                    FlagaZgodnościFormalnej = table.Column<bool>(type: "bit", nullable: false),
                    PowódOdrzucenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerAplikacji = table.Column<int>(type: "int", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UtworzonyPrzezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZmodyfikowanyPrzezId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WnioskiAplikacyjne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WnioskiAplikacyjne_KontoUżytkownika_UtworzonyPrzezId",
                        column: x => x.UtworzonyPrzezId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WnioskiAplikacyjne_KontoUżytkownika_ZmodyfikowanyPrzezId",
                        column: x => x.ZmodyfikowanyPrzezId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WnioskiAplikacyjne_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpłatyZgłoszeniowe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KwotaDoZapłatyNetto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataRejestracjiWpłaty = table.Column<DateOnly>(type: "date", nullable: false),
                    StatusTransakcji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WniosekAplikacyjnyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpłatyZgłoszeniowe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpłatyZgłoszeniowe_WnioskiAplikacyjne_WniosekAplikacyjnyId",
                        column: x => x.WniosekAplikacyjnyId,
                        principalTable: "WnioskiAplikacyjne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiuraNagrody_EdycjaKonkursuId",
                table: "BiuraNagrody",
                column: "EdycjaKonkursuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CzłonekJuryEdycjaKonkursu_OcenianeKonkursyId",
                table: "CzłonekJuryEdycjaKonkursu",
                column: "OcenianeKonkursyId");

            migrationBuilder.CreateIndex(
                name: "IX_EdycjaKonkursuKategoria_KategorieId",
                table: "EdycjaKonkursuKategoria",
                column: "KategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_EdycjeKonkursu_PrzewodniczącyId",
                table: "EdycjeKonkursu",
                column: "PrzewodniczącyId");

            migrationBuilder.CreateIndex(
                name: "IX_EksperciIpma_UmowaWspółpracyId",
                table: "EksperciIpma",
                column: "UmowaWspółpracyId",
                unique: true,
                filter: "[UmowaWspółpracyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Harmonogramy_EdycjaKonkursuId",
                table: "Harmonogramy",
                column: "EdycjaKonkursuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KontoUżytkownika_EkspertIpmaId",
                table: "KontoUżytkownika",
                column: "EkspertIpmaId",
                unique: true,
                filter: "[EkspertIpmaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OcenyIndywidualne_AsesorId",
                table: "OcenyIndywidualne",
                column: "AsesorId");

            migrationBuilder.CreateIndex(
                name: "IX_OcenyIndywidualne_ProjektId",
                table: "OcenyIndywidualne",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_OcenyKońcowe_ProjektId",
                table: "OcenyKońcowe",
                column: "ProjektId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OcenyWstępne_ProjektId",
                table: "OcenyWstępne",
                column: "ProjektId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpłatyZgłoszeniowe_WniosekAplikacyjnyId",
                table: "OpłatyZgłoszeniowe",
                column: "WniosekAplikacyjnyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_AplikantId",
                table: "Projekty",
                column: "AplikantId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_AsesorWiodącyId",
                table: "Projekty",
                column: "AsesorWiodącyId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_EdycjaKonkursuId",
                table: "Projekty",
                column: "EdycjaKonkursuId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_KategoriaId",
                table: "Projekty",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_UtworzonyPrzezId",
                table: "Projekty",
                column: "UtworzonyPrzezId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekty_ZmodyfikowanyPrzezId",
                table: "Projekty",
                column: "ZmodyfikowanyPrzezId");

            migrationBuilder.CreateIndex(
                name: "IX_PytanieOdJury_ProjektId",
                table: "PytanieOdJury",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_RaportyAplikacyjne_ProjektId",
                table: "RaportyAplikacyjne",
                column: "ProjektId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RaportyAplikacyjne_UtworzonyPrzezId",
                table: "RaportyAplikacyjne",
                column: "UtworzonyPrzezId");

            migrationBuilder.CreateIndex(
                name: "IX_RaportyAplikacyjne_ZmodyfikowanyPrzezId",
                table: "RaportyAplikacyjne",
                column: "ZmodyfikowanyPrzezId");

            migrationBuilder.CreateIndex(
                name: "IX_RaportyZWizyty_ProjektId",
                table: "RaportyZWizyty",
                column: "ProjektId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RaportyZWizyty_UtworzonyPrzezId",
                table: "RaportyZWizyty",
                column: "UtworzonyPrzezId");

            migrationBuilder.CreateIndex(
                name: "IX_RaportyZWizyty_ZmodyfikowanyPrzezId",
                table: "RaportyZWizyty",
                column: "ZmodyfikowanyPrzezId");

            migrationBuilder.CreateIndex(
                name: "IX_WnioskiAplikacyjne_ProjektId",
                table: "WnioskiAplikacyjne",
                column: "ProjektId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WnioskiAplikacyjne_UtworzonyPrzezId",
                table: "WnioskiAplikacyjne",
                column: "UtworzonyPrzezId");

            migrationBuilder.CreateIndex(
                name: "IX_WnioskiAplikacyjne_ZmodyfikowanyPrzezId",
                table: "WnioskiAplikacyjne",
                column: "ZmodyfikowanyPrzezId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiuraNagrody");

            migrationBuilder.DropTable(
                name: "CzłonekJuryEdycjaKonkursu");

            migrationBuilder.DropTable(
                name: "EdycjaKonkursuKategoria");

            migrationBuilder.DropTable(
                name: "Harmonogramy");

            migrationBuilder.DropTable(
                name: "OcenyIndywidualne");

            migrationBuilder.DropTable(
                name: "OcenyKońcowe");

            migrationBuilder.DropTable(
                name: "OcenyWstępne");

            migrationBuilder.DropTable(
                name: "OpłatyZgłoszeniowe");

            migrationBuilder.DropTable(
                name: "PytanieOdJury");

            migrationBuilder.DropTable(
                name: "RaportyAplikacyjne");

            migrationBuilder.DropTable(
                name: "RaportyZWizyty");

            migrationBuilder.DropTable(
                name: "WnioskiAplikacyjne");

            migrationBuilder.DropTable(
                name: "Projekty");

            migrationBuilder.DropTable(
                name: "EdycjeKonkursu");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "KontoUżytkownika");

            migrationBuilder.DropTable(
                name: "EksperciIpma");

            migrationBuilder.DropTable(
                name: "UmowyWspółpracy");
        }
    }
}
