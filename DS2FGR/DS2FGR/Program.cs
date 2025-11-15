using System.Diagnostics;
using System.Numerics;

using SoulsFormats;
using static SoulsFormats.PARAM;
using static SoulsFormats.PARAMDEF;


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

PARAMDEF get_obj_inst_def_paramdef_ex(
    PARAM param, int map_obj_inst_type, UInt16 unk04, byte default_state, 
    byte unk09, UInt32 unk10)
{
    PARAMDEF pd = new PARAMDEF();
    pd.ParamType = param.ParamType;
    pd.DataVersion = 7;
    pd.BigEndian = param.BigEndian;
    pd.Unicode = true;
    pd.FormatVersion = 104;

    Field f = new Field();
    f.DisplayName = "header ID";
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Param ID";
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Object Bullet";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk02";
    f.Default = 1.0;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk03";
    f.Default = -1.0;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Map Obj Instance Type";
    f.Default = map_obj_inst_type;
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk04";
    f.Default = unk04;
    f.DisplayType = PARAMDEF.DefType.u16;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk05";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk06";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk07";
    f.Default = 7;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk08";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Default State";
    f.Default = default_state;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk09";
    f.Default = unk09;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk10";
    f.Default = unk10;
    f.DisplayType = PARAMDEF.DefType.u32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Itemlot ID";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    return pd;
}

PARAMDEF get_obj_inst_def_paramdef(PARAM param)
{
    PARAMDEF pd = new PARAMDEF();
    pd.ParamType = param.ParamType;
    pd.DataVersion = 7;
    pd.BigEndian = param.BigEndian;
    pd.Unicode = true;
    pd.FormatVersion = 104;

    Field f = new Field();
    f.DisplayName = "header ID";
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Param ID";
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Object Bullet";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk02";
    f.Default = 1.0;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk03";
    f.Default = -1.0;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Map Obj Instance Type";
    f.Default = 100;
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk04";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u16;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk05";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk06";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk07";
    f.Default = 7;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk08";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Default State";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk09";
    f.Default = 50;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk10";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Itemlot ID";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    return pd;
}

PARAMDEF get_obj_inst_def_paramdef_fogwall(PARAM param)
{
    return get_obj_inst_def_paramdef_ex(param, 110, 6, 0, 255, 255);
}

PARAMDEF get_event_param_def_paramdef_ex(PARAM param, int event_id, int flag_id)
{
    PARAMDEF pd = new PARAMDEF();
    pd.ParamType = param.ParamType;
    pd.DataVersion = 7;
    pd.BigEndian = param.BigEndian;
    pd.Unicode = true;
    pd.FormatVersion = 104;

    Field f = new Field();
    f.DisplayName = "Event ID";
    f.Default = event_id;
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Flag ID";
    f.Default = flag_id;
    f.DisplayType = PARAMDEF.DefType.s32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk08";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk09";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk0A";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk0B";
    f.Default = 2;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk0C";
    f.Default = 1;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk0D";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk0E";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk0F";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    return pd;
}

PARAMDEF get_event_param_def_paramdef(PARAM param)
{
    return get_event_param_def_paramdef_ex(param, 0, 0);
}

