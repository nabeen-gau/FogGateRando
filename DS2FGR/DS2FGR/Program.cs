using System.Diagnostics;
using System.Numerics;

using SoulsFormats;
using static SoulsFormats.PARAM;
using static SoulsFormats.PARAMDEF;

using FogWallNS;

String check_backup(String name)
{
    if (!File.Exists(name + ".bak"))
    {
        File.Copy(name, name + ".bak");
        Console.WriteLine($"[BACKUP] {name}.bak created.");
    }
    return name + ".bak";
}

MSB2 load_map(String path)
{
    String new_path = check_backup(path);
    MSB2 msb2 = MSB2.Read(new_path);
    Console.WriteLine($"[SUCCESS] Map: {path} loaded");
    return msb2;
}

PARAM load_map_param(String path)
{
    String new_path = check_backup(path);
    PARAM p = PARAM.Read(new_path);
    Console.WriteLine($"[SUCCESS] Param: {path} loaded");
    return p;
}

Field new_field(PARAMDEF.DefType display_type, String display_name, object default_value)
{
    Field f = new Field();
    f.DisplayName = display_name;
    f.DisplayType = display_type;
    f.Default = default_value;
    return f;
} 

PARAMDEF new_paramdef(PARAM param)
{
    PARAMDEF pd = new PARAMDEF();
    pd.ParamType = param.ParamType;
    pd.DataVersion = 7;
    pd.BigEndian = param.BigEndian;
    pd.Unicode = true;
    pd.FormatVersion = 104;
    return pd;
}

PARAMDEF get_obj_inst_def_paramdef_ex(
    PARAM param, int map_obj_inst_type, UInt16 unk04, byte default_state, 
    byte unk09, UInt32 unk10)
{
    PARAMDEF pd = new_paramdef(param);
    pd.Fields.Add(new_field(PARAMDEF.DefType.s32, "header ID", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.s32, "Param ID", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.s32, "Object Bullet", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "Unk02", 1.0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "Unk03", -1.0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.s32, "Map Obj Instance Type", map_obj_inst_type));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u16, "Unk04", unk04));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk05", 255));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk06", 255));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk07", 7));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk08", 255));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Default State", default_state));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk09", unk09));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u32, "Unk10", unk10));
    pd.Fields.Add(new_field(PARAMDEF.DefType.s32, "Itemlot ID", 0));
    return pd;
}

PARAMDEF get_obj_inst_def_paramdef(PARAM param)
{

    return get_obj_inst_def_paramdef_ex(param, 100, 0, 255, 50, 255);
}

PARAMDEF get_obj_inst_def_paramdef_fogwall(PARAM param)
{
    return get_obj_inst_def_paramdef_ex(param, 110, 6, 0, 255, 255);
}
PARAMDEF get_obj_inst_def_paramdef_eventloc(PARAM param)
{
    return get_obj_inst_def_paramdef_ex(param, 110, 6, 0, 255, 255);
}

PARAMDEF get_event_param_def_paramdef_ex(PARAM param, int event_id, int flag_id)
{
    PARAMDEF pd = new_paramdef(param);
    pd.Fields.Add(new_field(PARAMDEF.DefType.s32, "Event ID", event_id));
    pd.Fields.Add(new_field(PARAMDEF.DefType.s32, "Flag ID", flag_id));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk08", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk09", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk0A", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk0B", 2));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk0C", 1));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk0D", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk0E", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8,  "Unk0F", 0));
    return pd;
}

PARAMDEF get_event_param_def_paramdef(PARAM param)
{
    return get_event_param_def_paramdef_ex(param, 0, 0);
}

PARAMDEF get_event_loc_def_paramdef_ex(PARAM param, Vector3 position, Vector3 rotation)
{
    PARAMDEF pd = new_paramdef(param);
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "pos_x", position.X));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "pos_y", position.Y));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "pos_z", position.Z));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "rot_x", rotation.X));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "rot_y", rotation.Y));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "rot_z", rotation.Z));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8, "Region Type", 1));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8, "Unk19", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8, "Unk1A", 255));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8, "Unk1B", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "scale_x", 0.5f));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "scale_y", 1.0f));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "scale_z", 1.0f));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u16, "Unk28", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u16, "Unk2A", 2560));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u32, "Unk2C", 0));
    return pd;
}

// TODO: fix this
PARAMDEF get_event_loc_def_paramdef_boss_spawn_point(PARAM param, Vector3 position, Vector3 rotation)
{
    PARAMDEF pd = new_paramdef(param);
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "pos_x", position.X));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "pos_y", position.Y));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "pos_z", position.Z));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "rot_x", rotation.X));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "rot_y", rotation.Y));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "rot_z", rotation.Z));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8, "Region Type", 3));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8, "Unk19", 255));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8, "Unk1A", 255));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u8, "Unk1B", 255));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "scale_x", 1.0f));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "scale_y", 1.0f));
    pd.Fields.Add(new_field(PARAMDEF.DefType.f32, "scale_z", 1.0f));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u16, "Unk28", 0));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u16, "Unk2A", 2567));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u32, "Unk2C", 0));
    return pd;
}

PARAMDEF get_event_loc_def_paramdef(PARAM param)
{
    return get_event_loc_def_paramdef_ex(param, new Vector3(0), new Vector3(0));
}

static int parse_map_name(string mapCode)
{
    // Remove non-numeric characters and concatenate the numbers
    string numericPart = string.Empty;
    foreach (char c in mapCode)
    {
        if (char.IsDigit(c))
        {
            numericPart += c;
        }
    }

    // Parse the resulting string to an integer
    return int.Parse(numericPart);
}

String get_script_helper_fns(String map_name, int map_num)
{
    String map_id = map_name.Substring(0, 6);

    return @$"
def event_{map_id}_x501(warp_obj_inst_id=_, event_loc=_):
    """"""
    [Function] wait until interact button is pressed on `warp_obj_inst_id` and warp to `event_loc`
    """"""
    assert event_{map_id}_x502(warp_obj_inst_id=warp_obj_inst_id)
    assert event_{map_id}_x503(event_loc=event_loc, warp_obj_inst_id=warp_obj_inst_id)
    return 0

def event_{map_id}_x502(warp_obj_inst_id=_):
    """"""
    [Conditions] Wait until interact button is pressed on `warp_obj_inst_id`
    """"""
    IsObjSearched(0, warp_obj_inst_id)
    assert ConditionGroup(0)
    return 0

def event_{map_id}_x503(event_loc=_, warp_obj_inst_id=_):
    """"""
    [Execution] Warp to the given event_location
    """"""
    DisableObjKeyGuide(warp_obj_inst_id, 1)
    ProhibitInGameMenu(1)
    ProhibitPlayerOperation(1)
    SetPlayerInvincible(1)
    PlayCutsceneAndWarpToMap(0, 0, {map_num}, event_loc, 0)
    assert CutsceneWarpEnded() != 0
    DisableObjKeyGuide(warp_obj_inst_id, 0)
    ProhibitInGameMenu(0)
    ProhibitPlayerOperation(0)
    SetPlayerInvincible(0)
    return 0

def event_{map_id}_x504(battle_id=_):
    """"""Wait until the boss of given battle_id is defeated""""""
    IsEventBossKill(0, battle_id, 0, 1)
    assert ConditionGroup(0)
    return 0

def event_{map_id}_x505(flag8=_):
    """"""[Reproduction] Is boss dead?
    flag8: Boss destruction flag
    """"""
    """"""State 0,1: Are you fighting the boss?""""""
    if GetEventFlag(flag8) != 0:
        """"""State 3: the boss is dead""""""
        return 1
    else:
        """"""State 2: the boss is not dead""""""
        return 0

";
}

