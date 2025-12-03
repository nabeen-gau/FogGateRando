using FogWallNS;
using SoulsFormats;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Numerics;
using System.Text;
using static SoulsFormats.PARAM;
using static SoulsFormats.PARAMDEF;

MSB2 load_map(String path)
{
    String new_path = Util.check_backup(path);
    MSB2 msb2 = MSB2.Read(new_path);
    Console.WriteLine($"[SUCCESS] Map: {path} loaded");
    return msb2;
}

PARAM load_map_param(String path)
{
    String new_path = Util.check_backup(path);
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

PARAMDEF get_event_loc_def_paramdef_ex(PARAM param, Vector3 position, Vector3 rotation, UInt16 unk2a = 2560)
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
    pd.Fields.Add(new_field(PARAMDEF.DefType.u16, "Unk2A", unk2a));
    pd.Fields.Add(new_field(PARAMDEF.DefType.u32, "Unk2C", 0));
    return pd;
}

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

String generate_esd_script(String map_name, int script_id, int warp_src_id, int warp_dest_id, int dst_map_id)
{
    String map_id = map_name.Substring(0, 6);
    return @$"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Normal fog gate event""""""
    assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id}, map_id={dst_map_id})
    RestartMachine()
    Quit()
";
}

String generate_esd_script_boss_from_behind(String map_name, int script_id, int warp_src_id, int warp_dest_id, int dst_map_id,
    BossName boss_name, String name, int destruction_flag)
{
    Debug.Assert(boss_name != BossName.None);
    String map_id = map_name.Substring(0, 6);
    return @$"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Boss({name}) fog gate event""""""
    DisableObjKeyGuide({warp_src_id}, 1)
    call = event_{map_id}_x505(flag8={destruction_flag})
    if call.Get() == 1:
        DisableObjKeyGuide({warp_src_id}, 0)
        assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id}, map_id={dst_map_id})
    elif call.Get() == 0:
        pass
    RestartMachine()
    Quit()
";
}

String generate_esd_script_boss_from_behind_v2(String map_name, int script_id, int warp_src_id, int warp_dest_id, int dst_map_id, 
    BossName boss_name, String name, int destruction_flag)
{
    Debug.Assert(boss_name != BossName.None);
    String map_id = map_name.Substring(0, 6);
    return @$"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Boss({name}) fog gate event""""""
    DisableObjKeyGuide({warp_src_id}, 1)
    assert event_{map_id}_x504(battle_id={destruction_flag})
    DisableObjKeyGuide({warp_src_id}, 0)
    assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id}, map_id={dst_map_id})
    RestartMachine()
    Quit()
";
}

String generate_vendrick_fog_gate_script(String map_name, int script_id, int warp_src_id, int warp_dest_id,
    int dst_map_id, BossName boss_name, String name, int destruction_flag)
{
    Debug.Assert(boss_name == BossName.Vendrick);
    String map_id = map_name.Substring(0, 6);
    return $@"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Boss({name}) fog gate event""""""
    DisableObjKeyGuide({warp_src_id}, 1)
    call = event_{map_id}_x505(flag8={destruction_flag})
    if call.Get() == 1:
        DisableObjKeyGuide({warp_src_id}, 0)
        assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id}, map_id={dst_map_id})
    elif call.Get() == 0:
        CompareEventFlag(0, {Constants.vendricks_hostility_flag}, 1)
        if ConditionGroup(0):
            pass
        else:
            DisableObjKeyGuide({warp_src_id}, 0)
            assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id}, map_id={dst_map_id})
    RestartMachine()
    Quit()
";
}

// NOTES
//# SetEventFlag(403000001, 1) # shadedwoods
//# SetEventFlag(403000002, 1) # castle
//# SetEventFlag(403000003, 1) # gulch

String generate_dark_chasm_fog_gate_script(String map_name, int script_id, int warp_src_id, int warp_dest_id, int dst_map_id,
    List<int> enemies_ids, int chasm_event_flag, String name)
{
    String map_id = map_name.Substring(0, 6);
    String ret = $@"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Dark chasm({name}) fog gate event""""""
    DisableObjKeyGuide({warp_src_id}, 1)
";
    foreach (int id in enemies_ids)
    {
        ret += $"    IsChrDeadOrRespawnOver(8, {id}, 1)\n";
    }
    ret += @$"    if ConditionGroup(8):
        DisableObjKeyGuide({warp_src_id}, 0)
        assert event_{map_id}_x502(warp_obj_inst_id={warp_src_id})
        SetEventFlag({chasm_event_flag}, 1)
        assert event_{map_id}_x503(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id}, map_id={dst_map_id})
    else:
        pass
    RestartMachine()
    Quit()
";
    return ret;
}

String generate_throne_room_exit_script(String map_name, int script_id, int warp_src_id, int warp_dest_id, int dst_map_id)
{
    String map_id = map_name.Substring(0, 6);
    return $@"
def event_{map_id}_1010():
    """"""State 0,2: [Preset] Throne room exit fog gate event""""""
    # disable the prompt
    DisableObjKeyGuide({warp_src_id}, 1)
    # check if throne duo is dead?
    call = event_{map_id}_x505(flag8={Constants.throne_watcher_defender_defeat_flag})
    # if the throne duo is dead
    if call.Get() == 1:
        # check if the giant lord is dead
        CompareEventFlag(0, {Constants.giant_lord_defeat_flag}, 0)
        # if the giant lord is not dead
        if ConditionGroup(0):
            # enable the prompt
            DisableObjKeyGuide({warp_src_id}, 0)
            assert event_{map_id}_x501(warp_obj_inst_id={warp_src_id}, event_loc={warp_dest_id}, map_id={dst_map_id})
        else:
            pass
    elif call.Get() == 0:
        pass
    RestartMachine()
    Quit()
";

}

String generate_cutscene_event_script(String map_name, int script_id, int warp_dst_id, int fog_gate_id)
{
    String map_id = map_name.Substring(0, 6);
    return $@"
def event_{map_id}_{script_id}():
    """"""State 0,2: [Preset] Cutscene play event""""""
    assert InGame() != 0
    IsPlayerInsidePoint(0, {warp_dst_id}, {warp_dst_id}, 1)
    assert ConditionGroup(0)
    ChangeObjState({fog_gate_id}, 100)
    assert CompareObjStateId({fog_gate_id}, 100, 1)
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

void recursive_add(List<Connection> to_skip)
{
    int to_skip_count = to_skip.Count;
    int modify_count = 0;
    for (int i = 0; i < to_skip_count; i++)
    {
        foreach (var added_item in GateConnections.items)
        {
            if (to_skip[i].Contains(added_item) && !to_skip.Contains(added_item))
            {
                to_skip.Add(added_item);
                modify_count++;
            }
        }
    }
    if (modify_count > 0)
    {
        recursive_add(to_skip);
    }
}

void check_connection(Connection item, List<Connection> to_skip)
{
    int modify_count = 0;
    foreach (var added_item in GateConnections.items)
    {
        if (item.Contains(added_item) && !to_skip.Contains(added_item))
        {
            to_skip.Add(added_item);
            modify_count++;
        }
    }
    recursive_add(to_skip);
}

// create a list of connection segments
List<List<Connection>> segments = new();
List<Connection> to_skip = new();
List<Connection> to_skip_global = new();
for (int i = 0; i < GateConnections.items.Count; i++)
{
    var item = GateConnections.items[i];
    if(to_skip_global.Contains(item))
    {
        continue;
    }
    to_skip.Clear();
    check_connection(item, to_skip);
    to_skip_global.AddRange(to_skip);
    segments.Add(new(to_skip));
}
var flat_connection_list = segments.SelectMany(g => g).ToList();
var duplicates = flat_connection_list
    .GroupBy(x => x)
    .Where(g => g.Count() > 1)
    .Select(g => g.Key)
    .ToList();
Debug.Assert(duplicates.Count == 0);

// TODO: change these before the final version
String mod_folder = Path.GetFullPath(@"..\..\..\..\..\mod");
String game_dir = Path.GetFullPath("..\\..\\..\\..\\..\\..\\Dark Souls II\\Dark Souls II");

String warp_obj_name = "o02_1050_0000";
String warp_obj_model_name = warp_obj_name.Substring(0, 8);
int warp_obj_inst_id = 10021101;

Dictionary<WarpNode, List<int>> chasm_enemy_ids = new Dictionary<WarpNode, List<int>>()
{
    {WarpNode.DarkChasmFromBlackGulchExitFront, new List<int>(){1005, 1006, 1007, 1008, 3200, 3210 } },
    {WarpNode.DarkChasmFromDrangleicCastleExitFront, new List<int>(){1004, 1009, 1012, 3100} },
    {WarpNode.DarkChasmFromShadedWoodsExitFront, new List<int>(){1000, 1002, 1003, 3000} },
};

Dictionary<WarpNode, int> chasm_event_flags = new()
{
    {WarpNode.DarkChasmFromShadedWoodsExitFront, 403000001},
    {WarpNode.DarkChasmFromDrangleicCastleExitFront, 403000002},
    {WarpNode.DarkChasmFromBlackGulchExitFront, 403000003},
};


Dictionary<BossName, int> boss_spawn_event_loc = new Dictionary<BossName, int>()
{
    {BossName.TheDukesDearFreja, 100000 },
    {BossName.OldIronKing, 1500000 },
    {BossName.Darklurker, 200000 }
};

Dictionary<BossName, EventID> boss_quitout_event_loc = new ()
{
    {BossName.Vendrick, new EventID(5000000, new Vector3(138.692612f, 19.494614f, 169.913712f)) },
};

// in event param if
// 0x8 - 0xa = 0
// 0xa = 1
// 0xc = 0
// 0xd = 5
// 0xe - 0xf = 0
// the event is for cutscene
// for nashandra = 12010
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
    {BossName.ThroneWatcherAndDefender, 12010 },
};

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
    {BossName.TwinDragonrider,              221000081},
    {BossName.LookingGlassKnight,           221000086},
    {BossName.DemonofSong,                  211000081},
    {BossName.VelstadtTheRoyalAegis,        224000081},
    {BossName.Vendrick,                     224000086},
    {BossName.GuardianDragon,               115000081},
    {BossName.AncientDragon,                127000081},
    {BossName.GiantLord,                    210000081},
    {BossName.ThroneWatcherAndDefender,     221000091},
    {BossName.Nashandra,                    221000096},
    {BossName.AldiaScholarOfTheFirstSin,    221000006},
    {BossName.Darklurker,                   403000081},
    {BossName.ElanaTheSqualidQueen,         535000081},
    {BossName.SinhTheSlumberingDragon,      535000096},
    {BossName.Gankfight,                    535000091},
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
    { MapName.DrangleicCastleThroneofWant,  "m20_21_00_00"},
    { MapName.UndeadCrypt,                  "m20_24_00_00"},
    { MapName.DragonMemories,               "m20_26_00_00"}, // disabled (no fog gates)
    { MapName.DarkChasmofOld,               "m40_03_00_00"},
    { MapName.ShulvaSanctumCity,            "m50_35_00_00"},
    { MapName.BrumeTower,                   "m50_36_00_00"},
    { MapName.FrozenEleumLoyce,             "m50_37_00_00"},
    { MapName.MemoryoftheKing,              "m50_38_00_00"}, // disabled (no fog gates)
};

Dictionary<String, List<FogWall>> fog_wall_dict = new Dictionary<string, List<FogWall>>();
fog_wall_dict[map_names[MapName.ThingsBetwixt]] = new List<FogWall> {
    new FogWall(WarpNode.Tutorial1EntryFront, "o00_0500_0001"),
    new FogWall(WarpNode.Tutorial2EntryFront, "o00_0500_0003"),
    new FogWall(WarpNode.Tutorial3EntryFront, "o00_0500_0004", front_blocked: true),
    new FogWall(WarpNode.Tutorial1ExitFront,  "o00_0500_0000"),
    new FogWall(WarpNode.Tutorial2ExitFront,  "o00_0500_0005"),
    new FogWall(WarpNode.Tutorial3ExitFront,  "o00_0500_0002"),
};
fog_wall_dict[map_names[MapName.Majula]] = new List<FogWall> {
    //new FogWall("Ma_limbo_1",    "o00_0501_0000", pvp: true), //disabled
    //new FogWall("Ma_limbo_2",    "o00_0501_0001", pvp: true), //disabled
    //new FogWall("Ma_limbo_3",    "o00_0501_0002", pvp: true), //disabled
    new FogWall(WarpNode.MajulaToForestOfFallenGiantsFront, "o00_0501_0100", pvp: true),
    new FogWall(WarpNode.MajulaToGraveOfSaintsFront, "o00_0501_0101", pvp: true, reverse: true), // y_offset = 43.455 - 42.057
    new FogWall(WarpNode.MajulaToHuntsmanCopseFront, "o00_0501_0102", pvp: true), // y_offset = 1.390f - 0.413f
    new FogWall(WarpNode.MajulaToRotundaLockstoneFront, "o00_0501_0103", pvp: true),
    new FogWall(WarpNode.MajulaToGutterFront, "o00_0501_0104", pvp: true), // y_offset = 71.218 - 69.941
    new FogWall(WarpNode.MajulaToShadedWoodsFront, "o00_0502_0103", pvp: true),
};
fog_wall_dict[map_names[MapName.Majula]][1].offset = new Vector3(0.0f, 43.455f - 42.057f, 0.0f);
fog_wall_dict[map_names[MapName.Majula]][2].offset = new Vector3(0.0f,  1.390f -  0.413f, 0.0f);
fog_wall_dict[map_names[MapName.Majula]][4].offset = new Vector3(0.0f, 71.218f - 69.941f, 0.0f);
fog_wall_dict[map_names[MapName.ForestOfTheFallenGiants]] = new List<FogWall> {
    new FogWall(WarpNode.LastGiantEntryFront, "o00_0501_0001", boss_name: BossName.TheLastGiant, cutscene: true),
    new FogWall(WarpNode.PursuerEntryFront, "o00_0501_0003", boss_name: BossName.ThePursuer, cutscene: true), // y_offset = 10.090f - 6.001f
    new FogWall(WarpNode.PursuerExitFront, "o00_0500_0004", boss_name: BossName.ThePursuer, boss_exit: true, cutscene: true),
    new FogWall(WarpNode.ForestOfFallenGiantsBalconyFront, "o00_0500_0000"),
    new FogWall(WarpNode.ForestOfFallenGiantsToCaleFront, "o00_0500_0003"),
    new FogWall(WarpNode.ForestOfFallenGiantsAfterFirstBonfireFront, "o00_0500_0002"),
    new FogWall(WarpNode.ForestOfFallenGiantsFromMajulaFront, "o00_0501_0002", pvp: true),
    new FogWall(WarpNode.ForestOfFallenGiantsToPursuerArenaFront, "o00_0500_0005", pvp: true),
};
fog_wall_dict[map_names[MapName.ForestOfTheFallenGiants]][1].offset = new Vector3(0.0f, 10.090f - 6.001f, 0.0f);
fog_wall_dict[map_names[MapName.BrightstoneCoveTseldora]] = new List<FogWall> {
    new FogWall(WarpNode.CongregationEntryFront, "o00_0500_0000", boss_name: BossName.ProwlingMagusAndCongregation),
    new FogWall(WarpNode.CongregationExitFront, "o00_0500_0001", boss_name: BossName.ProwlingMagusAndCongregation, boss_exit: true),
    new FogWall(WarpNode.BrightstoneCoveToDoorsOfPharrosFront, "o00_0500_0002", pvp: true),
    new FogWall(WarpNode.DukesDearFreyjaExitFront, "o00_0501_0001", boss_name: BossName.TheDukesDearFreja, boss_exit: true, cutscene: true, reverse: true),
    new FogWall(WarpNode.DukesDearFreyjaEntryFront, "o00_0502_0000", boss_name: BossName.TheDukesDearFreja, cutscene: true),
};
fog_wall_dict[map_names[MapName.AldiasKeep]] = new List<FogWall> {
    new FogWall(WarpNode.GuardianDragonEntryFront, "o00_0501_0000", boss_name: BossName.GuardianDragon),
    new FogWall(WarpNode.GuardianDragonExitFront, "o00_0501_0001", boss_name: BossName.GuardianDragon, boss_exit: true),
    new FogWall(WarpNode.AldiasKeepEntranceFront, "o00_0501_0002", pvp: true),
};
fog_wall_dict[map_names[MapName.TheLostBastilleBelfryLuna]] = new List<FogWall> {
    new FogWall(WarpNode.GargoylesEntryFront, "o00_0500_0000", boss_name: BossName.BelfryGargoyles),
    new FogWall(WarpNode.RuinSentinelsExitFront, "o00_0500_0001", boss_name: BossName.RuinSentinels, boss_exit: true, reverse: true),
    new FogWall(WarpNode.LostBastilleToSinnersRiseFront, "o00_0500_0005"),
    new FogWall(WarpNode.GargoylesExitFront, "o00_0500_0006", boss_name: BossName.BelfryGargoyles, boss_exit: true),
    // TODO: add boss fight triggers near hidden fog gates
    new FogWall(WarpNode.RuinSentinelsHiddenDoor1ExitFront, "o00_0500_0007", boss_name: BossName.RuinSentinels, boss_exit: true, front_blocked: true),
    new FogWall(WarpNode.RuinSentinelsHiddenDoor2ExitFront, "o00_0500_0008", boss_name: BossName.RuinSentinels, boss_exit: true, front_blocked: true),
    new FogWall(WarpNode.RuinSentinelsHiddenDoor3ExitFront, "o00_0500_0009", boss_name: BossName.RuinSentinels, boss_exit: true, front_blocked: true),
    new FogWall(WarpNode.RuinSentinelsHiddenDoor4ExitFront, "o00_0500_0010", boss_name: BossName.RuinSentinels, boss_exit: true, front_blocked: true), // one with ladder
    new FogWall(WarpNode.RuinSentinesUpperExitBack, "o00_0500_0011", reverse: true), 
    new FogWall(WarpNode.LostBastilleToShipFromWharfFront, "o00_0500_0012", pvp: true, reverse: true),
    new FogWall(WarpNode.LostBastilleToBelfryLunaFront, "o00_0500_0013", pvp: true, front_blocked: true, reverse: true), // TODO: cannot access when lockstone is not used but can be used from the other side
    new FogWall(WarpNode.RuinSentinelsEntryFront, "o00_0501_0000", boss_name: BossName.RuinSentinels, back_blocked: true),
    new FogWall(WarpNode.LostSinnerEntryFront, "o00_0501_0002", boss_name: BossName.TheLostSinner, cutscene: true),
    new FogWall(WarpNode.LostSinnerExitFront, "o00_0501_0003", boss_name: BossName.TheLostSinner, boss_exit: true, cutscene: true),
};
fog_wall_dict[map_names[MapName.HarvestValleyEarthenPeak]] = new List<FogWall> {
    new FogWall(WarpNode.CovetousDemonEntryFront, "o00_0500_0000", boss_name: BossName.CovetousDemon),
    new FogWall(WarpNode.EarthenPeakNearWindmillBurnLocationFront, "o00_0500_0001"),
    new FogWall(WarpNode.MythaEntryFront, "o00_0500_0002", boss_name: BossName.MythaTheBanefulQueen),
    new FogWall(WarpNode.CovetousDemonExitFront, "o00_0500_0003", boss_name: BossName.CovetousDemon, boss_exit: true),
    new FogWall(WarpNode.MythaExitFront, "o00_0501_0000", boss_name: BossName.MythaTheBanefulQueen, boss_exit: true),
    new FogWall(WarpNode.HarvestValleyToSkeletonLordsFront, "o00_0501_0001", pvp: true),
};
fog_wall_dict[map_names[MapName.NomansWharf]] = new List<FogWall> {
    new FogWall(WarpNode.FlexileSentryExitFront,  "o00_0500_0000", boss_name: BossName.FlexileSentry, boss_exit: true),
    new FogWall(WarpNode.FlexileSentryEntryFront, "o00_0500_0001", boss_name: BossName.FlexileSentry),
    new FogWall(WarpNode.NoMansWharfToHeidesFront,  "o00_0501_0000", pvp: true),
};
fog_wall_dict[map_names[MapName.IronKeepBelfrySol]] = new List<FogWall> {
    new FogWall(WarpNode.SmeltorDemonEntryFront, "o00_0500_0000", boss_name: BossName.SmelterDemon),
    new FogWall(WarpNode.IronKeepNearFlameThrowerAndTurtleFront, "o00_0500_0002"),
    new FogWall(WarpNode.BelfrySolExitFront, "o00_0500_0003"),
    new FogWall(WarpNode.BelfrySolEntryFront, "o00_0500_0004"),
    new FogWall(WarpNode.OldIronKingEntryFront, "o00_0500_0005", boss_name: BossName.OldIronKing, cutscene: true),
    new FogWall(WarpNode.OldIronKingExitFront, "o00_0500_0006", boss_name: BossName.OldIronKing, boss_exit: true, cutscene: true),
    new FogWall(WarpNode.SmeltorDemonExitFront, "o00_0500_0007", boss_name: BossName.SmelterDemon, boss_exit: true),
    new FogWall(WarpNode.SmeltorDemonToBonfireFront, "o00_0500_0008", pvp: true),
    new FogWall(WarpNode.IronKeepToBelfryAtPharrosLockstoneFront, "o00_0500_0010", pvp: true, front_blocked: true), // TODO: can access from behind the lockstone door but cannot from the lockstone side
//    new FogWall("IK_belfry_entry", "o00_0500_0011"), // duplicate of another maybe for pvp
    new FogWall(WarpNode.IronKeepToEarthenPeakFront, "o00_0501_0000", pvp: true, reverse: true),
};
fog_wall_dict[map_names[MapName.HuntsmanCopseUndeadPurgatory]] = new List<FogWall> {
    new FogWall(WarpNode.SkeletonLordsEntryFront, "o00_0501_0000", boss_name: BossName.SkeletonLords, use_second_death_check_impl: true),
    new FogWall(WarpNode.ChariotEntryFront, "o00_0501_0001", boss_name: BossName.ExecutionersChariot, cutscene: true),
    new FogWall(WarpNode.SkeletonLordsExitFront, "o00_0501_0004", boss_name: BossName.SkeletonLords, boss_exit: true, use_second_death_check_impl: true),
    new FogWall(WarpNode.ChariotExitFront, "o00_0501_0006", boss_name: BossName.ExecutionersChariot, boss_exit: true, cutscene: true),
    new FogWall(WarpNode.HuntsmanCopseToMajulaFront, "o00_0501_0007", pvp: true, reverse: true),
};
fog_wall_dict[map_names[MapName.TheGutterBlackGulch]] = new List<FogWall> {
    new FogWall(WarpNode.GutterNearAntQueenFront, "o00_0500_0000"),
    new FogWall(WarpNode.TheRottenExitFront, "o00_0500_0001", boss_name: BossName.TheRotten, boss_exit: true, cutscene: true),
    new FogWall(WarpNode.BlackGulchEntranceFront, "o00_0501_0000"),
    new FogWall(WarpNode.TheGutterFromGraveOfSaintsFront, "o00_0501_0001", pvp: true, reverse: true),
    new FogWall(WarpNode.TheRottenEntryFront, "o00_0503_0100", boss_name: BossName.TheRotten, cutscene: true),
};
fog_wall_dict[map_names[MapName.DragonAerieDragonShrine]] = new List<FogWall> {
    new FogWall(WarpNode.DragonAerieToAldiasKeepFront, "o00_0501_0000", reverse: true),
    new FogWall(WarpNode.AncientDragonFront, "o00_0502_0000", boss_name: BossName.AncientDragon), // TODO: hostile determination
};
fog_wall_dict[map_names[MapName.MajulaShadedWoods]] = new List<FogWall> {
    new FogWall(WarpNode.ShadedWoodsFromMajulaFront, "o00_0500_0100", pvp: true),
};
fog_wall_dict[map_names[MapName.HeidesTowerofFlame]] = new List<FogWall> {
    new FogWall(WarpNode.DragonriderEntryFront, "o00_0500_0000", boss_name: BossName.Dragonrider),
    new FogWall(WarpNode.DragonriderExitFront, "o00_0500_0001", boss_name: BossName.Dragonrider, boss_exit: true),
    new FogWall(WarpNode.HeidesToMajulaFront, "o00_0500_0002", pvp: true),
    new FogWall(WarpNode.HeidesToWharfFront, "o00_0500_0100", pvp: true),
    new FogWall(WarpNode.OldDragonslayerEntryFront, "o00_0501_0000", boss_name: BossName.OldDragonslayer),
    new FogWall(WarpNode.OldDragonslayerExitFront, "o00_0501_0001", boss_name: BossName.OldDragonslayer, boss_exit: true),
};
fog_wall_dict[map_names[MapName.ShadedWoodsShrineofWinter]] = new List<FogWall> {
    new FogWall(WarpNode.ScorpionessNajkaExitFront, "o00_0500_0000", boss_name: BossName.ScorpionessNajka, boss_exit: true),
    new FogWall(WarpNode.ShadedWoodsToMistyAreaFront, "o00_0501_0001", pvp: true, reverse: true),
    new FogWall(WarpNode.ScorpionessNajkaEntryFront, "o00_0503_0000", boss_name: BossName.ScorpionessNajka), // y_offset = 85.080-85.672
};
fog_wall_dict[map_names[MapName.ShadedWoodsShrineofWinter]][2].offset = new Vector3(0.0f, -85.080f + 85.672f, 0.0f);
fog_wall_dict[map_names[MapName.DoorsofPharros]] = new List<FogWall> {
    new FogWall(WarpNode.RoyalRatAuthorityExitFront, "o00_0500_0000", boss_name: BossName.RoyalRatAuthority, boss_exit: true),
    new FogWall(WarpNode.DoorOfPharrosToOrdealEndBonfireFront, "o00_0500_0001", pvp: true),
    new FogWall(WarpNode.DoorOfPharrosToRatKingDomainFront, "o00_0500_0002", pvp: true),
    new FogWall(WarpNode.RoyalRatAuthorityEntryFront, "o00_0501_0000", boss_name: BossName.RoyalRatAuthority),
};
fog_wall_dict[map_names[MapName.GraveofSaints]] = new List<FogWall> {
    new FogWall(WarpNode.GraveOfSaintsFromPitFront, "o00_0500_0000", pvp: true),
    new FogWall(WarpNode.GraveOfSaintsNearUpperBonfireFront, "o00_0501_0000", pvp: true),
    new FogWall(WarpNode.RoyalRatVanguardEntryFront, "o00_0501_0001", boss_name: BossName.RoyalRatVanguard),
    new FogWall(WarpNode.RoyalRatVanguardExitFront, "o00_0501_0002", boss_name: BossName.RoyalRatVanguard, boss_exit: true),
};
fog_wall_dict[map_names[MapName.MemoryofVammarOrroandJeigh]] = new List<FogWall> {
    new FogWall(WarpNode.GiantLordEntryFront, "o00_0500_0000", boss_name: BossName.GiantLord),
    new FogWall(WarpNode.GiantLordExitFront, "o00_0500_0001", boss_name: BossName.GiantLord, boss_exit: true),
};
fog_wall_dict[map_names[MapName.ShrineofAmana]] = new List<FogWall> {
    new FogWall(WarpNode.DemonOfSongEntryFront, "o00_0501_0000", boss_name: BossName.DemonofSong),
    new FogWall(WarpNode.ShrineOfAmanaTo2ndBonfireFront, "o00_0501_0001"),
    new FogWall(WarpNode.ShrineOfAmanaTo3rdBonfireFront, "o00_0501_0005"),
    new FogWall(WarpNode.DemonOfSongExitFront, "o00_0501_0006", boss_name: BossName.DemonofSong, boss_exit: true), // y_offset = 32.121f - 31.336f
    new FogWall(WarpNode.ShrineOfAmanaToDrangleicCastleFront, "o00_0501_0007", pvp: true),
};
fog_wall_dict[map_names[MapName.ShrineofAmana]][3].offset = new Vector3(0.0f, 32.121f - 31.336f, 0.0f);
fog_wall_dict[map_names[MapName.DrangleicCastleThroneofWant]] = new List<FogWall> {
    new FogWall(WarpNode.LookingGlassKnightEntryFront, "o00_0501_0000", boss_name: BossName.LookingGlassKnight),
    new FogWall(WarpNode.TwinDragonridersEntryFront, "o00_0501_0001", boss_name: BossName.TwinDragonrider),
    new FogWall(WarpNode.TwinDragonridersExitFront, "o00_0501_0004", boss_name: BossName.TwinDragonrider, boss_exit: true),
    new FogWall(WarpNode.LookingGlassKnightExitFront, "o00_0501_0005", boss_name: BossName.LookingGlassKnight, boss_exit: true), // y_offset = 75.655434f - 75.142822f
    new FogWall(WarpNode.FinalFightArenaFront, "o00_0501_0006", boss_name: BossName.ThroneWatcherAndDefender, cutscene: true),
    new FogWall(WarpNode.DrangleicCastleToChasmPortalFront, "o00_0501_0008", pvp: true), // y_offset = 70.787-72.757 // x_offset = -437.288 + 436.508
    new FogWall(WarpNode.DrangleicCastleToShadedWoodsFront, "o00_0504_0000", pvp: true, reverse: true),
};
fog_wall_dict[map_names[MapName.DrangleicCastleThroneofWant]][3].offset = new Vector3(0.0f, 75.655434f - 75.142822f, 0.0f);
fog_wall_dict[map_names[MapName.DrangleicCastleThroneofWant]][5].offset = new Vector3(-437.288f + 436.508f, -70.787f + 72.757f, 0.0f);
fog_wall_dict[map_names[MapName.UndeadCrypt]] = new List<FogWall> {
    new FogWall(WarpNode.UndeadCryptFromAgdayneToBonfireFront, "o00_0500_0000"),
    new FogWall(WarpNode.VelsdatEntryFront, "o00_0501_0000", boss_name: BossName.VelstadtTheRoyalAegis, cutscene: true),
    new FogWall(WarpNode.VelsdatExitFront, "o00_0501_0001", boss_name: BossName.VelstadtTheRoyalAegis, boss_exit: true, cutscene: true),
    new FogWall(WarpNode.UndeadCryptToShrineOfAmanaFront, "o00_0502_0000", pvp: true),
    new FogWall(WarpNode.VendrickFront, "o00_0505_0000", boss_name: BossName.Vendrick),
};
fog_wall_dict[map_names[MapName.DarkChasmofOld]] = new List<FogWall> {
    new FogWall(WarpNode.DarkChasmFromBlackGulchExitFront, "o00_0501_0000"),
    new FogWall(WarpNode.DarkChasmFromDrangleicCastleExitFront, "o00_0501_0001"),
    new FogWall(WarpNode.DarkChasmFromShadedWoodsExitFront, "o00_0501_0002"),
    new FogWall(WarpNode.DarkLurkerExitFront, "o00_0501_0003", boss_name: BossName.Darklurker, boss_exit: true), // y_offset = 13.792f - 11.966f
};
fog_wall_dict[map_names[MapName.DarkChasmofOld]][3].offset = new Vector3(0.0f, 13.792f - 11.966f, 0.0f);
fog_wall_dict[map_names[MapName.ShulvaSanctumCity]] = new List<FogWall> {
    new FogWall(WarpNode.SihnTheSlumberingDragonEntryFront, "o00_0500_0001", boss_name: BossName.SinhTheSlumberingDragon), // y_offset = 79.928f - 79.436f
    new FogWall(WarpNode.ElanaTheSqualidQueenEntryFront, "o00_0501_0000", boss_name: BossName.ElanaTheSqualidQueen), // y_offset = 71.928f - 71.637f
    new FogWall(WarpNode.GankSquadBossEntryFront, "o00_0501_0002", boss_name: BossName.Gankfight),
    new FogWall(WarpNode.GankSquadBossExitFront, "o00_0501_0003", boss_name: BossName.Gankfight, boss_exit: true),
    new FogWall(WarpNode.ShulvaToGankFight1Front, "o00_0501_0005", pvp: true),
    new FogWall(WarpNode.ShulvaEntranceFront, "o00_0501_0007", pvp: true),
    //new FogWall("Shulva_between_sihn_elana", "o00_0501_0008"), //disabled (duplicate)
    new FogWall(WarpNode.BetweenElanaAndSihnFront, "o00_0501_0010"), // y_offset = 74.743797f - 73.291435f
    new FogWall(WarpNode.ShulvaToGankFight2Front, "o00_0501_0011"),
    new FogWall(WarpNode.NearJesterThomasFront, "o00_0501_0012"), //y_offset = 41.540f - 41.289f
};
fog_wall_dict[map_names[MapName.ShulvaSanctumCity]][0].offset = new Vector3(0.0f, 79.928f - 79.436f, 0.0f);
fog_wall_dict[map_names[MapName.ShulvaSanctumCity]][1].offset = new Vector3(0.0f, 71.928f - 71.637f, 0.0f);
fog_wall_dict[map_names[MapName.ShulvaSanctumCity]][6].offset = new Vector3(0.0f, 5.0f * (74.744f - 73.291f) / 12.0f, 0.0f); // this is weird because of the inclined slope
fog_wall_dict[map_names[MapName.ShulvaSanctumCity]][8].offset = new Vector3(0.0f, 41.540f - 41.289f, 0.0f);
fog_wall_dict[map_names[MapName.BrumeTower]] = new List<FogWall> {
    new FogWall(WarpNode.BrumeTowerFrom2ndBonfireToCentralRoomFront, "o00_0500_0000"),
    new FogWall(WarpNode.BrumeTowerToFoyerBonfireFromOutsideFront, "o00_0500_0001"),
    new FogWall(WarpNode.BrumeTowerToScorchingIronSceptorKeyFront, "o00_0500_0002"),
    new FogWall(WarpNode.SirAlonneEntryFront, "o00_0500_0003", boss_name: BossName.SirAlonne),
    new FogWall(WarpNode.SirAlonneExitFront, "o00_0500_0004", boss_name: BossName.SirAlonne, boss_exit: true),
    new FogWall(WarpNode.FumeKnightEntryFront, "o00_0501_0000", boss_name: BossName.FumeKnight), // y_offset = 59.822f - 59.297f
    new FogWall(WarpNode.FumeKnightExitFront, "o00_0501_0001", boss_name: BossName.FumeKnight, boss_exit: true, reverse: true), //y_offset = 61.497f - 60.998f
    new FogWall(WarpNode.BlueSmeltorDemonEntryFront, "o00_0501_0002", boss_name: BossName.BlueSmelterDemon), //y_offset = 26.875f - 26.556f
    new FogWall(WarpNode.BlueSmeltorDemonExitFront, "o00_0501_0003", boss_name: BossName.BlueSmelterDemon, boss_exit: true),
    new FogWall(WarpNode.BrumeTowerEntranceFromLiftFront, "o00_0501_0006"),
    new FogWall(WarpNode.BrumeTowerToBlueSmelterDungeonFront, "o00_0501_0007"),
    //new FogWall("DLC2_entrance",                            "o00_0501_0008"), // disabled (duplicate)
};
fog_wall_dict[map_names[MapName.BrumeTower]][5].offset = new Vector3(0.0f, 59.822f - 59.297f, 0.0f);
fog_wall_dict[map_names[MapName.BrumeTower]][6].offset = new Vector3(0.0f, 61.497f - 60.998f, 0.0f);
fog_wall_dict[map_names[MapName.BrumeTower]][7].offset = new Vector3(0.0f, 26.875f - 26.556f, 0.0f);
fog_wall_dict[map_names[MapName.FrozenEleumLoyce]] = new List<FogWall> {
    new FogWall(WarpNode.AavaTheKingsPetExitFront, "o00_0500_0001", boss_name: BossName.AavaTheKingsPet, boss_exit: true),
    new FogWall(WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsFront, "o00_0500_0002"),
    new FogWall(WarpNode.IvoryKingFront, "o00_0500_0003", boss_name: BossName.BurntIvoryKing, back_blocked: true),
    new FogWall(WarpNode.LudAndZallenEntryFront, "o00_0501_0003", boss_name: BossName.LudAndZallen),
    new FogWall(WarpNode.AavaTheKingsPetEntryFront, "o00_0501_0005", boss_name: BossName.AavaTheKingsPet),
    new FogWall(WarpNode.LudAndZallenExitFront, "o00_0501_0006", boss_name: BossName.LudAndZallen, boss_exit: true),
    new FogWall(WarpNode.EleumLoyceCathedraEntranceFront, "o00_0501_0007", pvp: true), // y_offset = 25.841f - 23.046f
};
fog_wall_dict[map_names[MapName.FrozenEleumLoyce]][6].offset = new Vector3(0.0f, 25.841f - 23.046f, 0.0f);

foreach (var kvp in fog_wall_dict)
{
    string map_name = kvp.Key;
    List<FogWall> fog_walls = kvp.Value;

    for (int i = 0; i < fog_walls.Count; i++)
    {
        var fog_wall = fog_walls[i];

        if (fog_wall.boss_name != BossName.None)
        {
            if (fog_wall.cutscene)
            {
                fog_wall.event_id = boss_event_ids[fog_wall.boss_name];
            }
            fog_wall.destruction_flag = boss_destruction_flags[fog_wall.boss_name];
        }
    }
}

Dictionary<string, int> warp_map_id = new Dictionary<string, int>();
foreach(var mn in map_names)
{
    warp_map_id[mn.Value] = Util.parse_map_name(mn.Value);
}

Dictionary<String,String> esd_script_fn(Warp warp)
{
    String fb = warp.from.front ? "front" : "back";
    String fb2 = warp.to.front ? "front" : "back";
    Dictionary<String, String> scripts = new()
    {
        { warp.from.map_name , $"\n##{warp.from.fog_wall_name}({fb})-{warp.to.fog_wall_name}({fb2})##" },
    };
    if (warp.from.map_name != warp.to.map_name)
    {
        scripts[warp.to.map_name] = $"";
    }
    // generate and update the esd script for warping source
    if (warp.from.boss.name != BossName.None  && warp.from.boss_locked) // add condition to prevent player from leaving
    {
        if (warp.from.boss.use_second_death_check_impl)
        {
            scripts[warp.from.map_name] += generate_esd_script_boss_from_behind_v2(
                warp.from.map_name,
                warp.from.script_id,
                warp.from.warp_src_id,
                warp.to.location_id,
                Util.parse_map_name(warp.to.map_name),
                warp.from.boss.name,
                warp.from.boss.name_str.ToString(),
                warp.from.boss.destruction_flag
            );
        } else
        {
            scripts[warp.from.map_name] += generate_esd_script_boss_from_behind(
                warp.from.map_name,
                warp.from.script_id,
                warp.from.warp_src_id,
                warp.to.location_id,
                Util.parse_map_name(warp.to.map_name),
                warp.from.boss.name,
                warp.from.boss.name_str.ToString(),
                warp.from.boss.destruction_flag
            );
        }
    }
    else
    {
        if (warp.from.map_name == map_names[MapName.DarkChasmofOld] 
            && warp.from.boss.name == BossName.None
            && chasm_enemy_ids.ContainsKey(warp.from.fog_wall_name)
        )
        {
            scripts[warp.from.map_name]+= generate_dark_chasm_fog_gate_script(
                warp.from.map_name,
                warp.from.script_id,
                warp.from.warp_src_id,
                warp.to.location_id,
                Util.parse_map_name(warp.to.map_name),
                chasm_enemy_ids[warp.from.fog_wall_name],
                chasm_event_flags[warp.from.fog_wall_name],
                warp.from.fog_wall_name.ToString()
            );

        } 
        else
        {
            scripts[warp.from.map_name] += generate_esd_script(
                warp.from.map_name,
                warp.from.script_id,
                warp.from.warp_src_id,
                warp.to.location_id,
                Util.parse_map_name(warp.to.map_name)
            );
        }
    }

    scripts[warp.to.map_name] += $"\n##{warp.to.fog_wall_name}({fb2})-{warp.from.fog_wall_name}({fb})##";
    // generate and update the esd script for warping destination
    if (warp.to.boss.name != BossName.None && warp.to.boss_locked) // add condition to prevent player from leaving
    {
        if (warp.to.boss.use_second_death_check_impl)
        {
            scripts[warp.to.map_name] += generate_esd_script_boss_from_behind_v2(
                warp.to.map_name,
                warp.to.script_id,
                warp.to.warp_src_id,
                warp.from.location_id,
                Util.parse_map_name(warp.from.map_name),
                warp.to.boss.name,
                warp.to.boss.name_str.ToString(),
                warp.to.boss.destruction_flag
            );
        }
        else
        {
            if (warp.to.boss.name == BossName.Vendrick)
            {
                scripts[warp.to.map_name] += generate_vendrick_fog_gate_script(
                    warp.to.map_name,
                    warp.to.script_id,
                    warp.to.warp_src_id,
                    warp.from.location_id,
                    Util.parse_map_name(warp.from.map_name),
                    warp.to.boss.name,
                    warp.to.boss.name_str.ToString(),
                    warp.to.boss.destruction_flag
                );
            }
            else if (warp.to.boss.name == BossName.ThroneWatcherAndDefender)
            {
                scripts[warp.to.map_name] += generate_throne_room_exit_script(
                    warp.to.map_name,
                    warp.to.script_id,
                    warp.to.warp_src_id,
                    warp.from.location_id,
                    Util.parse_map_name(warp.from.map_name)
                );
            }
            else
            {
                scripts[warp.to.map_name] += generate_esd_script_boss_from_behind(
                    warp.to.map_name,
                    warp.to.script_id,
                    warp.to.warp_src_id,
                    warp.from.location_id,
                    Util.parse_map_name(warp.from.map_name),
                    warp.to.boss.name,
                    warp.to.boss.name_str.ToString(),
                    warp.to.boss.destruction_flag
                );
            }
        }
    }
    else
    {
        scripts[warp.to.map_name] += generate_esd_script(
            warp.to.map_name,
            warp.to.script_id,
            warp.to.warp_src_id,
            warp.from.location_id,
            Util.parse_map_name(warp.from.map_name)
        );
    }

    // if the fogdoor has cutscene it must run the cutscene when the player spawns
    if (warp.to.boss.cutscene && warp.to.boss_locked)
    {
        int fog_gate_id = warp.to.fog_gate_id;
        if (warp.to.boss.exit)
        {
            fog_gate_id = warp.to.twin_fog_gate_id;
        }
        scripts[warp.to.map_name] += generate_cutscene_event_script(
            warp.to.map_name,
            warp.to.cutscene_script_id,
            warp.to.location_id,
            fog_gate_id
        );
    } 
    if (warp.from.boss.cutscene && warp.from.boss_locked)
    {
        int fog_gate_id = warp.to.fog_gate_id;
        if (warp.from.boss.exit)
        {
            fog_gate_id = warp.from.twin_fog_gate_id;
        }
        scripts[warp.from.map_name] += generate_cutscene_event_script(
            warp.from.map_name,
            warp.from.cutscene_script_id,
            warp.from.location_id,
            fog_gate_id
        );
    }
    return scripts;
}

String get_esd_script_path(String map_name)
{
    return Path.Join(mod_folder, "ezstate", $"event_{map_name}.py");
}
String get_esd_file_path(String map_name)
{
    return Path.Join(mod_folder, "ezstate", $"event_{map_name}.esd");
}

String ezstate_path = Path.Join(mod_folder, "ezstate");
int warp_obj_idx = -1;
int warp_obj_inst_idx = -1;
MSB2.Part.Object? warp_obj = null;
MSB2.Model? warp_model = null;
PARAM.Row? warp_obj_inst = null;
List<Warp> warps = new();
foreach (var pair in map_names)
{
    String map_name = pair.Value;

    // hardcoded to 1000
    //int warp_obj_begin = warp_object_begin_list[map_name];
    int warp_obj_begin = 1000;

    // skip dragon memories and memory of the king
    if (pair.Key == MapName.MemoryoftheKing || pair.Key == MapName.DragonMemories) continue;

    int n_fog_walls = fog_wall_dict[map_name].Count;

    String map_path               = Path.Join(mod_folder, "map", map_name, map_name + ".msb");
    String param_event_loc_path   = Path.Join(mod_folder, "Param", "eventlocation_" + map_name + ".param");
    String param_event_path       = Path.Join(mod_folder, "Param", "eventparam_" + map_name + ".param");
    String obj_inst_param_path    = Path.Join(mod_folder, "Param", "mapobjectinstanceparam_" + map_name + ".param");

    MSB2  map               = load_map(map_path);
    PARAM param_event_loc   = load_map_param(param_event_loc_path);
    PARAM param_event       = load_map_param(param_event_path);
    PARAM obj_inst_param    = load_map_param(obj_inst_param_path);

    obj_inst_param.ApplyParamdef(get_obj_inst_def_paramdef(obj_inst_param));
    param_event.ApplyParamdef(get_event_param_def_paramdef(param_event));
    param_event_loc.ApplyParamdef(get_event_loc_def_paramdef(param_event_loc));

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
                if (twin_fog_wall.boss_name == fog_wall.boss_name)
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
    for (int i=0; i<param_event_loc.Rows.Count; i++)
    {
        var row = param_event_loc.Rows[i];
        if (row.ID == warp_point_begin - 1)
        {
            event_loc_insert_loc = i + 1;
            break;
        }
    }
    Debug.Assert(event_loc_insert_loc >= 0);

    // calculate the no. of boss cutscenes in a map
    int n_cutscenes = 0;
    foreach (var fg in fog_wall_dict[map_name])
    {
        if (fg.cutscene) n_cutscenes += 1;
    }

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
            if (next_row.ID - row.ID > n_warp_points + n_cutscenes)
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
        FogGateInfo fgi = new(map_name, fw);

        if (fw.reverse)
        {
            rot_fog_walls[i] = vector3_flip_y(rot_fog_walls[i]);
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
        if (fw.boss_name != BossName.None) // if the fog door contains the boss
        {
            if (boss_spawn_event_loc.Keys.Contains(fw.boss_name)) // if the spawn event loc is populated
            {
                if (!fw.boss_exit || fw.boss_name == BossName.Darklurker) // if it is the entry gate or Darklurker gate
                {
                    for (int j = 0; j < param_event_loc.Rows.Count; j++)
                    {
                        var row = param_event_loc.Rows[j];
                        if (row.ID == boss_spawn_event_loc[fw.boss_name])
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

        fgi.type = new(esd_script_begin, warp_obj_inst_begin, warp_point_begin, Util.parse_map_name(map_name));

        // if the fog door contains the boss with a cutscene create an event that triggers the cutscene
        if (fw.boss_name != BossName.None && fw.cutscene)
        {
            var row = new Row(event_param_begin + 2, 
                $"event_{event_param_begin+2}", 
                get_event_param_def_paramdef_ex(
                    param_event,
                    event_param_begin + 2,
                    0
                )
            );
            param_event.Rows.Add(row);
            event_param_begin++;
            esd_script_begin++;
        }


        // update the variables for next object
        warp_obj_inst_begin += 2;
        warp_obj_begin += 2;
        esd_script_begin += 2;
        event_param_begin += 2;
        obj_inst_insert_loc += 2;
        warp_point_begin += 2;
        event_loc_insert_loc += 2;

        warps.Add(new Warp(fgi));
    }

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

String py_files_list = "";
Dictionary<String, String> esd_script_dict = new();
foreach (var map_name_kv in map_names)
{
    String map_name = map_name_kv.Value;
    String esd_script_path = get_esd_script_path(map_name);
    if (!Path.Exists(esd_script_path))
    {
        String esd_tool = Path.GetFullPath("./esdtool/esdtool.exe");
        String argus = $"-ds2s -basedir \"{game_dir}\" -moddir \"{mod_folder}\" -backup -i\"{get_esd_file_path(map_name)}\" -writepy \"{esd_script_path}\"";
        Debug.Assert(File.Exists(esd_tool));
        run_external_command(esd_tool, argus);   // decomplie esd into .py files
        Debug.Assert(File.Exists(esd_script_path));
    }
    String path = Util.check_backup(esd_script_path);
    String esd_script = Util.read_string_from_file(path);
    esd_script += Util.get_script_helper_fns(map_name, Util.parse_map_name(map_name));
    esd_script_dict[map_name] = esd_script;
}

List<WarpInfo> warp_infos = new(warps.Count*2);
foreach (var warp in warps)
{
    warp_infos.Add(warp.from);
    warp_infos.Add(warp.to);
}

List<WarpNode> boss_nodes = new();
foreach (var wi in warp_infos)
{
    if (wi.boss.name != BossName.None 
        && (wi.fog_wall_name.ToString().Contains("EntryBack")
            || wi.fog_wall_name.ToString().Contains("ExitFront")))
    {
        boss_nodes.Add(wi.fog_wall_name);
    }
}

List<WarpNode> has_predefined_warp = new() 
{ 
    WarpNode.GameStartSpawnSrc,
    WarpNode.GameStartSpawnDst,

    WarpNode.MemoryOfTheKingCryptSrc,
    WarpNode.MemoryOfTheKingCryptDst,
    WarpNode.MemoryOfTheKingMemorySrc,
    WarpNode.MemoryOfTheKingMemoryDst,

    WarpNode.NearPateGiantMemoryExitSrc,
    WarpNode.NearPursuerGiantMemoryExitSrc,
    WarpNode.GiantLordMemoryExitSrc,
    WarpNode.NearPateGiantMemoryExitDst,
    WarpNode.NearPursuerGiantMemoryExitDst,
    WarpNode.GiantLordMemoryExitDst,

    WarpNode.NearPursuerGiantMemoryEntrySrc,
    WarpNode.NearPursuerGiantMemoryEntryDst,
    WarpNode.NearPateGiantMemoryEntrySrc,
    WarpNode.NearPateGiantMemoryEntryDst,
    WarpNode.GiantLordMemoryEntrySrc,
    WarpNode.GiantLordMemoryEntryDst,

    WarpNode.DragonMemoriesCoveSrc,
    WarpNode.DragonMemoriesCoveDst,
    WarpNode.DragonMemoriesMemorySrc,
    WarpNode.DragonMemoriesMemoryDst,

    WarpNode.ChasmPortalFromCastleDst,
    WarpNode.ChasmPortalFromBlackGulchDst,
    WarpNode.ChasmPortalFromShadedWoodsDst,
    WarpNode.ChasmPortalFromCastleSrc,
    WarpNode.ChasmPortalFromBlackGulchSrc,
    WarpNode.ChasmPortalFromShadedWoodsSrc,

    WarpNode.ChasmGulchExitWarpSrc,
    WarpNode.ChasmCastleExitWarpSrc,
    WarpNode.ChasmShadedWoodsExitWarpSrc,
    WarpNode.ChasmDarkLurkerExitWarpSrc,
    WarpNode.ChasmGulchExitWarpDst,
    WarpNode.ChasmCastleExitWarpDst,
    WarpNode.ChasmShadedWoodsExitWarpDst,
    WarpNode.ChasmDarkLurkerExitWarpDst,

    WarpNode.CoffinWarpSrc,
    WarpNode.CoffinWarpDst,
    WarpNode.PirateShipWharf,
    WarpNode.PirateShipBastille,

    WarpNode.DLC1EntranceBaseGame,
    WarpNode.DLC1EntranceDLC,
    WarpNode.DLC2EntranceBaseGame,
    WarpNode.DLC2EntranceDLC,
    WarpNode.DLC3EntranceBaseGame,
    WarpNode.DLC3EntranceDLC,

    WarpNode.SirAlonneMemoryExitSrc,
    WarpNode.SirAlonneMemoryExitDst,
    WarpNode.SirAlonneArmorDLCEntrySrc,
    WarpNode.SirAlonneArmorDLCEntryDst,

    WarpNode.IvoryKingFightEndDst,
    WarpNode.IvoryKingFightEndSrc,
    WarpNode.LudAndZallenExitWarpSrc,
    WarpNode.LudAndZallenExitWarpDst,

    WarpNode.NearPursuerBirdEntry,
    WarpNode.NearPursuerBirdExit,
};

Connection get_connection_from_name(WarpNode name)
{
    List<Connection> s1 = get_segment(name);
    foreach (var i in s1)
    {
        if (i.n1 == name || i.n2 == name) return i;
    }
    Debug.Assert(false);
    return new Connection(WarpNode.Lone, WarpNode.Lone);
}

List<WarpNode> starting_gates = new() 
{ 
    WarpNode.Tutorial1EntryFront,
    WarpNode.Tutorial2EntryFront,
    WarpNode.MajulaToForestOfFallenGiantsFront,
    WarpNode.MajulaToRotundaLockstoneFront,
    WarpNode.MajulaToGraveOfSaintsFront,
    WarpNode.MajulaToGutterFront,
    WarpNode.Tutorial3EntryFront,
};

// from's pair is lone
bool check_lone_to_lone_connection(WarpNode to)
{
    var segs = get_segment(to);
    int idx = -1;
    int fail_count = 0;
    int total_count = 0;
    foreach (var seg in segs)
    {
        idx++;
        if (total_count != fail_count) break;
        if (seg.n1 != to && seg.n2 != to) continue;
        total_count++;

        var pair_src = segs[idx].n1 == to ? segs[idx].n2 : segs[idx].n1;
        var pair_cond = segs[idx].n1 == to ? segs[idx].condition_n1 : segs[idx].condition_n2;
        if (pair_cond == Cond.OneWay)
        {
            fail_count++;
            continue;
        }
        var (pair_dst, cond) = get_warp_pair(pair_src);
        if (starting_gates.Contains(pair_dst)) return true;
        if (pair_dst == WarpNode.Lone) continue;
        if (!check_lone_to_lone_connection(pair_dst)) fail_count++;
    }
    if (fail_count == total_count) return false;
    return true;
}
bool is_this_warp_allowed(WarpNode from, WarpNode to)
{
    if (from == WarpNode.Lone || to == WarpNode.Lone) return false;
    if (has_predefined_warp.Contains(from) || has_predefined_warp.Contains(to)) return false;
    if (from == to) return false;
    if (GateConnections.cannot_warp_from.Contains(from))
    {
        return false;
    }
    if (GateConnections.cannot_warp_to.Contains(to))
    {
        return false;
    }
    Connection con_a = get_connection_from_name(from);
    Connection con_b = get_connection_from_name(to);
    if (con_a.n1 == WarpNode.Lone && con_b.n1 == WarpNode.Lone) return false;
    if (con_a.n2 == WarpNode.Lone && con_b.n2 == WarpNode.Lone) return false;
    if (con_a.n1 == WarpNode.Lone && con_b.n2 == WarpNode.Lone) return false;
    if (con_a.n2 == WarpNode.Lone && con_b.n1 == WarpNode.Lone) return false;

    // check if a lone <-> pair of possilbe gate <-> lone
    if (con_a.n1 == WarpNode.Lone || con_a.n2 == WarpNode.Lone)
    {
        if (!check_lone_to_lone_connection(to)) return false;
    }
    else if (con_b.n1 == WarpNode.Lone || con_b.n2 == WarpNode.Lone) 
    {
        if (!check_lone_to_lone_connection(from)) return false;
    }

    return true;
}

// TODO: add prevention for connection gates that dont lead to any where
// Example the final fight arena connected to outside the exit of rat authority fight

//Random rand = new Random();
Random rand = new Random(9842);
//Random rand = new Random(83754);
//Random rand = new Random(247);

// by default weight will be 1 for full random
// increasing weight will reduce its likelihood of being selected
int weighted_random_number(int start, int end, int odd, int weight)
{
    Debug.Assert(start <= odd && end >= odd);
    int total_factor = (end - start - 1) * weight + 1;
    int r = rand.Next(total_factor);
    if (r == 0) return odd;
    else if ((r - 1) / weight + 1 + start == odd) return start;
    else return (r - 1) / weight + 1 + start;
}

WarpInfo get_warp_info_from_name(WarpNode name)
{
    foreach (var wi in warp_infos)
    {
        if (wi.fog_wall_name == name) return wi;
    }
    Debug.Assert(false);
    return new WarpInfo();
}

List<Warp> selectedPairs = new(warps.Count);

// add the fixed warps to the selectedPairs
selectedPairs.Add(get_default_warp(
    MapName.ThingsBetwixt, MapName.ThingsBetwixt,
    WarpNode.GameStartSpawnSrc, WarpNode.GameStartSpawnDst
));

selectedPairs.Add(get_default_warp(
    MapName.ForestOfTheFallenGiants, MapName.TheLostBastilleBelfryLuna,
    WarpNode.NearPursuerBirdEntry, WarpNode.NearPursuerBirdExit
));

selectedPairs.Add(get_default_warp(
    MapName.FrozenEleumLoyce, MapName.FrozenEleumLoyce,
    WarpNode.LudAndZallenExitWarpSrc, WarpNode.LudAndZallenExitWarpDst,
    cond: Cond.LudAndZallenDead
));

selectedPairs.Add(get_default_warp(
    MapName.FrozenEleumLoyce, MapName.FrozenEleumLoyce,
    WarpNode.IvoryKingFightEndSrc, WarpNode.IvoryKingFightEndDst,
    cond: Cond.DLC3Unfreezed
));

selectedPairs.Add(get_default_warp(
    MapName.DarkChasmofOld, MapName.ShadedWoodsShrineofWinter,
    WarpNode.ChasmShadedWoodsExitWarpSrc, WarpNode.ChasmShadedWoodsExitWarpDst
));

selectedPairs.Add(get_default_warp(
    MapName.DarkChasmofOld, MapName.TheGutterBlackGulch,
    WarpNode.ChasmGulchExitWarpSrc, WarpNode.ChasmGulchExitWarpDst
));

selectedPairs.Add(get_default_warp(
    MapName.DarkChasmofOld, MapName.DrangleicCastleThroneofWant,
    WarpNode.ChasmCastleExitWarpSrc, WarpNode.ChasmCastleExitWarpDst
));

selectedPairs.Add(get_default_warp(
    MapName.TheGutterBlackGulch, MapName.DarkChasmofOld,
    WarpNode.ChasmPortalFromBlackGulchSrc, WarpNode.ChasmPortalFromBlackGulchDst,
    cond: Cond.DarkCovenentJoined
));

selectedPairs.Add(get_default_warp(
    MapName.DrangleicCastleThroneofWant, MapName.DarkChasmofOld,
    WarpNode.ChasmPortalFromCastleSrc, WarpNode.ChasmPortalFromCastleDst,
    cond: Cond.DarkCovenentJoined
));

selectedPairs.Add(get_default_warp(
    MapName.ShadedWoodsShrineofWinter, MapName.DarkChasmofOld,
    WarpNode.ChasmPortalFromShadedWoodsSrc, WarpNode.ChasmPortalFromShadedWoodsDst,
    cond: Cond.DarkCovenentJoined
));

selectedPairs.Add(get_default_warp(
    MapName.DarkChasmofOld, MapName.DrangleicCastleThroneofWant,
    WarpNode.ChasmDarkLurkerExitWarpSrc, WarpNode.ChasmDarkLurkerExitWarpDst
));

selectedPairs.Add(get_default_warp(
    MapName.ForestOfTheFallenGiants, MapName.MemoryofVammarOrroandJeigh,
    WarpNode.NearPateGiantMemoryEntrySrc, WarpNode.NearPateGiantMemoryEntryDst,
    cond: Cond.AshenMistHeart
));

selectedPairs.Add(get_default_warp(
    MapName.ForestOfTheFallenGiants, MapName.MemoryofVammarOrroandJeigh,
    WarpNode.NearPursuerGiantMemoryEntrySrc, WarpNode.NearPursuerGiantMemoryEntryDst,
    cond: Cond.AshenMistHeart
));

selectedPairs.Add(get_default_warp(
    MapName.ForestOfTheFallenGiants, MapName.MemoryofVammarOrroandJeigh,
    WarpNode.GiantLordMemoryEntrySrc, WarpNode.GiantLordMemoryEntryDst,
    cond: Cond.AshenMistHeart
));

selectedPairs.Add(get_default_warp(
    MapName.MemoryofVammarOrroandJeigh, MapName.ForestOfTheFallenGiants,
    WarpNode.NearPateGiantMemoryExitSrc, WarpNode.NearPateGiantMemoryExitDst,
    cond: Cond.AshenMistHeart
));

selectedPairs.Add(get_default_warp(
    MapName.MemoryofVammarOrroandJeigh, MapName.ForestOfTheFallenGiants,
    WarpNode.NearPursuerGiantMemoryExitSrc, WarpNode.NearPursuerGiantMemoryExitDst
));

selectedPairs.Add(get_default_warp(
    MapName.MemoryofVammarOrroandJeigh, MapName.ForestOfTheFallenGiants,
    WarpNode.GiantLordMemoryExitSrc, WarpNode.GiantLordMemoryExitDst
));

selectedPairs.Add(get_default_warp(
    MapName.BrightstoneCoveTseldora, MapName.DragonMemories,
    WarpNode.DragonMemoriesCoveSrc, WarpNode.DragonMemoriesMemoryDst,
    cond: Cond.AshenMistHeart
));

selectedPairs.Add(get_default_warp(
    MapName.DragonMemories, MapName.BrightstoneCoveTseldora,
    WarpNode.DragonMemoriesMemorySrc, WarpNode.DragonMemoriesCoveDst
));

selectedPairs.Add(get_default_warp(
    MapName.BrumeTower, MapName.BrumeTower,
    WarpNode.SirAlonneArmorDLCEntrySrc, WarpNode.SirAlonneArmorDLCEntryDst,
    cond: Cond.AshenMistHeart
));

selectedPairs.Add(get_default_warp(
    MapName.BrumeTower, MapName.BrumeTower,
    WarpNode.SirAlonneMemoryExitSrc, WarpNode.SirAlonneMemoryExitDst
));

selectedPairs.Add(get_default_warp(
    MapName.NomansWharf, MapName.TheLostBastilleBelfryLuna,
    WarpNode.PirateShipWharf, WarpNode.PirateShipBastille
));

selectedPairs.Add(get_default_warp(
    MapName.TheGutterBlackGulch, MapName.ShulvaSanctumCity,
    WarpNode.DLC1EntranceBaseGame, WarpNode.DLC1EntranceDLC
));

selectedPairs.Add(get_default_warp(
    MapName.IronKeepBelfrySol, MapName.BrumeTower,
    WarpNode.DLC2EntranceBaseGame, WarpNode.DLC2EntranceDLC
));

selectedPairs.Add(get_default_warp(
    MapName.ShadedWoodsShrineofWinter, MapName.FrozenEleumLoyce,
    WarpNode.DLC3EntranceBaseGame, WarpNode.DLC3EntranceDLC
));

selectedPairs.Add(get_default_warp(
    MapName.UndeadCrypt, MapName.MemoryoftheKing,
    WarpNode.MemoryOfTheKingCryptSrc, WarpNode.MemoryOfTheKingMemoryDst,
    cond: Cond.AshenMistHeart
));

selectedPairs.Add(get_default_warp(
    MapName.MemoryoftheKing, MapName.UndeadCrypt,
    WarpNode.MemoryOfTheKingMemorySrc, WarpNode.MemoryOfTheKingCryptDst
));

selectedPairs.Add(get_default_warp(
    MapName.FrozenEleumLoyce, MapName.FrozenEleumLoyce,
    WarpNode.CoffinWarpSrc, WarpNode.CoffinWarpDst
));

List<WarpNode> fix_warps_list = selectedPairs
    .SelectMany(x => new[] { x.from.fog_wall_name, x.to.fog_wall_name })
    .ToList();
int fix_warps_count = selectedPairs.Count;

List<WarpNode> skip_list = new();
List<int> not_selected_idx = new();
List<List<WarpNode>> segments_flat = new();
foreach (var i in segments)
{
    var elem = i.SelectMany(x => new[] { x.n1, x.n2 }).Distinct().ToList();
    segments_flat.Add(new(elem));
}

// randomize all the lone gates
int count = 0;
foreach (var segment in segments)
{
    foreach (var s in segment)
    {
        WarpNode node;
        if (s.n1 == WarpNode.Lone) node = s.n2;
        else if (s.n2 == WarpNode.Lone) node = s.n1;
        else continue;
        Top:
        int i1 = rand.Next(segments.Count);
        int i2 = rand.Next(segments[i1].Count);
        var to = segments[i1][i2];
        if (to.n1 == WarpNode.Lone || to.n2 == WarpNode.Lone) goto Top;

        if (is_this_warp_allowed(node, to.n1))
        {
            if (!segments_flat[i1].Contains(to.n1)) continue;
            if (to.condition_n1 == Cond.OneWay) goto Top;
            var cond = Cond.None;
            if (GateConnections.pirate_ship_nodes.Contains(node)
                ||GateConnections.pirate_ship_nodes.Contains(to.n1))
            {
                cond = Cond.ShipBellRang;
            }
            selectedPairs.Add(new(
                get_warp_info_from_name(node),
                get_warp_info_from_name(to.n1),
                cond: cond
            ));
            skip_list.Add(node);
            skip_list.Add(to.n1);
            Debug.Assert(segments_flat[count].Remove(node));
            Debug.Assert(segments_flat[i1].Remove(to.n1));
        }
        else if (is_this_warp_allowed(node, to.n2))
        {
            if (!segments_flat[i1].Contains(to.n2)) continue;
            if (to.condition_n2 == Cond.OneWay) goto Top;
            var cond = Cond.None;
            if (GateConnections.pirate_ship_nodes.Contains(node)
                ||GateConnections.pirate_ship_nodes.Contains(to.n1))
            {
                cond = Cond.ShipBellRang;
            }
            selectedPairs.Add(new(
                get_warp_info_from_name(node),
                get_warp_info_from_name(to.n2),
                cond: cond
            ));
            skip_list.Add(node);
            skip_list.Add(to.n2);
            Debug.Assert(segments_flat[count].Remove(node));
            Debug.Assert(segments_flat[i1].Remove(to.n2));
        }
        else
        {
            goto Top;
        }
    }
    count++;
}

int idx = 0;
int cur_iter = 0;
while (true)
{
    cur_iter++;
    if (cur_iter > 10000)
    {
        cur_iter = 0;
        idx++;
        if (idx >= segments_flat.Count && selectedPairs.Count - fix_warps_count  < warp_infos.Count / 2) idx = 0;
        else if (selectedPairs.Count - fix_warps_count  >= warp_infos.Count / 2) break;
    }
    // get random segment index that is less likely to be 0
    var frm_seg = segments_flat[idx];
    if (frm_seg.Count == 0)
    {
        segments_flat.RemoveAt(idx);
        if (idx != 0) idx--;
        continue;
    }
    int seg_grp_idx = weighted_random_number(0, segments_flat.Count, idx, 1);
    var to_seg = segments_flat[seg_grp_idx];
    if (to_seg.Count == 0)
    {
        segments_flat.RemoveAt(seg_grp_idx);
        if (idx != 0) idx--;
        continue;
    }

    int frm_seg_idx = rand.Next(frm_seg.Count);
    int to_seg_idx = rand.Next(to_seg.Count);

    var frm_s = frm_seg[frm_seg_idx];
    if (skip_list.Contains(frm_s)) continue;
    var to_s = to_seg[to_seg_idx];
    if (skip_list.Contains(to_s)) continue;

    if (has_predefined_warp.Contains(frm_s) || frm_s == WarpNode.Lone)
    {
        frm_seg.RemoveAt(frm_seg_idx);
        continue;
    }
    else if (has_predefined_warp.Contains(to_s) || to_s == WarpNode.Lone)
    {
        to_seg.RemoveAt(to_seg_idx);
        continue;
    }

    if (!is_this_warp_allowed(frm_s, to_s)) continue;

    skip_list.Add(frm_s);
    skip_list.Add(to_s);

    segments_flat[idx].Remove(frm_s);
    segments_flat[seg_grp_idx].Remove(to_s);

    var cond = Cond.None;
    if (GateConnections.pirate_ship_nodes.Contains(frm_s)
        ||GateConnections.pirate_ship_nodes.Contains(to_s))
    {
        cond = Cond.ShipBellRang;
    }
    selectedPairs.Add(new(
        get_warp_info_from_name(frm_s), 
        get_warp_info_from_name(to_s),
        cond: cond
    ));

    cur_iter = 0;
    idx++;
    if (idx >= segments_flat.Count && selectedPairs.Count - fix_warps_count  < warp_infos.Count / 2) idx = 0;
    else if (selectedPairs.Count - fix_warps_count  == warp_infos.Count / 2) break;
}

Warp get_default_warp(MapName map_name_src, MapName map_name_dst, WarpNode warp_node_src, WarpNode warp_node_dst, Cond cond = Cond.None)
{
    FogWall fw_src = new(warp_node_src, map_names[map_name_src]);
    WarpInfo warpinfo_src = new(map_names[map_name_src], -1, -1, -1, -1, fw_src);
    FogWall fw_dst = new(warp_node_dst, map_names[map_name_dst]);
    WarpInfo warpinfo_dst = new(map_names[map_name_dst], -1, -1, -1, -1, fw_dst);
    return new Warp(warpinfo_src, warpinfo_dst, cond: cond);
}

List<WarpInfo> flattened_list = selectedPairs
    .SelectMany(t => new[] { t.from, t.to })
    .ToList();

List<WarpInfo> flattened_list_copy = new(flattened_list.Count);
foreach (var i in flattened_list)
{
    if (!flattened_list_copy.Contains(i))
    {
        flattened_list_copy.Add(i);
    }
}

var duplicates2 = flattened_list
    .GroupBy(x => x)
    .Where(g => g.Count() > 1)
    .Select(g => g.Key)
    .ToList();
Debug.Assert(duplicates2.Count == 0);

(WarpNode, Cond) get_warp_pair(WarpNode pt_from)
{
    foreach (var p in selectedPairs)
    {
        if (p.from.fog_wall_name == pt_from)
        {
            return (p.to.fog_wall_name, p.cond);
        }
        else if (p.to.fog_wall_name == pt_from)
        {
            return (p.from.fog_wall_name, p.cond);
        }
    }
    return (WarpNode.Lone, Cond.None);
}
List<Connection> get_segment(WarpNode point)
{
    if (point == WarpNode.GameStartSpawnSrc) point = WarpNode.GameStartSpawnDst;
    for (int i=0; i<segments.Count; i++)
    {
        var seg = segments[i];
        foreach (var con in seg)
        {
            if (point == con.n1 || con.n2 == point)
            {
                return seg;
            }
        }

    }
    Debug.Assert(false);
    return new();
}

bool can_walk_to(WarpNode from, WarpNode to)
{
    if (from == WarpNode.Lone || to == WarpNode.Lone) return false;
    var segment = get_segment(from);
    foreach (var s in segment)
    {
        if (s.n1 == to && s.n2 == from)
        {
            if (s.condition_n1 != Cond.OneWay) return true;
            else return false;
        }
        else if (s.n2 == to && s.n1 == from)
        {
            if (s.condition_n2 != Cond.OneWay) return true;
            else return false;
        }
    }
    return false;
}

int get_segment_idx(WarpNode node)
{
    for (int i=0; i<segments.Count; i++)
    {
        for (int j=0; j < segments[i].Count; j++)
        {
            if (segments[i][j].n1 == node || segments[i][j].n2 == node) return i;
        }
    }
    Debug.Assert(false);
    return -1;
}

int get_selected_pair_idx_from_name(WarpNode node)
{
    for (int i=0; i<selectedPairs.Count; i++)
    {
        var pair = selectedPairs[i];
        if (pair.from.fog_wall_name == node || pair.to.fog_wall_name == node)
        {
            return i;
        }
    }
    Debug.Assert(false);
    return -1;
}

T pop<T>(List<T> list, int index)
{
    if (index < 0 || index >= list.Count)
    {
        throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
    }
    T item = list[index];
    list.RemoveAt(index);
    return item;
}

void swap_warp(WarpNode n1, WarpNode n2, List<Warp> cooldown_edges)
{
    var i1 = get_selected_pair_idx_from_name(n1);
    var i2 = get_selected_pair_idx_from_name(n2);
    var w1 = selectedPairs[i1];
    var w2 = selectedPairs[i2];
    Console.WriteLine($"Swapped: {selectedPairs[i1].from.fog_wall_name} - {selectedPairs[i1].to.fog_wall_name} & {selectedPairs[i2].from.fog_wall_name} - {selectedPairs[i2].to.fog_wall_name}");
    selectedPairs.RemoveAt(i1);
    var cond = Cond.None;
    if (GateConnections.pirate_ship_nodes.Contains(w1.from.fog_wall_name)
        ||GateConnections.pirate_ship_nodes.Contains(w2.to.fog_wall_name))
    {
        cond = Cond.ShipBellRang;
    }
    selectedPairs.Insert(i1, new(
        w1.from, w2.to, cond: cond
    ));
    selectedPairs.RemoveAt(i2);
    cond = Cond.None;
    if (GateConnections.pirate_ship_nodes.Contains(w2.from.fog_wall_name)
        ||GateConnections.pirate_ship_nodes.Contains(w1.to.fog_wall_name))
    {
        cond = Cond.ShipBellRang;
    }
    selectedPairs.Insert(i2, new(
        w2.from, w1.to, cond: cond
    ));
    cooldown_edges.Add(selectedPairs[i1]);
    cooldown_edges.Add(selectedPairs[i2]);
    Console.WriteLine($"Swapped: {selectedPairs[i1].from.fog_wall_name} - {selectedPairs[i1].to.fog_wall_name} & {selectedPairs[i2].from.fog_wall_name} - {selectedPairs[i2].to.fog_wall_name}");
}

void swap_warp_ex(Warp w1, Warp w2)
{
    var i1 = selectedPairs.IndexOf(w1);
    var i2 = selectedPairs.IndexOf(w2);
    Console.WriteLine($"Swapped: {selectedPairs[i1].from.fog_wall_name} - {selectedPairs[i1].to.fog_wall_name} & {selectedPairs[i2].from.fog_wall_name} - {selectedPairs[i2].to.fog_wall_name}");
    selectedPairs.RemoveAt(i1);
    var cond = Cond.None;
    if (GateConnections.pirate_ship_nodes.Contains(w1.from.fog_wall_name)
        ||GateConnections.pirate_ship_nodes.Contains(w2.to.fog_wall_name))
    {
        cond = Cond.ShipBellRang;
    }
    selectedPairs.Insert(i1, new(
        w1.from, w2.to, cond: cond
    ));
    selectedPairs.RemoveAt(i2);
    cond = Cond.None;
    if (GateConnections.pirate_ship_nodes.Contains(w2.from.fog_wall_name)
        ||GateConnections.pirate_ship_nodes.Contains(w1.to.fog_wall_name))
    {
        cond = Cond.ShipBellRang;
    }
    selectedPairs.Insert(i2, new(
        w2.from, w1.to, cond: cond
    ));
    Console.WriteLine($"Swapped: {selectedPairs[i1].from.fog_wall_name} - {selectedPairs[i1].to.fog_wall_name} & {selectedPairs[i2].from.fog_wall_name} - {selectedPairs[i2].to.fog_wall_name}");
}

void swap_warp_ex2(Edge w1, Edge w2)
{
    Console.WriteLine($"Swapping {w1} with {w2}");
    (w2.n2, w1.n1) = (w1.n1, w2.n2);
    (w2.cn2, w1.cn1) = (w1.cn1, w2.cn2);
}


Dictionary<WarpNode, List<WarpNode>> tree = new();
void add_edge(WarpNode n1, WarpNode n2)
{
    if (tree.ContainsKey(n1)) tree[n1].Add(n2);
    else tree[n1] = new() { n2};
}

WarpNode next_edge(WarpNode node)
{
    var segment = get_segment(node);
    foreach (var s in segment)
    {
        if (s.n1 == node && s.condition_n2 != Cond.OneWay)
        {
            if (tree.ContainsKey(s.n2)) continue;
            return s.n2;
        }
        else if (s.n2 == node && s.condition_n1 != Cond.OneWay)
        {
            if (tree.ContainsKey(s.n1)) continue;
            return s.n1;
        }
    }
    Debug.Assert(false);
    return WarpNode.Lone;
}

void travel_through(WarpNode warp_dst)
{
    var seg = get_segment(warp_dst);
    foreach (var s in seg)
    {
        WarpNode end_node = WarpNode.Lone;
        if (s.n1 == warp_dst && s.condition_n2 != Cond.OneWay)
        {
            if (tree.ContainsKey(s.n2)) continue;
            end_node = s.n2;
        }
        else if (s.n2 == warp_dst && s.condition_n1 != Cond.OneWay)
        {
            if (tree.ContainsKey(s.n1)) continue;
            end_node = s.n1;
        }
        else continue;
        add_edge(warp_dst, end_node);
    }
}


bool is_one_way_node(WarpNode node)
{
    var segment = get_segment(node);
    foreach (var s in segment)
    {
        if (s.n1 == node && s.condition_n2 != Cond.OneWay) return false;
        else if (s.n2 == node && s.condition_n1 != Cond.OneWay) return false;
    }
    return true;
}

uint get_no_of_access_pts(WarpNode node)
{
    var segment = get_segment(node);
    uint count = 0;
    foreach (var s in segment)
    {
        if (s.n1 == node && s.condition_n1 != Cond.OneWay)
        {
            count++;
        }
        else if (s.n2 == node && s.condition_n2 != Cond.OneWay)
        {
            count++;
        }
    }
    return count;
}

List<WarpNode> recursive_travelled_list = new();
List<WarpNode> looped_gates = new();
List<WarpNode> visited_nodes = new();
void recursive_travel(WarpNode node)
{
    recursive_travelled_list.Add(node);
    if (!tree.ContainsKey(node))
    {
        return;
    }
    foreach (var child in tree[node])
    {
        if (child == WarpNode.Lone) return;
        var (warp_dst, cond) = get_warp_pair(child);
        if (!visited_nodes.Contains(child) 
            && !has_predefined_warp.Contains(child)) visited_nodes.Add(child);
        //if (!visited_nodes.Contains(warp_dst) 
        //    && !has_predefined_warp.Contains(warp_dst)) visited_nodes.Add(warp_dst);
        add_edge(child, warp_dst);
        travel_through(warp_dst);
        if (recursive_travelled_list.Contains(warp_dst))
        {
            //Graph g = new();
            //foreach (var kv in tree)
            //{
            //    foreach (var item in kv.Value)
            //    {
            //        g.AddEdge(kv.Key, item, CType.Walk);
            //    }
            //}
            //var travel_tree = TreeNode.BuildTraversalTree(g, WarpNode.GameStartSpawnSrc, CType.Walk);
            //Debug.Assert(travel_tree != null);
            //StringBuilder sb = new();
            //TreeNode.PrintTree(travel_tree, sb);
            // child is looping? maybe?
            var n = get_no_of_access_pts(child);
            if (n > 1)
            {
                looped_gates.Add(child);
            }
            return;
        }
        recursive_travel(warp_dst);
    }

}

Dictionary<WarpNode, List<WarpNode>> tree_copy = new();
void copy_tree()
{
    tree_copy.Clear();
    foreach (var kv in tree)
    {
        tree_copy[kv.Key] = new();
        foreach (var child in kv.Value)
        {
            tree_copy[kv.Key].Add(child);
        }
    }
}

List<(Connection, WarpNode)> get_outgoing_edges(WarpNode node)
{
    var seg = get_segment(node);
    List<(Connection, WarpNode)> neighbours = new();
    foreach (var s in seg)
    {
        WarpNode end_node = WarpNode.Lone;
        if (s.n1 == node && s.condition_n2 != Cond.OneWay)
        {
            if (tree.ContainsKey(s.n2)) continue;
            end_node = s.n2;
        }
        else if (s.n2 == node && s.condition_n1 != Cond.OneWay)
        {
            if (tree.ContainsKey(s.n1)) continue;
            end_node = s.n1;
        }
        else continue;
        neighbours.Add((s, end_node));
    }
    var (warp_dst, cond) = get_warp_pair(node);
    Connection c = new(node, warp_dst, n1: cond, n2: cond);
    neighbours.Add((c, warp_dst));
    return neighbours;
}

List<Cond> get_node_items(WarpNode node)
{
    List<Cond> items = new();
    foreach (var item in GateConnections.key_reqs)
    {
        foreach (var access_node in item.access_nodes)
        {
            if (node == access_node && item.prereqs.Count == 0)
            {
                items.Add(item.cond);
            }
        }
    }
    return items;
}

List<CondNode> get_neighbors(Node node, List<Edge> all_edges)
{
    List<CondNode> neighbors = new();
    foreach (var edge in all_edges)
    {
        if (edge.n1.name == node.name)
            neighbors.Add(
                new(edge.n2, edge.cn2)
            );
        else if (edge.n2.name == node.name)
            neighbors.Add(
                new(edge.n1, edge.cn1)
            );
    }
    return neighbors;
}

bool blocked_edges_contain(List<CondNode> blocked_edges, CondNode node)
{
    foreach (var be in blocked_edges)
    {
        if (be.node.name == node.node.name && be.cond == node.cond)
        {
            return true;
        }
    }
    return false;
}

List<Node> run_bfs(Node start_node, List<Edge> all_edges)
{
    Inventory inventory = new();
    Queue<Node> queue = new();
    queue.Enqueue(start_node);
    HashSet<Node> visited_ids = [start_node];
    List<CondNode> blocked_edges = [];
    while (queue.Count > 0)
    {
        var current_node = queue.Dequeue();
        inventory.Update(current_node);
        List<CondNode> still_blocked = [];
        foreach (var be in blocked_edges)
        {
            if (inventory.HasKey(visited_ids, be.cond))
            {
                inventory.Use(be.cond);
                if (visited_ids.Contains(be.node)) continue;
                queue.Enqueue(be.node);
                visited_ids.Add(be.node);
            }
            else
            {
                still_blocked.Add(be);
            }
        }
        blocked_edges = still_blocked;
        var neighbors = get_neighbors(current_node, all_edges);
        foreach (var neighbor in neighbors)
        {
            if (neighbor.cond == Cond.OneWay) continue;
            if (visited_ids.Contains(neighbor.node)) continue;
            if (neighbor.cond != Cond.None && !inventory.HasKey(visited_ids, neighbor.cond))
            {
                if (!blocked_edges_contain(blocked_edges, neighbor))
                {
                    blocked_edges.Add(neighbor);
                }
                continue;
            }
            queue.Enqueue(neighbor.node);
            visited_ids.Add(neighbor.node);
        }
    }
    return visited_ids.ToList();
}

Warp find_warp_edge_in(List<WarpNode> reachable_nodes_set)
{
    foreach (var sp in selectedPairs)
    {
        var a_is_reachable = reachable_nodes_set.Contains(sp.from.fog_wall_name);
        var b_is_reachable = reachable_nodes_set.Contains(sp.to.fog_wall_name);
        if (a_is_reachable && b_is_reachable)
        {
            if (!has_predefined_warp.Contains(sp.from.fog_wall_name)) return sp;
        }
    }
    Debug.Assert(false);
    return new Warp();
}

Warp find_warp_edge_in_island(List<WarpNode> unreachable_nodes_set)
{
    foreach (var sp in selectedPairs)
    {
        if (unreachable_nodes_set.Contains(sp.from.fog_wall_name))
        {
            if (!has_predefined_warp.Contains(sp.from.fog_wall_name)) return sp;
        }
    }
    Debug.Assert(false);
    return new Warp();

}

List<Node> get_unreachable_ids(List<Node> visited_ids_node)
{
    var visited_ids = visited_ids_node.Select(x => x.name).ToList();
    List<Node> unreachable_ids = new();
    foreach (var wi in warp_infos)
    {
        if (visited_ids.Contains(wi.fog_wall_name)) continue;
        unreachable_ids.Add(node_from_name(wi.fog_wall_name));
    }
    foreach (var warp in has_predefined_warp)
    {
        if (visited_ids.Contains(warp)) continue;
        unreachable_ids.Add(node_from_name(warp));
    }
    return unreachable_ids;
}

Edge find_valid_warp(List<Edge> warp_edges, List<Node> node_set, List<Node> ignore_set)
{
    List<Edge> candidates = new();
    foreach (var edge in warp_edges)
    {
        if (ignore_set.Contains(edge.n1)) continue;
        if (ignore_set.Contains(edge.n2)) continue;
        if (has_predefined_warp.Contains(edge.n1.name) 
            || has_predefined_warp.Contains(edge.n2.name)) continue;
        if (node_set.Contains(edge.n1) && node_set.Contains(edge.n2)) candidates.Add(edge);
    }
    Console.WriteLine($"Found {candidates.Count} candidates that can be swapped.");
    return candidates[rand.Next(candidates.Count)];
}

Edge find_valid_unreachable_warp(List<Edge> warp_edges, List<Node> node_set, List<Node> ignore_set)
{
    List<Edge> candidates = new();
    foreach (var edge in warp_edges)
    {
        if (ignore_set.Contains(edge.n1)) continue;
        if (ignore_set.Contains(edge.n2)) continue;
        if (has_predefined_warp.Contains(edge.n1.name) 
            || has_predefined_warp.Contains(edge.n2.name)) continue;
        if (node_set.Contains(edge.n1) || node_set.Contains(edge.n2)) candidates.Add(edge);
    }
    return candidates[rand.Next(candidates.Count)];
}

Warp find_valid_warp_ex(WarpNode node, List<WarpNode> node_set, List<Warp> ignore_set)
{
    List<Warp> candidates = new();
    foreach (var edge in selectedPairs)
    {
        if (edge.from.fog_wall_name != node && edge.to.fog_wall_name != node) continue;
        if (ignore_set.Contains(edge)) continue;
        if (node_set.Contains(edge.from.fog_wall_name) && node_set.Contains(edge.to.fog_wall_name))
        {
            if (has_predefined_warp.Contains(edge.from.fog_wall_name)) continue;
            candidates.Add(edge);
        }
    }
    Debug.Assert(candidates.Count > 0);
    return candidates[rand.Next(candidates.Count)];
}

List<Node> cooldown_edges = new();
List<WarpNode> all_warp_nodes = warp_infos
    .Select(x => x.fog_wall_name)
    .Distinct()
    .Concat(has_predefined_warp)
    .ToList();
List<Node> all_nodes = new(all_warp_nodes.Count + 1);
all_nodes.Add(new(WarpNode.Lone, new()));
foreach (var node in all_warp_nodes)
{
    var keys = get_node_items(node);
    all_nodes.Add(
        new(node, keys)
    );
}
Node node_from_name(WarpNode name)
{
    foreach (var node in all_nodes)
    {
        if (node.name == name) return node;
    }
    throw new Exception($"Invalid node name {name}");
}
List<Edge> all_edges = new();
List<Edge> warp_edges = new();
foreach (var edge in selectedPairs)
{
    var new_edge = new Edge(
        node_from_name(edge.from.fog_wall_name),
        node_from_name(edge.to.fog_wall_name),
        cn1: edge.cond,
        cn2: edge.cond
    );
    all_edges.Add(new_edge);
    warp_edges.Add(new_edge);
}
foreach (var edge in GateConnections.items)
{
    all_edges.Add(new Edge(
        node_from_name(edge.n1),
        node_from_name(edge.n2), 
        cn1: edge.condition_n1,
        cn2: edge.condition_n2
    ));
}
var start_node = node_from_name(WarpNode.GameStartSpawnSrc);
List<Node> reachable_nodes = [];
List<Node> ignore_set = [];
while (true)
{
    reachable_nodes = run_bfs(start_node, all_edges);
    if (reachable_nodes.Count == all_nodes.Count) break;
    var unreachable_nodes = all_nodes.Except(reachable_nodes).ToList();
    var main_candidate = find_valid_warp(warp_edges, reachable_nodes, ignore_set);
    var unre_candidate = find_valid_unreachable_warp(warp_edges, unreachable_nodes, ignore_set);
    swap_warp_ex2(main_candidate, unre_candidate);
}

add_edge(WarpNode.GameStartSpawnSrc, WarpNode.GameStartSpawnDst);
travel_through(WarpNode.GameStartSpawnDst);
recursive_travel(WarpNode.GameStartSpawnDst);

Graph g = new();
foreach (var kv in tree)
{
    foreach (var item in kv.Value)
    {
        g.AddEdge(kv.Key, item, CType.Walk);
    }
}
var travel_tree = TreeNode.BuildTraversalTree(g, WarpNode.GameStartSpawnSrc, CType.Walk);
Debug.Assert(travel_tree != null);
StringBuilder sb = new();
TreeNode.PrintTree(travel_tree, sb);
write_string_to_file(sb.ToString(), "./log.txt");

//List<Warp> new_warps = WarpScrambler.Scramble(warps);
selectedPairs.Clear();
foreach (var edge in warp_edges)
{
    if (has_predefined_warp.Contains(edge.n1.name)) continue;
    selectedPairs.Add(new(
        get_warp_info_from_name(edge.n1.name),
        get_warp_info_from_name(edge.n2.name),
        cond: edge.cn2
    ));
}
foreach (var warp in selectedPairs)
{
    if (has_predefined_warp.Contains(warp.from.fog_wall_name)) continue;
    var scripts = esd_script_fn(warp);
    esd_script_dict[warp.from.map_name] += scripts[warp.from.map_name];
    if (warp.from.map_name != warp.to.map_name)
    {
        esd_script_dict[warp.to.map_name] += scripts[warp.to.map_name];
    }
}

foreach (var map_script_kv in esd_script_dict)
{
    String script_path = get_esd_script_path(map_script_kv.Key);
    py_files_list += $" {script_path}";
    write_string_to_file(map_script_kv.Value, script_path);
}

// run the esdtool.exe to generate esd files from python files
String esdtool_path = Path.GetFullPath("./esdtool/esdtool.exe");
String arguments = $"-ds2s -basedir \"{game_dir}\" -moddir \"{mod_folder}\" -backup -i{py_files_list} -writeloose \"{Path.Join(ezstate_path, "%e.esd")}\"";
Debug.Assert(File.Exists(esdtool_path));
run_external_command(esdtool_path, arguments);

// BUGS:
// 1. frejya does not spawn when coming from back gate
// 2. lost sinner cutscene not playing when coming from front gate but activates from back door
// 3. cannot access the majula to copse gate
// 4. Activate ruin sentinels when approached from hidden gates
// 5. i can leave the dark chasm from castle? (with havel) without defeating all enemies
// 6. if ivory king dies, the dlc3 wont be unfrozen before speaking with alsanna
// 7. add conditional warp for pirate ship
// 8. darklurker fight begins from outside the foggate
// 9. old iron king fight is also scuffed.