PARAMDEF get_event_loc_def_paramdef_ex(PARAM param, Vector3 position, Vector3 rotation)
{
    PARAMDEF pd = new PARAMDEF();
    pd.ParamType = param.ParamType;
    pd.DataVersion = 7;
    pd.BigEndian = param.BigEndian;
    pd.Unicode = true;
    pd.FormatVersion = 104;

    Field f = new Field();
    f.DisplayName = "pos_x";
    f.DisplayType = PARAMDEF.DefType.f32;
    f.Default = position.X;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "pos_y";
    f.Default = position.Y;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "pos_z";
    f.Default = position.Z;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "rot_x";
    f.Default = rotation.X;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "rot_y";
    f.Default = rotation.Y;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "rot_z";
    f.Default = rotation.Z;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Region Type";
    f.Default = 1;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk19";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk1A";
    f.Default = 255;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk1B";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u8;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "scale_x";
    f.Default = 0.5f;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "scale_y";
    f.Default = 1.0f;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "scale_z";
    f.Default = 1.0f;
    f.DisplayType = PARAMDEF.DefType.f32;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk28";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u16;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk2A";
    f.Default = 2560;
    f.DisplayType = PARAMDEF.DefType.u16;
    pd.Fields.Add(f);

    f = new Field();
    f.DisplayName = "Unk2C";
    f.Default = 0;
    f.DisplayType = PARAMDEF.DefType.u32;
    pd.Fields.Add(f);

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

String get_script_helper_fns(String map_name)
{
    String map_id = map_name.Substring(0, 6);
    int map_num = parse_map_name(map_name);

    return @$"def event_{map_id}_x84():
    """"""[Reproduction] Text monument""""""
    """"""State 0,1: End state""""""
    return 0

def event_{map_id}_x81(z31=_, action3=_):
    """"""[Preset] Text Stone Monument
    z31: Stele OBJ instance ID
    action3: Warp point
    """"""
    """"""State 0,1: [Reproduction] Text stone monument_SubState""""""
    assert event_{map_id}_x84()
    """"""State 3: [Condition] Text stone monument_SubState""""""
    assert event_{map_id}_x82(z15=z31)
    """"""State 2: [Execution] Text stone monument_SubState""""""
    assert event_{map_id}_x83(action3=action3, z31=z31)
    """"""State 4: End state""""""
    return 0

def event_{map_id}_x82(z15=_):
    """"""[Conditions] Text stone monument
    z15: Stele OBJ instance ID
    """"""
    """"""State 0,1: Wait for decision to check""""""
    IsObjSearched(0, z15)
    assert ConditionGroup(0)
    """"""State 2: End state""""""
    return 0

def event_{map_id}_x83(action3=_, z31=_):
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
    assert event_{map_id}_x81(z31={warp_src_id}, action3={warp_dest_id})
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
int warp_obj_inst_id = 10021101;

Vector3 pos_offs_event_loc = new Vector3(
    354.177948f + 143.81485f,
    -5.39768f - 24.411251f,
    132.339386f + 127.624603f
);

String[] map_names = { "m10_02_00_00", "m10_10_00_00"};

int count = 0;
Dictionary<String, Dictionary<string, int>> fog_wall_dict = new Dictionary<string, Dictionary<string, int>> {
     {
        map_names[count++],
        new Dictionary<string, int> {
            {"TB_tut1_entry", 10020600},
            {"TB_tut1_exit", 10020605},
            {"TB_tut3_exit", 10020610},
            {"TB_tut2_entry", 10020615},
            {"TB_tut3_entry", 10020620},
            {"TB_tut2_exit", 10020625},
        } 
     },
     {
        map_names[count++],
        new Dictionary<string, int> {
            {"FOFG_last_giant", 10100600},
            {"FOFG_pursuer_entry", 10100610},
            {"FOFG_pursuer_exit", 10100611},
            {"FOFG_balcony_to_last_giant", 10100630},
            {"FOFG_fire_pit_to_outside", 10100631},
            {"FOFG_first_fog_wall", 10100632},
            {"FOFG_PVP_majula_to_forest", 10100633},
            {"FOFG_PVP_to_pursuer", 10100640},
        }
     }
};

// object id postpended to o02_1050_ for creating the new warp object
Dictionary<String, int> warp_object_begin_list = new Dictionary<String, int> { 
    { "m10_02_00_00", 1000 },
    { "m10_10_00_00", 1000} 
};

// esd script begin index
Dictionary<string, int> esd_script_begin_list = new Dictionary<string, int> {
    { "m10_02_00_00", 1201 },
    { "m10_10_00_00", 1001 }
};

Dictionary<string, int> warp_obj_inst_begin_list = new Dictionary<string, int> {
    { "m10_02_00_00", 10021122 },
    { "m10_10_00_00", 10100712 }
};

Dictionary<string, int> warp_point_begin_list = new Dictionary<string, int> {
    { "m10_02_00_00", 500001 },
    { "m10_10_00_00", 1017 }
};

Dictionary<string, int> obj_inst_insert_loc_list = new Dictionary<string, int> {
    { "m10_02_00_00", 57 },
    { "m10_10_00_00", 1017 }
};

String ezstate_path = Path.Join(mod_folder, "ezstate");
int warp_obj_idx = -1;
int warp_obj_inst_idx = -1;
MSB2.Part.Object? warp_obj = null;
PARAM.Row? warp_obj_inst = null;

//for (int _i = 0; _i < map_names.Length; _i++)
for (int _i = 0; _i < 1; _i++)
    {
    String map_name = map_names[_i];

    int warp_obj_begin = warp_object_begin_list[map_name];
    int esd_script_begin = esd_script_begin_list[map_name];
    int warp_obj_inst_begin = warp_obj_inst_begin_list[map_name];
    int event_param_begin = esd_script_begin;
    int warp_point_begin = warp_point_begin_list[map_name];

    int n_fog_walls = fog_wall_dict[map_name].Count;
    String fog_wall_id_prefix = "o00_0500_";
    int disable_fog_wall_check_increment = 5;
    

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
    esd_script += get_script_helper_fns(map_name);

    // do this only for things betwixt: m10_02_00_00
    if (map_name == "m10_02_00_00")
    {
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

    // check if the object was found
    Debug.Assert(warp_obj_idx >= 0);
    Debug.Assert(warp_obj_inst_idx >= 0);
    Debug.Assert(warp_obj != null);
    Debug.Assert(warp_obj_inst != null);

    // get all the fog walls in the map and create a list of their
    // postion, rotation and draw groups
    int fog_wall_start = 0;
    List<Vector3> pos_fog_walls = new List<Vector3>();
    List<Vector3> rot_fog_walls = new List<Vector3>();
    List<uint> draw_groups            = new List<uint>();
    for (int i=0; i<n_fog_walls; i++)
    {
        String fog_wall_id = fog_wall_id_prefix + format_int_to_str(fog_wall_start, 4);
        MSB2.Part.Object? fog_wall = null;
        for (int j=0; j<map.Parts.Objects.Count; j++)
        {
            MSB2.Part.Object obj = map.Parts.Objects[j];
            if (obj.Name == fog_wall_id)
            {
                fog_wall = obj;
                break;
            }
        }
        if (fog_wall == null)
        {
            Console.WriteLine($"[ERROR] failed to find fog_wall_id: {fog_wall_id}");
            Debug.Assert(false);
        }
        pos_fog_walls.Add(fog_wall.Position);
        rot_fog_walls.Add(fog_wall.Rotation);
        draw_groups.Add(fog_wall.DrawGroups[0]);

        fog_wall_start++;
    }

    // disable fog gates
    foreach (KeyValuePair<string, int> entry in fog_wall_dict[map_name])
    {
        for (int i = 0; i < obj_inst_param.Rows.Count; i++)
        {
            var row = obj_inst_param.Rows[i];
            if (row.ID == entry.Value)
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

    // calculate the obj instance insert location
    int obj_inst_insert_loc = -1;
    for (int i =0; i<obj_inst_param.Rows.Count; i++)
    {
        var row = obj_inst_param.Rows[i];
        if (row.ID == warp_obj_inst_begin - 1)
        {
            obj_inst_insert_loc = i + 1;
            break;
        }
    }
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
        obj.DrawGroups[0] = 0;
        //obj.DrawGroups[0] = draw_groups[i]; // this makes the dummy object visible
        obj.DispGroups[0] = draw_groups[i];
        map.Parts.Objects.Add(obj);

        // create and add new map peice in behind of the fog door
        var obj2 = (MSB2.Part.Object)warp_obj.DeepCopy();
        Debug.Assert(obj2 != null);
        obj2.Position = pos_fog_walls[i];
        obj2.Rotation = vector3_flip_y(rot_fog_walls[i]);
        obj2.Name = "o02_1050_" + format_int_to_str(warp_obj_begin, 4);
        obj2.MapObjectInstanceParamID = warp_obj_inst_begin + 1;
        obj2.DrawGroups[0] = 0;
        //obj2.DrawGroups[0] = draw_groups[i]; // this makes the dummy object visible
        obj2.DispGroups[0] = draw_groups[i];
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
                vector3_move(pos_fog_walls[i] + pos_offs_event_loc, rot_fog_walls[i], -1), 
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
                vector3_move(pos_fog_walls[i] + pos_offs_event_loc, rot_fog_walls[i], 1),
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