String generate_esd_script(String map_name, int script_id, int warp_src_id, int warp_dest_id)
{
    String map_id = map_name.Substring(0, 6);
    return @$"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Normal fog gate event""""""
    assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id})
    RestartMachine()
    Quit()
";
}

String generate_esd_script_boss_cutscene(String map_name, int script_id, int warp_src_id, int warp_dest_id, FogWall fw)
{
    String map_id = map_name.Substring(0, 6);
    Debug.Assert(fw.event_id > 0);
    Debug.Assert(fw.instance_id > 0);
    int fog_gate_instance_id = fw.instance_id;
    if (fw.twin_gate_id >= 0)
    {
        fog_gate_instance_id = fw.twin_gate_id;
    }
    return $@"
def event_{map_id}_{script_id}():
    """"""Text stele_01""""""
    """"""State 0,2: [Preset] Boss({fw.name}) fog gate event with cutscene""""""
    IsObjSearched(0, {warp_src_id})
    assert ConditionGroup(0)
    DisableObjKeyGuide({warp_src_id}, 1)
    if CompareObjStateId({fog_gate_instance_id}, 100, 0):
        assert event_{map_id}_x503(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id})
    else:
        ChangeObjState({fog_gate_instance_id}, 100)
        assert CompareObjStateId({fog_gate_instance_id}, 100, 0)
        if EventEnded({fw.event_id}) != 0:
            assert event_{map_id}_x503(warp_obj_inst_id={fw.instance_id}, event_loc={warp_dest_id})
    DisableObjKeyGuide({warp_src_id}, 0)
    """"""State 1: Rerun""""""
    RestartMachine()
    Quit()
";
}

String generate_esd_script_boss_from_behind(String map_name, int script_id, int warp_src_id, int warp_dest_id, FogWall fw)
{
    Debug.Assert(fw.destruction_flag > 0);
    String map_id = map_name.Substring(0, 6);
    return @$"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Boss({fw.name}) fog gate event""""""
    DisableObjKeyGuide({warp_src_id}, 1)
    call = event_{map_id}_x505(flag8={fw.destruction_flag})
    if call.Get() == 1:
        DisableObjKeyGuide({warp_src_id}, 0)
        assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id})
    elif call.Get() == 0:
        pass
    RestartMachine()
    Quit()
";
}

String generate_esd_script_boss_from_behind_v2(String map_name, int script_id, int warp_src_id, int warp_dest_id, FogWall fw)
{
    Debug.Assert(fw.destruction_flag > 0);
    String map_id = map_name.Substring(0, 6);
    return @$"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Boss({fw.name}) fog gate event""""""
    DisableObjKeyGuide({warp_src_id}, 1)
    assert event_{map_id}_x504(battle_id={fw.destruction_flag})
    DisableObjKeyGuide({warp_src_id}, 0)
    assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id})
    RestartMachine()
    Quit()
";
}

void write_string_to_file(String str, String file_path)
{
    try
    {
        str = str.Replace("\r\n", "\n");
        File.WriteAllText(file_path, str);
        Console.WriteLine($"[SUCCESS] {file_path} created.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[ERROR] {ex.Message}");
    }
}

String read_string_from_file(String file_path)
{
    try
    {
        String str = File.ReadAllText(file_path);
        Console.WriteLine($"[SUCCESS] {file_path} loaded.");
        return str;
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine($"[ERROR] {file_path} not found: {ex.Message}");
        return "";
    }
    catch (IOException ex)
    {
        Console.WriteLine($"[ERROR] {file_path} read error: {ex.Message}");
        return "";
    }
}

static void run_external_command(string command_path, string arguments)
{
    Process process = new Process();
    process.StartInfo.FileName = command_path;
    process.StartInfo.Arguments = arguments;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = true;
    try
    {
        Console.WriteLine($"[COMMAND] {command_path} {arguments}");
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (!string.IsNullOrEmpty(error))
        {
            Console.WriteLine("[Output]" + output);
            Console.WriteLine("[Error] " + error);
        } else
        {
            Console.WriteLine("[COMMAND] Exited without any error.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[ERROR] {ex.Message}");
    }
}

String format_int_to_str(int value, int size)
{
    if (value > Math.Pow(10, size))
    {
        Console.WriteLine("[ERROR] invalid value for given size");
        Debug.Assert(false);
    }
    String s = "";
    for (int i = 0; i < size; i++)
    {
        if (value < Math.Pow(10, i + 1))
        {
            for (int j = 0; j < size - i - 1; j++) s += "0";
            break;
        }
    }
    s += $"{value}";
    return s;
}

Vector3 vector3_move(Vector3 position, Vector3 rotation, float distance)
{
    float yaw = rotation.Y * (float)(Math.PI / 180); // Rotate around Y-axis
    float x = (float)(Math.Sin(yaw) * -distance);
    float z = (float)(Math.Cos(yaw) * -distance);
    Vector3 newPosition = new Vector3(position.X + x, position.Y, position.Z + z);
    return newPosition;
}

static float normalize_angle(float angle)
{
    angle = angle % 360;
    if (angle < 0)
    {
        angle += 360;
    }
    return angle;
}

Vector3 vector3_flip_y(Vector3 rotation)
{
    return new Vector3(rotation.X, normalize_angle(rotation.Y + 180), rotation.Z);
}

// TODO: change these before the final version
String mod_folder = Path.GetFullPath(@"..\..\..\..\..\mod");
String game_dir = Path.GetFullPath("..\\..\\..\\..\\..\\..\\Dark Souls II\\Dark Souls II");

String warp_obj_name = "o02_1050_0000";
String warp_obj_model_name = warp_obj_name.Substring(0, 8);
int warp_obj_inst_id = 10021101;

Dictionary<BossName, List<StringChange>> boss_script_change = new Dictionary<BossName, List<StringChange>>() {
    {BossName.OldIronKing, new List<StringChange>{
        new StringChange(
            @"CompareObjState(0, 10190610, 100, 0)
    assert ConditionGroup(0)", ""),
        new StringChange(
            @"CompareObjState(0, 10190610, 100, 0)
            assert ConditionGroup(0)", ""
        )}
    },
};


Dictionary<BossName, int> boss_spawn_event_loc = new Dictionary<BossName, int>()
{
    {BossName.TheDukesDearFreja, 100000 },
    {BossName.OldIronKing, 1500000 }, // not necessary
};

// cutscene event id: EventEnded(id)
Dictionary<BossName, int> boss_event_ids = new Dictionary<BossName, int>()
{
    {BossName.TheLastGiant, 6510 },
    {BossName.ThePursuer, 6010 },
    {BossName.TheLostSinner, 15010 },
    {BossName.ExecutionersChariot, 9010 },
    {BossName.OldIronKing, 15010 },
    {BossName.TheDukesDearFreja, 4010 },
    {BossName.TheRotten, 5010 },
    {BossName.VelstadtTheRoyalAegis, 4010 },
};

//NOTES (for final battle):
//flag2: Global flag for determining the destruction of giants = 100972
//flag3: Other flags for queen knight AC destruction determination = 221000091
//z10: Boss Battle ID(for consecutive battles) = 1021021
//def event_m20_21_x123(z5=1100000, z6=1100000, z7=102, z8=1021020, z9=221020090, flag2=100972, flag3=221000091,z10 = 1021021):
// end roll execution judgement flag = 221000094
// noteworthy fn: def event_m20_21_x118():


// GetEventFlag
Dictionary<BossName, int> boss_destruction_flags = new Dictionary<BossName, int>()
{
    {BossName.TheLastGiant,                 110000081},
    {BossName.ThePursuer,                   110000086},
    {BossName.Dragonrider,                  131000081},
    {BossName.OldDragonslayer,              131000086},
    {BossName.FlexileSentry,                118000081},
    {BossName.RuinSentinels,                116000081},
    {BossName.TheLostSinner,                116000086},
    {BossName.BelfryGargoyles,              116000091},
    {BossName.SkeletonLords,                1023000},
    {BossName.ExecutionersChariot,          123000081},
    {BossName.CovetousDemon,                117000081},
    {BossName.MythaTheBanefulQueen,         117000091},
    {BossName.SmelterDemon,                 119000081},
    {BossName.OldIronKing,                  119000086},
    {BossName.ScorpionessNajka,             132000081},
    {BossName.RoyalRatAuthority,            133000081},
    {BossName.ProwlingMagusAndCongregation, 114000096},
    {BossName.TheDukesDearFreja,            114000081},
    {BossName.RoyalRatVanguard,             134000081},
    {BossName.TheRotten,                    125000081},
    {BossName.TwinDragonrider,              221000081}, //221000081
    {BossName.LookingGlassKnight,           221000086}, //221000086
    {BossName.DemonofSong,                  211000081},
    {BossName.VelstadtTheRoyalAegis,        224000081},
    {BossName.Vendrick,                     224000086},
    {BossName.GuardianDragon,               115000081},
    {BossName.AncientDragon,                127000081},
    {BossName.GiantLord,                    210000081},
    {BossName.ThroneWatcherAndDefender,     221000091}, // 221000091
    {BossName.Nashandra,                    221000096}, // 221000096 (giant lord = 100972)
    {BossName.AldiaScholarOfTheFirstSin,    221000006}, // 221000006
    {BossName.Darklurker,                   403000081},
    {BossName.ElanaTheSqualidQueen,         535000081},
    {BossName.SinhTheSlumberingDragon,      535000096},
    {BossName.Gankfight,                    535000091}, // petrochemical root = 535000091
    {BossName.FumeKnight,                   536000081},
    {BossName.SirAlonne,                    536000086},
    {BossName.BlueSmelterDemon,             536000091},
    {BossName.AavaTheKingsPet,              537000081},
    {BossName.BurntIvoryKing,               537000086},
    {BossName.LudAndZallen,                 537000091},
};


Dictionary<MapName, String> map_names = new Dictionary<MapName, String>()
{
    { MapName.ThingsBetwixt,                "m10_02_00_00"},
    { MapName.Majula,                       "m10_04_00_00"},
    { MapName.ForestOfTheFallenGiants,      "m10_10_00_00"},
    { MapName.BrightstoneCoveTseldora,      "m10_14_00_00"},
    { MapName.AldiasKeep,                   "m10_15_00_00"},
    { MapName.TheLostBastilleBelfryLuna,    "m10_16_00_00"},
    { MapName.HarvestValleyEarthenPeak,     "m10_17_00_00"},
    { MapName.NomansWharf,                  "m10_18_00_00"},
    { MapName.IronKeepBelfrySol,            "m10_19_00_00"},
    { MapName.HuntsmanCopseUndeadPurgatory, "m10_23_00_00"},
    { MapName.TheGutterBlackGulch,          "m10_25_00_00"},
    { MapName.DragonAerieDragonShrine,      "m10_27_00_00"},
    { MapName.MajulaShadedWoods,            "m10_29_00_00"},
    ////{ MapName.HeidesToNoMansWharf,          "m10_30_00_00"}, // disabled (no fog gates)
    { MapName.HeidesTowerofFlame,           "m10_31_00_00"},
    { MapName.ShadedWoodsShrineofWinter,    "m10_32_00_00"},
    { MapName.DoorsofPharros,               "m10_33_00_00"},
    { MapName.GraveofSaints,                "m10_34_00_00"},
    { MapName.MemoryofVammarOrroandJeigh,   "m20_10_00_00"},
    { MapName.ShrineofAmana,                "m20_11_00_00"},
    //{ MapName.DrangleicCastleThroneofWant,  "m20_21_00_00"},
    { MapName.UndeadCrypt,                  "m20_24_00_00"},
    ////{ MapName.DragonMemories,               "m20_26_00_00"}, // disabled (no fog gates)
    //{ MapName.DarkChasmofOld,               "m40_03_00_00"},
    //{ MapName.ShulvaSanctumCity,            "m50_35_00_00"},
    //{ MapName.BrumeTower,                   "m50_36_00_00"},
    //{ MapName.FrozenEleumLoyce,             "m50_37_00_00"},
    ////{ MapName.MemoryoftheKing,              "m50_38_00_00"}, // disabled (no fog gates)
};

Dictionary<String, List<FogWall>> fog_wall_dict = new Dictionary<string, List<FogWall>>();
fog_wall_dict[map_names[MapName.ThingsBetwixt]] = new List<FogWall> {
    new FogWall("TB_tut1_exit",  "o00_0500_0000"),
    new FogWall("TB_tut1_entry", "o00_0500_0001"),
    new FogWall("TB_tut3_exit",  "o00_0500_0002"),
    new FogWall("TB_tut2_entry", "o00_0500_0003"),
    new FogWall("TB_tut3_entry", "o00_0500_0004"),
    new FogWall("TB_tut2_exit",  "o00_0500_0005"),
};
fog_wall_dict[map_names[MapName.Majula]] = new List<FogWall> {
    //new FogWall("Ma_limbo_1",    "o00_0501_0000", pvp: true), //disabled
    //new FogWall("Ma_limbo_2",    "o00_0501_0001", pvp: true), //disabled
    //new FogWall("Ma_limbo_3",    "o00_0501_0002", pvp: true), //disabled
    new FogWall("Majula_to_Forest",        "o00_0501_0100", pvp: true),
    new FogWall("Majula_to_GraveOfSaints", "o00_0501_0101", pvp: true), // y_offset = 43.455 - 42.057
    new FogWall("Majula_to_HuntsmanCopse", "o00_0501_0102", pvp: true),
    new FogWall("Majula_to_Rotunda",       "o00_0501_0103", pvp: true),
    new FogWall("Majula_to_Gutter",        "o00_0501_0104", pvp: true), // y_offset = 71.218 - 69.941
    new FogWall("Majula_to_ShadedWoods",   "o00_0502_0103", pvp: true),
};
fog_wall_dict[map_names[MapName.Majula]][1].offset = new Vector3(0.0f, 43.455f - 42.057f, 0.0f);
fog_wall_dict[map_names[MapName.Majula]][4].offset = new Vector3(0.0f, 71.218f - 69.941f, 0.0f);
fog_wall_dict[map_names[MapName.ForestOfTheFallenGiants]] = new List<FogWall> {
    new FogWall("ForestOfFG_last_giant",            "o00_0501_0001", boss_enum_id: BossName.TheLastGiant, cutscene: true),
    new FogWall("ForestOfFG_pursuer_entry",         "o00_0501_0003", boss_enum_id: BossName.ThePursuer, cutscene: true), // y_offset = 10.090f - 6.001f
    new FogWall("ForestOfFG_pursuer_exit",          "o00_0500_0004", boss_enum_id: BossName.ThePursuer, boss_exit: true, cutscene: true),
    new FogWall("ForestOfFG_balcony_to_last_giant", "o00_0500_0000"),
    new FogWall("ForestOfFG_fire_pit_to_outside",   "o00_0500_0003"),
    new FogWall("ForestOfFG_first_fog_wall",        "o00_0500_0002"),
    new FogWall("ForestOfFG_PVP_majula_to_forest",  "o00_0501_0002", pvp: true),
    new FogWall("ForestOfFG_PVP_to_pursuer",        "o00_0500_0005", pvp: true),
};
fog_wall_dict[map_names[MapName.ForestOfTheFallenGiants]][1].offset = new Vector3(0.0f, 10.090f - 6.001f, 0.0f);
fog_wall_dict[map_names[MapName.BrightstoneCoveTseldora]] = new List<FogWall> {
    new FogWall("BCTseldora_congregation_entry", "o00_0500_0000", boss_enum_id: BossName.ProwlingMagusAndCongregation),
    new FogWall("BCTseldora_congregation_exit",  "o00_0500_0001", boss_enum_id: BossName.ProwlingMagusAndCongregation, boss_exit: true),
    new FogWall("BCTseldora_area_entry",         "o00_0500_0002", pvp: true),
    new FogWall("BCTseldora_freya_exit",         "o00_0501_0001", boss_enum_id: BossName.TheDukesDearFreja, boss_exit: true, cutscene: true, reverse: true),
    new FogWall("BCTseldora_freya_entry",        "o00_0502_0000", boss_enum_id: BossName.TheDukesDearFreja, cutscene: true),
};
fog_wall_dict[map_names[MapName.AldiasKeep]] = new List<FogWall> {
    new FogWall("AldiasKeep_guardian_dragon_entry", "o00_0501_0000", boss_enum_id: BossName.GuardianDragon),
    new FogWall("AldiasKeep_guardian_dragon_exit",  "o00_0501_0001", boss_enum_id: BossName.GuardianDragon, boss_exit: true),
    new FogWall("AldiasKeep_entry",                 "o00_0501_0002", pvp: true),
};
fog_wall_dict[map_names[MapName.TheLostBastilleBelfryLuna]] = new List<FogWall> {
    new FogWall("LostBastille_gargoyles_entry",   "o00_0500_0000", boss_enum_id: BossName.BelfryGargoyles),
    new FogWall("LostBastille_sentinels_exit",    "o00_0500_0001", boss_enum_id: BossName.RuinSentinels, boss_exit: true, reverse: true),
    new FogWall("LostBastille_to_sinners_rise",   "o00_0500_0005"),
    new FogWall("LostBastille_gargoyles_exit",    "o00_0500_0006", boss_enum_id: BossName.BelfryGargoyles, boss_exit: true),
    // TODO: add boss fight triggers near hidden fog gates
    new FogWall("LostBastille_sentinels_hidden1", "o00_0500_0007", boss_enum_id: BossName.RuinSentinels, boss_exit: true),
    new FogWall("LostBastille_sentinels_hidden2", "o00_0500_0008", boss_enum_id: BossName.RuinSentinels, boss_exit: true),
    new FogWall("LostBastille_sentinels_hidden3", "o00_0500_0009", boss_enum_id: BossName.RuinSentinels, boss_exit: true),
    new FogWall("LostBastille_sentinels_hidden4", "o00_0500_0010", boss_enum_id: BossName.RuinSentinels, boss_exit: true),
    new FogWall("LostBastille_sentinels_upper_exit",   "o00_0500_0011", reverse: true), 
    new FogWall("LostBastille_from_wharf",        "o00_0500_0012", pvp: true),
    new FogWall("LostBastille_to_belfry",         "o00_0500_0013", pvp: true), // TODO: cannot access when lockstone is not used but can be used from the other side
    new FogWall("LostBastille_sentinels_entry",   "o00_0501_0000", boss_enum_id: BossName.RuinSentinels),
    new FogWall("LostBastille_lost_sinner_entry", "o00_0501_0002", boss_enum_id: BossName.TheLostSinner, cutscene: true),
    new FogWall("LostBastille_lost_sinner_exit",  "o00_0501_0003", boss_enum_id: BossName.TheLostSinner, boss_exit: true, cutscene: true),
};
fog_wall_dict[map_names[MapName.HarvestValleyEarthenPeak]] = new List<FogWall> {
    new FogWall("EarthenPeak_covetous_entry",   "o00_0500_0000", boss_enum_id: BossName.CovetousDemon),
    new FogWall("EarthenPeak_mid_bonfire",      "o00_0500_0001"),
    new FogWall("EarthenPeak_mytha_entry",      "o00_0500_0002", boss_enum_id: BossName.MythaTheBanefulQueen),
    new FogWall("EarthenPeak_covetous_exit",    "o00_0500_0003", boss_enum_id: BossName.CovetousDemon, boss_exit: true),
    new FogWall("EarthenPeak_mytha_exit",       "o00_0501_0000", boss_enum_id: BossName.MythaTheBanefulQueen, boss_exit: true),
    new FogWall("EarthenPeak_from_skele_lords", "o00_0501_0001", pvp: true),
};
fog_wall_dict[map_names[MapName.NomansWharf]] = new List<FogWall> {
    new FogWall("NMWharf_sentry_exit",  "o00_0500_0000", boss_enum_id: BossName.FlexileSentry, boss_exit: true),
    new FogWall("NMWharf_sentry_entry", "o00_0500_0001", boss_enum_id: BossName.FlexileSentry),
    new FogWall("NMWharf_from_heides",  "o00_0501_0000", pvp: true),
};
fog_wall_dict[map_names[MapName.IronKeepBelfrySol]] = new List<FogWall> {
    new FogWall("IronKeep_smelter_entry",          "o00_0500_0000", boss_enum_id: BossName.SmelterDemon),
    new FogWall("IronKeep_lava_pit_after_smelter", "o00_0500_0002"),
    new FogWall("IronKeep_belfry_exit",            "o00_0500_0003"),
    new FogWall("IronKeep_belfry_entry",           "o00_0500_0004"),
    new FogWall("IronKeep_OIK_entry",              "o00_0500_0005", boss_enum_id: BossName.OldIronKing, cutscene: true),
    new FogWall("IronKeep_OIK_exit",               "o00_0500_0006", boss_enum_id: BossName.OldIronKing, boss_exit: true, cutscene: true),
    new FogWall("IronKeep_smelter_exit",           "o00_0500_0007", boss_enum_id: BossName.SmelterDemon, boss_exit: true),
    new FogWall("IronKeep_smelter_to_bonfire",     "o00_0500_0008", pvp: true),
    new FogWall("IronKeep_pharros_to_belfry",      "o00_0500_0010", pvp: true), // TODO: can access from behind the lockstone door but cannot from the lockstone side
//    new FogWall("IK_belfry_entry",           "o00_0500_0011"), // duplicate of another maybe for pvp
    new FogWall("IK_from_EarthenPeak",       "o00_0501_0000", pvp: true),
};
fog_wall_dict[map_names[MapName.HuntsmanCopseUndeadPurgatory]] = new List<FogWall> {
    new FogWall("HuntsmanCopse_skelelords_entry", "o00_0501_0000", boss_enum_id: BossName.SkeletonLords, use_second_death_check_impl: true),
    new FogWall("HuntsmanCopse_chariot_entry",    "o00_0501_0001", boss_enum_id: BossName.ExecutionersChariot, cutscene: true),
    new FogWall("HuntsmanCopse_skelelords_exit",  "o00_0501_0004", boss_enum_id: BossName.SkeletonLords, boss_exit: true, use_second_death_check_impl: true),
    new FogWall("HuntsmanCopse_chariot_exit",     "o00_0501_0006", boss_enum_id: BossName.ExecutionersChariot, boss_exit: true, cutscene: true),
    new FogWall("HuntsmanCopse_from_majula",      "o00_0501_0007", pvp: true),
};
fog_wall_dict[map_names[MapName.TheGutterBlackGulch]] = new List<FogWall> {
    new FogWall("GutterBlackGulch_to_gutter_mid_bonfire", "o00_0500_0000"),
    new FogWall("GutterBlackGulch_rotten_exit",           "o00_0500_0001", boss_enum_id: BossName.TheRotten, boss_exit: true, cutscene: true),
    new FogWall("GutterBlackGulch_gulch_entry",           "o00_0501_0000"),
    new FogWall("GutterBlackGulch_from_GoS",              "o00_0501_0001", pvp: true),
    new FogWall("GutterBlackGulch_rotten_entry",          "o00_0503_0100", boss_enum_id: BossName.TheRotten, cutscene: true),
};
fog_wall_dict[map_names[MapName.DragonAerieDragonShrine]] = new List<FogWall> {
    new FogWall("DragonAerie_entrance",   "o00_0501_0000"),
    new FogWall("DragonAerie_ancient_dragon_entry", "o00_0502_0000", boss_enum_id: BossName.AncientDragon),
};
fog_wall_dict[map_names[MapName.MajulaShadedWoods]] = new List<FogWall> {
    new FogWall("MajulaToShadedWoods_entrance", "o00_0500_0100", pvp: true),
};
fog_wall_dict[map_names[MapName.HeidesTowerofFlame]] = new List<FogWall> {
    new FogWall("HeidesTowerOfFlame_dragonrider_entry",  "o00_0500_0000", boss_enum_id: BossName.Dragonrider),
    new FogWall("HeidesTowerOfFlame_dragonrider_exit",   "o00_0500_0001", boss_enum_id: BossName.Dragonrider, boss_exit: true),
    new FogWall("HeidesTowerOfFlame_to_majula",          "o00_0500_0002", pvp: true),
    new FogWall("HeidesTowerOfFlame_to_NMW",             "o00_0500_0100", pvp: true),
    new FogWall("HeidesTowerOfFlame_dragonslayer_entry", "o00_0501_0000", boss_enum_id: BossName.OldDragonslayer),
    new FogWall("HeidesTowerOfFlame_dragonslayer_exit",  "o00_0501_0001", boss_enum_id: BossName.OldDragonslayer, boss_exit: true),
};
fog_wall_dict[map_names[MapName.ShadedWoodsShrineofWinter]] = new List<FogWall> {
    new FogWall("ShadedWoods_najka_exit",   "o00_0500_0000", boss_enum_id: BossName.ScorpionessNajka, boss_exit: true),
    new FogWall("ShadedWoods_to_mist_area", "o00_0501_0001", pvp: true),
    new FogWall("ShadedWoods_najka_entry",  "o00_0503_0000", boss_enum_id: BossName.ScorpionessNajka), // y_offset = 85.080-85.672
};
fog_wall_dict[map_names[MapName.ShadedWoodsShrineofWinter]][2].offset = new Vector3(0.0f, -85.080f + 85.672f, 0.0f);
fog_wall_dict[map_names[MapName.DoorsofPharros]] = new List<FogWall> {
    new FogWall("DoorsOfPharros_rat_boss_exit",    "o00_0500_0000", boss_enum_id: BossName.RoyalRatAuthority, boss_exit: true),
    new FogWall("DoorsOfPharros_to_rat_boss", "o00_0500_0001", pvp: true),
    new FogWall("DoorsOfPharros_entrance",    "o00_0500_0002", pvp: true),
    new FogWall("DoorsOfPharros_rat_boss_entry",   "o00_0501_0000", boss_enum_id: BossName.RoyalRatAuthority),
};
fog_wall_dict[map_names[MapName.GraveofSaints]] = new List<FogWall> {
    new FogWall("GoS_entrance",    "o00_0500_0000", pvp: true),
    new FogWall("GoS_to_rat_boss", "o00_0501_0000", pvp: true),
    new FogWall("GoS_rat_entry",   "o00_0501_0001", boss_enum_id: BossName.RoyalRatVanguard),
    new FogWall("GoS_rat_exit",    "o00_0501_0002", boss_enum_id: BossName.RoyalRatVanguard, boss_exit: true),
};
fog_wall_dict[map_names[MapName.MemoryofVammarOrroandJeigh]] = new List<FogWall> {
    new FogWall("Memory_giant_entry", "o00_0500_0000", boss_enum_id: BossName.GiantLord),
    new FogWall("Memory_giant_exit",  "o00_0500_0001", boss_enum_id: BossName.GiantLord, boss_exit: true),
};
fog_wall_dict[map_names[MapName.ShrineofAmana]] = new List<FogWall> {
    new FogWall("ShrineOfAmana_Demon_entry",             "o00_0501_0000", boss_enum_id: BossName.DemonofSong),
    new FogWall("ShrineOfAmana_to_2nd_bonfire",          "o00_0501_0001"),
    new FogWall("ShrineOfAmana_to_harvals_rest_bonfire", "o00_0501_0005"),
    new FogWall("ShrineOfAmana_Demon_exit",              "o00_0501_0006", boss_enum_id: BossName.DemonofSong, boss_exit: true), // y_offset = 32.121f - 31.336f
    new FogWall("ShrineOfAmana_from_castle",             "o00_0501_0007", pvp: true),
};
fog_wall_dict[map_names[MapName.ShrineofAmana]][3].offset = new Vector3(0.0f, 32.121f - 31.336f, 0.0f);
//fog_wall_dict[map_names[MapName.DrangleicCastleThroneofWant]] = new List<FogWall> {
//    new FogWall("DC_mirror_knight_entry",     "o00_0501_0000", boss: true),
//    new FogWall("DC_twin_dragonriders_entry", "o00_0501_0001", boss: true),
//    new FogWall("DC_twin_dragonriders_exit",  "o00_0501_0004", boss: true, boss_exit: true),
//    new FogWall("DC_mirror_knight_exit",      "o00_0501_0005", boss: true, boss_exit: true),
//    new FogWall("DC_throne_room",             "o00_0501_0006", boss: true),
//    new FogWall("DC_to_chasm_entrance",       "o00_0501_0008", pvp: true), // y_offset = 70.787-72.757 // x_offset = -437.288 + 436.508
//    new FogWall("DC_entrance",                "o00_0504_0000", pvp: true),
//};
//fog_wall_dict[map_names[MapName.DrangleicCastleThroneofWant]][5].offset = new Vector3(-437.288f + 436.508f, -70.787f + 72.757f, 0.0f);
fog_wall_dict[map_names[MapName.UndeadCrypt]] = new List<FogWall> {
    new FogWall("UndeadCrypt_to_bonfire_room", "o00_0500_0000"),
    new FogWall("UndeadCrypt_velsdat_entry",   "o00_0501_0000", boss_enum_id: BossName.VelstadtTheRoyalAegis, cutscene: true),
    new FogWall("UndeadCrypt_velsdat_exit",    "o00_0501_0001", boss_enum_id: BossName.VelstadtTheRoyalAegis, boss_exit: true, cutscene: true),
    new FogWall("UndeadCrypt_entrance",        "o00_0502_0000", pvp: true),
    new FogWall("UndeadCrypt_vendrick_entry",  "o00_0505_0000", boss_enum_id: BossName.Vendrick), // TODO: should be allowed to leave the fight before aggroing him
};
//fog_wall_dict[map_names[MapName.DarkChasmofOld]] = new List<FogWall> {
//    new FogWall("DarkChasm_one_exit",   "o00_0501_0000"),
//    new FogWall("DarkChasm_two_exit",   "o00_0501_0001"),
//    new FogWall("DarkChasm_three_exit", "o00_0501_0002"),
//    new FogWall("DarkChasm_boss_exit",  "o00_0501_0003", boss: true, boss_exit: true), // y_offset = 13.792f - 11.966f
//};
//fog_wall_dict[map_names[MapName.DarkChasmofOld]][3].offset = new Vector3(0.0f, 13.792f - 11.966f, 0.0f);
//fog_wall_dict[map_names[MapName.ShulvaSanctumCity]] = new List<FogWall> {
//    new FogWall("Shulva_sihn_entry",                  "o00_0500_0001", boss: true), // y_offset = 79.928f - 79.436f
//    new FogWall("Shulva_elana_entry",                 "o00_0501_0000", boss: true), // y_offset = 71.928f - 71.637f
//    new FogWall("Shulva_gank_entry",                  "o00_0501_0002", boss: true),
//    new FogWall("Shulva_gank_exit",                   "o00_0501_0003", boss: true, boss_exit: true),
//    new FogWall("Shulva_to_gank_fight_from_bonfire",  "o00_0501_0005", pvp: true),
//    new FogWall("Shulva_entrance",                    "o00_0501_0007", pvp: true),
//    //new FogWall("Shulva_between_sihn_elana",          "o00_0501_0008"), //disabled (duplicate)
//    new FogWall("Shulva_between_sihn_elana2",         "o00_0501_0010"), // y_offset = 74.743797f - 73.291435f
//    new FogWall("Shulva_to_gank_fight_from_bonfire2", "o00_0501_0011"),
//    new FogWall("Shulva_near_jester_thomas",          "o00_0501_0012"), //y_offset = 41.540f - 41.289f
//};
//fog_wall_dict[map_names[MapName.ShulvaSanctumCity]][0].offset = new Vector3(0.0f, 79.928f - 79.436f, 0.0f);
//fog_wall_dict[map_names[MapName.ShulvaSanctumCity]][1].offset = new Vector3(0.0f, 71.928f - 71.637f, 0.0f);
//fog_wall_dict[map_names[MapName.ShulvaSanctumCity]][6].offset = new Vector3(0.0f, 5.0f * (74.744f - 73.291f) / 12.0f, 0.0f);
//fog_wall_dict[map_names[MapName.ShulvaSanctumCity]][8].offset = new Vector3(0.0f, 41.540f - 41.289f, 0.0f);
//fog_wall_dict[map_names[MapName.BrumeTower]] = new List<FogWall> {
//    new FogWall("DLC2_from_2nd_bonfire_to_center",          "o00_0500_0000"),
//    new FogWall("DLC2_to_central_bonfire_room",             "o00_0500_0001"),
//    new FogWall("DLC2_to_scorching_iron_sceptor_key_tower", "o00_0500_0002"),
//    new FogWall("DLC2_sir_alonne_entry",                    "o00_0500_0003", boss: true),
//    new FogWall("DLC2_sir_alonne_exit",                     "o00_0500_0004", boss: true, boss_exit: true),
//    new FogWall("DLC2_raime_entry",                         "o00_0501_0000", boss: true), // y_offset = 59.822f - 59.297f
//    new FogWall("DLC2_raime_exit",                          "o00_0501_0001", boss: true, boss_exit: true), //y_offset = 61.497f - 60.998f
//    new FogWall("DLC2_smelter_entry",                       "o00_0501_0002", boss: true), //y_offset = 26.875f - 26.556f
//    new FogWall("DLC2_smelter_exit",                        "o00_0501_0003", boss: true, boss_exit: true),
//    new FogWall("DLC2_entrance",                            "o00_0501_0006"),
//    new FogWall("DLC2_to_smelter_area",                     "o00_0501_0007"),
//    //new FogWall("DLC2_entrance",                            "o00_0501_0008"), // disabled (duplicate)
//};
//fog_wall_dict[map_names[MapName.BrumeTower]][5].offset = new Vector3(0.0f, 59.822f - 59.297f, 0.0f);
//fog_wall_dict[map_names[MapName.BrumeTower]][6].offset = new Vector3(0.0f, 61.497f - 60.998f, 0.0f);
//fog_wall_dict[map_names[MapName.BrumeTower]][7].offset = new Vector3(0.0f, 26.875f - 26.556f, 0.0f);
//fog_wall_dict[map_names[MapName.FrozenEleumLoyce]] = new List<FogWall> {
//    new FogWall("DLC3_aava_exit",         "o00_0500_0001", boss: true, boss_exit: true),
//    new FogWall("DLC3_after_getting_eye", "o00_0500_0002"),
//    new FogWall("DLC3_ivory_king_entry",  "o00_0500_0003", boss: true),
//    new FogWall("DLC3_2cats_entry",       "o00_0501_0003", boss: true),
//    new FogWall("DLC3_aava_entry",        "o00_0501_0005", boss: true),
//    new FogWall("DLC3_2cats_exit",        "o00_0501_0006", boss: true, boss_exit: true),
//    new FogWall("DLC3_to_cathedral",      "o00_0501_0007", pvp: true), // y_offset = 25.841f - 23.046f
//};
//fog_wall_dict[map_names[MapName.FrozenEleumLoyce]][6].offset = new Vector3(0.0f, 25.841f - 23.046f, 0.0f);

foreach (var kvp in fog_wall_dict)
{
    string map_name = kvp.Key;
    List<FogWall> fog_walls = kvp.Value;

    for (int i = 0; i < fog_walls.Count; i++)
    {
        var fog_wall = fog_walls[i];

        if (fog_wall.enum_id != BossName.None)
        {
            if (fog_wall.cutscene)
            {
                fog_wall.event_id = boss_event_ids[fog_wall.enum_id];
            }
            fog_wall.destruction_flag = boss_destruction_flags[fog_wall.enum_id];
        }
    }
}

Dictionary<string, int> warp_map_id = new Dictionary<string, int>();
foreach(var mn in map_names)
{
    warp_map_id[mn.Value] = parse_map_name(mn.Value);
}

String ezstate_path = Path.Join(mod_folder, "ezstate");
int warp_obj_idx = -1;
int warp_obj_inst_idx = -1;
MSB2.Part.Object? warp_obj = null;
MSB2.Model? warp_model = null;
PARAM.Row? warp_obj_inst = null;
String py_files_list = "";
foreach (var pair in map_names)
{
    String map_name = pair.Value;

    // hardcoded to 1000
    //int warp_obj_begin = warp_object_begin_list[map_name];
    int warp_obj_begin = 1000;

    int n_fog_walls = fog_wall_dict[map_name].Count;

    String map_path               = Path.Join(mod_folder, "map", map_name, map_name + ".msb");
    String param_event_loc_path   = Path.Join(mod_folder, "Param", "eventlocation_" + map_name + ".param");
    String param_event_path       = Path.Join(mod_folder, "Param", "eventparam_" + map_name + ".param");
    String obj_inst_param_path    = Path.Join(mod_folder, "Param", "mapobjectinstanceparam_" + map_name + ".param");
    String esd_script_path        = Path.Join(mod_folder, "ezstate", $"event_{map_name}.py");

    MSB2  map               = load_map(map_path);
    PARAM param_event_loc   = load_map_param(param_event_loc_path);
    PARAM param_event       = load_map_param(param_event_path);
    PARAM obj_inst_param    = load_map_param(obj_inst_param_path);

    obj_inst_param.ApplyParamdef(get_obj_inst_def_paramdef(obj_inst_param));
    param_event.ApplyParamdef(get_event_param_def_paramdef(param_event));
    param_event_loc.ApplyParamdef(get_event_loc_def_paramdef(param_event_loc));

    String path = check_backup(esd_script_path);
    String esd_script = read_string_from_file(path);
    esd_script += "##Generated by DS2SFogGateRando##\n";
    esd_script += get_script_helper_fns(map_name, warp_map_id[map_name]);

    // get the instance id from map name
    for (int i=0; i<map.Parts.Objects.Count; i++)
    {
        var obj = map.Parts.Objects[i];
        for (int j=0; j < fog_wall_dict[map_name].Count; j++)
        {
            if (obj.Name == fog_wall_dict[map_name][j].map_name)
            {
                fog_wall_dict[map_name][j].instance_id = obj.MapObjectInstanceParamID;
                break;
            }
        }
    }

    // if the fog gate is exit fog gate get the fog gate instance id of its main fog gate
    // and store in the twin_gate_id
    for (int i=0; i < fog_wall_dict[map_name].Count; i++)
    {
        var fog_wall = fog_wall_dict[map_name][i];
        if (fog_wall.boss_exit && fog_wall.cutscene)
        {
            for (int j = 0; j < fog_wall_dict[map_name].Count; j++)
            {
                if (i == j) continue;
                var twin_fog_wall = fog_wall_dict[map_name][j];
                if (twin_fog_wall.enum_id == fog_wall.enum_id)
                {
                    fog_wall.twin_gate_id = twin_fog_wall.instance_id;
                    break;
                }
            }
        }
    }

    // do this only for things betwixt: m10_02_00_00
    if (map_name == map_names[MapName.ThingsBetwixt])
    {
        // get the model out of the map
        for (int i=0; i<map.Models.Objects.Count; i++)
        {
            var model = map.Models.Objects[i];
            if (model.Name == warp_obj_model_name)
            {
                warp_model = model.DeepCopy();
                break;
            }
        }

        // get the object to be used for warping
        for (int i = 0; i < map.Parts.Objects.Count; i++)
        {
            warp_obj = map.Parts.Objects[i];
            if (warp_obj.Name == warp_obj_name)
            {
                warp_obj_idx = i;
                break;
            }
        }

        // get the object instance to be used for warping
        for (int i = 0; i < obj_inst_param.Rows.Count; i++)
        {
            warp_obj_inst = obj_inst_param.Rows[i];
            if (warp_obj_inst.ID == warp_obj_inst_id)
            {
                warp_obj_inst_idx = i;
                break;
            }
        }
    } 
    else // for maps other than Things Betwixt
    {
        // add warp_model to the map model list
        Debug.Assert(warp_model != null);
        map.Models.Add(warp_model);
    }

    // check if the object was found
    Debug.Assert(warp_model != null);
    Debug.Assert(warp_obj_idx >= 0);
    Debug.Assert(warp_obj_inst_idx >= 0);
    Debug.Assert(warp_obj != null);
    Debug.Assert(warp_obj_inst != null);

    // get all the fog walls in the map and create a list of their
    // postion, rotation and draw groups
    List<Vector3> pos_fog_walls  = new List<Vector3>();
    List<Vector3> rot_fog_walls  = new List<Vector3>();
    List<uint[]> draw_groups = new List<uint[]>();
    foreach (var fw in fog_wall_dict[map_name])
    {
        MSB2.Part.Object? fog_wall = null;
        for (int j = 0; j < map.Parts.Objects.Count; j++)
        {
            MSB2.Part.Object obj = map.Parts.Objects[j];
            if (obj.Name == fw.map_name)
            {
                fog_wall = obj;
                break;
            }
        }
        if (fog_wall == null)
        {
            Console.WriteLine($"[ERROR] failed to find fog_wall_id: {fw.name}");
            Debug.Assert(false);
        }
        if (fw.offset != null)
        {
            pos_fog_walls.Add(fog_wall.Position + (Vector3)fw.offset);
        } else
        {
            pos_fog_walls.Add(fog_wall.Position);
        }
        rot_fog_walls.Add(fog_wall.Rotation);
        draw_groups.Add(fog_wall.DrawGroups);
    }

    // disable fog gates
    foreach (var entry in fog_wall_dict[map_name])
    {
        for (int i = 0; i < obj_inst_param.Rows.Count; i++)
        {
            var row = obj_inst_param.Rows[i];
            if (row.ID == entry.instance_id)
            {
                var new_row = new Row(
                    row.ID,
                    $"objinstance_{row.ID}",
                    get_obj_inst_def_paramdef_fogwall(obj_inst_param)
                );
                // TODO: this may cause errors
                // new_row.DataOffset = row.DataOffset;
                obj_inst_param.Rows.Remove(row);
                obj_inst_param.Rows.Insert(i, new_row);
            }
        }
    }
    // calculate warp_point_begin
    int warp_point_begin = -1;
    int n_warp_points = 2 * n_fog_walls;

    for (int i=0; i<param_event_loc.Rows.Count; i++)
    {
        var row = param_event_loc.Rows[i];
        if (i+1 < param_event_loc.Rows.Count)
        {
            var next_row = param_event_loc.Rows[i+1];
            if (next_row.ID - row.ID > n_warp_points)
            {
                warp_point_begin = row.ID + 1;
                break;
            }
        }
        else if (param_event_loc.Rows.Count == 1)
        {
            warp_point_begin = row.ID + 1;
        }
        else if (param_event_loc.Rows.Count == i+1)
        {
            warp_point_begin = row.ID + 1;
        }
        else
        {
            // Unreachable
            Debug.Assert(false);
        }
    }
    Debug.Assert(warp_point_begin >= 0);

    // calculate warp_obj_inst_begin and
    // calculate the obj instance insert location
    int warp_obj_inst_begin = -1;
    int obj_inst_insert_loc = -1;
    for (int i = 0; i < obj_inst_param.Rows.Count; i++)
    {
        var row = obj_inst_param.Rows[i];
        if (obj_inst_param.Rows.Count == 0 || i+1 == obj_inst_param.Rows.Count)
        {
            warp_obj_inst_begin = row.ID + 1;
            obj_inst_insert_loc = i + 1;
        }
        else if (i+1 < obj_inst_param.Rows.Count)
        {
            var next_row = obj_inst_param.Rows[i+1];
            if (next_row.ID - row.ID > n_warp_points)
            {
                warp_obj_inst_begin = row.ID + 1;
                obj_inst_insert_loc = i + 1;
                break;
            }
        }
        else
        {
            // Unreachable
            Debug.Assert(false);
        }
    }
    Debug.Assert(warp_obj_inst_begin >= 0);
    Debug.Assert(obj_inst_insert_loc >= 0);

    // calculate event_loc_insert_loc
    int event_loc_insert_loc = -1;
    for (int i=0; i< param_event_loc.Rows.Count; i++)
    {
        var row = param_event_loc.Rows[i];
        if (row.ID == warp_point_begin - 1)
        {
            event_loc_insert_loc = i + 1;
            break;
        }
    }
    Debug.Assert(event_loc_insert_loc >= 0);

    // cacluate esd_script_begin
    int esd_script_begin = -1;
    for (int i=0; i<param_event.Rows.Count; i++)
    {
        var row = param_event.Rows[i];
        if (param_event.Rows.Count == 0) esd_script_begin = row.ID + 1;
        else if (i + 1 == param_event.Rows.Count) esd_script_begin = row.ID + 1;
        else if (i + 1 < param_event.Rows.Count)
        {
            var next_row = param_event.Rows[i + 1];
            if (next_row.ID - row.ID > n_warp_points)
            {
                esd_script_begin = row.ID + 1;
                break;
            }
        }
        else Debug.Assert(false); //unreachable
    }
    Debug.Assert(esd_script_begin >= 0);
    int event_param_begin = esd_script_begin;

    Vector3 pos_offs_event_loc;
    if (map.Events.MapOffsets.Count > 0)
    {
        pos_offs_event_loc = map.Events.MapOffsets[0].Translation;
    } else
    {
        pos_offs_event_loc = new Vector3(0.0f);
    }

    // generate the objects and events for all the fog walls in the map
    for (int i=0; i< pos_fog_walls.Count; i++)
    {
        FogWall fw = fog_wall_dict[map_name][i];
        if (fw.reverse)
        {
            rot_fog_walls[i] = vector3_flip_y(rot_fog_walls[i]);
        }
        if (boss_script_change.Keys.Contains(fw.enum_id))
        {
            if (fw.destruction_flag > 0 && !fw.boss_exit)
            {

                for (int j=0; j<boss_script_change[fw.enum_id].Count; j++)
                {
                    esd_script = esd_script.Replace(boss_script_change[fw.enum_id][j].from, boss_script_change[fw.enum_id][j].to);
                }
            }
        }
        // create and add new map peice in front of the fog door
        var obj = (MSB2.Part.Object)warp_obj.DeepCopy();
        Debug.Assert(obj != null);
        obj.Position = pos_fog_walls[i];
        obj.Rotation = rot_fog_walls[i];
        obj.Name = "o02_1050_" + format_int_to_str(warp_obj_begin, 4);
        obj.MapObjectInstanceParamID = warp_obj_inst_begin;
        for (int j=0; j<obj.DrawGroups.Length; j++)
        {
            obj.DrawGroups[j] = 0;
            //obj.DrawGroups[j] = draw_groups[i][j]; // this makes the dummy object visible
        }
        for (int j=0; j<obj.DispGroups.Length; j++)
        {
            obj.DispGroups[j] = draw_groups[i][j];
        }
        map.Parts.Objects.Add(obj);

        // create and add new map peice in behind of the fog door
        var obj2 = (MSB2.Part.Object)warp_obj.DeepCopy();
        Debug.Assert(obj2 != null);
        obj2.Position = pos_fog_walls[i];
        obj2.Rotation = vector3_flip_y(rot_fog_walls[i]);
        obj2.Name = "o02_1050_" + format_int_to_str(warp_obj_begin+1, 4);
        obj2.MapObjectInstanceParamID = warp_obj_inst_begin + 1;
        for (int j = 0; j < obj.DrawGroups.Length; j++)
        {
            obj2.DrawGroups[j] = 0;
            //obj2.DrawGroups[j] = draw_groups[i][j]; // this makes the dummy object visible
        }
        for (int j = 0; j < obj2.DispGroups.Length; j++)
        {
            obj2.DispGroups[j] = draw_groups[i][j];
        }
        map.Parts.Objects.Add(obj2);


        // create and add new object instance param for piece in front of fog door
        var warp_obj_inst_row = new Row(
            warp_obj_inst_begin,
            $"objinstance_{warp_obj_inst_begin}",
            get_obj_inst_def_paramdef(obj_inst_param)
        );
        // it is necessay to insert in between or else it does not work
        obj_inst_param.Rows.Insert(obj_inst_insert_loc, warp_obj_inst_row);

        // create and add new object instance param for piece behind of fog door
        var warp_obj_inst_row2 = new Row(
            warp_obj_inst_begin + 1,
            $"objinstance_{warp_obj_inst_begin + 1}",
            get_obj_inst_def_paramdef(obj_inst_param)
        );
        // it is necessay to insert in between or else it does not work
        obj_inst_param.Rows.Insert(obj_inst_insert_loc + 1, warp_obj_inst_row2);

        // create and add new event param for infront of fog door
        var warp_event_row = new Row(
            event_param_begin,
            $"event_{event_param_begin}",
            get_event_param_def_paramdef_ex(
                param_event,
                event_param_begin,
                warp_obj_inst_begin
            )
        );
        param_event.Rows.Add(warp_event_row);

        // create and add new event param for behind of fog door
        var warp_event_row2 = new Row(
            event_param_begin + 1,
            $"event_{event_param_begin + 1}",
            get_event_param_def_paramdef_ex(
                param_event,
                event_param_begin + 1,
                warp_obj_inst_begin + 1
            )
        );
        param_event.Rows.Add(warp_event_row2);

        // create and add the new warp points behind the fog door
        var warp_point_row = new Row(
            warp_point_begin,
            $"eventloc_{warp_point_begin}",
            get_event_loc_def_paramdef_ex(
                param_event_loc,
                vector3_move(pos_fog_walls[i] - pos_offs_event_loc, rot_fog_walls[i], -1), 
                rot_fog_walls[i]
            )
        );
        param_event_loc.Rows.Insert(event_loc_insert_loc, warp_point_row);

        // adjust the boss spawn event loc to the warp point if the boss should spawn
        if (fw.destruction_flag >= 0) // if the fog door contains the boss
        {
            if (boss_spawn_event_loc.Keys.Contains(fw.enum_id)) // if the spawn event loc is populated
            {
                if (!fw.boss_exit) // if it is the entry gate
                {
                    for (int j = 0; j < param_event_loc.Rows.Count; j++)
                    {
                        var row = param_event_loc.Rows[j];
                        if (row.ID == boss_spawn_event_loc[fw.enum_id])
                        {
                            var new_row = new Row(
                                row.ID,
                                $"eventloc_{row.ID}",
                                get_event_loc_def_paramdef_boss_spawn_point(param_event_loc, 
                                    vector3_move(pos_fog_walls[i] - pos_offs_event_loc, rot_fog_walls[i], -1),
                                    rot_fog_walls[i]
                                )
                            );
                            param_event_loc.Rows.Remove(row);
                            param_event_loc.Rows.Insert(j, new_row);
                            break;
                        }
                    }
                }
            }

        }

        // create and add the new warp points infront the fog door
        var warp_point_row2 = new Row(
            warp_point_begin + 1,
            $"eventloc_{warp_point_begin + 1}",
            get_event_loc_def_paramdef_ex(
                param_event_loc,
                vector3_move(pos_fog_walls[i] - pos_offs_event_loc, rot_fog_walls[i], 1),
                vector3_flip_y(rot_fog_walls[i])
            )
        );
        param_event_loc.Rows.Insert(event_loc_insert_loc + 1, warp_point_row2);

        // generate and update the esd script for infront of fogdoor
        if (fw.destruction_flag > 0 && fw.boss_exit) // add condition to prevent player from leaving
        {
            if (fw.use_second_death_check_impl)
            {
                esd_script += generate_esd_script_boss_from_behind_v2(
                    map_name,
                    esd_script_begin,
                    warp_obj_inst_begin,
                    warp_point_begin,
                    fw
                );
            } else
            {
                esd_script += generate_esd_script_boss_from_behind(
                    map_name,
                    esd_script_begin,
                    warp_obj_inst_begin,
                    warp_point_begin,
                    fw
                );
            }
        }
        else if (fw.destruction_flag > 0 && !fw.boss_exit && fw.cutscene)
        {
            esd_script += generate_esd_script_boss_cutscene(
                map_name,
                esd_script_begin,
                warp_obj_inst_begin,
                warp_point_begin,
                fw
            );
        }
        else
        {
            esd_script += generate_esd_script(
                map_name,
                esd_script_begin,
                warp_obj_inst_begin,
                warp_point_begin
            );
        }

        // generate and update the esd script for behind of fogdoor
        if (fw.destruction_flag > 0 && !fw.boss_exit) // add condition to prevent player from leaving
        {
            if (fw.use_second_death_check_impl)
            {
                esd_script += generate_esd_script_boss_from_behind_v2(
                    map_name,
                    esd_script_begin + 1,
                    warp_obj_inst_begin + 1,
                    warp_point_begin + 1,
                    fw
                );
            }
            else
            {
                esd_script += generate_esd_script_boss_from_behind(
                    map_name,
                    esd_script_begin + 1,
                    warp_obj_inst_begin + 1,
                    warp_point_begin + 1,
                    fw
                );
            }
        }
        else if (fw.destruction_flag > 0 && fw.boss_exit && fw.cutscene) // entering from behind the fog gate and cutscene has to play
        {
            esd_script += generate_esd_script_boss_cutscene(
                map_name,
                esd_script_begin + 1,
                warp_obj_inst_begin + 1,
                warp_point_begin + 1,
                fw
            );
        }
        else
        {
            esd_script += generate_esd_script(
                map_name,
                esd_script_begin + 1,
                warp_obj_inst_begin + 1,
                warp_point_begin + 1
            );
        }

        // update the variables for next object
        warp_obj_inst_begin += 2;
        warp_obj_begin += 2;
        esd_script_begin += 2;
        event_param_begin += 2;
        obj_inst_insert_loc += 2;
        warp_point_begin += 2;
        event_loc_insert_loc += 2;
    }

    // generate esd file from script
    write_string_to_file(esd_script, esd_script_path);
    py_files_list += $" {esd_script_path}";
    
    // write the modded files
    byte[] map_bin = map.Write();
    byte[] obj_inst_param_bin = obj_inst_param.Write();
    byte[] event_param_bin = param_event.Write();
    byte[] event_loc_bin = param_event_loc.Write();
    try
    {
        File.WriteAllBytes(map_path, map_bin);
        File.WriteAllBytes(obj_inst_param_path, obj_inst_param_bin);
        File.WriteAllBytes(param_event_path, event_param_bin);
        File.WriteAllBytes(param_event_loc_path, event_loc_bin);
        Console.WriteLine($"[SUCCESS] {map_name} done!\n");
    }
    catch (IOException ex)
    {
        Console.WriteLine($"[ERROR] {ex.Message}");
    }
    catch (UnauthorizedAccessException ex)
    {
        Console.WriteLine($"[ERROR] Access denied. {ex.Message}");
    }
}

// run the esdtool.exe to generate esd files from python files
String esdtool_path = Path.GetFullPath("./esdtool/esdtool.exe");
String arguments = $"-ds2s -basedir \"{game_dir}\" -moddir {mod_folder} -backup -i{py_files_list} -writeloose {Path.Join(ezstate_path, "%e.esd")}";
Debug.Assert(File.Exists(esdtool_path));
run_external_command(esdtool_path, arguments);