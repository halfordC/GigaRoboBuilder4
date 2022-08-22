using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GigaRoboBuilder4.Data.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pilot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Heart = table.Column<int>(type: "INTEGER", nullable: false),
                    Rage = table.Column<int>(type: "INTEGER", nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxFightingSpirit = table.Column<int>(type: "INTEGER", nullable: false),
                    MainImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PilotAbility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Rules = table.Column<string>(type: "TEXT", nullable: false),
                    MainArtImage = table.Column<string>(type: "TEXT", nullable: false),
                    LogoImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotAbility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Robot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxArmour = table.Column<int>(type: "INTEGER", nullable: false),
                    Defence = table.Column<int>(type: "INTEGER", nullable: false),
                    MainImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Build",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ChosenRobotId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChosenPilotId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChosenPilotAbilityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Build", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Build_Pilot_ChosenPilotId",
                        column: x => x.ChosenPilotId,
                        principalTable: "Pilot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Build_PilotAbility_ChosenPilotAbilityId",
                        column: x => x.ChosenPilotAbilityId,
                        principalTable: "PilotAbility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Build_Robot_ChosenRobotId",
                        column: x => x.ChosenRobotId,
                        principalTable: "Robot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PilotCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false),
                    Cooldown = table.Column<int>(type: "INTEGER", nullable: false),
                    MinRange = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxRange = table.Column<int>(type: "INTEGER", nullable: false),
                    Requirements = table.Column<string>(type: "TEXT", nullable: false),
                    Rules = table.Column<string>(type: "TEXT", nullable: false),
                    MainArtImage = table.Column<string>(type: "TEXT", nullable: false),
                    CooldownImage = table.Column<string>(type: "TEXT", nullable: false),
                    DiceImage = table.Column<string>(type: "TEXT", nullable: false),
                    TypeImage = table.Column<string>(type: "TEXT", nullable: false),
                    LogoImage = table.Column<string>(type: "TEXT", nullable: false),
                    BuildId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PilotCard_Build_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Build",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RobotAbility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RobotId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Rules = table.Column<string>(type: "TEXT", nullable: false),
                    PowerTokens = table.Column<int>(type: "INTEGER", nullable: false),
                    LogoImage = table.Column<string>(type: "TEXT", nullable: false),
                    BuildId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotAbility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RobotAbility_Build_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Build",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RobotCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RobotId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false),
                    IsUltimate = table.Column<bool>(type: "INTEGER", nullable: false),
                    CardType = table.Column<string>(type: "TEXT", nullable: false),
                    SubType = table.Column<string>(type: "TEXT", nullable: false),
                    Cooldown = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    DamageString = table.Column<string>(type: "TEXT", nullable: false),
                    AttackDice = table.Column<int>(type: "INTEGER", nullable: false),
                    MinRange = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxRange = table.Column<int>(type: "INTEGER", nullable: false),
                    Requirements = table.Column<string>(type: "TEXT", nullable: false),
                    Rules = table.Column<string>(type: "TEXT", nullable: false),
                    MainArtImage = table.Column<string>(type: "TEXT", nullable: false),
                    CooldownImage = table.Column<string>(type: "TEXT", nullable: false),
                    DiceImage = table.Column<string>(type: "TEXT", nullable: false),
                    DamageImage = table.Column<string>(type: "TEXT", nullable: false),
                    TypeImage = table.Column<string>(type: "TEXT", nullable: false),
                    CounterImage = table.Column<string>(type: "TEXT", nullable: false),
                    ComboImage = table.Column<string>(type: "TEXT", nullable: false),
                    LogoImage = table.Column<string>(type: "TEXT", nullable: false),
                    BuildId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RobotCard_Build_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Build",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "Id", "Heart", "MainImage", "MaxFightingSpirit", "Name", "Power", "Rage" },
                values: new object[] { 1, 6, "", 40, "Hadrian Corto", 2, 5 });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "Id", "Heart", "MainImage", "MaxFightingSpirit", "Name", "Power", "Rage" },
                values: new object[] { 2, 4, "", 25, "Takashi Kato", 3, 8 });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "Id", "Heart", "MainImage", "MaxFightingSpirit", "Name", "Power", "Rage" },
                values: new object[] { 3, 6, "", 30, "Noriko Nagare", 2, 6 });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "Id", "Heart", "MainImage", "MaxFightingSpirit", "Name", "Power", "Rage" },
                values: new object[] { 4, 10, "", 45, "Dash", 1, 2 });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "Id", "Heart", "MainImage", "MaxFightingSpirit", "Name", "Power", "Rage" },
                values: new object[] { 5, 5, "", 20, "Kong of the Wastes", 1, 5 });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "Id", "Heart", "MainImage", "MaxFightingSpirit", "Name", "Power", "Rage" },
                values: new object[] { 6, -1, "", 25, "Med'racht Singh", 2, 8 });

            migrationBuilder.InsertData(
                table: "Pilot",
                columns: new[] { "Id", "Heart", "MainImage", "MaxFightingSpirit", "Name", "Power", "Rage" },
                values: new object[] { 7, 0, "", 20, "Terroch Arkan", 3, 5 });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 1, "", "", "Wasteland Mechanic", 1, "To survive, Hadrian will scrap weapons to gain the parts needed for repairs. If they are in your hand, you may remove 1/2 of of your total cards from the game to Trigger: Repair 1/4 of your robot’s Max Armor." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 2, "", "", "Improvise Through Sacrifice", 1, "Hadrian can retrofit any systems to adapt to combat. If they are in your hand, you may remove 4 of your cards from the game once to Trigger: Permanently gain Boost." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 3, "", "", "Wed to Steel", 1, "Hadrian’s cybernetics connect directly to his robot’s frame for unparalleled control. If they are in your hand, you may remove 4 of your cards from the game to Trigger: Permanently increase your Speed by 2, to a maximum of 9." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 4, "", "", "Think you can stop me!?", 2, "Takashi’s chosen robot only takes 1/2 damage from collisions." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 5, "", "", "Honorable Defeat", 2, "Even on the edge of destruction, Takashi’s tenacious spirit refuses to falter. You can only be defeated by an Attack or Effect that inflicts 4 or more damage at once." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 6, "", "", "Born to fight", 2, "Takashi’s close combat fighting skill results in his robot’s melee attacks dealing damage +1." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 7, "", "", "Bleeding Edge", 3, "Noriko can push her robot beyond its physical limits. At any time, she may permanently subtract Armor to gain an equivalent amount of Fighting Spirit." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 8, "", "", "Crusade", 3, "Noriko’s ferocious spirit can’t be contained. Her robot begins with only 3/4 of its total Armor, but her heart is permanently increased by 2." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 9, "", "", "Suicide Drive", 3, "Noriko sheds her robot’s defensive systems and puts everything into her attacks. Your robot’s Defense is permanently reduced to 0, but you always gain Power during your Upkeep." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 10, "", "", "Circuit Flow", 4, "Dash’s speed and reflexes are unmatched. Add +3 to all Recovery Roll results." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 11, "", "", "Combat Logic", 4, "Dash’s natural piloting ability reduces the cost of your Robot cards by 1 Fighting Spirit." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 12, "", "", "Righteous Spirit", 4, "Dash will do everything he can to avoid collateral damage. Any time an opponent forces you to collide with a structure, immediately increase his Rage by 3 until the end of the current turn." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 13, "", "", "Logistical Prowess", 5, "Kong gains 1 Power Token at the beginning of your turn. At the beginning of your turn you may pay 1 Fighting Spirit to place or move 1 Target Token to any unoccupied hex. Once per turn, you may spend 1 Power Token to Trigger: Move 1 card in your Cooldown Meter 1 slot." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 14, "", "", "Ultimate Price", 5, "Kong gains 1 Power Token at the beginning of your turn. At the beginning of your turn you may pay 1 Fighting Spirit to place or move 1 Target Token to any unoccupied hex. If your opponent is on a hex with a Target Token and you have played a successful attack, you may remove the Target Token from play to Trigger: Inflict +3 damage." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 15, "", "", "End The Cycle", 5, "Kong gains 1 Power Token at the beginning of your turn. At the beginning of your turn you may pay 1 Fighting Spirit to place or move 1 Target Token to any unoccupied hex. Once per turn, if you have not attacked by the end of your turn, gain 1 Power Token." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 16, "", "", "Righteous Fury", 6, "Singh's Heart is X, where X = the number of Power Tokens in your Power Token Control. On your opponent's Attacking turn, gain Rage every time your opponent successfully attacks you but does not inflict damage." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 17, "", "", "Zoider Honor", 6, "Singh's Heart is X, where X = the number of Power Tokens in your Power Token Control. Whenever your opponent successfully plays an Instant that affects your Attack, or Instant cards in play, gain 1/2 Rage." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 18, "", "", "Battle Hardened", 6, "Singh's Heart is X, where X = the number of Power Tokens in your Power Token Control. Permanently increase your Defense by 2." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 19, "", "", "Zoider Terroch", 7, "Terroch Arkan can gain Power Tokens as long as there is room in the Power Token Control, even if it exceeds the standard limit of 6. Once per turn you may spend X Power Tokens to increase your Fighting Spirit by X⋅3. You may play any one Robot card by spending 4 Power Tokens." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 20, "", "", "Power Control", 7, "Terroch Arkan can gain Power Tokens as long as there is room in the Power Token Control, even if it exceeds the standard limit of 6. Once per turn you may spend X Power Tokens to increase your Fighting Spirit by X⋅3. When you deactivate a robot ability, you immediately gain Power Tokens equal to that ability's cost -1." });

            migrationBuilder.InsertData(
                table: "PilotAbility",
                columns: new[] { "Id", "LogoImage", "MainArtImage", "Name", "PilotId", "Rules" },
                values: new object[] { 21, "", "", "Zoider Supremecy", 7, "Terroch Arkan can gain Power Tokens as long as there is room in the Power Token Control, even if it exceeds the standard limit of 6. Once per turn you may spend X Power Tokens to increase your Fighting Spirit by X⋅3. You gain +1 Power Token immediately after an opponent uses a Power Die or gains a Power Token." });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 1, null, 3, "Cooldown_Meter_3.png", 5, "", "Noriko_logo.png", "Break_Through.png", 0, 0, "BREAK THROUGH", 3, "Must be played in response to your opponent's successful Attack/Reactive Attack.", "X=the amount of Power Dice used by both you and your opponent. Reduce incoming damage by X.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 2, null, 3, "Cooldown_Meter_3.png", 6, "", "Noriko_logo.png", "Shield_Siphon.png", 2, 0, "SHIELD SIPHON", 3, "", "Destroy a Static Barrier within range, or an Active Barrier on an opponent within range, to Trigger: Create 1 Barrier.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 3, null, 3, "Cooldown_Meter_3.png", 2, "", "Noriko_logo.png", "Hijack.png", 0, 1, "HIJACK", 3, "", "Choose 1 card in your opponentâ€™s hand and place it into their Cooldown Meter, Deactivated. Your opponent may then do the same to you.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 4, null, 2, "Cooldown_Meter_2.png", 2, "", "Noriko_logo.png", "Pain_and_Gain.png", 0, 0, "PAIN AND GAIN", 3, "", "Until the end of this turn, Gain 1 Fighting Spirit per point of damage Inflicted to you, in addition to your Rage.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 5, null, 3, "Cooldown_Meter_3.png", 3, "", "Noriko_logo.png", "Power_Launch.png", 0, 0, "POWER LAUNCH", 3, "Must be played in response to your successful Attack/Reactive Attack.", "While resolving your Attack, you may Throw your opponent up to 2 hexes. If thereâ€™s another Forced Movement keyword in your Attackâ€™s Rules Text, ignore it.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 6, null, 3, "Cooldown_Meter_3.png", 2, "", "Noriko_logo.png", "Spear.png", 2, 1, "SPEAR", 3, "Must be played in response to your successful Attack/Reactive Attack.", "While resolving your Attack, you may Push your opponent +1 hex.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 7, null, 3, "Cooldown_Meter_3.png", 4, "", "Noriko_logo.png", "Reacquire_Target.png", 0, 0, "REACQUIRE TARGET", 3, "", "Re-roll your Attack Roll.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 8, null, 3, "Cooldown_Meter_3.png", 3, "", "Noriko_logo.png", "Counter_Chain.png", 0, 0, "COUNTER CHAIN", 3, "Does not affect Ultimate Techniques.", "Until the end of this turn, add the Counter Subtype to 1 Attack Card in your hand or in play.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 9, null, 3, "Cooldown_Meter_3.png", 3, "", "Noriko_logo.png", "Combo_Chain.png", 0, 0, "COMBO CHAIN", 3, "Does not affect Ultimate Techniques.", "Until the end of this turn, add the Combo Subtype to 1 Attack Card in your hand.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 10, null, 3, "Cooldown_Meter_3.png", 3, "", "Noriko_logo.png", "Counter_Breaker.png", 0, 0, "COUNTER BREAKER", 3, "", "Until the end of this turn, your opponent's Attack Card loses the Counter subtype.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 11, null, 3, "Cooldown_Meter_3.png", 4, "", "Dash_logo.png", "Open_Path.png", 0, 0, "OPEN PATH", 4, "Does not affect Ultimate Techniques.", "Choose 1 of your opponent's Attack Cards. Until the end of this turn, that card loses its Rules Text.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 12, null, 3, "Cooldown_Meter_3.png", 4, "", "Dash_logo.png", "Reflex_Edge.png", 0, 0, "REFLEX EDGE", 4, "", "Cancel your opponent's Instant.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 13, null, 2, "Cooldown_Meter_2.png", 3, "", "Dash_logo.png", "Reflex_Strike.png", 0, 0, "REFLEX STRIKE", 4, "Must be played before you begin resolving your Attack/Reactive Attack.", "Choose 1 of your unresolved Attack Cards and return it to your hand, then replace it with 1 Attack Card from your hand. Pay or Gain the difference in cost to the previous card.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 14, null, 3, "Cooldown_Meter_3.png", 2, "", "Dash_logo.png", "Spirit_Flare.png", 0, 0, "SPIRIT FLARE", 4, "", "On your next turn you cannot play any cards or resolve your Upkeep and Combat phases, and during that Cooldown Phase, only Trauma Tokens will decrease Cooldown Slots. On the Upkeep of your turn following that, Gain 30 Fighting Spirit instead of choosing Heart or Power.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 15, null, 3, "Cooldown_Meter_3.png", 0, "", "Dash_logo.png", "Spirit_Spark.png", 0, 0, "SPIRIT SPARK", 4, "", "Gain 3 Fighting Spirit.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 16, null, 3, "Cooldown_Meter_3.png", 3, "", "Dash_logo.png", "Target_Lock.png", 0, 0, "TARGET LOCK", 4, "", "Your current Attack's successes cannot be affected by Instants.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 17, null, 3, "Cooldown_Meter_3.png", 4, "", "Dash_logo.png", "Trauma_Flow.png", 1, 1, "TRAUMA FLOW", 4, "", "Perform a Recovery Roll. On a failure, X=1. On a success, X=3. Move X Tokens from your Cooldown Meter to the matching Cooldown Slots of your opponent's Cooldown Meter.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 18, null, 3, "Cooldown_Meter_3.png", 3, "", "Dash_logo.png", "Combat_Flow.png", 0, 0, "COMBAT FLOW", 4, "", "Choose X dice from your Attack Roll. Pay X to re-roll those dice.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 19, null, 3, "Cooldown_Meter_3.png", 1, "", "Dash_logo.png", "Power_Flow.png", 0, 0, "POWER FLOW", 4, "", "Choose X dice from your opponentâ€™s Attack Roll. Remove X Power Tokens from your Power Token Control to Trigger: Your opponent must re-roll those dice.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 20, null, 3, "Cooldown_Meter_3.png", 2, "", "Dash_logo.png", "Battle_Focus.png", 0, 0, "BATTLE FOCUS", 4, "Does not affect Ultimate Techniques.", "Choose 1 card from your successful Attack. X=its cost. Gain X Fighting Spirit.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 21, null, 1, "Cooldown_Meter_1.png", 0, "", "Arkan_logo.png", "Price_of_Power.png", 0, 0, "PRICE OF POWER", 7, "Must spend 4 Power Tokens to play this card.", "While this card is Activated, Your opponent must spend 1 Power Token to Gain Rage. If your opponent Gains Rage, Trigger: Gain 1 Power Token.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 22, null, 2, "Cooldown_Meter_2.png", 0, "", "Arkan_logo.png", "Soldiers_Folly.png", 0, 0, "SOLDIER'S FOLLY", 7, "Must spend 5 Power Tokens to play this card.", "While this card is Activated, X=your opponent's Rage. Your Heart=X.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 23, null, 2, "Cooldown_Meter_2.png", 0, "", "Arkan_logo.png", "Terrochs_Will.png", 0, 0, "TERROCH'S WILL", 7, "Must spend 3 Power Tokens to play this card.", "While this card is Activated, once per turn you may spend 1 Power Token to Trigger: Choose an opponent in an adjacent hex. Deactivate an Activated card in that opponent's Cooldown Meter.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 24, null, 3, "Cooldown_Meter_3.png", 0, "", "Arkan_logo.png", "Falter_and_Fail.png", 0, 0, "FALTER AND FAIL", 7, "Must spend 3 Power Tokens to play this card.", "Choose 1 card in your opponent's hand that is not an Ultimate Technique and place it into their Cooldown Meter, Deactivated.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 25, null, 3, "Cooldown_Meter_3.png", 0, "", "Arkan_logo.png", "Core_Strike.png", 0, 0, "CORE STRIKE", 7, "Must spend 1 Power Token to play this card. Must be played after you and your opponent have declared Attacks/Reactive Attacks.", "Add 1 power die to your Attack Roll. X=the lowest die result from your opponent's Attack or Defense Roll. If successful, your Attack Inflicts +X damage.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 26, null, 3, "Cooldown_Meter_3.png", 0, "", "Arkan_logo.png", "Core_Shot.png", 0, 0, "CORE SHOT", 7, "Must spend 1 Power Token to play this card. Must be played after you and your opponent have declared Attacks/Reactive Attacks.", "Add 1 power die to your Attack Roll. X=the lowest die result from your opponent's Attack or Defense Roll. If your Attack is successful, your opponent loses X Fighting Spirit.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 27, null, 3, "Cooldown_Meter_3.png", 0, "", "Arkan_logo.png", "Decimation.png", 0, 0, "DECIMATION", 7, "You may spend any amount of Power Tokens to play this card. X=That amount.", "Your opponent must perform X Recovery Rolls. Per failure, your opponent must choose 1 card in their Cooldown Meter that's not an Ultimate Technique and permanently remove it from the game. After this card resolves, remove it from the game.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 28, null, 3, "Cooldown_Meter_3.png", 0, "", "Arkan_logo.png", "Place_of_Power.png", 0, 0, "PLACE OF POWER", 7, "Must spend 2 Power Token to play this card.", "Increase 1 card in your Cooldown Meter to Cooldown Slot 3.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 29, null, 3, "Cooldown_Meter_3.png", 0, "", "Arkan_logo.png", "Terrochs_Control.png", 0, 0, "TERROCH'S CONTROL", 7, "Must spend 2 Power Tokens to play this card.", "Return 1 card from your Cooldown Meter to your hand.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 30, null, 3, "Cooldown_Meter_3.png", 0, "", "Arkan_logo.png", "Spear_of_the_Armada.png", 0, 0, "SPEAR OF THE ARMADA", 7, "Must spend 6 Power Tokens to play this card. Must be played while you are the Active Player.", "Take an extra turn after this one.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 31, null, 3, "Cooldown_Meter_3.png", 3, "", "Takashi_logo.png", "All_Fired_Up.png", 0, 0, "ALL FIRED UP", 2, "", "X=the Fire in your Cooldown Meter. While this card is Activated, Gain X Fighting Spirit at the beginning of your Upkeep.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 32, null, 3, "Cooldown_Meter_3.png", 2, "", "Takashi_logo.png", "Hit_For_Hit.png", 0, 0, "HIT FOR HIT", 2, "", "Choose X dice from your Attack roll and re-roll them. If your opponent is able, they may also re-roll X dice from their Attack roll.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 33, null, 3, "Cooldown_Meter_3.png", 3, "", "Takashi_logo.png", "Head_On.png", 0, 0, "HEAD ON", 2, "You must be the Target of an Attack. Does not affect Ultimate Techniques.", "Your opponent's Attack is automatically successful and is considered to have 2 successes. If you would Gain Rage, Gain Rage twice instead of once.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 34, null, 3, "Cooldown_Meter_3.png", 4, "", "Takashi_logo.png", "Never_Back_Down.png", 0, 0, "NEVER BACK DOWN", 2, "", "Until the end of this turn, you cannot be Forcefully Moved.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 35, null, 3, "Cooldown_Meter_3.png", 3, "", "Takashi_logo.png", "Hot_Blooded.png", 0, 0, "HOT-BLOODED", 2, "", "Until the end of this turn, reduce the cost of your Attack Cards by 2. Until the end of your opponent's next turn, your Defense is reduced to 0.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 36, null, 3, "Cooldown_Meter_3.png", 3, "", "Takashi_logo.png", "Channel_Rage.png", 0, 0, "CHANNEL RAGE", 2, "Must be played in response to your opponent's successful Attack/Reactive Attack.", "X=your Rage. Do not Gain Rage from your opponent's successful Attack. Your next Attack Inflicts damage+X if successful.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 37, null, 3, "Cooldown_Meter_3.png", 3, "", "Takashi_logo.png", "Channel_Spirit.png", 0, 0, "CHANNEL SPIRIT", 2, "", "Spend X Power Tokens to Trigger: Roll X Power Dice. The combined total you roll=Y. Gain Yâ‹…1/2 Fighting Spirit.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 38, null, 3, "Cooldown_Meter_3.png", 1, "", "Takashi_logo.png", "Critical_Aim.png", 0, 0, "CRITICAL AIM", 2, "", "You or your opponent must re-roll 1 Die of your choosing.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 39, null, 3, "Cooldown_Meter_3.png", 5, "", "Takashi_logo.png", "Unstoppable.png", 0, 0, "UNSTOPPABLE", 2, "Must be played in response to your opponent's successful Attack/Reactive Attack.", "X=the amount of Power Dice used for your successful Attack or Defense Roll. Gain Xâ‹…1/2 Power Tokens.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 40, null, 3, "Cooldown_Meter_3.png", 1, "", "Takashi_logo.png", "High_Stakes.png", 0, 0, "HIGH STAKES", 2, "Does not affect Ultimate Techniques.", "Perform a Recovery Roll. On a success, you may play 1 Instant for free. On a failure, you must place 1 Instant into your Cooldown Meter, Deactivated.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 41, null, 3, "Cooldown_Meter_3.png", 4, "", "Hadrian_logo.png", "Reboot.png", 0, 0, "REBOOT", 1, "", "On your next turn you cannot play cards, resolve your Upkeep and Combat phases, and only Trauma Tokens will advance during your Cooldown phase. At the beginning of the following turn, remove all cards and tokens from your Cooldown Meter.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 42, null, 3, "Cooldown_Meter_3.png", 6, "", "Hadrian_logo.png", "Neural_Link_Disrupt.png", 0, 0, "NEURAL LINK DISRUPT", 1, "Does not affect Ultimate Techniques. Must be played IN RESPONSE TO YOUR opponent declarING THEIR Attack/Reactive Attack.", "Your opponent must return the cards comprising their unresolved Attack to their hand, then randomly choose and play a new Attack Card that they can legally play. They must pay or Gain the difference in cost to the previous card.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 43, null, 3, "Cooldown_Meter_3.png", 6, "", "Hadrian_logo.png", "Backfire.png", 0, 0, "BACKFIRE", 1, "Does not affect Ultimate Techniques. Must be played in response to your opponent's successful Ranged Attack.", "Your opponent must perform a Recovery Roll. On a failure, ignore their Ranged Attackâ€™s Rules Text and damage. It must enter their Cooldown Meter Deactivated.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 44, null, 3, "Cooldown_Meter_3.png", 4, "", "Hadrian_logo.png", "Deflector_Wave.png", 0, 0, "DEFLECTOR WAVE", 1, "", "Choose your or your opponent's Attack Card. That card is immune to Instants this turn.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 45, null, 3, "Cooldown_Meter_3.png", 4, "", "Hadrian_logo.png", "Rechamber.png", 0, 0, "RE-CHAMBER", 1, "", "Choose 1 card in your Cooldown Meter and return it to your hand. Choose 1 card in your hand and place it into your Cooldown Meter, Activated.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 46, null, 3, "Cooldown_Meter_3.png", 2, "", "Hadrian_logo.png", "Reengage.png", 0, 0, "RE-ENGAGE", 1, "", "Place any amount of cards from your hand into your Cooldown Meter, Deactivated. Their combined cost=X. You may play any card in your hand whose cost is X or less, and is not an Ultimate Technique, for free.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 47, null, 3, "Cooldown_Meter_3.png", 1, "", "Hadrian_logo.png", "Surge_Shield.png", 0, 0, "SURGE SHIELD", 1, "", "Pay 2â‹…X to Trigger: Remove X Power Surges from your Cooldown Meter.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 48, null, 3, "Cooldown_Meter_3.png", 1, "", "Hadrian_logo.png", "Nerves_of_Steel.png", 0, 0, "NERVES OF STEEL", 1, "", "Pay 2â‹…X to Trigger: Remove X Panic from your Cooldown Meter.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 49, null, 3, "Cooldown_Meter_3.png", 1, "", "Hadrian_logo.png", "Fire_Control.png", 0, 0, "FIRE CONTROL", 1, "", "Pay 2â‹…X to Trigger: Remove X Fire from your Cooldown Meter.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 50, null, 3, "Cooldown_Meter_3.png", 3, "", "Hadrian_logo.png", "Tachyon_Emitter.png", 0, 0, "TACHYON EMITTER", 1, "", "Until the end of this turn, your opponent cannot play Attack cards with the Counter Subtype.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 51, null, 3, "Cooldown_Meter_3.png", 2, "", "Kong_logo.png", "Fear.png", 0, 0, "FEAR", 5, "", "Until the end of this turn, whenever your opponent Gains Rage, Trigger: Inflict 1 Panic to your opponent.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 52, null, 3, "Cooldown_Meter_3.png", 1, "", "Kong_logo.png", "Sabotage.png", 0, 0, "SABOTAGE", 5, "", "When this card is Activated, place 1 Target Token on any Structure's hex. When this card returns to your hand, Destroy 1 Targeted Structure and remove the Target Token from play.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 53, null, 3, "Cooldown_Meter_3.png", 3, "", "Kong_logo.png", "Intimidation.png", 0, 0, "INTIMIDATION", 5, "Does not affect Ultimate Techniques. Must be played in response to your opponent declaring an Attack/Reactive Attack.", "X=your opponent's Attack's cost. Your opponent must pay an additional X in order to play the Attack this turn. If the additional cost isn't paid, your opponent must return all of the cards comprising the Attack to their hand, regain the Fighting Spirit paid to play the Attack, and they cannot play those cards until the end of their turn.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 54, null, 3, "Cooldown_Meter_3.png", 3, "", "Kong_logo.png", "Improvised_Offense.png", 0, 0, "IMPROVISED OFFENSE", 5, "", "While Activated, while you're on or adjacent to Rubble, your Melee Attacks Inflict damage +2.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 55, null, 3, "Cooldown_Meter_3.png", 3, "", "Kong_logo.png", "Scorched_Earth.png", 0, 0, "SCORCHED EARTH", 5, "", "When this card is Activated, place a Target Token on any unoccupied hex. When this card returns to your hand, create 1 Inferno on any 1 Targeted hex, and Inflict 1 Fire to all adjacent hexes. Remove the Target Token from play.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 56, null, 3, "Cooldown_Meter_3.png", 2, "", "Kong_logo.png", "Supply_Drop.png", 0, 0, "SUPPLY DROP", 5, "", "If you're on a hex with a Target Token, you may remove the Target Token from play to Trigger: Gain 3 Armor.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 57, null, 3, "Cooldown_Meter_3.png", 2, "", "Kong_logo.png", "Giga_Amp.png", 0, 0, "GIGA AMP", 5, "", "If you're on a hex with a Target Token, you may remove the Target Token from play to Trigger: Gain 1 Power Token.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 58, null, 3, "Cooldown_Meter_3.png", 2, "", "Kong_logo.png", "Guerilla_Tactics.png", 0, 0, "GUERRILLA TACTICS", 5, "", "Activate any 1 Deactivated card in your Cooldown Meter.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 59, null, 2, "Cooldown_Meter_2.png", 1, "", "Kong_logo.png", "Dogs_of_War.png", 0, 0, "DOGS OF WAR", 5, "", "When this card is Activated, place a Target Token on any unoccupied hex. When this card returns to your hand, Inflict 3 damage to any 1 Targeted hex. Remove the Target Token from play.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 60, null, 3, "Cooldown_Meter_3.png", 3, "", "Kong_logo.png", "Hacked_Technique.png", 0, 0, "HACKED TECHNIQUE", 5, "Does not affect Ultimate Techniques.", "Choose 1 Attack Card from your opponent's hand or Cooldown Meter. X=its Rules Text. Replace the Rules Text of 1 card in your next Attack with X.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 61, null, 3, "Cooldown_Meter_3.png", 3, "", "Singh_logo.png", "Shield_of_the_Insurrection.png", 0, 0, "SHIELD OF THE INSURRECTION", 6, "Must be played in response to your successful Reactive Attack.", "X=Your Reactive Attack's successes. Gain X Power Tokens.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 62, null, 3, "Cooldown_Meter_3.png", 3, "", "Singh_logo.png", "Bulwark.png", 0, 0, "BULWARK", 6, "Must be played in response to your successful Reactive Attack.", "X=Your Reactive Attack's successes. Increase your robot's Defense by X, to a maximum of 5, until the end of this turn.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 63, null, 2, "Cooldown_Meter_2.png", 3, "", "Singh_logo.png", "Perfect_Defense.png", 0, 0, "PERFECT DEFENSE", 6, "Must be played in response to declaring a Reactive Attack.", "You may add your Robot's Defense dice to your Attack Roll, treating each one as a 10-sided Attack die.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 64, null, 3, "Cooldown_Meter_3.png", 8, "", "Singh_logo.png", "Iron_Carapace.png", 0, 0, "IRON CARAPACE", 6, "Does not affect Ultimate Techniques.", "Perform a Recovery Roll. On a Success, Cancel your opponent's Attack Card.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 65, null, 3, "Cooldown_Meter_3.png", 3, "", "Singh_logo.png", "Tactical_Instinct.png", 0, 0, "TACTICAL INSTINCT", 6, "Must be played after you and your opponent have declared Attacks/Reactive Attacks.", "If your opponent's Attack Card has the Counter subtype, Trigger: Your opponent's Attack Card loses the Counter subtype until it enters their Cooldown Meter. Your Attack Card Gains the Counter subtype, whether you are Attacking or Reactive Attacking.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 66, null, 3, "Cooldown_Meter_3.png", 2, "", "Singh_logo.png", "Roar_of_the_Armada.png", 0, 0, "ROAR OF THE ARMADA", 6, "", "Pay this card's Fighting Spirit cost + X. Perform X Recovery Rolls. Per Success, choose and Deactivate 1 Card in your opponent's Cooldown Meter.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 67, null, 3, "Cooldown_Meter_3.png", 3, "", "Singh_logo.png", "Interceptor.png", 0, 0, "INTERCEPTOR", 6, "Must be played in response to your opponent declaring an Attack/Reactive Attack.", "Choose 1 Ranged Attack in your hand and place it into your Cooldown Meter, Deactivated. X=its Attack Die Value. Your opponent must perform X Recovery Rolls. Per failure, they must remove 1 Attack Die from their Attack Roll.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 68, null, 3, "Cooldown_Meter_3.png", 0, "", "Singh_logo.png", "Fractured_Offense.png", 0, 0, "FRACTURED OFFENSE", 6, "Must be played in response to your successful Attack Roll.", "X=the amount of Power Dice used in your Attack Roll. Perform X Recovery Rolls. Per Success, increase the amount of damage Inflicted to your opponent by 1.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 69, null, 3, "Cooldown_Meter_3.png", 3, "", "Singh_logo.png", "Medrachts_Might.png", 0, 0, "MED'RACHT'S MIGHT", 6, "Add this card's Rules Text to the Rules Text of your unresolved Attack Card.", "Your opponent does not collect Rage or Power from your successful Attack.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "PilotCard",
                columns: new[] { "Id", "BuildId", "Cooldown", "CooldownImage", "Cost", "DiceImage", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "PilotId", "Requirements", "Rules", "Type", "TypeImage" },
                values: new object[] { 70, null, 2, "Cooldown_Meter_2.png", 2, "", "Singh_logo.png", "Blood_of_the_Armada.png", 0, 0, "BLOOD OF THE ARMADA", 6, "", "Pay this card's Fighting Spirit cost + X. Perform X Recovery Rolls. Per Success, your opponent loses 1 Power Token.", "INSTANT", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "Robot",
                columns: new[] { "Id", "Defence", "MainImage", "MaxArmour", "Name", "Speed" },
                values: new object[] { 1, 2, "holder", 40, "AYZN", 4 });

            migrationBuilder.InsertData(
                table: "Robot",
                columns: new[] { "Id", "Defence", "MainImage", "MaxArmour", "Name", "Speed" },
                values: new object[] { 2, 1, "holder", 40, "CHOGOKING", 5 });

            migrationBuilder.InsertData(
                table: "Robot",
                columns: new[] { "Id", "Defence", "MainImage", "MaxArmour", "Name", "Speed" },
                values: new object[] { 3, 2, "holder", 30, "DAI-RAIJIN V", 7 });

            migrationBuilder.InsertData(
                table: "Robot",
                columns: new[] { "Id", "Defence", "MainImage", "MaxArmour", "Name", "Speed" },
                values: new object[] { 4, 1, "holder", 45, "O-GUN", 5 });

            migrationBuilder.InsertData(
                table: "Robot",
                columns: new[] { "Id", "Defence", "MainImage", "MaxArmour", "Name", "Speed" },
                values: new object[] { 5, 2, "holder", 35, "SHINOKAMI", 5 });

            migrationBuilder.InsertData(
                table: "Robot",
                columns: new[] { "Id", "Defence", "MainImage", "MaxArmour", "Name", "Speed" },
                values: new object[] { 6, 1, "holder", 35, "ASCALON ALPHA", 6 });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 1, null, "", "Iron Fusion Stage 1!", 1, 1, "Decrease all attack damage received by 1 while activated." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 2, null, "", "Iron Fusion Stage 2!", 2, 1, "(Iron Fusion Stage 1! must be activated) Inflict damage +1 while activated." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 3, null, "", "Iron Fusion Stage 3 - Ayzn Black!", 3, 1, "(Iron Fusion Stage 2! must be activated) Increase attack roll results by 1 while activated." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 4, null, "", "Detonator Overload", 2, 1, "While Activated, if your Melee Attack card was successful, you may permanently remove it from the game to Trigger: You may spend X Power Dice to add +X damage to this attack." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 5, null, "", "Titan's Stride", 1, 1, "While Activated, when you spend your movement, you move through and destroy Structures by receiving 2 Damage. You must always end your movement past the Structure’s hex. Do not resolve the Impact Rules on Impact Cards drawn for Structures destroyed this way." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 6, null, "", "Iron Fusion Override", 0, 1, "You may receive 1 Fire to Trigger: You may play any “Ayzn Black” cards without having “Iron Fusion Stage 3-Ayzn Black” Activated, until the end of this turn." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 7, null, "", "Thunder Clap", 0, 3, "Pay 2 Fighting Spirit to move a Power Surge from your Cooldown Meter to this Ability. Remove Six Power Surges on this ability to Trigger: You may play any 1 card for free." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 8, null, "", "Ion Shield", 0, 3, "Remove 3 Power Surges from your Cooldown Meter to Trigger: Create 1 Barrier." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 9, null, "", "Double Dagger", 3, 3, "While Activated, you may re-roll your unsuccessful Melee attack rolls once." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 10, null, "", "Storm of Strikes", 2, 3, "WHILE ACTIVATED, YOU MAY REMOVE 1 POWER SURGE FROM YOUR \nCOOLDOWN METER DURING ANY OPPONENT’S COOLDOWN PHASE TO \nTRIGGER: DECREASE your COMBO CARDs BY 1 cooldown slot." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 11, null, "", "Arc Wing", 1, 3, "While Activated, gain Boost." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 12, null, "", "Ion Exhaust", 0, 3, "Spend 2 Power Token to Trigger: Remove all Power Surges from your Cooldown Meter." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 13, null, "", "Chogoking Sabre", 2, 2, "While Activated, Increase the Maximum Range of your Melee Attacks by 1." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 14, null, "", "Phoenix Wing Reborn", 0, 2, "If “Chogoking Sabre” is Activated, you may Deactivate it to Trigger: Gain Boost until the end of this turn." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 15, null, "", "Blazing Aegis", 3, 2, "While Activated, if you are adjacent to an opponent at the end of their turn, Trigger: Inflict 1 Fire to all Adjacent opponents" });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 16, null, "", "Trace Burn", 1, 2, "While Activated, whenever you receive Fire, increase the amount by 1." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 17, null, "", "Aegis Fire", 2, 2, "While Activated, increase your Defense by 1." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 18, null, "", "Magma Breach", 2, 2, "While Activated, gain 1 Power Token whenever you receive Fire damage" });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 19, null, "", "Anchor Shield", 0, 4, "When damage is Inflicted to you, you may pay 2 Fighting Spirit to place any 1 card that inflicts Anchors into Cooldown, Deactivated, to Trigger: Reduce Inflicted by 3." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 20, null, "", "Burst Anchor", 0, 4, "While you are the Active Player, whenever you are adjacent to an Anchored  hex, you may PAY 3 Power Tokens to Trigger: LEAP to any hex adjacent to any Anchored hex." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 21, null, "", "Star Spanner Sacrifice", 0, 4, "If “Star Spanner” is Activated, you may Deactivate it  and pay X Fighting Spirit to \nTrigger: reduce damage inflicted to you by your Opponent’s Ranged Attack by X." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 22, null, "", "Star Spanner", 1, 4, "While Activated, your Melee Attack Cards inflict +1 damage." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 23, null, "", "Cosmos Shield", 0, 4, "You may spend 2 Power Tokens to Trigger: Create 1 Barrier." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 24, null, "", "Sky Anchor Overload", 0, 4, "Spend 3 Power Tokens to trigger: All Anchors inflict 3 damage and are then destroyed." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 25, null, "", "Heart Of The Wolf", 0, 5, "Spend 2 Power Tokens to Trigger: X=the amount of Panic in your Cooldown Meter. Gain  X⋅2 Fighting Spirit." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 26, null, "", "Leap Of The Wolf", 0, 5, "Pay 3 Fighting Spirit and remove 1 Panic from your Cooldown Meter to Trigger: You may Leap 1 hex even if you have already spent your movement this turn." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 27, null, "", "Jaws Of The Wolf", 3, 5, "While Activated, you may replace the Rules Text of a Fang Attack Card with the rules text of any other Fang Attack  Card in your Cooldown Meter." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 28, null, "", "Bite Of The Wolf", 0, 5, "Once per attack, you may gain 1 Panic to Trigger: Reroll your unsuccessful Fang attack." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 29, null, "", "Hunger Of The Wolf", 2, 5, "While Activated, when you start your turn with Combat Advantage increase your Speed by 2." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 30, null, "", "Wolfsbane", 1, 5, "While Activated, once per turn you may spend 1 Power Token to Trigger: Create 1 Barrier." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 31, null, "", "Rocket Sprint", 1, 6, "While Activated, on your Active Turn you may spend X Power TOKENS\nto TRIGGER: move X hexes, even if you have already spent your movement this turn." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 32, null, "", "Sniper's Perch", 3, 6, "While Activated, whenever you have Combat Advantage add 2 Attack Dice to your Attack Roll instead of 1." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 33, null, "", "Cover Shooter", 1, 6, "While Activated, whenever you’re in Cover, add 1 Defense Die to your Attack Rolls, treating it as a 10-sided Attack Die." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 34, null, "", "Bullet Hell", 0, 6, "Spend 5 Power Tokens to Trigger: All of your Ranged Attack Cards Gain the Combo subtype until the end of this turn" });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 35, null, "", "Spotter", 0, 6, "Spend 3 Power Tokens to Trigger: All of your Attack Die results are increased by 1 until the end of this turn." });

            migrationBuilder.InsertData(
                table: "RobotAbility",
                columns: new[] { "Id", "BuildId", "LogoImage", "Name", "PowerTokens", "RobotId", "Rules" },
                values: new object[] { 36, null, "", "Sniper Gust", 0, 6, "Spend 1 Power Token to Trigger: Gain Boost until the end of this turn." });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 1, 5, -1, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 10, "Counter_Icon.png", "Damage_Icon.png", "Copy the damage text of your opponent's Attack Card.", "Dice_Icon.png", true, "Ascalon_Logo.png", "Bullet_Buffet.png", 6, 2, "BULLET BUFFET!", "Must be played in response to your opponent's Attack/Reactive Attack.", 6, "X=the total Base Damage of your opponent's Attack Card.", "COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 2, 3, 5, null, "RANGED", "", 2, "Cooldown_Meter_2.png", 9, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Bullet_Drive.png", 6, 2, "BULLET DRIVE!", "", 6, "Move 1 hex away from your opponent and Gain 1 Power Surge. Push your opponent 1 hex per success.", "COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 3, 2, 1, null, "RANGED", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 3, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Eat_Your_Fill.png", 4, 2, "EAT YOUR FILL!", "If played in a Combo, ignore this card's Trigger.", 6, "If this Attack is successful, Trigger: You may play this Attack for free against 1 new Target, once.", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 4, 3, 1, null, "RANGED", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 3, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Gladius_Rapid_Fire.png", 4, 2, "GLADIUS RAPID FIRE!", "", 6, "——", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 5, 1, 2, null, "RANGED", "", 0, "", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Gladius_Suppressing_Fire.png", 5, 2, "GLADIUS SUPPRESSING FIRE!", "", 6, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 6, 2, 2, null, "RANGED", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Gunpowder_Hail.png", 5, 2, "GUNPOWDER HAIL!", "", 6, "While Activated, your opponent's Ranged Attack Rolls are reduced by 1 Attack Die.", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 7, 2, 5, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 6, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Heart_Lancer.png", 6, 3, "HEART LANCER!", "", 6, "Inflict 1 Panic per success.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 8, 5, 12, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 18, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", true, "Ascalon_Logo.png", "Kill_Caliber.png", 8, 2, "KILL CALIBER!", "", 6, "Whenever this Attack is successful, you may Gain 1 Panic and 2 Power Surges to Trigger: You may play this Attack for free against 1 new Target.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 9, 5, 3, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 12, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", true, "Ascalon_Logo.png", "Magnum_Hurricane.png", 3, 1, "MAGNUM HURRICANE!", "", 6, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 10, 3, 2, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 10, "", "Damage_Icon.png", "Inflict damage per success. X=the damage Inflicted to your opponent. Inflict X⋅1/2 damage to all hexes adjacent to your opponent.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Rocket_Carousel.png", 5, 2, "ROCKET CAROUSEL!", "", 6, "Inflict 1 Fire to all opponents damaged by this Attack.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 11, 3, 4, null, "RANGED", "", 2, "Cooldown_Meter_2.png", 7, "", "Damage_Icon.png", "Inflict damage. Inflict 1/2 damage to all Targets adjacent to your opponent.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Rocket_Catapault.png", 5, 2, "ROCKET CATAPULT!", "", 6, "Create 1 Crater on your opponent's hex. Throw your opponent up to 2 hexes. Inflict 1 Fire to all opponents damaged by this  Attack.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 12, 3, 3, null, "RANGED", "", 2, "Cooldown_Meter_2.png", 6, "", "Damage_Icon.png", "Inflict damage to all hexes adjacent to you, then you may move up to 4 hexes.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Rocket_Jump.png", 1, 1, "ROCKET JUMP!", "", 6, "Gain 1 Fire and 1 Panic. If you are in top of a Structure, Destroy that Structure. Otherwise Create 1 Crater on your hex.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 13, 3, 5, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 8, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Sniper_Gale.png", 6, 3, "SNIPER GALE!", "", 6, "You may move up to 2 hexes per success.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 14, 1, 3, null, "RANGED", "Combo_Icon.png", 3, "Cooldown_Meter_3.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Vulcan_Dash.png", 3, 2, "VULCAN DASH!", "", 6, "You may move up to 3 hexes.", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 15, 1, 3, null, "RANGED", "", 1, "Cooldown_Meter_1.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Xyston_Fire.png", 6, 3, "XYSTON FIRE!", "", 6, "You may Push your opponent 1 hex.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 16, 3, 3, null, "MELEE", "", 3, "Cooldown_Meter_3.png", 6, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Bullet_Rider_Kick.png", 3, 1, "BULLET RIDER KICK!", "", 6, "Leap to any hex adjacent to your opponent. You may Throw your opponent up to 1 hex per success.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 17, 2, 3, null, "MELEE", "", 3, "Cooldown_Meter_3.png", 6, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Bullet_Rider_Punch.png", 3, 2, "BULLET RIDER PUNCH!", "", 6, "Leap to any hex adjacent to your opponent, and within range.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 18, 1, 3, null, "MELEE", "Combo_Icon.png", 1, "Cooldown_Meter_1.png", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ascalon_Logo.png", "Xyston_Home_Run_Swing.png", 1, 1, "XYSTON HOME RUN SWING!", "", 6, "——", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 19, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Ascalon_Logo.png", "Ballistic_Ballet.png", 0, 0, "BALLISTIC BALLET!", "", 6, "While Activated, you may re-roll your entire Defense Roll once per Attack.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 20, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 1, "", "", "", "", false, "Ascalon_Logo.png", "Blind_Fire.png", 0, 0, "BLIND FIRE!", "Does not affect Ultimate Techniques.", 6, "Cancel your opponent's Instant. Gain 2 Panic.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 21, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Ascalon_Logo.png", "Dead_Eye.png", 0, 0, "DEAD EYE!", "Must be played in response to your successful Attack/Reactive Attack.", 6, "Increase 1 card in your opponent's Cooldown Meter to Cooldown Slot 3.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 22, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", false, "Ascalon_Logo.png", "Deflector.png", 0, 0, "DEFLECTOR!", "Does not affect Ultimate Techniques.", 6, "If a Ranged Attack would Inflict damage to your hex, perform a Recovery Roll. On a success, that damage is Inflicted to any 1 adjacent hex of your choice.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 23, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Ascalon_Logo.png", "Evac_Assist.png", 0, 0, "EVAC ASSIST!", "", 6, "If you are Forcefully Moved, you choose the legal hex you are moved to.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 24, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "Ascalon_Logo.png", "Explosive_Shot.png", 0, 0, "EXPLOSIVE SHOT!", "", 6, "If successful, your next Ranged Attack Inflicts 1/2 damage to all adjacent Targets.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 25, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 5, "", "", "", "", false, "Ascalon_Logo.png", "Gunslinger_Tango.png", 0, 0, "GUNSLINGER TANGO!", "", 6, "While Activated, if you are the Target of an Attack, Trigger: Add 1 Attack Die to your next Attack Roll.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 26, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 5, "", "", "", "", false, "Ascalon_Logo.png", "Incendiary_Shot.png", 0, 0, "INCENDIARY SHOT!", "", 6, "If successful, your next Ranged Attack Inflicts 1 Fire per success.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 27, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 5, "", "", "", "", false, "Ascalon_Logo.png", "Lock_and_Load.png", 0, 0, "LOCK AND LOAD!", "", 6, "Remove 1 Ranged Attack Card from your Cooldown Meter and return it to your hand.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 28, 0, 0, null, "INSTANT", "", 1, "Cooldown_Meter_1.png", 3, "", "", "", "", false, "Ascalon_Logo.png", "Point_Blank.png", 0, 0, "POINT BLANK!", "", 6, "Reduce the minimum range of your next Ranged Attack to 1.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 29, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 2, "", "", "", "", false, "Ascalon_Logo.png", "Reload.png", 0, 0, "RELOAD!", "", 6, "Increase or Decrease 1 Ranged Attack Card in your Cooldown Meter by 1 Cooldown Slot.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 30, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Ascalon_Logo.png", "Sure_Shot.png", 0, 0, "SURE SHOT!", "", 6, "Double the maximum range of your next Ranged Attack.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 31, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "Ascalon_Logo.png", "Tesla_Shot.png", 0, 0, "TESLA SHOT!", "", 6, "If successful, your next Ranged Attack Inflicts 1 Power Surge per success.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 32, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Ascalon_Logo.png", "Vulcan_Shield.png", 0, 0, "VULCAN SHIELD!", "Must be played in response to your opponent's Attack Roll. Does not affect Ultimate Techniques.", 6, "You may Gain X Panic to Trigger: Remove X of your opponent's successful dice from play.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 33, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Ascalon_Logo.png", "Xyston_Phalanx_Form.png", 0, 0, "XYSTON PHALANX FORM!", "", 6, "Create 1 Barrier. While Activated, you may pay this card's cost and Gain 1 Panic to Trigger: Create 1 Barrier.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 34, 3, 7, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 8, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Ayzn_Black_Onyx_Blaster.png", 3, 2, "AYZN BLACK! ONYX BLASTER!", "IRON FUSION STAGE 3! AYZN BLACK! must be activated.", 1, "Your opponent must perform a Recovery Roll. On a failure, they must permanently remove 1 card from their hand", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 35, 1, 2, null, "RANGED ATTACK", "", 1, "Cooldown_Meter_1.png", 3, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Ayzn_Blaster.png", 3, 2, "AYZN BLASTER!", "", 1, "You may Push your opponent 1 hex.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 36, 3, 1, null, "RANGED ATTACK", "", 2, "Cooldown_Meter_2.png", 2, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "Ayzn_logo.png", "Ayzn_Gatling_Blaster.png", 3, 2, "AYZN GATLING BLASTER!", "", 1, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 37, 2, 4, null, "RANGED ATTACK", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "STEEL_GEYSER.png", 3, 2, "STEEL GEYSER!", "", 1, "You may Pull your opponent up to 1 hex per success.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 38, 3, 5, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 6, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Ayzn_Black_Calamity_KO.png", 1, 1, "AYZN BLACK! CALAMITY K.O.!", "IRON FUSION STAGE 3! AYZN BLACK! must be activated.", 1, "Your opponent must perform a Recovery Roll. On a failure, they can not Gain Power until the beginning of their next turn.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 39, 3, 7, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 10, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Ayzn_Black_Core_Collapse.png", 1, 1, "AYZN BLACK! CORE COLLAPSE!", "IRON FUSION STAGE 3! AYZN BLACK! must be activated.", 1, "Your opponent must remove all of the Power Tokens in their Power Token Control.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 40, 3, 3, null, "MELEE ATTACK", "", 1, "Cooldown_Meter_1.png", 6, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Ayzn_Black_Cross_Counter_Stagger.png", 1, 1, "AYZN BLACK! CROSS COUNTER STAGGER!", "IRON FUSION STAGE 3! AYZN BLACK! must be activated.", 1, "Inflict 1 Panic per success.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 41, 5, 8, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 20, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", true, "Ayzn_logo.png", "Ayzn_Blitz_Knuckle.png", 1, 1, "AYZN BLITZ KNUCKLE!", "", 1, "Inflict 1 Fire, 1 Panic, and 1 Power Surge to your opponent per success.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 42, 2, 2, null, "MELEE ATTACK", "", 1, "Cooldown_Meter_1.png", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Ayzn_Punch.png", 1, 1, "AYZN PUNCH!", "", 1, "——", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 43, 2, 5, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 8, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Core_Breach.png", 1, 1, "CORE BREACH!", "", 1, "Your opponent must remove 1 Power Token from their Power Token Control per success.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 44, 2, 3, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 6, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Corroder_Impact.png", 1, 1, "CORRODER IMPACT!", "", 1, "X=this Attack's successes. Your opponent must randomly choose X cards from their hand and place them into their Cooldown Meter, Deactivated.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 45, 1, 4, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 6, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Corrosion_Cutter.png", 1, 1, "CORROSION CUTTER!", "Your opponent's current Attack Roll is reduced by 1 Attack Die.", 1, "While Activated, your opponent's Attack Rolls are reduced by 1 Attack Die.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 46, 2, -1, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 10, "Counter_Icon.png", "Damage_Icon.png", "Inflict X⋅2 damage to your opponent.", "Dice_Icon.png", false, "Ayzn_logo.png", "Cross_Counter.png", 1, 1, "CROSS COUNTER!", "Must be played in response to a Melee Attack.", 1, "X=your opponent's Melee Attack's damage.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 47, 1, 6, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 8, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "HAMMERSCHLAG.png", 1, 1, "HAMMERSCHLAG!", "You must not be at Tier 1 or Tier 2.", 1, "Create 1 Crater on your hex. Create 1 Crater on your opponent's hex.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 48, 3, 8, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 11, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Iron_Meteor.png", 3, 2, "IRON METEOR!", "You must be at Tier 1 or Tier 2.", 1, "Push your opponent 1 hex, then move to your opponent's previous hex. If this move causes you to be on top of a Structure, you must collide with that Structure.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 49, 3, 2, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 8, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "Knuckle_Duster_Whirlwind.png", 1, 1, "KNUCKLE DUSTER WHIRLWIND!", "", 1, "You may Push your opponent 1 hex, and then move to a hex adjacent to your opponent, per success.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 50, 2, 3, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 5, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "PANZERFAUST.png", 1, 1, "PANZERFAUST!", "", 1, "Your opponent must randomly choose 1 card from their hand and place it into their Cooldown Meter, Deactivated.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 51, 3, 1, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 6, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "PANZERSCHLAG.png", 1, 1, "PANZERSCHLAG!", "", 1, "Inflict 1 Fire per success. Create 1 Crater on your opponent's hex.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 52, 1, 2, null, "MELEE ATTACK", "", 0, "", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "SCHNELLER_SCHLAG.png", 1, 1, "SCHNELLER SCHLAG!", "", 1, "——", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 53, 2, 3, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "SHATTER_HAND.png", 1, 1, "SHATTER HAND!", "", 1, "X=this Attack’s successes. Choose X cards in your opponent’s Cooldown Meter and increase their Cooldown Slot by 1.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 54, 2, 3, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ayzn_logo.png", "TUMULT_CASCADE.png", 1, 1, "TUMULT CASCADE!", "Reduce the result of each Attack Die in your opponent's Attack Roll by 1.", 1, "——", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 55, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", true, "Ayzn_logo.png", "Ayzn_Black_Iron_Fusion_Overkill.png", 0, 0, "AYZN BLACK! IRON FUSION OVERKILL!", "IRON FUSION STAGE 3! AYZN BLACK! must be activated.", 1, "Until the end of this turn, all of your Melee Attack Cards Gain the Combo keyword.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 56, 0, 0, null, "INSTANT", "", 1, "Cooldown_Meter_1.png", 16, "", "", "", "", true, "Ayzn_logo.png", "Ayzn_Black_Onyx_Generator.png", 0, 0, "AYZN BLACK! ONYX GENERATOR!", "IRON FUSION STAGE 3! AYZN BLACK! must be activated.", 1, "Permanently reduce the costs of all of your cards without AYZN BLACK in their name by ½. Remove this card from play.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 57, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Ayzn_logo.png", "Ayzn_Bunker.png", 0, 0, "AYZN BUNKER!", "", 1, "Until the end of this turn, you Gain +1 Defense while on a Crater.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 58, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", false, "Ayzn_logo.png", "Ayzn_Generator.png", 0, 0, "AYZN GENERATOR!", "", 1, "You Gain +1 Defense while this card is Activated in your Cooldown Meter. When your opponent Inflicts damage to you, Deactivate this card.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 59, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Ayzn_logo.png", "Blade_Breaker.png", 0, 0, "BLADE BREAKER!", "", 1, "Perform a Recovery Roll. On a success, \nDeactivate 1 of your opponent’s Activated cards or Robot Abilities. If this would remove the Requirements of their Instant, the Instant is Canceled. If this would remove the Requirements of their Attack, Ignore the Attack’s Rules Text.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 60, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Ayzn_logo.png", "FEUERKRAFT.png", 0, 0, "FEUERKRAFT!", "", 1, "Until the end of this turn, each time you Attack you may choose 1 of your Attack Dice and raise its result by 1.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 61, 0, 0, null, "INSTANT", "", 1, "Cooldown_Meter_1.png", 3, "", "", "", "", false, "Ayzn_logo.png", "Knuckle_Detonator.png", 0, 0, "KNUCKLE DETONATOR!", "", 1, "X=the amount of Power Dice used in your next Attack Roll. If successful, your next attack Inflicts damage + X.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 62, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 5, "", "", "", "", false, "Ayzn_logo.png", "LUFTFAUST.png", 0, 0, "LUFTFAUST!", "", 1, "Destroy all adjacent Elemental Impact Tiles.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 63, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Ayzn_logo.png", "RIVET_REND.png", 0, 0, "RIVET REND!", "", 1, "Until the beginning of your next turn, whenever you Inflict damage to your opponent, Inflict +1 Panic.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 64, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Ayzn_logo.png", "SCHWARZER_RITTER.png", 0, 0, "SCHWARZER RITTER!", "", 1, "Create 1 Barrier.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 65, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 4, "", "", "", "", false, "Ayzn_logo.png", "SENSOR_SMASHER.png", 0, 0, "SENSOR SMASHER!", "", 1, "While Activated, when you are the Target of an opponent's Ranged Attack, their Attack's maximum range is reduced by 1/2 (an Attack's maximum range cannot be less than its minimum range.)", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 66, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Ayzn_logo.png", "TUMULT_WAVE.png", 0, 0, "TUMULT WAVE!", "", 1, "Your opponent must re-roll their Attack Roll.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 67, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 1, "", "", "", "", false, "Dai_logo.png", "Ion_Intake.png", 3, 1, "ION INTAKE!", "", 3, "Until the end of this turn, whenever damage is Inflicted to you, Gain 3 Power Surges.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 68, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 2, "", "", "", "", false, "Dai_logo.png", "Flash_Counter.png", 0, 0, "FLASH COUNTER!", "Does not affect Ultimate Techniques.", 3, "Perform a Recovery Roll. On a success, Cancel your opponent's Instant.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 69, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 2, "", "", "", "", false, "Dai_logo.png", "Flash_Shield.png", 0, 0, "FLASH SHIELD!", "Must be played in response to your unsuccessful Defense Roll.", 3, "For each Defense Die that is higher than an opponent's Attack Die, reduce incoming damage by 1/2.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 70, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 6, "", "", "", "", false, "Dai_logo.png", "Overvoltage.png", 3, 1, "OVERVOLTAGE!", "", 3, "Inflict 3 Power Surges to you and your opponent.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 71, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 10, "", "", "", "", false, "Dai_logo.png", "Lightning_Heist.png", 3, 1, "LIGHTNING HEIST!", "", 3, "While Activated, whenever an opponent spends 1 or more Power Tokens, Trigger: You may Gain 1 Power Token.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 72, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 18, "", "", "", "", false, "Dai_logo.png", "Flash_Phase.png", 0, 0, "FLASH PHASE!", "", 3, "While Activated, whenever damage is Inflicted to you, perform a Recovery Roll. On a success, reduce the damage by 1/2.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 73, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 10, "", "", "", "", true, "Dai_logo.png", "Storm_Caller.png", 0, 0, "STORM CALLER!", "", 3, "While Activated, whenever your Attacks are successful, Trigger: Create 1 Arc Hazard on your opponent's hex.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 74, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "Dai_logo.png", "Auxiliary_Charge.png", 0, 0, "AUXILIARY CHARGE!", "", 3, "Add 1 Attack Die to your next Attack Roll. Gain 1 Power Surge.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 75, 0, 0, null, "INSTANT", "", 1, "Cooldown_Meter_1.png", 3, "", "", "", "", false, "Dai_logo.png", "Charge.png", 0, 0, "CHARGE!", "", 3, "If successful, your next Attack Inflicts +2 damage.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 76, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "Dai_logo.png", "FTL_Drive_Engage.png", 0, 0, "F.T.L. DRIVE, ENGAGE!", "Must be played while you are the Active Player.", 3, "Until the end of this turn, you may spend your movement as many times as you want. You cannot exceed your total Speed.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 77, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Dai_logo.png", "Power_Amp.png", 0, 0, "POWER AMP!", "", 3, "While Activated, each time this card is affected by a Power Surge in your Cooldown Meter, you Gain 1 Power Token.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 78, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Dai_logo.png", "FTL_Combo.png", 0, 0, "F.T.L. COMBO!", "", 3, "You may use a Combo in response to your opponent's Attack.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 79, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", false, "Dai_logo.png", "Electro_Clash.png", 0, 0, "ELECTRO CLASH!", "Must be played in response to your opponent's Attack or Defense roll.", 3, "X=the amount of Power Surges in your Cooldown Meter. Perform X Recovery Rolls. Per success, remove the die with the lowest result from your opponent's roll.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 80, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Dai_logo.png", "Tesla_Surge.png", 0, 0, "TESLA SURGE!", "", 3, "Inflict 1 Power Surge to all opponents adjacent to you.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 81, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 7, "", "", "", "", false, "Dai_logo.png", "EMP_Burst.png", 3, 1, "E.M.P. BURST!", "", 3, "You and all players within range must perform a Recovery Roll. If a player fails, they must randomly place 1/2 of their hand into their Cooldown Meter, Deactivated.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 82, 3, 4, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 10, "", "Damage_Icon.png", "Inflict damage to all hexes adjacent to you.", "Dice_Icon.png", false, "Dai_logo.png", "Lightning_Tempest_Striker.png", 5, 1, "LIGHTNING TEMPEST STRIKER!", "", 3, "All opponents within range must perform a Recovery Roll. On a failure, they are Pulled to the closest hex that's adjacent to you. Inflict 1 Power Surge and 1 Fire per success to all robots that are adjacent to you. Gain 1 Power Surge.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 83, 5, 12, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 19, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", true, "Dai_logo.png", "Electro_Detonator.png", 1, 1, "ELECTRO DETONATOR!", "X=the amount of Power Surges in your Cooldown Meter. Add X Power Dice to this Attack.", 3, "Create X Arc Hazards on your opponent's hex and/or the hexes adjacent to your opponent. Remove all Power Surges from your Cooldown Meter.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 84, 1, 1, null, "MELEE ATTACK", "Combo_Icon.png", 0, "", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Flash_Strike.png", 1, 1, "FLASH STRIKE!", "", 3, "——", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 85, 1, 2, null, "MELEE ATTACK", "Combo_Icon.png", 1, "Cooldown_Meter_1.png", 3, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Volt_Spike.png", 1, 1, "VOLT SPIKE!", "", 3, "Inflict 1 Power Surge to your opponent. If this Attack is played in a Combo, decrease the minimum Range of the following Combo card by 1.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 86, 3, 3, null, "MELEE ATTACK", "Combo_Icon.png", 3, "Cooldown_Meter_3.png", 3, "", "Damage_Icon.png", "Inflict damage. You may pay 2⋅X Fighting Spirit to Trigger: Inflict +2⋅X damage.", "Dice_Icon.png", false, "Dai_logo.png", "Flash_Combo.png", 1, 1, "FLASH COMBO!", "", 3, "Your successes=X.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 87, 2, 2, null, "MELEE ATTACK", "Combo_Icon.png", 1, "Cooldown_Meter_1.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Arc_Heel.png", 1, 1, "ARC HEEL!", "", 3, "You may move up to 1 hex per success. If this Attack is played in a Combo, increase the maximum Range of the following Combo card by 1.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 88, 1, 3, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Thunder_Wave.png", 2, 1, "THUNDER WAVE!", "X=the amount of Power Surges in your Cooldown Meter. Add X Attack Dice to this Attack.", 3, "You may Push all opponents within range up to 2 hexes.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 89, 2, 2, null, "MELEE ATTACK", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "V_Cutter.png", 1, 1, "V CUTTER!", "", 3, "You may return this card to your hand instead of to your Cooldown Meter.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 90, 2, 3, null, "MELEE ATTACK", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 7, "", "Damage_Icon.png", "Inflict damage +X.", "Dice_Icon.png", false, "Dai_logo.png", "Cloud_Breaker.png", 2, 1, "CLOUD BREAKER!", "", 3, "X=the amount of Power Surges in your opponent's Cooldown Meter.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 91, 2, 2, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 7, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "Dai_logo.png", "Lightning_Glaive.png", 2, 1, "LIGHTNING GLAIVE!", "X=the amount of Power Surges in your opponent's Cooldown Meter. Add X Attack Dice to this Attack.", 3, "——", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 92, 3, 2, null, "MELEE ATTACK", "Combo_Icon.png", 3, "Cooldown_Meter_3.png", 8, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "Dai_logo.png", "V_Slasher.png", 1, 1, "V SLASHER!", "", 3, "You may return this card to your hand instead of to your Cooldown Meter. Create 1 Arc Hazard on your opponent's hex.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 93, 5, 8, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 18, "", "Damage_Icon.png", "Inflict damage. Inflict +2 damage for every Power Surge in your opponent’s Cooldown Meter. Then remove all Power Surge Tokens from your opponent’s Cooldown Meter.", "Dice_Icon.png", true, "Dai_logo.png", "Tesla_Impacter.png", 8, 4, "TESLA IMPACTER!", "", 3, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 94, 1, 1, null, "RANGED ATTACK", "Combo_Icon.png", 1, "Cooldown_Meter_1.png", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Ionize_Fire.png", 4, 2, "IONIZE! FIRE!", "If you have 2 or more Power Surges in your Cooldown Meter, you may play this card for free.", 3, "Gain 1 Power Surge.", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 95, 1, 2, null, "RANGED ATTACK", "Combo_Icon.png", 1, "Cooldown_Meter_1.png", 3, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Arc_Hunter.png", 3, 1, "ARC HUNTER!", "Whenever there is a Structure within range of this Attack, you may recalculate range beginning at that Structure. This Attack ignores Cover.", 3, "——", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 96, 3, 1, null, "RANGED ATTACK", "Combo_Icon.png", 1, "Cooldown_Meter_1.png", 6, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Bolt_Caster.png", 3, 1, "BOLT CASTER!", "", 3, "You may Throw your opponent up to 1 hex per success. Inflict 1 Power Surge per success.", "COMBO/COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 97, 2, 4, null, "RANGED ATTACK", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 6, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Tesla_Bolt.png", 8, 4, "TESLA BOLT!", "", 3, "If this Attack is played in a Combo, then increase the maximum Range of the following Combo card by 1. If your opponent is on top of a Structure, Destroy that Structure. Otherwise Create 1 Crater on your opponent’s hex.", "COMBO/COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 98, 2, 5, null, "RANGED ATTACK", "Combo_Icon.png", 3, "Cooldown_Meter_3.png", 8, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "V_Blaster.png", 4, 2, "V BLASTER!", "X=the amount of Power Surges in your Cooldown Meter. Add X Attack Dice to this Attack.", 3, "You may Push your opponent up to 1 hex per success.", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 99, 2, 1, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 8, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Dai_logo.png", "Raiden_Crush.png", 6, 2, "RAIDEN CRUSH!", "", 3, "X=the amount of Power Surges in your opponent's Cooldown Meter. Inflict X Fire.", "COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 100, 5, -1, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 20, "", "Damage_Icon.png", "Inflict X⋅3 damage.", "Dice_Icon.png", true, "shinokami_logo.png", "Apocalypse_Gate.png", 11, 1, "APOCALYPSE GATE!", "", 5, "X=the amount of Static Barriers on the map. Destroy every Static Barrier. Gain 1 Panic for each Barrier Destroyed.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 101, 3, 4, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 10, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Banish_Gate.png", 2, 2, "BANISH GATE!", "", 5, "If your opponent is within range of a Static Barrier, you may Throw them up to 2 hexes away from any other Static Barrier on the map.", "COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 102, 1, 2, null, "RANGED", "", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Barrier_Break.png", 5, 1, "BARRIER BREAK!", "", 5, "Your opponent loses 1 Power Token. If your opponent loses 1 Power Token, Trigger: Create 1 Barrier.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 103, 1, 3, null, "RANGED", "", 2, "Cooldown_Meter_2.png", 5, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage. You may Destroy X Barriers within 3 hexes of your opponent to Trigger: Inflict +X⋅3 damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Barrier_Crush.png", 4, 1, "BARRIER CRUSH!", "", 5, "X=the amount of Static Barriers within 3 hexes of your opponent.", "COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 104, 2, 4, null, "RANGED", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage. If you are adjacent to a Static Barrier, Destroy it to Trigger: Inflict damage +2.", "Dice_Icon.png", false, "shinokami_logo.png", "Barrier_Needle.png", 3, 2, "BARRIER NEEDLE!", "", 5, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 105, 2, 5, null, "RANGED", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage. If there is a Static Barrier in the Path of this Attack, Inflict +3 damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Burning_Gate.png", 5, 1, "BURNING GATE!", "", 5, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 106, 3, 4, null, "RANGED", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Crimson_Crescent_Claw.png", 5, 2, "CRIMSON CRESCENT CLAW!", "Must be played immediately after spending your movement.", 5, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 107, 3, 8, null, "RANGED", "", 3, "Cooldown_Meter_3.png", 6, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Giga_Gate.png", 5, 1, "GIGA GATE!", "You must Destroy 1 adjacent Static Barrier and place 3 Ranged Attack Cards into your Cooldown Meter, Deactivated.", 5, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 108, 1, 3, null, "RANGED", "", 1, "Cooldown_Meter_1.png", 3, "", "Damage_Icon.png", "Inflict damage+X.", "Dice_Icon.png", false, "shinokami_logo.png", "Hell_Hounds_Howl.png", 3, 1, "HELL HOUND'S HOWL!", "", 5, "X=the amount of Panic in your opponent's Cooldown Meter.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 109, 2, 3, null, "MELEE", "", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage. If there is a Static Barrier in your Attack's Path, Destroy it to Trigger: Inflict +2 damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Barrier_Drive.png", 3, 1, "BARRIER DRIVE!", "", 5, "Move to the closest hex adjacent to your opponent.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 110, 2, 1, null, "MELEE", "", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage per success. If there is a Static Barrier in the Path of this Attack, Destroy it to Trigger: Inflict +1 damage per success.", "Dice_Icon.png", false, "shinokami_logo.png", "Burning_Fang.png", 3, 1, "BURNING FANG!", "", 5, "Move to the closest hex adjacent to your opponent.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 111, 2, 1, null, "MELEE", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "shinokami_logo.png", "Dark_Fang.png", 1, 1, "DARK FANG!", "", 5, "Inflict 1 Panic to your opponent.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 112, 2, 4, null, "MELEE", "", 1, "Cooldown_Meter_1.png", 6, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Hells_Gate.png", 3, 1, "HELL'S GATE!", "You may calculate the range of this Attack starting from any Static Barrier on the map.", 5, "——", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 113, 2, 0, null, "MELEE", "", 1, "Cooldown_Meter_1.png", 5, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Hells_Roar.png", 2, 1, "HELL'S ROAR!", "", 5, "Inflict 1 Panic per success.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 114, 5, 8, null, "MELEE", "", 3, "Cooldown_Meter_3.png", 14, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", true, "shinokami_logo.png", "Lone_Wolfs_Wrath.png", 1, 1, "LONE WOLF'S WRATH!", "Must be played immediately after spending your movement.", 5, "While Activated, Panic in Cooldown Slot 1 of your opponent's Cooldown Meter cannot leave their Cooldown Meter.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 115, 2, 1, null, "MELEE", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "shinokami_logo.png", "Red_Fang.png", 1, 1, "RED FANG!", "", 5, "Inflict 1 Fire to your opponent.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 116, 3, 4, null, "MELEE", "", 2, "Cooldown_Meter_2.png", 6, "", "Damage_Icon.png", "Inlfict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Warp_Gate_Fang.png", 3, 1, "WARP GATE FANG!", "If there is a Static Barrier within range, you may recalculate the range of this Attack starting from that Static Barrier.", 5, "If you recalculated the range of this Attack from a Static Barrier, you may Destroy it to Trigger: Leap to a hex adjacent to your opponent.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 117, 2, 1, null, "MELEE", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "shinokami_logo.png", "White_Fang.png", 1, 1, "WHITE FANG!", "", 5, "Inflict 1 Power Surge to your opponent.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 118, 2, 4, null, "MELEE", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Wolfs_Claw.png", 1, 1, "WOLF'S CLAW!", "Must be played immediately after spending your movement.", 5, "You may Push your opponent up to 1 hex per success.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 119, 1, 2, null, "MELEE", "Combo_Icon.png", 0, "", 3, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "shinokami_logo.png", "Wolfs_Fang.png", 1, 1, "WOLF'S FANG!", "", 5, "——", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 120, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "shinokami_logo.png", "Aegis.png", 0, 0, "AEGIS!", "", 5, "Create 1 Barrier.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 121, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 8, "", "", "", "", false, "shinokami_logo.png", "Armorvore.png", 0, 0, "ARMORVORE!", "Must be played in response to your successful Attack/Reactive Attack.", 5, "X=the amount of damage your Attack Inflicts to your opponent. Until the end of this turn, whenever your Attacks are successful, Gain X⋅½ Armor.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 122, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "shinokami_logo.png", "Blood_Moon_Aegis.png", 0, 0, "BLOOD MOON AEGIS!", "", 5, "Destroy 2 adjacent Static Barriers to Trigger: Cancel your opponent's Instant, then add its Rules Text to this card.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 123, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 20, "", "", "", "", true, "shinokami_logo.png", "Break_the_Seal_Cerberus_Fang.png", 0, 0, "BREAK THE SEAL! CERBERUS FANG!", "", 5, "While Activated, all of your Attack Cards with FANG in their name have a Cooldown Value of 0.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 124, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "shinokami_logo.png", "Death_Spore.png", 0, 0, "DEATH SPORE!", "", 5, "While Activated, all Attacks Inflict +2 damage. When this card leaves your Cooldown Meter, you must pay 10 Fighting Spirit or lose 5 Armor.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 125, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "shinokami_logo.png", "Full_Boost_Claw.png", 0, 0, "FULL BOOST CLAW!", "Must be played while you are the Active Player. Must be played before spending your movement.", 5, "When a Structure is adjacent to your movement's path, perform a Recovery Roll. On each Success, that Structure is Destroyed. You are immune to any Impact card effects caused by this card.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 126, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "shinokami_logo.png", "Full_Moon_Aegis.png", 0, 0, "FULL MOON AEGIS!", "You must be adjacent to a Static Barrier.", 5, "Destroy an adjacent Static Barrier to Trigger: Cancel your opponent's Instant.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 127, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "shinokami_logo.png", "Grapple_Claw.png", 0, 0, "GRAPPLE CLAW!", "Must be played immediately after spending your movement.", 5, "If you are adjacent to a Structure, you may Leap to any hex adjacent to that Structure.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 128, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", false, "shinokami_logo.png", "Iron_Rend.png", 0, 0, "IRON REND!", "", 5, "Your opponent cannot Gain Armor this turn.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 129, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "shinokami_logo.png", "Life_Spore.png", 0, 0, "LIFE SPORE!", "", 5, "While Activated, and you are the Active Player, you may Destroy any adjacent Static Barrier to Trigger: Gain 2 Armor. When this card leaves your Cooldown Meter, you must pay 10 Fighting Spirit or lose 5 Armor.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 130, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", false, "shinokami_logo.png", "Mirror_Phase.png", 0, 0, "MIRROR PHASE!", "Must be played after you and your opponent have declared Attacks/Reactive Attacks.", 5, "Replace the Rules Text of your Attack Card with the Rules Text from your opponent's Attack Card.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 131, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", -1, "", "", "", "", false, "shinokami_logo.png", "Mirror_Shield.png", 0, 0, "MIRROR SHIELD!", "", 5, "Search your opponent's hand and choose any 1 Instant. X=its cost. Pay X to Trigger: Add the chosen Instant's Rules Text to this card until the end of this turn.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 132, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "shinokami_logo.png", "Tooth_and_Claw.png", 0, 0, "TOOTH AND CLAW!", "", 5, "Choose 1 Instant that's in your Cooldown Meter that's not an Ultimate Technique. X=its cost. Pay X to Trigger: Add the chosen Instant's Rules Text to this card until the end of this turn.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 133, 2, 1, null, "RANGED ATTACK", "Combo_Icon.png", 3, "Cooldown_Meter_3.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Burst_Chain_Leviathan.png", 4, 1, "BURST-CHAIN LEVIATHAN!", "", 4, "Until the end of this turn, every time your opponent moves or is Forcefully Moved, they receive 1 damage for each hex they move across.", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 134, 2, 0, null, "RANGED ATTACK", "", 1, "Cooldown_Meter_1.png", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Sky_Anchor.png", 3, 1, "SKY ANCHOR!", "", 4, "Inflict 1 Anchor to your opponent.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 135, 3, 3, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 10, "", "Damage_Icon.png", "Inflict damage. You may remove 2 of your successful dice from this Attack to Trigger: Inflict damage again.", "Dice_Icon.png", false, "Ogun_logo.png", "Spin_On_Galaxy_Slicer.png", 3, 2, "SPIN ON, GALAXY SLICER!", "", 4, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 136, 5, 2, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 14, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", true, "Ogun_logo.png", "Nebula_Destroyer.png", 4, 2, "NEBULA DESTROYER!", "If this Attack is unsuccessful, remove 2 dice used in this Attack to Trigger: Re-roll this Attack.", 4, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 137, 5, 10, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 20, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", true, "Ogun_logo.png", "Phantasm_Chain_Blaster.png", 4, 2, "PHANTASM CHAIN BLASTER!", "", 4, "Pull your opponent to a hex adjacent to you, then you may Throw your opponent up to 4 hexes.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 138, 2, 2, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Anchor_Buster.png", 1, 1, "ANCHOR BUSTER!", "", 4, "Throw your opponent 1 hex. Inflict 1 Anchor to your opponent.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 139, 1, 2, null, "MELEE ATTACK", "", 0, "", 3, "", "Damage_Icon.png", "Inflict damage. If your opponent is Anchored, Inflict +3 damage, and your opponent must remove 1 Anchor from their Cooldown Meter.", "Dice_Icon.png", false, "Ogun_logo.png", "Anchor_Smasher.png", 1, 1, "ANCHOR SMASHER!", "", 4, "——", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 140, 2, 2, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 6, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Anchor_Sprint.png", 3, 1, "ANCHOR SPRINT!", "", 4, "Move to a hex within range. Create 1 Anchor on any 2 hexes that you moved across.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 141, 1, 2, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Black_Hole_Bomber.png", 4, 1, "BLACK HOLE BOMBER!", "", 4, "If your opponent is on top of a Structure, they collide with that Structure. You may Throw your opponent 1 hex. Move to a hex adjacent to your opponent.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 142, 2, 1, null, "MELEE ATTACK", "Combo_Icon.png", 1, "Cooldown_Meter_1.png", 3, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Black_Hole_Suplex.png", 1, 1, "BLACK HOLE SUPLEX!", "", 4, "You may Throw your opponent 1 hex. If your opponent collides with a Structure, Trigger: Perform a Recovery Roll. On a success, you are immune to any Impact card effects caused by this Attack.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 143, 2, 3, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 7, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Burst_Chain_Lariat.png", 4, 2, "BURST-CHAIN LARIAT!", "", 4, "Move to a hex within range. Any opponent who is adjacent to any hex on this movement's Path is then Pulled to a hex adjacent to you.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 144, 3, 6, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 10, "", "Damage_Icon.png", "Inflict damage to all opponents within range.", "Dice_Icon.png", false, "Ogun_logo.png", "Burst_Chain_Pandemonium.png", 4, 1, "BURST-CHAIN PANDEMONIUM!", "Ignore elevation when calculating the Range of this Attack.", 4, "All opponents within range must perform a Recovery Roll. On a success, they’re immune to any damage caused by this Attack. You may move 1 hex per success.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 145, 1, 1, null, "MELEE ATTACK", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 3, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Burst_Chain.png", 4, 2, "BURST-CHAIN!", "", 4, "Pull your opponent to a hex adjacent to you.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 146, 1, 3, null, "MELEE ATTACK", "", 1, "Cooldown_Meter_1.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Graviton_Smash.png", 1, 1, "GRAVITON SMASH!", "", 4, "If there is an Elemental Impact Tile adjacent to your opponent, Pull it to your opponent's hex. Gain 1 Power Surge.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 147, 2, 1, null, "MELEE ATTACK", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 2, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Harpoon_Counter.png", 1, 1, "HARPOON COUNTER!", "", 4, "You may Throw your opponent to a hex adjacent to you.", "COMBO/COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 148, 1, 2, null, "MELEE ATTACK", "Combo_Icon.png", 3, "Cooldown_Meter_3.png", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Harpoon_Hook.png", 1, 1, "HARPOON HOOK!", "", 4, "You may Throw your opponent 1 hex.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 149, 1, 1, null, "MELEE ATTACK", "Combo_Icon.png", 1, "Cooldown_Meter_1.png", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Harpoon_Upper.png", 1, 1, "HARPOON UPPER!", "", 4, "——", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 150, 2, 2, null, "MELEE ATTACK", "Combo_Icon.png", 3, "Cooldown_Meter_3.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Luna_Vault.png", 1, 1, "LUNA VAULT!", "", 4, "Leap to a hex adjacent to your opponent. Throw your opponent to a hex adjacent to you.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 151, 2, 4, null, "MELEE ATTACK", "", 0, "", 4, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Sky_Anchor_Depth_Charge.png", 4, 1, "SKY ANCHOR DEPTH CHARGE!", "Your opponent must be Anchored.", 4, "Your opponent must remove 1 Anchor from their Cooldown Meter, and Deactivate any cards and abilities that grant Boost. If your opponent is on top of a Structure, they Collide with that Structure.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 152, 2, 4, null, "MELEE ATTACK", "Combo_Icon.png", 0, "", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Sky_Anchor_Exo_Driver.png", 4, 1, "SKY ANCHOR EXO-DRIVER!", "Your opponent must be Anchored.", 4, "Your opponent must remove 1 Anchor from their Cooldown Meter. You may Pull your opponent to a hex adjacent to you.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 153, 2, 4, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 8, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Sky_Anchor_Orbital_Swing.png", 4, 1, "SKY ANCHOR ORBITAL SWING!", "Your opponent must be Anchored.", 4, "You may Throw your opponent up to 4 hexes. Create 1 Crater on the hex they land on. They must remove 1 Anchor from their Cooldown Meter.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 154, 2, 3, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Ogun_logo.png", "Star_Spanner_Cranium_Crusher.png", 1, 1, "STAR SPANNER CRANIUM CRUSHER!", "STAR SPANNER must be Activated.", 4, "Inflict 2 Panic to your opponent.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 155, 5, 8, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 18, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", true, "Ogun_logo.png", "Supernova_Star_Spanner.png", 1, 1, "SUPERNOVA STAR SPANNER!", "STAR SPANNER must be Activated.", 4, "You may Push your opponent up to 8 hexes. Inflict 1 Panic per success.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 156, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "Ogun_logo.png", "Burst_Chain_Blocker.png", 0, 0, "BURST-CHAIN BLOCKER!", "", 4, "Until the end of this turn, each time your opponent's Attack would Forcefully Move you, perform a Recovery Roll. On a success, you cannot be Forcefully Moved by that Attack.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 157, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 2, "", "", "", "", false, "Ogun_logo.png", "Burst_Chain_Link_Breaker.png", 0, 0, "BURST-CHAIN LINK BREAKER!", "", 4, "If your Attack uses a Forced Movement keyword, you may change it to any other Forced Movement keyword until the end of this turn.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 158, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Ogun_logo.png", "Burst_Chain_Surujin.png", 4, 2, "BURST-CHAIN SURUJIN!", "Must be played in response to your opponent declaring movement.", 4, "Your opponent must perform a Recovery Roll. On a failure, your opponent cannot spend their movement this turn.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 159, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 6, "", "", "", "", false, "Ogun_logo.png", "Burst_Chain_Typhoon.png", 5, 3, "BURST-CHAIN TYPHOON!", "You must be adjacent to a Structure. Does not affect Ultimate Techniques.", 4, "Reduce your opponent's Attack's Base Damage to 0. Destroy an adjacent Structure, and draw 1 Impact Card as if you collided with it.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 160, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 6, "", "", "", "", false, "Ogun_logo.png", "Graviton_Gear.png", 4, 1, "GRAVITON GEAR!", "", 4, "Choose an opponent within range. Pull up to 6 Elemental Impact Tiles within 3 hexes of that opponent to the closest hex adjacent to them. Gain 1 Power Surge.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 161, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 4, "", "", "", "", false, "Ogun_logo.png", "Gravity_Well.png", 4, 2, "GRAVITY WELL!", "", 4, "All opponents must perform a Recovery Roll. On a failure, they are Pulled up to 3 hexes. Gain 1 Panic.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 162, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "Ogun_logo.png", "Lasso_Chain.png", 0, 0, "LASSO CHAIN!", "", 4, "X=the range between you and your opponent. Until the end of this turn, if you are Forcefully Moved, your opponent must move with you, ending their movement X hexes away from you. You Gain 1 Panic.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 163, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 5, "", "", "", "", false, "Ogun_logo.png", "Star_Spanner_Terra_Impact.png", 0, 0, "STAR SPANNER TERRA IMPACT!", "STAR SPANNER must be Activated.", 4, "If successful, your next Melee Attack forces your opponent to draw 1 Impact Card. They only resolve the Collision rules and Tier 1 damage effects, and they ignore the Destruction rules.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 164, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", false, "Ogun_logo.png", "Star_Spanner_Tune_Up.png", 0, 0, "STAR SPANNER TUNE UP!", "STAR SPANNER must be Activated.", 4, "Gain 3 Armor.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 165, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 7, "", "", "", "", false, "Ogun_logo.png", "System_Purge.png", 0, 0, "SYSTEM PURGE!", "", 4, "While Activated, when you would Gain Fighting Spirit you may instead remove all Tokens from one Cooldown Slot.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 166, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", false, "Chogoking_logo.png", "Burning_Circuit.png", 0, 0, "BURNING CIRCUIT!", "", 2, "Return X cards from your Cooldown Meter to your hand. Gain 1/2X Fire.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 167, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Chogoking_logo.png", "Burning_Core.png", 0, 0, "BURNING CORE!", "", 2, "X=the Fire in your Cooldown Meter. Gain 1/2X Armor. Remove X Fire from your Cooldown Meter and replace them with 1/2X Panic.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 168, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 10, "", "", "", "", false, "Chogoking_logo.png", "Countermeasures.png", 0, 0, "COUNTERMEASURES!", "", 2, "Remove all Tokens from your Cooldown Meter.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 169, 0, 0, null, "INSTANT", "", 2, "Cooldown_Meter_2.png", 3, "", "", "", "", false, "Chogoking_logo.png", "Fire_Starter.png", 0, 0, "FIRE STARTER!", "", 2, "Create an Inferno on an adjacent hex.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 170, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 6, "", "", "", "", false, "Chogoking_logo.png", "Genki_Drive.png", 0, 0, "GENKI DRIVE!", "Must be played while you are the Active Player.", 2, "Until the end of this turn, you may spend your movement up to your total Speed, twice. You Gain 1 Fire.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 171, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 6, "", "", "", "", false, "Chogoking_logo.png", "Magma_Power.png", 0, 0, "MAGMA POWER!", "You must be on an Inferno.", 2, "While Activated, Gain 1 Power Token during your Upkeep.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 172, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 3, "", "", "", "", false, "Chogoking_logo.png", "Phoenix_Wing.png", 0, 0, "PHOENIX WING!", "If you’re on an Inferno, you may Destroy the Inferno to Trigger: You may play this card for free.", 2, "Gain Boost until the end of this 1 turn. Gain 1 Fire.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 173, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 5, "", "", "", "", false, "Chogoking_logo.png", "Plasma_Knuckles.png", 0, 0, "PLASMA KNUCKLES!", "", 2, "While Activated, if you have Fire in your Cooldown Meter, your successful melee Attack Cards each Inflict +1 Fire.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 174, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 6, "", "", "", "", false, "Chogoking_logo.png", "Sol_Engine_Ignition.png", 0, 0, "SOL ENGINE IGNITION!", "", 2, "Perform 3 Recovery Rolls. On each success, Gain 2 armor.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 175, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 8, "", "", "", "", false, "Chogoking_logo.png", "Sol_Engine_On.png", 0, 0, "SOL ENGINE ON!", "", 2, "Gain 1 Fire. While Activated, increase the amount of all Fighting Spirit Gained by 2.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 176, 0, 0, null, "INSTANT", "", 3, "Cooldown_Meter_3.png", 8, "", "", "", "", true, "Chogoking_logo.png", "Sol_Engine_Overdrive.png", 0, 0, "SOL ENGINE OVERDRIVE!", "", 2, "While Activated, you may play any card from your Cooldown Meter with a cost of 2 or more by paying 1 ½ times its cost.", "", "Instant_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 177, 3, 3, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 7, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Afterburner_Takedown.png", 4, 1, "AFTERBURNER TAKEDOWN!", "", 2, "Move to a hex adjacent to your opponent. Throw that opponent 1 hex per success. Create 1 Crater on the hex your opponent was Thrown to.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 178, 1, 1, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage per Success.", "Dice_Icon.png", false, "Chogoking_logo.png", "Atom_Smasher_Barrage.png", 1, 1, "ATOM SMASHER BARRAGE!", "X=the amount of Power Tokens you control. Add X Power Dice to this Attack.", 2, "——", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 179, 2, 4, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 6, "", "Damage_Icon.png", "Inflict damage + X.", "Dice_Icon.png", false, "Chogoking_logo.png", "Atom_Smasher.png", 1, 1, "ATOM SMASHER!", "", 2, "X=the amount of Power Tokens you control.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 180, 2, 2, null, "MELEE ATTACK", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Burning_Chogoking_Fist.png", 1, 1, "BURNING CHOGOKING FIST!", "", 2, "You may Push your opponent up to 1 hex per success.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 181, 2, 6, null, "MELEE ATTACK", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Burning_Chrome_Blade.png", 1, 1, "BURNING CHROME BLADE!", "CHOGOKING SABRE! must be Activated.", 2, "You may increase or decrease each card in your Cooldown Meter by 1 Cooldown Slot.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 182, 3, 3, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 8, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Chogoking_Sabre_Eruptor.png", 2, 1, "CHOGOKING SABRE ERUPTOR!", "CHOGOKING SABRE! must be Activated.", 2, "Per success, you may Create 1 Inferno on your opponent's hex or a hex adjacent to your opponent.", "COUNTER", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 183, 5, 3, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 20, "", "Damage_Icon.png", "Inflict damage per success. Inflict +X damage..", "Dice_Icon.png", true, "Chogoking_logo.png", "Inferno_Blade.png", 2, 1, "INFERNO BLADE!", "CHOGOKING SABRE! must be activated.", 2, "X=the amount of Infernos adjacent to you and adjacent to your opponent.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 184, 2, 6, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 8, "", "Damage_Icon.png", "Inflict damage + X.", "Dice_Icon.png", false, "Chogoking_logo.png", "Nova_Blazer.png", 1, 1, "NOVA BLAZER!", "", 2, "X=the Fire in your Cooldown Meter.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 185, 1, 2, null, "MELEE ATTACK", "", 2, "Cooldown_Meter_2.png", 3, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Phoenix_Kick.png", 4, 1, "PHOENIX KICK!", "", 2, "Leap to a hex adjacent to your opponent, within range. You may Push your opponent 1 hex.", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 186, 1, 2, null, "MELEE ATTACK", "Combo_Icon.png", 0, "", 3, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Turbine_Spike.png", 1, 1, "TURBINE SPIKE!", "", 2, "You may Push your opponent 1 hex.", "COMBO", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 187, 3, 4, null, "MELEE ATTACK", "", 3, "Cooldown_Meter_3.png", 6, "", "Damage_Icon.png", "Inflict damage. If you are on or adjacent to an Inferno, you may Destroy the Inferno and Inflict +3 damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Volcano_Slasher.png", 1, 1, "VOLCANO SLASHER!", "CHOGOKING SABRE! must be Activated.", 2, "——", "", "Melee_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 188, 1, 3, null, "RANGED ATTACK", "", 1, "Cooldown_Meter_1.png", 2, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Chogoking_Beam.png", 5, 2, "CHOGOKING BEAM!", "", 2, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 189, 2, 5, null, "RANGED ATTACK", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Cinder_Shock.png", 3, 2, "CINDER SHOCK!", "", 2, "You may increase or decrease 1 card in your Cooldown Meter by 1 Cooldown Slot, per success. You Gain 1 Fire.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 190, 2, 3, null, "RANGED ATTACK", "Combo_Icon.png", 3, "Cooldown_Meter_3.png", 5, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Combuster_Beam.png", 3, 2, "COMBUSTER BEAM!", "", 2, "You may choose X⋅3 cards in your Cooldown Meter and increase them to Cooldown Slot 3 to Trigger: Inflict X Fire to your opponent.", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 191, 3, 1, null, "RANGED ATTACK", "", 2, "Cooldown_Meter_2.png", 8, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "Chogoking_logo.png", "Dynamo_Fist.png", 3, 1, "DYNAMO FIST!", "", 2, "Gain 1 Power Token per success.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 192, 1, 0, null, "RANGED ATTACK", "", 2, "Cooldown_Meter_2.png", 8, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Nova_Spark.png", 4, 2, "NOVA SPARK!", "", 2, "X=the Fire in your Cooldown Meter. Remove X Fire from your Cooldown Meter to Trigger: Inflict X Fire to your opponent.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 193, 2, 4, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 7, "", "Damage_Icon.png", "Inflict damage. You may place X Attack Cards into your Cooldown Meter, Deactivated, to Trigger: Inflict +X⋅1/2 damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Plasma_Shooter.png", 3, 1, "PLASMA SHOOTER!", "", 2, "——", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 194, 2, 6, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 8, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage to all hexes adjacent to you. Inflict +2 damage to opponents at a higher Tier", "Dice_Icon.png", false, "Chogoking_logo.png", "Razing_Bolt.png", 1, 1, "RAZING BOLT!", "All opponents within range of this Attack must perform a Recovery Roll. On a success, they are immune to any damage caused by this Attack.", 2, "——", "COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 195, 3, 5, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 8, "Counter_Icon.png", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Razing_Storm.png", 1, 1, "RAZING STORM!", "If played in a Combo, ignore this card's Trigger.", 2, "Per success, you may Create 1 Inferno on your Target's hex or a hex adjacent to your Target. Whenever this Attack is successful, Trigger: You may play this Attack for free against 1 new Target.", "COUNTER", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 196, 5, 8, null, "RANGED ATTACK", "", 3, "Cooldown_Meter_3.png", 18, "", "Damage_Icon.png", "Inflict damage + X.", "Dice_Icon.png", true, "Chogoking_logo.png", "Sol_Sphere.png", 7, 3, "SOL SPHERE!", "", 2, "X=the Fire in both you and your opponent's Cooldown Meter. Increase X cards in your opponent's Cooldown Meter to their Cooldown Slot 3.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 197, 2, 2, null, "RANGED ATTACK", "", 2, "Cooldown_Meter_2.png", 5, "", "Damage_Icon.png", "Inflict damage per success.", "Dice_Icon.png", false, "Chogoking_logo.png", "Trichogoking_Beam.png", 5, 2, "TRI-CHOGOKING BEAM!", "", 2, "If this Attack is successful, Trigger: You may play this Attack for free against 1 new Target, once.", "", "Ranged_Icon.png" });

            migrationBuilder.InsertData(
                table: "RobotCard",
                columns: new[] { "Id", "AttackDice", "BaseDamage", "BuildId", "CardType", "ComboImage", "Cooldown", "CooldownImage", "Cost", "CounterImage", "DamageImage", "DamageString", "DiceImage", "IsUltimate", "LogoImage", "MainArtImage", "MaxRange", "MinRange", "Name", "Requirements", "RobotId", "Rules", "SubType", "TypeImage" },
                values: new object[] { 198, 2, 1, null, "RANGED ATTACK", "Combo_Icon.png", 2, "Cooldown_Meter_2.png", 4, "", "Damage_Icon.png", "Inflict damage.", "Dice_Icon.png", false, "Chogoking_logo.png", "Turbine_Fist.png", 3, 1, "TURBINE FIST!", "", 2, "You may increase or decrease 1 card in your Cooldown Meter by 1 Cooldown Slot.", "COMBO", "Ranged_Icon.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Build_ChosenPilotAbilityId",
                table: "Build",
                column: "ChosenPilotAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_ChosenPilotId",
                table: "Build",
                column: "ChosenPilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Build_ChosenRobotId",
                table: "Build",
                column: "ChosenRobotId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotCard_BuildId",
                table: "PilotCard",
                column: "BuildId");

            migrationBuilder.CreateIndex(
                name: "IX_RobotAbility_BuildId",
                table: "RobotAbility",
                column: "BuildId");

            migrationBuilder.CreateIndex(
                name: "IX_RobotCard_BuildId",
                table: "RobotCard",
                column: "BuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PilotCard");

            migrationBuilder.DropTable(
                name: "RobotAbility");

            migrationBuilder.DropTable(
                name: "RobotCard");

            migrationBuilder.DropTable(
                name: "Build");

            migrationBuilder.DropTable(
                name: "Pilot");

            migrationBuilder.DropTable(
                name: "PilotAbility");

            migrationBuilder.DropTable(
                name: "Robot");
        }
    }
}
