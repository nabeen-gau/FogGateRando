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

    return @$"def event_{map_id}_x500():
    """"""[Reproduction] Text monument""""""
    """"""State 0,1: End state""""""
    return 0

def event_{map_id}_x501(z31=_, action3=_):
    """"""[Preset] Text Stone Monument
    z31: Stele OBJ instance ID
    action3: Warp point
    """"""
    """"""State 0,1: [Reproduction] Text stone monument_SubState""""""
    assert event_{map_id}_x500()
    """"""State 3: [Condition] Text stone monument_SubState""""""
    assert event_{map_id}_x502(z15=z31)
    """"""State 2: [Execution] Text stone monument_SubState""""""
    assert event_{map_id}_x503(action3=action3, z31=z31)
    """"""State 4: End state""""""
    return 0

def event_{map_id}_x502(z15=_):
    """"""[Conditions] Text stone monument
    z15: Stele OBJ instance ID
    """"""
    """"""State 0,1: Wait for decision to check""""""
    IsObjSearched(0, z15)
    assert ConditionGroup(0)
    """"""State 2: End state""""""
    return 0

def event_{map_id}_x503(action3=_, z31=_):
    """"""[Execution] Text stele
    action3: Warp Point
    z31: Stele OBJ instance ID
    """"""
    """"""State 0,2: Disable key guide""""""
    DisableObjKeyGuide(z31, 1)
    """"""State 3: Activate key guide""""""
    DisableObjKeyGuide(z31, 0)
    PlayCutsceneAndWarpToMap(0, 0, {map_num}, action3, 0)
    """"""State 4: End state""""""
    return 0
";
}


String generate_esd_script(String map_name, int script_id, int warp_src_id, int warp_dest_id)
{
    String map_id = map_name.Substring(0, 6);
    return @$"
def event_{map_id}_{script_id}():
    """"""Text stele_01""""""
    """"""State 0,2: [Preset] Text Stone Monument_SubState""""""
    # action:3500:""Bonfires are places of respite\nYou may also light torches on them""
    assert event_{map_id}_x501(z31={warp_src_id}, action3={warp_dest_id})
    """"""State 1: Rerun""""""
    RestartMachine()
    Quit()
";
}


void write_string_to_file(String str, String file_path)
{
    try
    {
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
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine($"[COMMAND] {command_path} {arguments}");
        if (!string.IsNullOrEmpty(error))
        {
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

Dictionary<MapName, String> map_names = new Dictionary<MapName, String>()
{
    { MapName.ThingsBetwixt,           "m10_02_00_00"},
    { MapName.ForestOfTheFallenGiants, "m10_10_00_00"},
    { MapName.BrightstoneCoveTseldora, "m10_14_00_00"},
};

Dictionary < String, List<FogWall>> fog_wall_dict = new Dictionary<string, List<FogWall>>();
fog_wall_dict[map_names[MapName.ThingsBetwixt]] = new List<FogWall> {
    new FogWall("TB_tut1_entry", "o00_0500_0000", 10020600),
    new FogWall("TB_tut1_exit",  "o00_0500_0001", 10020605),
    new FogWall("TB_tut3_exit",  "o00_0500_0002", 10020610),
    new FogWall("TB_tut2_entry", "o00_0500_0003", 10020615),
    new FogWall("TB_tut3_entry", "o00_0500_0004", 10020620),
    new FogWall("TB_tut2_exit",  "o00_0500_0004", 10020625),
};
fog_wall_dict[map_names[MapName.ForestOfTheFallenGiants]] = new List<FogWall> {
    new FogWall("FOFG_last_giant",            "o00_0501_0001", 10100600, boss: true),
    new FogWall("FOFG_pursuer_entry",         "o00_0501_0003", 10100610, boss: true),
    new FogWall("FOFG_pursuer_exit",          "o00_0500_0004", 10100611, boss: true, boss_exit: true),
    new FogWall("FOFG_balcony_to_last_giant", "o00_0500_0000", 10100630),
    new FogWall("FOFG_fire_pit_to_outside",   "o00_0500_0003", 10100631),
    new FogWall("FOFG_first_fog_wall",        "o00_0500_0002", 10100632),
    new FogWall("FOFG_PVP_majula_to_forest",  "o00_0501_0002", 10100633, pvp: true),
    new FogWall("FOFG_PVP_to_pursuer",        "o00_0500_0005", 10100640, pvp: true),
};
fog_wall_dict[map_names[MapName.BrightstoneCoveTseldora]] = new List<FogWall> {
    new FogWall("BCT_congregation_entry", "o00_0500_0000", 10140603, boss: true),
    new FogWall("BCT_congregation_exit",  "o00_0500_0001", 10140600, boss: true, boss_exit: true),
    new FogWall("BCT_area_entry",         "o00_0500_0002", 10140604, pvp: true),
    new FogWall("BCT_freya_exit",         "o00_0501_0001", 10140601, boss: true, boss_exit: true),
    new FogWall("BCT_freya_entry",        "o00_0502_0000", 10140602, boss: true),
};


// object id postpended to o02_1050_ for creating the new warp object
Dictionary<String, int> warp_object_begin_list = new Dictionary<String, int> { 
    { map_names[MapName.ThingsBetwixt],           1000 },
    { map_names[MapName.ForestOfTheFallenGiants], 1000 },
    { map_names[MapName.BrightstoneCoveTseldora], 1000 },
};

// esd script begin index
Dictionary<string, int> esd_script_begin_list = new Dictionary<string, int> {
    { map_names[MapName.ThingsBetwixt],           1201 },
    { map_names[MapName.ForestOfTheFallenGiants], 1001 },
    { map_names[MapName.BrightstoneCoveTseldora], 1001 },
};

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

for (int _i = (int)MapName.ThingsBetwixt; _i < map_names.Count; _i++)
{
    String map_name = map_names[(MapName)_i];

    int warp_obj_begin = warp_object_begin_list[map_name];
    int esd_script_begin = esd_script_begin_list[map_name];
    int event_param_begin = esd_script_begin;

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
        pos_fog_walls.Add(fog_wall.Position);
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

    Vector3 pos_offs_event_loc = map.Events.MapOffsets[0].Translation;

    // generate the objects and events for all the fog walls in the map
    for (int i=0; i< pos_fog_walls.Count; i++)
    {
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
            obj.DrawGroups[j] = draw_groups[i][j]; // this makes the dummy object visible
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
            obj2.DrawGroups[j] = draw_groups[i][j]; // this makes the dummy object visible
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

        // create and add the new warp points infront the fog door
        var warp_point_row2 = new Row(
            warp_point_begin + 1,
            $"eventloc_{warp_point_begin + 1}",
            get_event_loc_def_paramdef_ex(
                param_event_loc,
                vector3_move(pos_fog_walls[i] - pos_offs_event_loc, rot_fog_walls[i], 1),
                rot_fog_walls[i]
            )
        );
        param_event_loc.Rows.Insert(event_loc_insert_loc + 1, warp_point_row2);

        // generate and update the esd script for infront of fogdoor
        esd_script += generate_esd_script(
            map_name, 
            esd_script_begin, 
            warp_obj_inst_begin,
            warp_point_begin
        );

        // generate and update the esd script for behind of fogdoor
        esd_script += generate_esd_script(
            map_name,
            esd_script_begin + 1,
            warp_obj_inst_begin + 1,
            warp_point_begin + 1
        );

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
    String esdtool_path = Path.GetFullPath("./esdtool/esdtool.exe");
    String arguments = $"-ds2s -basedir \"{game_dir}\" -moddir {mod_folder} -backup -i {esd_script_path} -writeloose {Path.Join(ezstate_path, "%e.esd")}";
    Debug.Assert(File.Exists(esdtool_path));
    run_external_command(esdtool_path, arguments);

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
        Console.WriteLine($"[SUCCESS] {map_name} done!");
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
